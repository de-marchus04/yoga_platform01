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
    public class ConsultationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultationsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /api/consultations?lang=ru — public list of active consultations with translations.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<ConsultationDto>>> GetConsultations([FromQuery] string lang = "ru")
        {
            var items = await _context.Consultations
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .ToListAsync();

            var ids = items.Select(c => c.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Consultation" && ids.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var result = items.Select(c =>
            {
                var ct = translations.Where(t => t.EntityId == c.Id).ToDictionary(t => t.Field, t => t.Value);
                string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

                var benefits = F("Benefits").Split('|', StringSplitOptions.RemoveEmptyEntries);
                var forWhom = F("ForWhom").Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => { var parts = x.Split("~", 2); return new ForWhomItem(parts.ElementAtOrDefault(0) ?? "", parts.ElementAtOrDefault(1) ?? ""); })
                    .ToArray();

                return new ConsultationDto(c.Id, c.Slug, c.IsOnline, c.IsOffline, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                    F("Quote"), benefits, F("ImageUrl"), F("Duration"), F("Format"), F("LanguageOffered"),
                    F("PriceLabel"), forWhom, F("CtaHeading"), F("CtaText"));
            }).ToList();

            return Ok(result);
        }

        /// <summary>
        /// GET /api/consultations/{slug}?lang=ru
        /// </summary>
        [HttpGet("{slug}")]
        public async Task<ActionResult<ConsultationDto>> GetConsultation(string slug, [FromQuery] string lang = "ru")
        {
            var item = await _context.Consultations
                .FirstOrDefaultAsync(c => c.Slug == slug && c.IsActive);

            if (item == null) return NotFound();

            var ct = await _context.Translations
                .Where(t => t.EntityType == "Consultation" && t.EntityId == item.Id && t.Language == lang)
                .ToDictionaryAsync(t => t.Field, t => t.Value);

            string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

            var benefits = F("Benefits").Split('|', StringSplitOptions.RemoveEmptyEntries);
            var forWhom = F("ForWhom").Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => { var parts = x.Split("~", 2); return new ForWhomItem(parts.ElementAtOrDefault(0) ?? "", parts.ElementAtOrDefault(1) ?? ""); })
                .ToArray();

            var dto = new ConsultationDto(item.Id, item.Slug, item.IsOnline, item.IsOffline, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                F("Quote"), benefits, F("ImageUrl"), F("Duration"), F("Format"), F("LanguageOffered"),
                F("PriceLabel"), forWhom, F("CtaHeading"), F("CtaText"));

            return Ok(dto);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<Consultation>> CreateConsultation([FromBody] Consultation item)
        {
            item.Id = Guid.NewGuid();
            _context.Consultations.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetConsultation), new { slug = item.Slug }, item);
        }

        // GET: api/consultations/all (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Consultation>>> GetAllConsultations()
        {
            return await _context.Consultations.OrderBy(c => c.SortOrder).ToListAsync();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateConsultation(Guid id, [FromBody] Consultation item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteConsultation(Guid id)
        {
            var item = await _context.Consultations.FindAsync(id);
            if (item == null) return NotFound();

            var translations = await _context.Translations
                .Where(t => t.EntityType == "Consultation" && t.EntityId == id)
                .ToListAsync();
            _context.Translations.RemoveRange(translations);
            _context.Consultations.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
