using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Hubs;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<BlogHub> _hub;

        public BlogController(AppDbContext context, IHubContext<BlogHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        /// <summary>
        /// GET /api/blog?lang=ru&category=articles — public list of active blog posts.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<BlogPostDto>>> GetPosts(
            [FromQuery] string lang = "ru",
            [FromQuery] string? category = null,
            [FromQuery] string? section = null,
            [FromQuery] Guid? relatedEntityId = null)
        {
            var query = _context.BlogPosts.Where(b => b.IsActive);

            if (!string.IsNullOrEmpty(category))
                query = query.Where(b => b.Category == category);

            if (!string.IsNullOrEmpty(section) && relatedEntityId.HasValue)
            {
                var id = relatedEntityId.Value;
                query = query.Where(b => b.Sections.Any(s => s == section) || b.RelatedCourseId == id || b.RelatedConsultationId == id || b.RelatedRetreatId == id);
            }
            else if (!string.IsNullOrEmpty(section))
            {
                query = query.Where(b => b.Sections.Any(s => s == section));
            }
            else if (relatedEntityId.HasValue)
            {
                var id = relatedEntityId.Value;
                query = query.Where(b => b.RelatedCourseId == id || b.RelatedConsultationId == id || b.RelatedRetreatId == id);
            }

            var posts = await query
                .OrderByDescending(b => b.PublishedAt)
                .ToListAsync();

            var ids = posts.Select(p => p.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "BlogPost" && ids.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var result = posts.Select(p =>
            {
                var ct = translations.Where(t => t.EntityId == p.Id).ToDictionary(t => t.Field, t => t.Value);
                string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

                return new BlogPostDto(p.Id, p.Slug, p.Category, F("Title"), F("Excerpt"), F("Tag"), p.MediaUrl, p.PublishedAt, p.Sections, p.RelatedCourseId, p.RelatedConsultationId, p.RelatedRetreatId);
            }).ToList();

            return Ok(result);
        }

        /// <summary>
        /// GET /api/blog/{slug}?lang=ru
        /// </summary>
        [HttpGet("{slug}")]
        public async Task<ActionResult<BlogPostDto>> GetPost(string slug, [FromQuery] string lang = "ru")
        {
            var post = await _context.BlogPosts
                .FirstOrDefaultAsync(b => b.Slug == slug && b.IsActive);

            if (post == null) return NotFound();

            var ct = await _context.Translations
                .Where(t => t.EntityType == "BlogPost" && t.EntityId == post.Id && t.Language == lang)
                .ToDictionaryAsync(t => t.Field, t => t.Value);

            string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

            return Ok(new BlogPostDto(post.Id, post.Slug, post.Category, F("Title"), F("Excerpt"), F("Tag"), post.MediaUrl, post.PublishedAt, post.Sections, post.RelatedCourseId, post.RelatedConsultationId, post.RelatedRetreatId));
        }

        // GET: api/blog/all (Admin Only — all posts including inactive)
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<BlogPost>>> GetAllPosts()
        {
            return await _context.BlogPosts.OrderByDescending(b => b.PublishedAt).ToListAsync();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreatePost([FromBody] BlogPost post)
        {
            post.Id = Guid.NewGuid();
            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();
            await _hub.Clients.All.SendAsync("BlogUpdated", post.Sections);
            return CreatedAtAction(nameof(GetPost), new { slug = post.Slug }, post);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] BlogPost post)
        {
            if (id != post.Id) return BadRequest();
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await _hub.Clients.All.SendAsync("BlogUpdated", post.Sections);
            return NoContent();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post == null) return NotFound();

            var translations = await _context.Translations
                .Where(t => t.EntityType == "BlogPost" && t.EntityId == id)
                .ToListAsync();
            _context.Translations.RemoveRange(translations);
            _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
