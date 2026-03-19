namespace Yoga.Shared.DTOs
{
    public record CourseModuleDto(
        Guid Id,
        string Title,
        string Description,
        int SortOrder
    );

    public record CourseDto(
        Guid Id,
        string Slug,
        bool IsOnline,
        bool IsOffline,
        string Title,
        string Subtitle,
        string Eyebrow,
        string Description,
        string[] Benefits,
        string ImageUrl,
        string Duration,
        string Level,
        string Format,
        string Schedule,
        ForWhomItem[] ForWhom,
        string CtaHeading,
        string CtaText,
        List<CourseModuleDto> Modules
    );

    public record ConsultationDto(
        Guid Id,
        string Slug,
        bool IsOnline,
        bool IsOffline,
        string Title,
        string Subtitle,
        string Eyebrow,
        string Description,
        string Quote,
        string[] Benefits,
        string ImageUrl,
        string Duration,
        string Format,
        string LanguageOffered,
        string PriceLabel,
        ForWhomItem[] ForWhom,
        string CtaHeading,
        string CtaText
    );

    public record ForWhomItem(string Title, string Text);

    public record BlogPostDto(
        Guid Id,
        string Slug,
        string Category,
        string Title,
        string Excerpt,
        string Tag,
        string? MediaUrl,
        DateTime PublishedAt,
        string[] Sections,
        Guid? RelatedCourseId,
        Guid? RelatedConsultationId,
        Guid? RelatedRetreatId
    );

    public record SitePageDto(
        string Slug,
        Dictionary<string, string> Fields
    );

    public record RetreatDto(
        Guid Id,
        string Title,
        string Description,
        string Location,
        DateTime StartDate,
        DateTime EndDate,
        string? ImageUrl,
        string? PriceLabel,
        string? Program
    );

    public record YagyaDto(
        Guid Id,
        string Title,
        string Description,
        string Location,
        DateTime StartDate,
        DateTime EndDate,
        string? ImageUrl,
        string? PriceLabel,
        string? Program
    );
}
