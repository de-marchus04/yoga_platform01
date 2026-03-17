using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    /// <summary>User-facing cabinet API — accessed by authenticated Customers.</summary>
    [ApiController]
    [Route("api/my")]
    [Authorize(Roles = "Customer")]
    public class CustomerAccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerAccountController(AppDbContext context) => _context = context;

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var cid = GetCustomerId();
            if (cid == null) return Unauthorized();

            var customer = await _context.Customers
                .Include(c => c.Subscription)
                .FirstOrDefaultAsync(c => c.Id == cid);
            if (customer == null) return NotFound();

            var grants = await _context.CustomerAccessGrants
                .Include(g => g.Customer)
                .Where(g => g.CustomerId == cid && g.Status == "Active")
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();

            var enrichedGrants = await EnrichGrantsAsync(grants);

            var upcomingEvents = await _context.LiveEvents
                .Where(e => e.IsPublished && e.Status != "Ended" && e.Status != "Cancelled")
                .OrderBy(e => e.StartsAt)
                .Take(10)
                .Select(e => new LiveEventDto(
                    e.Id, e.Title, e.Description, e.StartsAt, e.EndsAt,
                    e.Status, e.AccessPolicy, e.SeriesId, e.IsPublished,
                    e.RecordingUrl != null, e.CreatedAt
                )).ToListAsync();

            var totalLeads = await _context.Leads.CountAsync(l => l.CustomerId == cid);

            var sub = customer.Subscription is { IsActive: true }
                ? new CustomerSubscriptionDto(customer.Subscription.Id,
                    customer.Subscription.Tier.ToString(),
                    customer.Subscription.StartsAt,
                    customer.Subscription.EndsAt,
                    customer.Subscription.IsActive)
                : null;

            return Ok(new MyDashboardDto(
                new CustomerProfileDto(customer.FullName, customer.Phone, customer.Messenger),
                enrichedGrants, sub, upcomingEvents, totalLeads
            ));
        }

        [HttpGet("grants")]
        public async Task<ActionResult<List<AccessGrantDto>>> MyGrants()
        {
            var cid = GetCustomerId();
            if (cid == null) return Unauthorized();

            var grants = await _context.CustomerAccessGrants
                .Include(g => g.Customer)
                .Where(g => g.CustomerId == cid)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();

            var items = await EnrichGrantsAsync(grants);
            return Ok(items);
        }

        [HttpGet("leads")]
        public async Task<ActionResult<List<LeadSummaryDto>>> MyLeads()
        {
            var cid = GetCustomerId();
            if (cid == null) return Unauthorized();

            var items = await _context.Leads
                .Where(l => l.CustomerId == cid)
                .OrderByDescending(l => l.CreatedAt)
                .Take(50)
                .Select(l => new LeadSummaryDto(
                    l.Id, l.Name, l.ContactDetails, l.Messager, l.Comment, l.CreatedAt, l.IsProcessed,
                    l.Status, l.TargetFormat, null, // AdminNotes hidden from customer
                    l.CourseId, l.ConsultationId, l.RetreatId,
                    null, null, null
                )).ToListAsync();
            return Ok(items);
        }

        [HttpGet("events")]
        public async Task<ActionResult<List<LiveEventDto>>> MyEvents()
        {
            var cid = GetCustomerId();
            if (cid == null) return Unauthorized();

            // Events accessible via grants
            var grantedEventIds = await _context.CustomerAccessGrants
                .Where(g => g.CustomerId == cid && g.Status == "Active" && g.LiveEventId != null)
                .Select(g => g.LiveEventId!.Value)
                .ToListAsync();

            // Check if customer has active subscription (for AllSubscribers events)
            var hasSubscription = await _context.CustomerSubscriptions.AnyAsync(
                s => s.CustomerId == cid && s.IsActive
                     && s.StartsAt <= DateTime.UtcNow
                     && (s.EndsAt == null || s.EndsAt > DateTime.UtcNow));

            var items = await _context.LiveEvents
                .Where(e => e.IsPublished &&
                    (e.AccessPolicy == "Public"
                     || (e.AccessPolicy == "AllSubscribers" && hasSubscription)
                     || grantedEventIds.Contains(e.Id)))
                .OrderBy(e => e.StartsAt)
                .Select(e => new LiveEventDto(
                    e.Id, e.Title, e.Description, e.StartsAt, e.EndsAt,
                    e.Status, e.AccessPolicy, e.SeriesId, e.IsPublished,
                    e.RecordingUrl != null, e.CreatedAt
                )).ToListAsync();
            return Ok(items);
        }

        private Guid? GetCustomerId()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }

        private async Task<List<AccessGrantDto>> EnrichGrantsAsync(
            List<Yoga.Shared.Models.CustomerAccessGrant> grants, string lang = "ru")
        {
            var courseIds = grants.Where(g => g.CourseId != null).Select(g => g.CourseId!.Value).Distinct().ToList();
            var consultIds = grants.Where(g => g.ConsultationId != null).Select(g => g.ConsultationId!.Value).Distinct().ToList();
            var retreatIds = grants.Where(g => g.RetreatId != null).Select(g => g.RetreatId!.Value).Distinct().ToList();
            var eventIds = grants.Where(g => g.LiveEventId != null).Select(g => g.LiveEventId!.Value).Distinct().ToList();

            // Slugs from entity tables
            var courseSlugs = courseIds.Any()
                ? await _context.Courses.Where(c => courseIds.Contains(c.Id)).ToDictionaryAsync(c => c.Id, c => c.Slug)
                : new();
            var consultSlugs = consultIds.Any()
                ? await _context.Consultations.Where(c => consultIds.Contains(c.Id)).ToDictionaryAsync(c => c.Id, c => c.Slug)
                : new();
            var retreatTitles = retreatIds.Any()
                ? await _context.Retreats.Where(r => retreatIds.Contains(r.Id)).ToDictionaryAsync(r => r.Id, r => r.Title)
                : new();
            var eventTitles = eventIds.Any()
                ? await _context.LiveEvents.Where(e => eventIds.Contains(e.Id)).ToDictionaryAsync(e => e.Id, e => e.Title)
                : new();

            // Translated titles
            var allIds = courseIds.Cast<Guid>().Concat(consultIds).ToList();
            var translations = allIds.Any()
                ? await _context.Translations
                    .Where(t => allIds.Contains(t.EntityId) && t.Field == "Title" && t.Language == lang)
                    .ToDictionaryAsync(t => t.EntityId, t => t.Value)
                : new();

            return grants.Select(g => new AccessGrantDto(
                g.Id, g.CustomerId, g.Customer?.FullName ?? "", g.AccessType.ToString(),
                g.CourseId, g.ConsultationId, g.RetreatId, g.LiveEventId,
                g.StartsAt, g.EndsAt, g.Status, g.SourceLeadId, g.Notes, g.CreatedAt,
                CourseName: g.CourseId != null && translations.TryGetValue(g.CourseId.Value, out var cn) ? cn : null,
                CourseSlug: g.CourseId != null && courseSlugs.TryGetValue(g.CourseId.Value, out var cs) ? cs : null,
                ConsultationName: g.ConsultationId != null && translations.TryGetValue(g.ConsultationId.Value, out var conN) ? conN : null,
                ConsultationSlug: g.ConsultationId != null && consultSlugs.TryGetValue(g.ConsultationId.Value, out var conS) ? conS : null,
                RetreatTitle: g.RetreatId != null && retreatTitles.TryGetValue(g.RetreatId.Value, out var rt) ? rt : null,
                LiveEventTitle: g.LiveEventId != null && eventTitles.TryGetValue(g.LiveEventId.Value, out var et) ? et : null
            )).ToList();
        }
    }
}
