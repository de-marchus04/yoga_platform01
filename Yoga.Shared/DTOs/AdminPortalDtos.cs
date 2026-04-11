namespace Yoga.Shared.DTOs;

public record AdminLoginRequest(string Login, string Password);

public record AdminLoginResponse(string Token, DateTime ExpiresAt);

public record AdminCurrentUserDto(Guid Id, string Login);

public record AdminSectionMetricDto(
	string Key,
	string Label,
	int Total,
	int Active,
	int Drafts = 0
);

public record AdminDashboardDto(
	AdminCurrentUserDto CurrentUser,
	IReadOnlyList<AdminSectionMetricDto> Sections,
	int SitePagesCount,
	int LeadsCount,
	int TranslationEntriesCount,
	int UiTranslationEntriesCount,
	string AnalyticsProvider,
	bool AnalyticsConfigured,
	string? AnalyticsDashboardUrl,
	bool CanBootstrapSampleContent = false
);

public record AdminCatalogItemDto(
	Guid Id,
	string Slug,
	string Title,
	bool IsActive,
	int SortOrder,
	string? Meta = null
);

public record AdminCatalogSectionDto(
	string Key,
	string Label,
	IReadOnlyList<AdminCatalogItemDto> Items,
	bool CanBootstrapSampleContent = false
);

public record AdminContentEditorDto(
	string SectionKey,
	string Label,
	Guid? Id,
	string Slug,
	int SortOrder,
	bool IsActive,
	bool IsDraft,
	bool SupportsFormatFlags,
	bool IsOnline,
	bool IsOffline,
	bool SupportsEventDates,
	DateTime? EventStartDate,
	DateTime? EventEndDate,
	string PublicPath,
	IReadOnlyList<string> Languages,
	IReadOnlyList<ContentField> Fields,
	Dictionary<string, Dictionary<string, string>> Translations
);

public record AdminContentSaveRequestDto(
	string Slug,
	int SortOrder,
	bool IsActive,
	bool IsDraft,
	bool IsOnline,
	bool IsOffline,
	DateTime? EventStartDate,
	DateTime? EventEndDate,
	Dictionary<string, Dictionary<string, string>> Translations
);

public record AdminCourseLessonEditorDto(
	Guid? Id,
	int SortOrder,
	Dictionary<string, Dictionary<string, string>> Translations
);

public record AdminCourseModuleEditorDto(
	Guid? Id,
	int SortOrder,
	Dictionary<string, Dictionary<string, string>> Translations,
	List<AdminCourseLessonEditorDto> Lessons
);

public record AdminCourseEditorDto(
	AdminContentEditorDto Content,
	List<AdminCourseModuleEditorDto> Modules
);

public record AdminCourseLessonSaveRequestDto(
	Guid? Id,
	int SortOrder,
	Dictionary<string, Dictionary<string, string>> Translations
);

public record AdminCourseModuleSaveRequestDto(
	Guid? Id,
	int SortOrder,
	Dictionary<string, Dictionary<string, string>> Translations,
	List<AdminCourseLessonSaveRequestDto> Lessons
);

public record AdminCourseSaveRequestDto(
	AdminContentSaveRequestDto Content,
	List<AdminCourseModuleSaveRequestDto> Modules
);

public record AdminBootstrapResponse(
	bool Created,
	string Message,
	IReadOnlyList<AdminCatalogItemDto> CreatedItems
);

public record AdminLeadDto(
	Guid Id,
	string Name,
	string ContactDetails,
	string? Messager,
	string? Comment,
	DateTime CreatedAt,
	Guid? CourseId,
	Guid? ConsultationId,
	Guid? RetreatId,
	Guid? YagyaId,
	string TargetFormat,
	int Status,
	string? OperatorNote,
	string? SubjectTitle
);

public record AdminLeadUpdateRequest(
	int Status,
	string? OperatorNote
);

public record AdminLeadsListDto(
	IReadOnlyList<AdminLeadDto> Items,
	int TotalCount
);

public record AdminMediaFileDto(
	Guid Id,
	string FileName,
	string ContentType,
	long Size,
	DateTime UploadedAt,
	string? AltText,
	string Url
);

public record AdminMediaListDto(
	IReadOnlyList<AdminMediaFileDto> Items,
	int TotalCount
);

public record AdminMediaAltUpdateRequest(string? AltText);

public record AdminTranslationCoverageDto(
	string Language,
	int TotalFields,
	int FilledFields
);

public record AdminTranslationEntityRowDto(
	Guid Id,
	string EntityType,
	string Slug,
	string DefaultTitle,
	IReadOnlyList<AdminTranslationCoverageDto> Coverage
);

public record AdminTranslationWorkspaceDto(
	IReadOnlyList<AdminTranslationEntityRowDto> Entities,
	IReadOnlyList<string> Languages,
	int TotalEntities
);

public record AdminUiTranslationRowDto(
	string Key,
	Dictionary<string, string> Values
);

public record AdminUiTranslationSaveRequest(
	Dictionary<string, Dictionary<string, string>> Rows
);
