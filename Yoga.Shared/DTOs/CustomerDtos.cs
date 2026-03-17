namespace Yoga.Shared.DTOs
{
    // ── Customer ──

    public record CustomerDto(
        Guid Id,
        string Email,
        string FullName,
        string? Phone,
        string? Messenger,
        bool IsActive,
        DateTime CreatedAt,
        DateTime? LastLoginAt,
        CustomerSubscriptionDto? Subscription
    );

    public record CustomerProfileDto(
        string FullName,
        string? Phone,
        string? Messenger
    );

    public record CreateCustomerRequest(
        string Email,
        string Password,
        string FullName,
        string? Phone,
        string? Messenger
    );

    // ── Customer Auth ──

    public record CustomerLoginRequest(string Email, string Password);
    public record CustomerLoginResponse(string Token, string Email, string FullName);
    public record CustomerChangePasswordRequest(string CurrentPassword, string NewPassword);

    // ── Subscription ──

    public record CustomerSubscriptionDto(
        Guid Id,
        string Tier,
        DateTime StartsAt,
        DateTime? EndsAt,
        bool IsActive
    );

    public record CreateSubscriptionRequest(
        Guid CustomerId,
        string Tier, // "Premium" | "Vip"
        DateTime StartsAt,
        DateTime? EndsAt
    );

    // ── Access Grants ──

    public record AccessGrantDto(
        Guid Id,
        Guid CustomerId,
        string CustomerName,
        string AccessType,
        Guid? CourseId,
        Guid? ConsultationId,
        Guid? RetreatId,
        Guid? LiveEventId,
        DateTime StartsAt,
        DateTime? EndsAt,
        string Status,
        Guid? SourceLeadId,
        string? Notes,
        DateTime CreatedAt,
        // Resolved display names & slugs (populated server-side for cabinet)
        string? CourseName = null,
        string? CourseSlug = null,
        string? ConsultationName = null,
        string? ConsultationSlug = null,
        string? RetreatTitle = null,
        string? LiveEventTitle = null
    );

    public record CreateAccessGrantRequest(
        Guid CustomerId,
        string AccessType, // "Course" | "Consultation" | "Retreat" | "LiveEvent" | "LiveEventSeries"
        Guid? CourseId,
        Guid? ConsultationId,
        Guid? RetreatId,
        Guid? LiveEventId,
        DateTime? StartsAt,
        DateTime? EndsAt,
        Guid? SourceLeadId,
        string? Notes
    );

    // ── Premium Resources ──

    public record PremiumResourceDto(
        Guid Id,
        string Title,
        string? Description,
        string ResourceType,
        string? MediaUrl,
        TimeSpan? Duration,
        string? MinimumTier,
        string? Category,
        int SortOrder,
        bool IsActive
    );

    public record CreatePremiumResourceRequest(
        string Title,
        string? Description,
        string ResourceType,
        string? MediaUrl,
        TimeSpan? Duration,
        string? MinimumTier,
        string? Category,
        int SortOrder
    );

    // ── Live Events ──

    public record LiveEventDto(
        Guid Id,
        string Title,
        string? Description,
        DateTime StartsAt,
        DateTime? EndsAt,
        string Status,
        string AccessPolicy,
        Guid? SeriesId,
        bool IsPublished,
        bool HasRecording,
        DateTime CreatedAt
    );

    public record LiveEventDetailDto(
        Guid Id,
        string Title,
        string? Description,
        DateTime StartsAt,
        DateTime? EndsAt,
        string Status,
        string? JoinUrl,        // Only included when customer has access
        string? RecordingUrl,   // Only included when customer has access and event ended
        string AccessPolicy,
        Guid? SeriesId,
        bool IsPublished
    );

    public record CreateLiveEventRequest(
        string Title,
        string? Description,
        DateTime StartsAt,
        DateTime? EndsAt,
        string? JoinUrl,
        string AccessPolicy,
        Guid? SeriesId
    );

    public record UpdateLiveEventRequest(
        string Title,
        string? Description,
        DateTime StartsAt,
        DateTime? EndsAt,
        string? JoinUrl,
        string? RecordingUrl,
        string Status,
        string AccessPolicy,
        Guid? SeriesId,
        bool IsPublished
    );

    // ── Cabinet aggregates ──

    public record MyDashboardDto(
        CustomerProfileDto Profile,
        List<AccessGrantDto> ActiveGrants,
        CustomerSubscriptionDto? Subscription,
        List<LiveEventDto> UpcomingEvents,
        int TotalLeads
    );

    // ── Lead extension ──

    public record CreateCustomerFromLeadRequest(
        Guid LeadId,
        string Email,
        string Password,
        string FullName,
        string? Phone,
        string? Messenger
    );

    public record GrantAccessFromLeadRequest(
        Guid LeadId,
        Guid CustomerId,
        string AccessType,
        Guid? CourseId,
        Guid? ConsultationId,
        Guid? RetreatId,
        Guid? LiveEventId,
        DateTime? EndsAt,
        string? Notes
    );
}
