using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Services;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "SuperAdmin")]
    public class MediaController : ControllerBase
    {
        private const long MaxUploadSizeBytes = 256L * 1024 * 1024;
        private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg",
            ".mp4", ".webm", ".mov",
            ".mp3", ".wav", ".m4a", ".aac", ".ogg",
            ".pdf"
        };

        private readonly AppDbContext _context;
        private readonly IFileStorageService _storageService;

        public MediaController(AppDbContext context, IFileStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
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
        [RequestSizeLimit(MaxUploadSizeBytes)]
        public async Task<ActionResult<MediaFile>> Upload(IFormFile file, [FromForm] string? entityType = null, [FromForm] string? entityId = null)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided");

            if (file.Length > MaxUploadSizeBytes)
                return BadRequest($"File is too large. Maximum allowed size is {MaxUploadSizeBytes / (1024 * 1024)} MB.");

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
                return BadRequest("File type not allowed");

            var storedFile = await _storageService.SaveAsync(file, entityType, HttpContext.RequestAborted);

            var media = new MediaFile
            {
                Id = Guid.NewGuid(),
                Url = storedFile.Url,
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

            await _storageService.DeleteAsync(media.Url, HttpContext.RequestAborted);

            _context.MediaFiles.Remove(media);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
