using System.ComponentModel.DataAnnotations;

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
        [Required, EmailAddress, StringLength(255)] string Email,
        [Required, StringLength(128, MinimumLength = 8)] string Password,
        [Required, StringLength(200)] string FullName,
        [StringLength(30)] string? Phone,
        [StringLength(100)] string? Messenger
    );

    // ── Customer Auth ──

    public record CustomerLoginRequest(
        [Required, EmailAddress, StringLength(255)] string Email,
        [Required, StringLength(128)] string Password
    );
    public record CustomerLoginResponse(string Token, string Email, string FullName);
    public record CustomerChangePasswordRequest(
        [Required, StringLength(128)] string CurrentPassword,
        [Required, StringLength(128, MinimumLength = 8)] string NewPassword
    );

    // ── Subscription ──

    public record CustomerSubscriptionDto(
        Guid Id,
        string Tier,
        DateTime StartsAt,
        DateTime? EndsAt,
        bool IsActive
    );

    public record CreateSubscriptionRequest(
        [Required] Guid CustomerId,
        [Required, StringLength(50)] string Tier, // "Premium" | "Vip"
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
        [Required] Guid CustomerId,
        [Required, StringLength(50)] string AccessType, // "Course" | "Consultation" | "Retreat" | "LiveEvent" | "LiveEventSeries"
        Guid? CourseId,
        Guid? ConsultationId,
        Guid? RetreatId,
        Guid? LiveEventId,
        DateTime? StartsAt,
        DateTime? EndsAt,
        Guid? SourceLeadId,
        [StringLength(1000)] string? Notes
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
        bool IsActive,
        bool IsPrivateMedia = true
    );

    public record ProtectedMediaAccessDto(
        string Url,
        DateTimeOffset? ExpiresAt
    );

    public record CreatePremiumResourceRequest(
        [Required, StringLength(300)] string Title,
        [StringLength(2000)] string? Description,
        [Required, StringLength(50)] string ResourceType,
        [StringLength(500)] string? MediaUrl,
        TimeSpan? Duration,
        [StringLength(50)] string? MinimumTier,
        [StringLength(100)] string? Category,
        int SortOrder,
        bool IsPrivateMedia = true
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
        bool IsPublished,
        bool IsRecordingPrivate = true
    );

    public record CreateLiveEventRequest(
        [Required, StringLength(300)] string Title,
        [StringLength(5000)] string? Description,
        DateTime StartsAt,
        DateTime? EndsAt,
        [StringLength(500)] string? JoinUrl,
        [Required, StringLength(50)] string AccessPolicy,
        Guid? SeriesId,
        bool IsRecordingPrivate = true
    );

    public record UpdateLiveEventRequest(
        [Required, StringLength(300)] string Title,
        [StringLength(5000)] string? Description,
        DateTime StartsAt,
        DateTime? EndsAt,
        [StringLength(500)] string? JoinUrl,
        [StringLength(500)] string? RecordingUrl,
        [Required, StringLength(50)] string Status,
        [Required, StringLength(50)] string AccessPolicy,
        Guid? SeriesId,
        bool IsPublished,
        bool IsRecordingPrivate = true
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
        [Required] Guid LeadId,
        [Required, EmailAddress, StringLength(255)] string Email,
        [Required, StringLength(128, MinimumLength = 8)] string Password,
        [Required, StringLength(200)] string FullName,
        [StringLength(30)] string? Phone,
        [StringLength(100)] string? Messenger
    );

    public record GrantAccessFromLeadRequest(
        [Required] Guid LeadId,
        [Required] Guid CustomerId,
        [Required, StringLength(50)] string AccessType,
        Guid? CourseId,
        Guid? ConsultationId,
        Guid? RetreatId,
        Guid? LiveEventId,
        DateTime? EndsAt,
        [StringLength(1000)] string? Notes
    );

    // ── Password Reset ──

    public record ForgotPasswordRequest(
        [Required, EmailAddress, StringLength(255)] string Email
    );

    public record ResetPasswordRequest(
        [Required] string Token,
        [Required, StringLength(128, MinimumLength = 8)] string NewPassword
    );

    // ── Access Check ──

    public record AccessCheckResult(bool HasAccess, Guid? GrantId);
}
