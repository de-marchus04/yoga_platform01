using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminPortalController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IConfiguration _config;

    public AdminPortalController(AppDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    [HttpPost("login")]
    [EnableRateLimiting("validation")]
    public async Task<ActionResult<AdminLoginResponse>> Login([FromBody] AdminLoginRequest? body)
    {
        if (body is null || string.IsNullOrWhiteSpace(body.Login) || string.IsNullOrWhiteSpace(body.Password))
            return BadRequest();

        var user = await _db.AdminUsers.FirstOrDefaultAsync(u => u.Login == body.Login);
        if (user is null)
            return Unauthorized();

        if (!VerifyPassword(body.Password, user.PasswordHash))
            return Unauthorized();

        var token = GenerateJwt(user);
        var expiresAt = DateTime.UtcNow.AddHours(8);
        return Ok(new AdminLoginResponse(token, expiresAt));
    }

    [HttpPost("seed-admin")]
    [EnableRateLimiting("validation")]
    public async Task<IActionResult> SeedAdmin()
    {
        if (await _db.AdminUsers.AnyAsync())
            return Conflict("Admin user already exists.");

        var login = _config["AdminPortal:Login"];
        var password = _config["AdminPortal:Password"];

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            return BadRequest("AdminPortal:Login and AdminPortal:Password must be configured.");

        var user = new AdminUser
        {
            Login = login,
            PasswordHash = HashPassword(password)
        };

        _db.AdminUsers.Add(user);
        await _db.SaveChangesAsync();
        return Ok("Admin user created.");
    }

    private string GenerateJwt(AdminUser user)
    {
        var secret = _config["AdminPortal:JwtSecret"] ?? throw new InvalidOperationException("AdminPortal:JwtSecret not configured.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var token = new JwtSecurityToken(
            issuer: "yoga-api",
            audience: "yoga-client",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, 100_000, HashAlgorithmName.SHA256, 32);
        return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }

    private static bool VerifyPassword(string password, string storedHash)
    {
        var parts = storedHash.Split(':');
        if (parts.Length != 2) return false;

        var salt = Convert.FromBase64String(parts[0]);
        var expectedHash = Convert.FromBase64String(parts[1]);
        var actualHash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, 100_000, HashAlgorithmName.SHA256, 32);
        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }
}
