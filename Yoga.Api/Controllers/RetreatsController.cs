using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RetreatsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RetreatsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/retreats?lang=ru (Public - anyone can see active retreats)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RetreatDto>>> GetActiveRetreats([FromQuery] string lang = "ru")
        {
            var retreats = await _context.Retreats
                .Where(r => r.IsActive)
                .OrderBy(r => r.StartDate)
                .ToListAsync();

            var ids = retreats.Select(r => r.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Retreat" && ids.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var result = retreats.Select(r =>
            {
                var ct = translations.Where(t => t.EntityId == r.Id).ToDictionary(t => t.Field, t => t.Value);
                return ToRetreatDto(r, ct);
            });

            return Ok(result);
        }

        // GET: api/retreats/all (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Retreat>>> GetAllRetreats()
        {
            return await _context.Retreats.OrderBy(r => r.StartDate).ToListAsync();
        }

        // POST: api/retreats (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<Retreat>> CreateRetreat([FromBody] Retreat retreat)
        {
            retreat.Id = Guid.NewGuid();
            _context.Retreats.Add(retreat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActiveRetreats), new { id = retreat.Id }, retreat);
        }

        // PUT: api/retreats/{id} (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRetreat(Guid id, [FromBody] Retreat retreat)
        {
            if (id != retreat.Id)
            {
                return BadRequest();
            }

            _context.Entry(retreat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetreatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/retreats/upcoming?lang=ru
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<RetreatDto>>> GetUpcomingRetreats([FromQuery] string lang = "ru")
        {
            var now = DateTime.UtcNow;
            var retreats = await _context.Retreats
                .Where(r => r.StartDate > now)
                .OrderBy(r => r.StartDate)
                .ToListAsync();

            return Ok(await MapToDto(retreats, lang));
        }

        // GET: api/retreats/past?lang=ru
        [HttpGet("past")]
        public async Task<ActionResult<IEnumerable<RetreatDto>>> GetPastRetreats([FromQuery] string lang = "ru")
        {
            var now = DateTime.UtcNow;
            var retreats = await _context.Retreats
                .Where(r => r.EndDate < now)
                .OrderByDescending(r => r.StartDate)
                .ToListAsync();

            return Ok(await MapToDto(retreats, lang));
        }

        // GET: api/retreats/by-slug/{slug}?lang=ru — must be before {id:guid}
        [HttpGet("by-slug/{slug}")]
        public async Task<ActionResult<RetreatDto>> GetRetreatBySlug(string slug, [FromQuery] string lang = "ru")
        {
            if (string.IsNullOrWhiteSpace(slug)) return NotFound();
            var retreat = await _context.Retreats.FirstOrDefaultAsync(r => r.Slug == slug);
            if (retreat == null) return NotFound();

            var translations = await _context.Translations
                .Where(t => t.EntityType == "Retreat" && t.EntityId == retreat.Id && t.Language == lang)
                .ToListAsync();

            var ct = translations.ToDictionary(t => t.Field, t => t.Value);
            return Ok(ToRetreatDto(retreat, ct));
        }

        // GET: api/retreats/{id}?lang=ru
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RetreatDto>> GetRetreat(Guid id, [FromQuery] string lang = "ru")
        {
            var retreat = await _context.Retreats.FindAsync(id);
            if (retreat == null) return NotFound();

            var translations = await _context.Translations
                .Where(t => t.EntityType == "Retreat" && t.EntityId == id && t.Language == lang)
                .ToListAsync();

            var ct = translations.ToDictionary(t => t.Field, t => t.Value);
            return Ok(ToRetreatDto(retreat, ct));
        }

        private async Task<IEnumerable<RetreatDto>> MapToDto(List<Retreat> retreats, string lang)
        {
            var ids = retreats.Select(r => r.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Retreat" && ids.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            return retreats.Select(r =>
            {
                var ct = translations.Where(t => t.EntityId == r.Id).ToDictionary(t => t.Field, t => t.Value);
                return ToRetreatDto(r, ct);
            });
        }

        private static RetreatDto ToRetreatDto(Retreat r, Dictionary<string, string> ct) =>
            new(
                r.Id,
                ct.TryGetValue("Title", out var title) ? title : r.Title,
                ct.TryGetValue("Description", out var desc) ? desc : r.Description,
                ct.TryGetValue("Location", out var loc) ? loc : r.Location,
                r.StartDate,
                r.EndDate,
                r.ImageUrl,
                ct.TryGetValue("PriceLabel", out var price) ? price : r.PriceLabel,
                ct.TryGetValue("Program", out var prog) ? prog : r.Program,
                r.Slug
            );

        private bool RetreatExists(Guid id)
        {
            return _context.Retreats.Any(e => e.Id == id);
        }

        // DELETE: api/retreats/{id} (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRetreat(Guid id)
        {
            var retreat = await _context.Retreats.FindAsync(id);
            if (retreat == null) return NotFound();

            // Remove related translations
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Retreat" && t.EntityId == id)
                .ToListAsync();
            _context.Translations.RemoveRange(translations);

            _context.Retreats.Remove(retreat);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
