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
    public class SitePagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SitePagesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /api/sitepages/{slug}?lang=ru — returns all translated fields for a site page.
        /// </summary>
        [HttpGet("{slug}")]
        public async Task<ActionResult<SitePageDto>> GetPage(string slug, [FromQuery] string lang = "ru")
        {
            var page = await _context.SitePages.FirstOrDefaultAsync(p => p.Slug == slug);
            if (page == null) return NotFound();

            var fields = await _context.Translations
                .Where(t => t.EntityType == "SitePage" && t.EntityId == page.Id && t.Language == lang)
                .ToDictionaryAsync(t => t.Field, t => t.Value);

            return Ok(new SitePageDto(page.Slug, fields));
        }

        /// <summary>
        /// GET /api/sitepages — list all site pages.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<SitePage>>> GetPages()
        {
            return await _context.SitePages.ToListAsync();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<SitePage>> CreatePage([FromBody] SitePage page)
        {
            page.Id = Guid.NewGuid();
            _context.SitePages.Add(page);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPage), new { slug = page.Slug }, page);
        }
    }
}
