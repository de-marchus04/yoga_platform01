using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitemapController : ControllerBase
    {
        private readonly AppDbContext _context;
        private const string BaseUrl = "https://www.medisha.space";

        public SitemapController(AppDbContext context) => _context = context;

        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> Get()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            AddUrl(sb, "/", "weekly", "1.0");
            AddUrl(sb, "/about", "monthly", "0.8");
            AddUrl(sb, "/contacts", "monthly", "0.6");
            AddUrl(sb, "/privacy", "yearly", "0.3");
            AddUrl(sb, "/terms", "yearly", "0.3");
            AddUrl(sb, "/courses", "weekly", "0.85");
            AddUrl(sb, "/consultations", "weekly", "0.85");

            var courses = await _context.Courses
                .Where(c => c.IsActive)
                .Select(c => c.Slug)
                .ToListAsync();
            foreach (var slug in courses)
                AddUrl(sb, $"/courses/{slug}", "weekly", "0.8");

            var consultations = await _context.Consultations
                .Where(c => c.IsActive)
                .Select(c => c.Slug)
                .ToListAsync();
            foreach (var slug in consultations)
                AddUrl(sb, $"/consultations/{slug}", "weekly", "0.7");

            var retreats = await _context.Retreats
                .Where(r => r.IsActive && r.Slug != "")
                .Select(r => r.Slug)
                .ToListAsync();
            foreach (var slug in retreats)
                AddUrl(sb, $"/retreats/{slug}", "monthly", "0.7");

            var yagyas = await _context.Yagyas
                .Where(y => y.IsActive && y.Slug != "")
                .Select(y => y.Slug)
                .ToListAsync();
            foreach (var slug in yagyas)
                AddUrl(sb, $"/yagyas/{slug}", "monthly", "0.7");

            sb.AppendLine("</urlset>");
            return Content(sb.ToString(), "application/xml", Encoding.UTF8);
        }

        private static void AddUrl(StringBuilder sb, string path, string changefreq, string priority)
        {
            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{BaseUrl}{path}</loc>");
            sb.AppendLine($"    <changefreq>{changefreq}</changefreq>");
            sb.AppendLine($"    <priority>{priority}</priority>");
            sb.AppendLine("  </url>");
        }
    }
}
