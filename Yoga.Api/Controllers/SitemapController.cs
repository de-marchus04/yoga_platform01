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

            // Static pages
            AddUrl(sb, "/", "weekly", "1.0");
            AddUrl(sb, "/about", "monthly", "0.8");
            AddUrl(sb, "/contacts", "monthly", "0.6");
            AddUrl(sb, "/blog", "daily", "0.8");
            AddUrl(sb, "/blog/articles", "daily", "0.7");
            AddUrl(sb, "/blog/photos", "weekly", "0.6");
            AddUrl(sb, "/blog/videos", "weekly", "0.6");
            AddUrl(sb, "/retreats/past", "monthly", "0.5");

            // Courses
            var courses = await _context.Courses
                .Where(c => c.IsActive)
                .Select(c => c.Slug)
                .ToListAsync();
            foreach (var slug in courses)
                AddUrl(sb, $"/courses/{slug}", "weekly", "0.8");

            // Consultations
            var consultations = await _context.Consultations
                .Where(c => c.IsActive)
                .Select(c => c.Slug)
                .ToListAsync();
            foreach (var slug in consultations)
                AddUrl(sb, $"/consultations/{slug}", "weekly", "0.7");

            // Retreats (canonical slug URL when set)
            var retreats = await _context.Retreats
                .Select(r => new { r.Id, r.Slug })
                .ToListAsync();
            foreach (var r in retreats)
            {
                var path = !string.IsNullOrWhiteSpace(r.Slug) ? $"/retreats/{r.Slug}" : $"/retreats/{r.Id}";
                AddUrl(sb, path, "monthly", "0.7");
            }

            // Blog posts
            var posts = await _context.BlogPosts
                .Where(p => p.IsActive)
                .Select(p => p.Slug)
                .ToListAsync();
            foreach (var slug in posts)
                AddUrl(sb, $"/blog/{slug}", "monthly", "0.6");

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
