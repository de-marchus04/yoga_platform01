using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/admin/customers")]
    [Authorize(Roles = "SuperAdmin")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<CustomerDto>>> GetAll(
            [FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? search = null)
        {
            var query = _context.Customers.Include(c => c.Subscription).AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(c => c.FullName.Contains(search) || c.Email.Contains(search));

            var total = await query.CountAsync();
            var items = await query.OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Select(c => new CustomerDto(
                    c.Id, c.Email, c.FullName, c.Phone, c.Messenger, c.IsActive,
                    c.CreatedAt, c.LastLoginAt,
                    c.Subscription != null && c.Subscription.IsActive
                        ? new CustomerSubscriptionDto(c.Subscription.Id, c.Subscription.Tier.ToString(),
                            c.Subscription.StartsAt, c.Subscription.EndsAt, c.Subscription.IsActive)
                        : null
                )).ToListAsync();

            return Ok(new PaginatedResult<CustomerDto>(items, total, page, pageSize));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var c = await _context.Customers.Include(x => x.Subscription).FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return NotFound();
            return Ok(new CustomerDto(
                c.Id, c.Email, c.FullName, c.Phone, c.Messenger, c.IsActive,
                c.CreatedAt, c.LastLoginAt,
                c.Subscription is { IsActive: true }
                    ? new CustomerSubscriptionDto(c.Subscription.Id, c.Subscription.Tier.ToString(),
                        c.Subscription.StartsAt, c.Subscription.EndsAt, c.Subscription.IsActive)
                    : null
            ));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest req)
        {
            if (await _context.Customers.AnyAsync(c => c.Email == req.Email))
                return Conflict(new { message = "Email already exists" });

            var customer = new Customer
            {
                Email = req.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
                FullName = req.FullName,
                Phone = req.Phone,
                Messenger = req.Messenger
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(new { customer.Id });
        }

        [HttpPut("{id:guid}/toggle-active")]
        public async Task<IActionResult> ToggleActive(Guid id)
        {
            var c = await _context.Customers.FindAsync(id);
            if (c == null) return NotFound();
            c.IsActive = !c.IsActive;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // ── Subscription management ──

        [HttpPost("{id:guid}/subscription")]
        public async Task<IActionResult> CreateSubscription(Guid id, [FromBody] CreateSubscriptionRequest req)
        {
            var customer = await _context.Customers.Include(c => c.Subscription).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) return NotFound();

            if (!Enum.TryParse<SubscriptionTier>(req.Tier, true, out var tier))
                return BadRequest(new { message = "Invalid tier" });

            // Deactivate existing subscription if any
            if (customer.Subscription != null)
                customer.Subscription.IsActive = false;

            var sub = new CustomerSubscription
            {
                CustomerId = id,
                Tier = tier,
                StartsAt = req.StartsAt,
                EndsAt = req.EndsAt,
                GrantedByAdminId = GetAdminId()
            };
            _context.CustomerSubscriptions.Add(sub);
            await _context.SaveChangesAsync();

            return Ok(new { sub.Id });
        }

        [HttpDelete("{id:guid}/subscription")]
        public async Task<IActionResult> DeactivateSubscription(Guid id)
        {
            var sub = await _context.CustomerSubscriptions.FirstOrDefaultAsync(s => s.CustomerId == id && s.IsActive);
            if (sub == null) return NotFound();
            sub.IsActive = false;
            await _context.SaveChangesAsync();
            return Ok();
        }

        private Guid? GetAdminId()
        {
            var sub = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
