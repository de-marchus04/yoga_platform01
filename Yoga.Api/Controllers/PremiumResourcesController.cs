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
    [Route("api/premium-resources")]
    public class PremiumResourcesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PremiumResourcesController(AppDbContext context) => _context = context;

        // Admin: full CRUD
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<PremiumResourceDto>>> GetAll()
        {
            var items = await _context.PremiumResources.OrderBy(r => r.SortOrder)
                .Select(r => ToDto(r)).ToListAsync();
            return Ok(items);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePremiumResourceRequest req)
        {
            SubscriptionTier? tier = null;
            if (!string.IsNullOrEmpty(req.MinimumTier) && Enum.TryParse<SubscriptionTier>(req.MinimumTier, true, out var t))
                tier = t;

            var resource = new PremiumResource
            {
                Title = req.Title,
                Description = req.Description,
                ResourceType = req.ResourceType,
                MediaUrl = req.MediaUrl,
                Duration = req.Duration,
                MinimumTier = tier,
                Category = req.Category,
                SortOrder = req.SortOrder
            };
            _context.PremiumResources.Add(resource);
            await _context.SaveChangesAsync();
            return Ok(new { resource.Id });
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreatePremiumResourceRequest req)
        {
            var resource = await _context.PremiumResources.FindAsync(id);
            if (resource == null) return NotFound();

            SubscriptionTier? tier = null;
            if (!string.IsNullOrEmpty(req.MinimumTier) && Enum.TryParse<SubscriptionTier>(req.MinimumTier, true, out var t))
                tier = t;

            resource.Title = req.Title;
            resource.Description = req.Description;
            resource.ResourceType = req.ResourceType;
            resource.MediaUrl = req.MediaUrl;
            resource.Duration = req.Duration;
            resource.MinimumTier = tier;
            resource.Category = req.Category;
            resource.SortOrder = req.SortOrder;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var r = await _context.PremiumResources.FindAsync(id);
            if (r == null) return NotFound();
            _context.PremiumResources.Remove(r);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Customer: list resources accessible to them
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<ActionResult<List<PremiumResourceDto>>> GetAccessible()
        {
            var customerId = GetCustomerId();
            if (customerId == null) return Unauthorized();

            // Check subscription
            var subscription = await _context.CustomerSubscriptions
                .FirstOrDefaultAsync(s => s.CustomerId == customerId && s.IsActive
                    && s.StartsAt <= DateTime.UtcNow && (s.EndsAt == null || s.EndsAt > DateTime.UtcNow));

            var query = _context.PremiumResources.Where(r => r.IsActive);

            if (subscription != null)
            {
                // Subscriber sees resources matching their tier or below
                query = query.Where(r => r.MinimumTier == null || r.MinimumTier <= subscription.Tier);
            }
            else
            {
                // Non-subscriber sees only resources without tier requirement
                query = query.Where(r => r.MinimumTier == null);
            }

            var items = await query.OrderBy(r => r.SortOrder).Select(r => ToDto(r)).ToListAsync();
            return Ok(items);
        }

        private static PremiumResourceDto ToDto(PremiumResource r) => new(
            r.Id, r.Title, r.Description, r.ResourceType, r.MediaUrl,
            r.Duration, r.MinimumTier?.ToString(), r.Category, r.SortOrder, r.IsActive);

        private Guid? GetCustomerId()
        {
            var sub = User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
