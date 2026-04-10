using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YagyasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YagyasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<YagyaDto>>> GetYagyas([FromQuery] string lang = "uk")
        {
            var items = await _context.Yagyas
                .Where(y => y.IsActive)
                .OrderBy(y => y.SortOrder)
                .Include(y => y.Subcategories.Where(s => s.IsActive).OrderBy(s => s.SortOrder))
                .ToListAsync();

            var ids = items.Select(y => y.Id).ToList();
            var subIds = items.SelectMany(y => y.Subcategories).Select(s => s.Id).ToList();

            var translations = await _context.Translations
                .Where(t => t.Language == lang &&
                    ((t.EntityType == "Yagya" && ids.Contains(t.EntityId)) ||
                     (t.EntityType == "YagyaSubcategory" && subIds.Contains(t.EntityId))))
                .ToListAsync();

            var result = items.Select(y => BuildDto(y, translations)).ToList();
            return Ok(result);
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<YagyaDto>> GetYagya(string slug, [FromQuery] string lang = "uk")
        {
            var item = await _context.Yagyas
                .Include(y => y.Subcategories.Where(s => s.IsActive).OrderBy(s => s.SortOrder))
                .FirstOrDefaultAsync(y => y.Slug == slug && y.IsActive);

            if (item is null) return NotFound();

            var ids = new List<Guid> { item.Id };
            var subIds = item.Subcategories.Select(s => s.Id).ToList();

            var translations = await _context.Translations
                .Where(t => t.Language == lang &&
                    ((t.EntityType == "Yagya" && ids.Contains(t.EntityId)) ||
                     (t.EntityType == "YagyaSubcategory" && subIds.Contains(t.EntityId))))
                .ToListAsync();

            return Ok(BuildDto(item, translations));
        }

        private static YagyaDto BuildDto(Yagya y, List<Translation> translations)
        {
            var ct = translations.Where(t => t.EntityId == y.Id).ToDictionary(t => t.Field, t => t.Value);
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

            var subcategories = y.Subcategories.Select(s =>
            {
                var st = translations.Where(t => t.EntityId == s.Id).ToDictionary(t => t.Field, t => t.Value);
                string SF(string field) => st.TryGetValue(field, out var v) ? v : string.Empty;
                return new YagyaSubcategoryDto(s.Id, s.Slug, SF("Title"), SF("Description"), SF("ImageUrl"), s.SortOrder);
            }).ToList();

            return new YagyaDto(y.Id, y.Slug, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                benefits, F("ImageUrl"), F("Duration"), F("Format"),
                F("PriceLabel"), forWhom, F("CtaHeading"), F("CtaText"), subcategories);
        }
    }
}
