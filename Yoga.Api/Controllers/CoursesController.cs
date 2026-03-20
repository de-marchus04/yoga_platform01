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
                    .ThenInclude(m => m.Lessons.OrderBy(l => l.SortOrder))
                .ToListAsync();

            var courseIds = courses.Select(c => c.Id).ToList();
            var translations = await _context.Translations
                .Where(t => t.EntityType == "Course" && courseIds.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var moduleIds = courses.SelectMany(c => c.Modules).Select(m => m.Id).ToList();
            var moduleTranslations = await _context.Translations
                .Where(t => t.EntityType == "CourseModule" && moduleIds.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var lessonIds = courses.SelectMany(c => c.Modules).SelectMany(m => m.Lessons).Select(l => l.Id).ToList();
            var lessonTranslations = lessonIds.Count > 0
                ? await _context.Translations
                    .Where(t => t.EntityType == "CourseLesson" && lessonIds.Contains(t.EntityId) && t.Language == lang)
                    .ToListAsync()
                : new List<Translation>();

            var result = courses.Select(c => BuildCourseDto(c, translations, moduleTranslations, lessonTranslations)).ToList();

            return Ok(result);
        }

        /// <summary>
        /// GET /api/courses/{slug}?lang=ru — single course by slug with translations.
        /// </summary>
        [HttpGet("{slug}")]
        public async Task<ActionResult<CourseDto>> GetCourse(string slug, [FromQuery] string lang = "ru")
        {
            slug = ResolveCourseSlug(slug);

            var course = await _context.Courses
                .Include(c => c.Modules.OrderBy(m => m.SortOrder))
                    .ThenInclude(m => m.Lessons.OrderBy(l => l.SortOrder))
                .FirstOrDefaultAsync(c => c.Slug == slug && c.IsActive);

            if (course == null) return NotFound();

            var ct = await _context.Translations
                .Where(t => t.EntityType == "Course" && t.EntityId == course.Id && t.Language == lang)
                .ToListAsync();

            var moduleIds = course.Modules.Select(m => m.Id).ToList();
            var moduleTranslations = await _context.Translations
                .Where(t => t.EntityType == "CourseModule" && moduleIds.Contains(t.EntityId) && t.Language == lang)
                .ToListAsync();

            var lessonIds = course.Modules.SelectMany(m => m.Lessons).Select(l => l.Id).ToList();
            var lessonTranslations = lessonIds.Count > 0
                ? await _context.Translations
                    .Where(t => t.EntityType == "CourseLesson" && lessonIds.Contains(t.EntityId) && t.Language == lang)
                    .ToListAsync()
                : new List<Translation>();

            var dto = BuildCourseDto(course, ct, moduleTranslations, lessonTranslations);
            return Ok(dto);
        }

        private static CourseDto BuildCourseDto(Course c, List<Translation> courseTranslations, List<Translation> moduleTranslations, List<Translation> lessonTranslations)
        {
            var ct = courseTranslations.Where(t => t.EntityId == c.Id).ToDictionary(t => t.Field, t => t.Value);
            string F(string field) => ct.TryGetValue(field, out var v) ? v : string.Empty;

            var modules = c.Modules.Select(m =>
            {
                var mt = moduleTranslations.Where(t => t.EntityId == m.Id).ToDictionary(t => t.Field, t => t.Value);
                string MF(string field) => mt.TryGetValue(field, out var v) ? v : string.Empty;

                var lessons = m.Lessons.Select(l =>
                {
                    var lt = lessonTranslations.Where(t => t.EntityId == l.Id).ToDictionary(t => t.Field, t => t.Value);
                    string LF(string field) => lt.TryGetValue(field, out var v) ? v : string.Empty;
                    return new CourseLessonDto(l.Id, LF("Title"), LF("Theory"), LF("Practice"), LF("Assignment"), l.SortOrder);
                }).ToList();

                return new CourseModuleDto(m.Id, MF("Title"), MF("Description"), m.SortOrder, lessons);
            }).ToList();

            var benefits = F("Benefits").Split('|', StringSplitOptions.RemoveEmptyEntries);
            var forWhom = F("ForWhom").Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => { var parts = x.Split("~", 3); return new ForWhomItem(parts.ElementAtOrDefault(0) ?? "", parts.ElementAtOrDefault(1) ?? "", parts.Length > 2 ? NullIfEmpty(parts[2]) : null); })
                .ToArray();

            return new CourseDto(c.Id, c.Slug, c.IsOnline, c.IsOffline, F("Title"), F("Subtitle"), F("Eyebrow"), F("Description"),
                benefits, F("ImageUrl"), F("Duration"), F("Level"), F("Format"), F("Schedule"),
                forWhom, F("CtaHeading"), F("CtaText"), modules,
                NullIfEmpty(F("PresentationImage1Url")), NullIfEmpty(F("PresentationImage2Url")),
                NullIfEmpty(F("InstructorImageUrl")), NullIfEmpty(F("InstructorName")), NullIfEmpty(F("InstructorBio")));
        }

        private static string? NullIfEmpty(string s) => string.IsNullOrWhiteSpace(s) ? null : s;

        private static string ResolveCourseSlug(string slug) => slug.Trim().ToLowerInvariant() switch
        {
            "pranavidya" => "pranayama",
            _ => slug.Trim().ToLowerInvariant()
        };

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

        // GET: api/courses/all (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            return await _context.Courses
                .OrderBy(c => c.SortOrder)
                .Include(c => c.Modules.OrderBy(m => m.SortOrder))
                    .ThenInclude(m => m.Lessons.OrderBy(l => l.SortOrder))
                .ToListAsync();
        }

        /// <summary>
        /// PUT /api/courses/{id} — update a course with modules and lessons (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest();

            var existing = await _context.Courses
                .Include(c => c.Modules)
                    .ThenInclude(m => m.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null) return NotFound();

            // Update course scalar properties
            _context.Entry(existing).CurrentValues.SetValues(course);

            // Sync modules
            var incomingModuleIds = course.Modules.Select(m => m.Id).ToHashSet();
            var removedModules = existing.Modules.Where(m => !incomingModuleIds.Contains(m.Id)).ToList();

            // Delete removed modules and their lesson translations
            if (removedModules.Count > 0)
            {
                var removedModuleIds = removedModules.Select(m => m.Id).ToList();
                var removedLessonIds = removedModules.SelectMany(m => m.Lessons).Select(l => l.Id).ToList();

                var orphanTranslations = await _context.Translations
                    .Where(t =>
                        (t.EntityType == "CourseModule" && removedModuleIds.Contains(t.EntityId)) ||
                        (t.EntityType == "CourseLesson" && removedLessonIds.Contains(t.EntityId)))
                    .ToListAsync();
                _context.Translations.RemoveRange(orphanTranslations);
                _context.CourseLessons.RemoveRange(removedModules.SelectMany(m => m.Lessons));
                _context.CourseModules.RemoveRange(removedModules);
            }

            foreach (var incomingModule in course.Modules)
            {
                var existingModule = existing.Modules.FirstOrDefault(m => m.Id == incomingModule.Id);
                if (existingModule == null)
                {
                    // New module
                    existing.Modules.Add(incomingModule);
                }
                else
                {
                    // Update module scalar properties
                    _context.Entry(existingModule).CurrentValues.SetValues(incomingModule);

                    // Sync lessons within module
                    var incomingLessonIds = incomingModule.Lessons.Select(l => l.Id).ToHashSet();
                    var removedLessons = existingModule.Lessons.Where(l => !incomingLessonIds.Contains(l.Id)).ToList();

                    if (removedLessons.Count > 0)
                    {
                        var removedLessonIds = removedLessons.Select(l => l.Id).ToList();
                        var orphanLessonTranslations = await _context.Translations
                            .Where(t => t.EntityType == "CourseLesson" && removedLessonIds.Contains(t.EntityId))
                            .ToListAsync();
                        _context.Translations.RemoveRange(orphanLessonTranslations);
                        _context.CourseLessons.RemoveRange(removedLessons);
                    }

                    foreach (var incomingLesson in incomingModule.Lessons)
                    {
                        var existingLesson = existingModule.Lessons.FirstOrDefault(l => l.Id == incomingLesson.Id);
                        if (existingLesson == null)
                        {
                            existingModule.Lessons.Add(incomingLesson);
                        }
                        else
                        {
                            _context.Entry(existingLesson).CurrentValues.SetValues(incomingLesson);
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _context.Courses
                .Include(c => c.Modules)
                    .ThenInclude(m => m.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();

            var moduleIds = course.Modules.Select(m => m.Id).ToList();
            var lessonIds = course.Modules.SelectMany(m => m.Lessons).Select(l => l.Id).ToList();

            var translations = await _context.Translations
                .Where(t =>
                    (t.EntityType == "Course" && t.EntityId == id) ||
                    (t.EntityType == "CourseModule" && moduleIds.Contains(t.EntityId)) ||
                    (t.EntityType == "CourseLesson" && lessonIds.Contains(t.EntityId)))
                .ToListAsync();
            _context.Translations.RemoveRange(translations);
            _context.CourseLessons.RemoveRange(course.Modules.SelectMany(m => m.Lessons));
            _context.CourseModules.RemoveRange(course.Modules);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
