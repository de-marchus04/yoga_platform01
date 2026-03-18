using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Services;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/premium-resources")]
    public class PremiumResourcesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuditTrailService _auditTrail;
        private readonly IFileStorageService _storageService;

        public PremiumResourcesController(AppDbContext context, IAuditTrailService auditTrail, IFileStorageService storageService)
        {
            _context = context;
            _auditTrail = auditTrail;
            _storageService = storageService;
        }

        // Admin: full CRUD
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<PremiumResourceDto>>> GetAll()
        {
            var items = await _context.PremiumResources
                .OrderBy(r => r.SortOrder)
                .ToListAsync();

            var result = items.Select(r => ToDto(r)).ToList();
            return Ok(result);
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
                IsPrivateMedia = req.IsPrivateMedia,
                Duration = req.Duration,
                MinimumTier = tier,
                Category = req.Category,
                SortOrder = req.SortOrder
            };
            _context.PremiumResources.Add(resource);
            _context.AdminAuditLogs.Add(_auditTrail.CreateEntry(
                User,
                HttpContext,
                "premium-resource-created",
                nameof(PremiumResource),
                resource.Id,
                $"Created premium resource '{resource.Title}'.",
                new { resource.ResourceType, resource.MinimumTier, resource.Category, resource.SortOrder, resource.IsPrivateMedia }));
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
            resource.IsPrivateMedia = req.IsPrivateMedia;
            resource.Duration = req.Duration;
            resource.MinimumTier = tier;
            resource.Category = req.Category;
            resource.SortOrder = req.SortOrder;
            _context.AdminAuditLogs.Add(_auditTrail.CreateEntry(
                User,
                HttpContext,
                "premium-resource-updated",
                nameof(PremiumResource),
                resource.Id,
                $"Updated premium resource '{resource.Title}'.",
                new { resource.ResourceType, resource.MinimumTier, resource.Category, resource.SortOrder, resource.IsActive, resource.IsPrivateMedia }));
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var r = await _context.PremiumResources.FindAsync(id);
            if (r == null) return NotFound();
            _context.AdminAuditLogs.Add(_auditTrail.CreateEntry(
                User,
                HttpContext,
                "premium-resource-deleted",
                nameof(PremiumResource),
                r.Id,
                $"Deleted premium resource '{r.Title}'.",
                new { r.ResourceType, r.Category, r.MinimumTier }));
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

            var items = await GetAccessibleQuery(customerId.Value)
                .OrderBy(r => r.SortOrder)
                .ToListAsync();

            var result = items.Select(r => ToDto(r, includeMediaUrl: !r.IsPrivateMedia)).ToList();
            return Ok(result);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("{id:guid}/access")]
        public async Task<ActionResult<ProtectedMediaAccessDto>> GetProtectedAccess(Guid id)
        {
            var customerId = GetCustomerId();
            if (customerId == null) return Unauthorized();

            var resource = await GetAccessibleQuery(customerId.Value)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resource == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(resource.MediaUrl))
                return BadRequest(new { message = "Resource does not have media." });

            var access = await _storageService.GetReadAccessAsync(resource.MediaUrl, resource.IsPrivateMedia, cancellationToken: HttpContext.RequestAborted);
            return Ok(new ProtectedMediaAccessDto(access.Url, access.ExpiresAt));
        }

        private IQueryable<PremiumResource> GetAccessibleQuery(Guid customerId)
        {
            var now = DateTime.UtcNow;
            var subscription = _context.CustomerSubscriptions
                .FirstOrDefault(s => s.CustomerId == customerId && s.IsActive
                    && s.StartsAt <= now && (s.EndsAt == null || s.EndsAt > now));

            var query = _context.PremiumResources.Where(r => r.IsActive);

            if (subscription != null)
                query = query.Where(r => r.MinimumTier == null || r.MinimumTier <= subscription.Tier);
            else
                query = query.Where(r => r.MinimumTier == null);

            return query;
        }

        private static PremiumResourceDto ToDto(PremiumResource r, bool includeMediaUrl = true) => new(
            r.Id, r.Title, r.Description, r.ResourceType, includeMediaUrl ? r.MediaUrl : null,
            r.Duration, r.MinimumTier?.ToString(), r.Category, r.SortOrder, r.IsActive, r.IsPrivateMedia);

        private Guid? GetCustomerId()
        {
            var sub = User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
