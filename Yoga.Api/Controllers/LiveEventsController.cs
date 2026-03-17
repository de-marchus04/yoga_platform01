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
    [ApiController]
    [Route("api/live-events")]
    public class LiveEventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LiveEventsController(AppDbContext context) => _context = context;

        // ── Public: published events (no JoinUrl) ──
        [HttpGet]
        public async Task<ActionResult<List<LiveEventDto>>> GetPublished()
        {
            var items = await _context.LiveEvents
                .Where(e => e.IsPublished)
                .OrderBy(e => e.StartsAt)
                .Select(e => new LiveEventDto(
                    e.Id, e.Title, e.Description, e.StartsAt, e.EndsAt,
                    e.Status, e.AccessPolicy, e.SeriesId, e.IsPublished,
                    e.RecordingUrl != null, e.CreatedAt
                )).ToListAsync();
            return Ok(items);
        }

        // ── Customer: get event detail with JoinUrl if authorized ──
        [Authorize(Roles = "Customer")]
        [HttpGet("{id:guid}/watch")]
        public async Task<IActionResult> Watch(Guid id)
        {
            var customerId = GetCustomerId();
            if (customerId == null) return Unauthorized();

            var ev = await _context.LiveEvents.FindAsync(id);
            if (ev == null || !ev.IsPublished) return NotFound();

            var hasAccess = await CheckAccess(customerId.Value, ev);
            if (!hasAccess) return Forbid();

            return Ok(new LiveEventDetailDto(
                ev.Id, ev.Title, ev.Description, ev.StartsAt, ev.EndsAt,
                ev.Status,
                ev.Status is "Live" or "Scheduled" ? ev.JoinUrl : null,
                ev.Status == "Ended" ? ev.RecordingUrl : null,
                ev.AccessPolicy, ev.SeriesId, ev.IsPublished
            ));
        }

        // ── Admin CRUD ──
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<LiveEventDto>>> GetAll()
        {
            var items = await _context.LiveEvents.OrderByDescending(e => e.StartsAt)
                .Select(e => new LiveEventDto(
                    e.Id, e.Title, e.Description, e.StartsAt, e.EndsAt,
                    e.Status, e.AccessPolicy, e.SeriesId, e.IsPublished,
                    e.RecordingUrl != null, e.CreatedAt
                )).ToListAsync();
            return Ok(items);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ev = await _context.LiveEvents.FindAsync(id);
            if (ev == null) return NotFound();
            return Ok(new LiveEventDetailDto(
                ev.Id, ev.Title, ev.Description, ev.StartsAt, ev.EndsAt,
                ev.Status, ev.JoinUrl, ev.RecordingUrl,
                ev.AccessPolicy, ev.SeriesId, ev.IsPublished
            ));
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLiveEventRequest req)
        {
            var ev = new LiveEvent
            {
                Title = req.Title,
                Description = req.Description,
                StartsAt = req.StartsAt,
                EndsAt = req.EndsAt,
                JoinUrl = req.JoinUrl,
                AccessPolicy = req.AccessPolicy,
                SeriesId = req.SeriesId
            };
            _context.LiveEvents.Add(ev);
            await _context.SaveChangesAsync();
            return Ok(new { ev.Id });
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLiveEventRequest req)
        {
            var ev = await _context.LiveEvents.FindAsync(id);
            if (ev == null) return NotFound();

            ev.Title = req.Title;
            ev.Description = req.Description;
            ev.StartsAt = req.StartsAt;
            ev.EndsAt = req.EndsAt;
            ev.JoinUrl = req.JoinUrl;
            ev.RecordingUrl = req.RecordingUrl;
            ev.Status = req.Status;
            ev.AccessPolicy = req.AccessPolicy;
            ev.SeriesId = req.SeriesId;
            ev.IsPublished = req.IsPublished;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ev = await _context.LiveEvents.FindAsync(id);
            if (ev == null) return NotFound();
            _context.LiveEvents.Remove(ev);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private async Task<bool> CheckAccess(Guid customerId, LiveEvent ev)
        {
            if (ev.AccessPolicy == "Public") return true;

            if (ev.AccessPolicy == "AllSubscribers")
            {
                return await _context.CustomerSubscriptions.AnyAsync(
                    s => s.CustomerId == customerId && s.IsActive
                         && s.StartsAt <= DateTime.UtcNow
                         && (s.EndsAt == null || s.EndsAt > DateTime.UtcNow));
            }

            // GrantOnly — check individual grant
            return await _context.CustomerAccessGrants.AnyAsync(
                g => g.CustomerId == customerId && g.Status == "Active"
                     && (g.LiveEventId == ev.Id
                         || (g.AccessType == AccessType.LiveEventSeries && g.LiveEventId == ev.SeriesId))
                     && g.StartsAt <= DateTime.UtcNow
                     && (g.EndsAt == null || g.EndsAt > DateTime.UtcNow));
        }

        private Guid? GetCustomerId()
        {
            var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
