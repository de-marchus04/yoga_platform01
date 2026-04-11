using System.Text.Json.Serialization;

namespace Yoga.Shared.DTOs
{
    public record CourseLessonDto(
        Guid Id,
        string Title,
        string Theory,
        string Practice,
        string Assignment,
        int SortOrder
    );

    public record CourseModuleDto(
        Guid Id,
        string Title,
        string Description,
        int SortOrder,
        List<CourseLessonDto> Lessons,
        string? ImageUrl = null
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
        List<CourseModuleDto> Modules,
        string? PresentationImage1Url = null,
        string? PresentationImage2Url = null,
        string? InstructorImageUrl = null,
        string? InstructorName = null,
        string? InstructorBio = null
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

    public record ForWhomItem(string Title, string Text, string? ImageUrl = null);

    public record SitePageDto(
        string Slug,
        Dictionary<string, string> Fields
    );

    public record RetreatSubcategoryDto(
        Guid Id,
        string Slug,
        string Title,
        string Description,
        string ImageUrl,
        int SortOrder
    );

    public record RetreatDto(
        Guid Id,
        string Slug,
        string Title,
        string Subtitle,
        string Eyebrow,
        string Description,
        string[] Benefits,
        string ImageUrl,
        string Duration,
        string Location,
        string Format,
        string PriceLabel,
        ForWhomItem[] ForWhom,
        string CtaHeading,
        string CtaText,
        List<RetreatSubcategoryDto> Subcategories,
        [property: JsonPropertyName("eventStartDate")] DateTime? EventStartDate,
        [property: JsonPropertyName("eventEndDate")] DateTime? EventEndDate
    );

    public record YagyaSubcategoryDto(
        Guid Id,
        string Slug,
        string Title,
        string Description,
        string ImageUrl,
        int SortOrder
    );

    public record YagyaDto(
        Guid Id,
        string Slug,
        string Title,
        string Subtitle,
        string Eyebrow,
        string Description,
        string[] Benefits,
        string ImageUrl,
        string Duration,
        string Format,
        string PriceLabel,
        ForWhomItem[] ForWhom,
        string CtaHeading,
        string CtaText,
        List<YagyaSubcategoryDto> Subcategories,
        [property: JsonPropertyName("eventStartDate")] DateTime? EventStartDate,
        [property: JsonPropertyName("eventEndDate")] DateTime? EventEndDate
    );
}
