using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.DTOs
{
    // Dashboard
    public record DashboardDto(
        int TotalRetreats,
        int ActiveRetreats,
        int TotalCourses,
        int TotalConsultations,
        int TotalBlogPosts,
        int TotalLeads,
        int UnprocessedLeads,
        List<LeadSummaryDto> RecentLeads,
        List<ActivityDayDto> Activity
    );

    public record LeadSummaryDto(
        Guid Id,
        string Name,
        string ContactDetails,
        string? Messager,
        string? Comment,
        DateTime CreatedAt,
        bool IsProcessed,
        string Status,
        string? TargetFormat,
        string? AdminNotes,
        Guid? CourseId,
        Guid? ConsultationId,
        Guid? RetreatId,
        string? CourseSlug,
        string? ConsultationSlug,
        string? RetreatTitle
    );

    public record ActivityDayDto(DateTime Date, int Count);

    public record PublicContentResetPreviewDto(
        int Courses,
        int CourseModules,
        int Consultations,
        int Retreats,
        int BlogPosts,
        int SitePageTranslations,
        int EntityTranslations,
        int MediaFiles
    );

    public record PublicContentResetResultDto(
        int Courses,
        int CourseModules,
        int Consultations,
        int Retreats,
        int BlogPosts,
        int SitePageTranslations,
        int EntityTranslations,
        int MediaFiles,
        DateTime ExecutedAt
    );

    // Admin user management
    public record AdminUserDto(
        Guid Id,
        string Username,
        string? DisplayName,
        string? Email,
        DateTime CreatedAt,
        DateTime? LastLoginAt
    );

    public record CreateAdminUserRequest(
        [Required, StringLength(100, MinimumLength = 3)] string Username,
        [Required, StringLength(128, MinimumLength = 8)] string Password,
        [StringLength(200)] string? DisplayName,
        [EmailAddress, StringLength(255)] string? Email
    );

    public record ChangePasswordRequest(
        [Required, StringLength(128)] string CurrentPassword,
        [Required, StringLength(128, MinimumLength = 8)] string NewPassword
    );

    // Paginated response
    public record PaginatedResult<T>(List<T> Items, int TotalCount, int Page, int PageSize);
}
