using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/customer-auth")]
    public class CustomerAuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public CustomerAuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        [EnableRateLimiting("auth")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginRequest request)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == request.Email);
            if (customer == null || !BCrypt.Net.BCrypt.Verify(request.Password, customer.PasswordHash))
                return Unauthorized(new { message = "Invalid email or password" });

            if (!customer.IsActive)
                return Unauthorized(new { message = "Account is deactivated" });

            customer.LastLoginAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var token = GenerateToken(customer);
            return Ok(new CustomerLoginResponse(token, customer.Email, customer.FullName));
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var customerId = GetCustomerId();
            if (customerId == null) return Unauthorized();

            var customer = await _context.Customers
                .Include(c => c.Subscription)
                .FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null) return NotFound();

            return Ok(new CustomerDto(
                customer.Id, customer.Email, customer.FullName,
                customer.Phone, customer.Messenger, customer.IsActive,
                customer.CreatedAt, customer.LastLoginAt,
                customer.Subscription is { IsActive: true }
                    ? new CustomerSubscriptionDto(customer.Subscription.Id,
                        customer.Subscription.Tier.ToString(),
                        customer.Subscription.StartsAt,
                        customer.Subscription.EndsAt,
                        customer.Subscription.IsActive)
                    : null
            ));
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] CustomerProfileDto dto)
        {
            var customerId = GetCustomerId();
            if (customerId == null) return Unauthorized();

            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null) return NotFound();

            customer.FullName = dto.FullName;
            customer.Phone = dto.Phone;
            customer.Messenger = dto.Messenger;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Customer")]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] CustomerChangePasswordRequest dto)
        {
            var customerId = GetCustomerId();
            if (customerId == null) return Unauthorized();

            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null) return NotFound();

            if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, customer.PasswordHash))
                return BadRequest(new { message = "Current password is incorrect" });

            customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Password changed" });
        }

        private string GenerateToken(Customer customer)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, customer.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Customer"),
                new Claim("full_name", customer.FullName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryMinutes"]!)),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private Guid? GetCustomerId()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
