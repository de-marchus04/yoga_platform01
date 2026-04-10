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

        [HttpGet("{slug}")]
        public async Task<ActionResult<SitePageDto>> GetPage(string slug, [FromQuery] string lang = "uk")
        {
            var page = await _context.SitePages.FirstOrDefaultAsync(p => p.Slug == slug);
            if (page == null) return NotFound();

            var fields = await _context.Translations
                .Where(t => t.EntityType == "SitePage" && t.EntityId == page.Id && t.Language == lang)
                .ToDictionaryAsync(t => t.Field, t => t.Value);

            return Ok(new SitePageDto(page.Slug, fields));
        }
    }
}
