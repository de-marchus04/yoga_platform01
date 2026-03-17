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
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /api/courses?lang=ru — public list of active courses with translations.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetCourses([FromQuery] string lang = "ru")
        {
            var courses = await _context.Courses
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .Include(c => c.Modules.OrderBy(m => m.SortOrder))
                .ToListAsync();

            var courseIds = courses.Select(c => c.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Course" && courseIds.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var moduleIds = courses.SelectMany(c => c.Modules).Select(m => m.Id).ToList();
            var moduleTranslations = await _context.Translations
                .Where(t => t.EntityType == "CourseModule" && moduleIds.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var result = courses.Select(c =>
            {
                var ct = translations.Where(t => t.EntityId == c.Id).ToDictionary(t => t.Field, t => t.Value);
                string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

                var modules = c.Modules.Select(m =>
                {
                    var mt = moduleTranslations.Where(t => t.EntityId == m.Id).ToDictionary(t => t.Field, t => t.Value);
                    string MF(string field) => mt.TryGetValue(field, out var v) ? v : string.Empty;
                    return new CourseModuleDto(m.Id, MF("Title"), MF("Description"), m.SortOrder);
                }).ToList();

                var benefits = F("Benefits").Split('|', StringSplitOptions.RemoveEmptyEntries);
                var forWhom = F("ForWhom").Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => { var parts = x.Split("~", 2); return new ForWhomItem(parts.ElementAtOrDefault(0) ?? "", parts.ElementAtOrDefault(1) ?? ""); })
                    .ToArray();

                return new CourseDto(c.Id, c.Slug, c.IsOnline, c.IsOffline, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                    benefits, F("ImageUrl"), F("Duration"), F("Level"), F("Format"), F("Schedule"),
                    forWhom, F("CtaHeading"), F("CtaText"), modules);
            }).ToList();

            return Ok(result);
        }

        /// <summary>
        /// GET /api/courses/{slug}?lang=ru — single course by slug with translations.
        /// </summary>
        [HttpGet("{slug}")]
        public async Task<ActionResult<CourseDto>> GetCourse(string slug, [FromQuery] string lang = "ru")
        {
            var course = await _context.Courses
                .Include(c => c.Modules.OrderBy(m => m.SortOrder))
                .FirstOrDefaultAsync(c => c.Slug == slug && c.IsActive);

            if (course == null) return NotFound();

            var ct = await _context.Translations
                .Where(t => t.EntityType == "Course" && t.EntityId == course.Id && t.Language == lang)
                .ToDictionaryAsync(t => t.Field, t => t.Value);

            string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

            var moduleIds = course.Modules.Select(m => m.Id).ToList();
            var moduleTranslations = await _context.Translations
                .Where(t => t.EntityType == "CourseModule" && moduleIds.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var modules = course.Modules.Select(m =>
            {
                var mt = moduleTranslations.Where(t => t.EntityId == m.Id).ToDictionary(t => t.Field, t => t.Value);
                string MF(string field) => mt.TryGetValue(field, out var v) ? v : string.Empty;
                return new CourseModuleDto(m.Id, MF("Title"), MF("Description"), m.SortOrder);
            }).ToList();

            var benefits = F("Benefits").Split('|', StringSplitOptions.RemoveEmptyEntries);
            var forWhom = F("ForWhom").Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => { var parts = x.Split("~", 2); return new ForWhomItem(parts.ElementAtOrDefault(0) ?? "", parts.ElementAtOrDefault(1) ?? ""); })
                .ToArray();

            var dto = new CourseDto(course.Id, course.Slug, course.IsOnline, course.IsOffline, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                benefits, F("ImageUrl"), F("Duration"), F("Level"), F("Format"), F("Schedule"),
                forWhom, F("CtaHeading"), F("CtaText"), modules);

            return Ok(dto);
        }

        /// <summary>
        /// POST /api/courses — create a new course (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse([FromBody] Course course)
        {
            course.Id = Guid.NewGuid();
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { slug = course.Slug }, course);
        }

        /// <summary>
        /// PUT /api/courses/{id} — update a course (admin).
        /// </summary>
        // GET: api/courses/all (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            return await _context.Courses.OrderBy(c => c.SortOrder).Include(c => c.Modules.OrderBy(m => m.SortOrder)).ToListAsync();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest();
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _context.Courses.Include(c => c.Modules).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();

            var moduleIds = course.Modules.Select(m => m.Id).ToList();
            var translations = await _context.Translations
                .Where(t => (t.EntityType == "Course" && t.EntityId == id) || (t.EntityType == "CourseModule" && moduleIds.Contains(t.EntityId)))
                .ToListAsync();
            _context.Translations.RemoveRange(translations);
            _context.CourseModules.RemoveRange(course.Modules);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
