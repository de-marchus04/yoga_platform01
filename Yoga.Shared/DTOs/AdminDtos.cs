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
        string Username,
        string Password,
        string? DisplayName,
        string? Email
    );

    public record ChangePasswordRequest(string CurrentPassword, string NewPassword);

    // Paginated response
    public record PaginatedResult<T>(List<T> Items, int TotalCount, int Page, int PageSize);
}
