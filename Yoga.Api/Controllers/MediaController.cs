using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "SuperAdmin")]
    public class MediaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MediaController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediaFile>>> GetAll([FromQuery] string? entityType = null)
        {
            var query = _context.MediaFiles.AsQueryable();
            if (!string.IsNullOrEmpty(entityType))
                query = query.Where(m => m.EntityType == entityType);
            return await query.OrderByDescending(m => m.SortOrder).ToListAsync();
        }

        [HttpPost("upload")]
        [RequestSizeLimit(10 * 1024 * 1024)] // 10MB
        public async Task<ActionResult<MediaFile>> Upload(IFormFile file, [FromForm] string? entityType = null, [FromForm] string? entityId = null)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg", ".mp4", ".webm" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(ext))
                return BadRequest("File type not allowed");

            var uploadsDir = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsDir);

            var fileName = $"{Guid.NewGuid()}{ext}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var media = new MediaFile
            {
                Id = Guid.NewGuid(),
                Url = $"/uploads/{fileName}",
                Alt = Path.GetFileNameWithoutExtension(file.FileName),
                EntityType = entityType ?? "",
                EntityId = Guid.TryParse(entityId, out var eid) ? eid : Guid.Empty
            };

            _context.MediaFiles.Add(media);
            await _context.SaveChangesAsync();

            return Ok(media);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MediaFile updated)
        {
            var media = await _context.MediaFiles.FindAsync(id);
            if (media == null) return NotFound();

            media.Alt = updated.Alt;
            media.EntityType = updated.EntityType;
            media.EntityId = updated.EntityId;
            media.SortOrder = updated.SortOrder;

            await _context.SaveChangesAsync();
            return Ok(media);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var media = await _context.MediaFiles.FindAsync(id);
            if (media == null) return NotFound();

            // Try to delete physical file
            if (media.Url.StartsWith("/uploads/"))
            {
                var filePath = Path.Combine(_env.ContentRootPath, "wwwroot", media.Url.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            _context.MediaFiles.Remove(media);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
