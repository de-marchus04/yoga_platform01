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
    public class YagyasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YagyasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<YagyaDto>>> GetActiveYagyas([FromQuery] string lang = "ru")
        {
            var items = await _context.Yagyas
                .Where(item => item.IsActive)
                .OrderBy(item => item.StartDate)
                .ToListAsync();

            return Ok(await MapToDto(items, lang));
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<YagyaDto>>> GetUpcomingYagyas([FromQuery] string lang = "ru")
        {
            var now = DateTime.UtcNow;
            var items = await _context.Yagyas
                .Where(item => item.IsActive && item.StartDate > now)
                .OrderBy(item => item.StartDate)
                .ToListAsync();

            return Ok(await MapToDto(items, lang));
        }

        [HttpGet("past")]
        public async Task<ActionResult<IEnumerable<YagyaDto>>> GetPastYagyas([FromQuery] string lang = "ru")
        {
            var now = DateTime.UtcNow;
            var items = await _context.Yagyas
                .Where(item => item.EndDate < now)
                .OrderByDescending(item => item.StartDate)
                .ToListAsync();

            return Ok(await MapToDto(items, lang));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<YagyaDto>> GetYagya(Guid id, [FromQuery] string lang = "ru")
        {
            var item = await _context.Yagyas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok((await MapToDto(new List<Yagya> { item }, lang)).First());
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Yagya>>> GetAllYagyas()
        {
            return await _context.Yagyas.OrderBy(item => item.StartDate).ToListAsync();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<Yagya>> CreateYagya([FromBody] Yagya item)
        {
            item.Id = Guid.NewGuid();
            _context.Yagyas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetYagya), new { id = item.Id }, item);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateYagya(Guid id, [FromBody] Yagya item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteYagya(Guid id)
        {
            var item = await _context.Yagyas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var translations = await _context.Translations
                .Where(t => t.EntityType == "Yagya" && t.EntityId == id)
                .ToListAsync();
            _context.Translations.RemoveRange(translations);

            var media = await _context.MediaFiles
                .Where(m => m.EntityType == "Yagya" && m.EntityId == id)
                .ToListAsync();
            _context.MediaFiles.RemoveRange(media);

            _context.Yagyas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private async Task<IEnumerable<YagyaDto>> MapToDto(List<Yagya> items, string lang)
        {
            var ids = items.Select(item => item.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Yagya" && ids.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            return items.Select(item =>
            {
                var ct = translations.Where(t => t.EntityId == item.Id).ToDictionary(t => t.Field, t => t.Value);
                return new YagyaDto(
                    item.Id,
                    ct.TryGetValue("Title", out var title) ? title : item.Title,
                    ct.TryGetValue("Description", out var description) ? description : item.Description,
                    ct.TryGetValue("Location", out var location) ? location : item.Location,
                    item.StartDate,
                    item.EndDate,
                    item.ImageUrl,
                    ct.TryGetValue("PriceLabel", out var priceLabel) ? priceLabel : item.PriceLabel,
                    ct.TryGetValue("Program", out var program) ? program : item.Program);
            });
        }
    }
}