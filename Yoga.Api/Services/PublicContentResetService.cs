using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Services
{
    public class PublicContentResetService
    {
        private static readonly string[] PublicSitePageSlugs = ["home", "about", "contacts", "courses", "consultations", "blog", "retreats", "yagyas"];

        private readonly AppDbContext _context;
        private readonly IFileStorageService _storageService;
        private readonly IAuditTrailService _auditTrailService;
        private readonly ILogger<PublicContentResetService> _logger;

        public PublicContentResetService(
            AppDbContext context,
            IFileStorageService storageService,
            IAuditTrailService auditTrailService,
            ILogger<PublicContentResetService> logger)
        {
            _context = context;
            _storageService = storageService;
            _auditTrailService = auditTrailService;
            _logger = logger;
        }

        public async Task<PublicContentResetPreviewDto> PreviewAsync(CancellationToken cancellationToken = default)
        {
            var data = await LoadResetDataAsync(cancellationToken);
            return ToPreviewDto(data);
        }

        public async Task<PublicContentResetResultDto> ResetAsync(
            ClaimsPrincipal user,
            HttpContext httpContext,
            CancellationToken cancellationToken = default)
        {
            var data = await LoadResetDataAsync(cancellationToken);

            foreach (var mediaFile in data.MediaFiles)
            {
                try
                {
                    await _storageService.DeleteAsync(mediaFile.Url, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to delete media file {MediaFileId} during public content reset", mediaFile.Id);
                }
            }

            _context.MediaFiles.RemoveRange(data.MediaFiles);
            _context.Translations.RemoveRange(data.SitePageTranslations);
            _context.Translations.RemoveRange(data.EntityTranslations);
            _context.CourseModules.RemoveRange(data.CourseModules);
            _context.Courses.RemoveRange(data.Courses);
            _context.Consultations.RemoveRange(data.Consultations);
            _context.Retreats.RemoveRange(data.Retreats);
            _context.BlogPosts.RemoveRange(data.BlogPosts);

            var result = new PublicContentResetResultDto(
                data.Courses.Count,
                data.CourseModules.Count,
                data.Consultations.Count,
                data.Retreats.Count,
                data.BlogPosts.Count,
                data.SitePageTranslations.Count,
                data.EntityTranslations.Count,
                data.MediaFiles.Count,
                DateTime.UtcNow);

            _context.AdminAuditLogs.Add(_auditTrailService.CreateEntry(
                user,
                httpContext,
                "PublicContentReset",
                "PublicContent",
                null,
                $"Public content reset executed. Deleted {result.Courses} courses, {result.Consultations} consultations, {result.Retreats} retreats, {result.BlogPosts} blog posts and {result.MediaFiles} media files.",
                result));

            await _context.SaveChangesAsync(cancellationToken);
            return result;
        }

        private static PublicContentResetPreviewDto ToPreviewDto(PublicContentResetData data)
        {
            return new PublicContentResetPreviewDto(
                data.Courses.Count,
                data.CourseModules.Count,
                data.Consultations.Count,
                data.Retreats.Count,
                data.BlogPosts.Count,
                data.SitePageTranslations.Count,
                data.EntityTranslations.Count,
                data.MediaFiles.Count);
        }

        private async Task<PublicContentResetData> LoadResetDataAsync(CancellationToken cancellationToken)
        {
            var publicSitePageIds = await _context.SitePages
                .Where(page => PublicSitePageSlugs.Contains(page.Slug))
                .Select(page => page.Id)
                .ToListAsync(cancellationToken);

            var courses = await _context.Courses
                .Include(course => course.Modules)
                .OrderBy(course => course.SortOrder)
                .ToListAsync(cancellationToken);
            var courseIds = courses.Select(course => course.Id).ToList();
            var courseModules = courses.SelectMany(course => course.Modules).ToList();
            var moduleIds = courseModules.Select(module => module.Id).ToList();

            var consultations = await _context.Consultations
                .OrderBy(item => item.SortOrder)
                .ToListAsync(cancellationToken);
            var consultationIds = consultations.Select(item => item.Id).ToList();

            var retreats = await _context.Retreats.ToListAsync(cancellationToken);
            var retreatIds = retreats.Select(item => item.Id).ToList();

            var blogPosts = await _context.BlogPosts.ToListAsync(cancellationToken);
            var blogPostIds = blogPosts.Select(item => item.Id).ToList();

            var sitePageTranslations = await _context.Translations
                .Where(translation => translation.EntityType == "SitePage" && publicSitePageIds.Contains(translation.EntityId))
                .ToListAsync(cancellationToken);

            var entityTranslations = await _context.Translations
                .Where(translation =>
                    (translation.EntityType == "Course" && courseIds.Contains(translation.EntityId)) ||
                    (translation.EntityType == "CourseModule" && moduleIds.Contains(translation.EntityId)) ||
                    (translation.EntityType == "Consultation" && consultationIds.Contains(translation.EntityId)) ||
                    (translation.EntityType == "Retreat" && retreatIds.Contains(translation.EntityId)) ||
                    (translation.EntityType == "BlogPost" && blogPostIds.Contains(translation.EntityId)))
                .ToListAsync(cancellationToken);

            var mediaFiles = await _context.MediaFiles
                .Where(media =>
                    (media.EntityType == "Course" && courseIds.Contains(media.EntityId)) ||
                    (media.EntityType == "CourseModule" && moduleIds.Contains(media.EntityId)) ||
                    (media.EntityType == "Consultation" && consultationIds.Contains(media.EntityId)) ||
                    (media.EntityType == "Retreat" && retreatIds.Contains(media.EntityId)) ||
                    (media.EntityType == "BlogPost" && blogPostIds.Contains(media.EntityId)) ||
                    (media.EntityType == "SitePage" && publicSitePageIds.Contains(media.EntityId)))
                .ToListAsync(cancellationToken);

            return new PublicContentResetData(
                courses,
                courseModules,
                consultations,
                retreats,
                blogPosts,
                sitePageTranslations,
                entityTranslations,
                mediaFiles);
        }

        private sealed record PublicContentResetData(
            List<Course> Courses,
            List<CourseModule> CourseModules,
            List<Consultation> Consultations,
            List<Retreat> Retreats,
            List<BlogPost> BlogPosts,
            List<Translation> SitePageTranslations,
            List<Translation> EntityTranslations,
            List<MediaFile> MediaFiles);
    }
}