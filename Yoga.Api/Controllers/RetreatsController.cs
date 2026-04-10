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

        [HttpGet]
        public async Task<ActionResult<List<RetreatDto>>> GetRetreats([FromQuery] string lang = "uk")
        {
            var items = await _context.Retreats
                .Where(r => r.IsActive)
                .OrderBy(r => r.SortOrder)
                .Include(r => r.Subcategories.Where(s => s.IsActive).OrderBy(s => s.SortOrder))
                .ToListAsync();

            var ids = items.Select(r => r.Id).ToList();
            var subIds = items.SelectMany(r => r.Subcategories).Select(s => s.Id).ToList();

            var translations = await _context.Translations
                .Where(t => t.Language == lang &&
                    ((t.EntityType == "Retreat" && ids.Contains(t.EntityId)) ||
                     (t.EntityType == "RetreatSubcategory" && subIds.Contains(t.EntityId))))
                .ToListAsync();

            var result = items.Select(r => BuildDto(r, translations)).ToList();
            return Ok(result);
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<RetreatDto>> GetRetreat(string slug, [FromQuery] string lang = "uk")
        {
            var item = await _context.Retreats
                .Include(r => r.Subcategories.Where(s => s.IsActive).OrderBy(s => s.SortOrder))
                .FirstOrDefaultAsync(r => r.Slug == slug && r.IsActive);

            if (item is null) return NotFound();

            var ids = new List<Guid> { item.Id };
            var subIds = item.Subcategories.Select(s => s.Id).ToList();

            var translations = await _context.Translations
                .Where(t => t.Language == lang &&
                    ((t.EntityType == "Retreat" && ids.Contains(t.EntityId)) ||
                     (t.EntityType == "RetreatSubcategory" && subIds.Contains(t.EntityId))))
                .ToListAsync();

            return Ok(BuildDto(item, translations));
        }

        private static RetreatDto BuildDto(Retreat r, List<Translation> translations)
        {
            var ct = translations.Where(t => t.EntityId == r.Id).ToDictionary(t => t.Field, t => t.Value);
            string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

            var benefits = F("Benefits").Split('|', StringSplitOptions.RemoveEmptyEntries);
            var forWhom = F("ForWhom").Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var parts = x.Split("~", 3);
                    return new ForWhomItem(
                        parts.ElementAtOrDefault(0) ?? "",
                        parts.ElementAtOrDefault(1) ?? "",
                        parts.Length > 2 && !string.IsNullOrWhiteSpace(parts[2]) ? parts[2] : null);
                }).ToArray();

            var subcategories = r.Subcategories.Select(s =>
            {
                var st = translations.Where(t => t.EntityId == s.Id).ToDictionary(t => t.Field, t => t.Value);
                string SF(string field) => st.TryGetValue(field, out var v) ? v : string.Empty;
                return new RetreatSubcategoryDto(s.Id, s.Slug, SF("Title"), SF("Description"), SF("ImageUrl"), s.SortOrder);
            }).ToList();

            return new RetreatDto(r.Id, r.Slug, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                benefits, F("ImageUrl"), F("Duration"), F("Location"), F("Format"),
                F("PriceLabel"), forWhom, F("CtaHeading"), F("CtaText"), subcategories);
        }
    }
}
