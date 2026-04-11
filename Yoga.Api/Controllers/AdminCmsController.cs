using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Options;
using Microsoft.Extensions.Options;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/admin/cms")]
public class AdminCmsController : ControllerBase
{
    private static readonly IReadOnlyList<string> EditorLanguages = new[] { "uk", "ru", "en" };
    private static readonly IReadOnlyList<ContentField> CourseEditorFields = new[]
    {
        new ContentField("Title", "Title", ContentFieldType.Text, "Hero"),
        new ContentField("Subtitle", "Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("Eyebrow", "Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("Description", "Description", ContentFieldType.TextArea, "Hero"),
        new ContentField("Benefits", "Benefits", ContentFieldType.TextArea, "Details", "One item per line."),
        new ContentField("Duration", "Duration", ContentFieldType.Text, "Details"),
        new ContentField("Level", "Level", ContentFieldType.Text, "Details"),
        new ContentField("Format", "Format", ContentFieldType.Text, "Details"),
        new ContentField("Schedule", "Schedule", ContentFieldType.Text, "Details"),
        new ContentField("ForWhom", "For Whom", ContentFieldType.ForWhom, "Audience", "One item per line: title~text~imageUrl"),
        new ContentField("CtaHeading", "CTA Heading", ContentFieldType.Text, "CTA"),
        new ContentField("CtaText", "CTA Text", ContentFieldType.TextArea, "CTA"),
        new ContentField("ImageUrl", "Hero Image URL", ContentFieldType.Image, "Media"),
        new ContentField("PresentationImage1Url", "Presentation Image 1", ContentFieldType.Image, "Media"),
        new ContentField("PresentationImage2Url", "Presentation Image 2", ContentFieldType.Image, "Media"),
        new ContentField("InstructorName", "Instructor Name", ContentFieldType.Text, "Instructor"),
        new ContentField("InstructorBio", "Instructor Bio", ContentFieldType.TextArea, "Instructor"),
        new ContentField("InstructorImageUrl", "Instructor Image URL", ContentFieldType.Image, "Instructor")
    };
    private static readonly IReadOnlyList<ContentField> ConsultationEditorFields = new[]
    {
        new ContentField("Title", "Title", ContentFieldType.Text, "Hero"),
        new ContentField("Subtitle", "Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("Eyebrow", "Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("Description", "Description", ContentFieldType.TextArea, "Hero"),
        new ContentField("Quote", "Quote", ContentFieldType.TextArea, "Hero"),
        new ContentField("Benefits", "Benefits", ContentFieldType.TextArea, "Details", "One item per line."),
        new ContentField("Duration", "Duration", ContentFieldType.Text, "Details"),
        new ContentField("Format", "Format", ContentFieldType.Text, "Details"),
        new ContentField("LanguageOffered", "Languages Offered", ContentFieldType.Text, "Details"),
        new ContentField("ForWhom", "For Whom", ContentFieldType.ForWhom, "Audience", "One item per line: title~text~imageUrl"),
        new ContentField("CtaHeading", "CTA Heading", ContentFieldType.Text, "CTA"),
        new ContentField("CtaText", "CTA Text", ContentFieldType.TextArea, "CTA"),
        new ContentField("ImageUrl", "Hero Image URL", ContentFieldType.Image, "Media")
    };
    private static readonly IReadOnlyList<ContentField> CourseModuleEditorFields = new[]
    {
        new ContentField("Title", "Module Title", ContentFieldType.Text),
        new ContentField("Description", "Module Description", ContentFieldType.TextArea),
        new ContentField("ImageUrl", "Module Image URL", ContentFieldType.Image)
    };
    private static readonly IReadOnlyList<ContentField> CourseLessonEditorFields = new[]
    {
        new ContentField("Title", "Lesson Title", ContentFieldType.Text),
        new ContentField("Theory", "Theory", ContentFieldType.TextArea),
        new ContentField("Practice", "Practice", ContentFieldType.TextArea),
        new ContentField("Assignment", "Assignment", ContentFieldType.TextArea)
    };
    private static readonly IReadOnlyList<ContentField> RetreatEditorFields = new[]
    {
        new ContentField("Title", "Title", ContentFieldType.Text, "Hero"),
        new ContentField("Subtitle", "Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("Eyebrow", "Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("Description", "Description", ContentFieldType.TextArea, "Hero"),
        new ContentField("Benefits", "Benefits", ContentFieldType.TextArea, "Details", "One item per line."),
        new ContentField("Duration", "Duration", ContentFieldType.Text, "Details"),
        new ContentField("Location", "Location", ContentFieldType.Text, "Details"),
        new ContentField("Format", "Format", ContentFieldType.Text, "Details"),
        new ContentField("ForWhom", "For Whom", ContentFieldType.ForWhom, "Audience", "One item per line: title~text~imageUrl"),
        new ContentField("CtaHeading", "CTA Heading", ContentFieldType.Text, "CTA"),
        new ContentField("CtaText", "CTA Text", ContentFieldType.TextArea, "CTA"),
        new ContentField("ImageUrl", "Hero Image URL", ContentFieldType.Image, "Media")
    };
    private static readonly IReadOnlyList<ContentField> YagyaEditorFields = new[]
    {
        new ContentField("Title", "Title", ContentFieldType.Text, "Hero"),
        new ContentField("Subtitle", "Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("Eyebrow", "Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("Description", "Description", ContentFieldType.TextArea, "Hero"),
        new ContentField("Benefits", "Benefits", ContentFieldType.TextArea, "Details", "One item per line."),
        new ContentField("Duration", "Duration", ContentFieldType.Text, "Details"),
        new ContentField("Format", "Format", ContentFieldType.Text, "Details"),
        new ContentField("ForWhom", "For Whom", ContentFieldType.ForWhom, "Audience", "One item per line: title~text~imageUrl"),
        new ContentField("CtaHeading", "CTA Heading", ContentFieldType.Text, "CTA"),
        new ContentField("CtaText", "CTA Text", ContentFieldType.TextArea, "CTA"),
        new ContentField("ImageUrl", "Hero Image URL", ContentFieldType.Image, "Media")
    };
    private static readonly IReadOnlyList<ContentField> HomePageFields = new[]
    {
        new ContentField("MetaTitle", "Meta Title", ContentFieldType.Text, "SEO"),
        new ContentField("MetaDescription", "Meta Description", ContentFieldType.TextArea, "SEO"),
        new ContentField("HeroEyebrow", "Hero Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("HeroTitle", "Hero Title", ContentFieldType.Text, "Hero"),
        new ContentField("HeroSubtitle", "Hero Subtitle", ContentFieldType.Text, "Hero"),
        new ContentField("HeroText", "Hero Text", ContentFieldType.TextArea, "Hero"),
        new ContentField("HeroImage", "Hero Image", ContentFieldType.Image, "Hero"),
        new ContentField("Content", "Rich Content", ContentFieldType.RichText, "Hero"),
        new ContentField("Stats1Value", "Stats 1 Value", ContentFieldType.Text, "Stats"),
        new ContentField("Stats1Label", "Stats 1 Label", ContentFieldType.Text, "Stats"),
        new ContentField("Stats2Value", "Stats 2 Value", ContentFieldType.Text, "Stats"),
        new ContentField("Stats2Label", "Stats 2 Label", ContentFieldType.Text, "Stats"),
        new ContentField("Stats3Value", "Stats 3 Value", ContentFieldType.Text, "Stats"),
        new ContentField("Stats3Label", "Stats 3 Label", ContentFieldType.Text, "Stats"),
        new ContentField("Stats4Value", "Stats 4 Value", ContentFieldType.Text, "Stats"),
        new ContentField("Stats4Label", "Stats 4 Label", ContentFieldType.Text, "Stats"),
        new ContentField("Dir1Title", "Direction 1 Title", ContentFieldType.Text, "Directions"),
        new ContentField("Dir1Text", "Direction 1 Text", ContentFieldType.TextArea, "Directions"),
        new ContentField("Dir1LinkText", "Direction 1 Link Text", ContentFieldType.Text, "Directions"),
        new ContentField("Dir2Title", "Direction 2 Title", ContentFieldType.Text, "Directions"),
        new ContentField("Dir2Text", "Direction 2 Text", ContentFieldType.TextArea, "Directions"),
        new ContentField("Dir2LinkText", "Direction 2 Link Text", ContentFieldType.Text, "Directions"),
        new ContentField("Dir3Title", "Direction 3 Title", ContentFieldType.Text, "Directions"),
        new ContentField("Dir3Text", "Direction 3 Text", ContentFieldType.TextArea, "Directions"),
        new ContentField("Dir3LinkText", "Direction 3 Link Text", ContentFieldType.Text, "Directions"),
        new ContentField("QuoteText", "Quote Text", ContentFieldType.RichText, "Quote"),
        new ContentField("QuoteAuthor", "Quote Author", ContentFieldType.Text, "Quote"),
        new ContentField("Format1Title", "Format 1 Title", ContentFieldType.Text, "Formats"),
        new ContentField("Format1Text", "Format 1 Text", ContentFieldType.TextArea, "Formats"),
        new ContentField("Format1Cta", "Format 1 CTA", ContentFieldType.Text, "Formats"),
        new ContentField("Format2Title", "Format 2 Title", ContentFieldType.Text, "Formats"),
        new ContentField("Format2Text", "Format 2 Text", ContentFieldType.TextArea, "Formats"),
        new ContentField("Format2Cta", "Format 2 CTA", ContentFieldType.Text, "Formats"),
        new ContentField("Review1Quote", "Review 1 Quote", ContentFieldType.TextArea, "Reviews"),
        new ContentField("Review1Author", "Review 1 Author", ContentFieldType.Text, "Reviews"),
        new ContentField("Review1Program", "Review 1 Program", ContentFieldType.Text, "Reviews"),
        new ContentField("Review2Quote", "Review 2 Quote", ContentFieldType.TextArea, "Reviews"),
        new ContentField("Review2Author", "Review 2 Author", ContentFieldType.Text, "Reviews"),
        new ContentField("Review2Program", "Review 2 Program", ContentFieldType.Text, "Reviews"),
        new ContentField("Review3Quote", "Review 3 Quote", ContentFieldType.TextArea, "Reviews"),
        new ContentField("Review3Author", "Review 3 Author", ContentFieldType.Text, "Reviews"),
        new ContentField("Review3Program", "Review 3 Program", ContentFieldType.Text, "Reviews")
    };
    private static readonly IReadOnlyList<ContentField> AboutPageFields = new[]
    {
        new ContentField("MetaTitle", "Meta Title", ContentFieldType.Text, "SEO"),
        new ContentField("HeroImageUrl", "Hero Image", ContentFieldType.Image, "Hero"),
        new ContentField("HeroTitle", "Hero Title", ContentFieldType.Text, "Hero"),
        new ContentField("HeroSubtitle", "Hero Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("Content", "Rich Content", ContentFieldType.RichText, "Hero"),
        new ContentField("Founder1Role", "Founder 1 Role", ContentFieldType.Text, "Founder 1"),
        new ContentField("Founder1Name", "Founder 1 Name", ContentFieldType.Text, "Founder 1"),
        new ContentField("Founder1Text1", "Founder 1 Text 1", ContentFieldType.TextArea, "Founder 1"),
        new ContentField("Founder1Text2", "Founder 1 Text 2", ContentFieldType.TextArea, "Founder 1"),
        new ContentField("Founder1ImageUrl", "Founder 1 Image", ContentFieldType.Image, "Founder 1"),
        new ContentField("Founder2Role", "Founder 2 Role", ContentFieldType.Text, "Founder 2"),
        new ContentField("Founder2Name", "Founder 2 Name", ContentFieldType.Text, "Founder 2"),
        new ContentField("Founder2Text1", "Founder 2 Text 1", ContentFieldType.TextArea, "Founder 2"),
        new ContentField("Founder2Text2", "Founder 2 Text 2", ContentFieldType.TextArea, "Founder 2"),
        new ContentField("Founder2ImageUrl", "Founder 2 Image", ContentFieldType.Image, "Founder 2"),
        new ContentField("Founder3Role", "Founder 3 Role", ContentFieldType.Text, "Founder 3"),
        new ContentField("Founder3Name", "Founder 3 Name", ContentFieldType.Text, "Founder 3"),
        new ContentField("Founder3Text1", "Founder 3 Text 1", ContentFieldType.TextArea, "Founder 3"),
        new ContentField("Founder3Text2", "Founder 3 Text 2", ContentFieldType.TextArea, "Founder 3"),
        new ContentField("Founder3ImageUrl", "Founder 3 Image", ContentFieldType.Image, "Founder 3"),
        new ContentField("Phil1Title", "Philosophy 1 Title", ContentFieldType.Text, "Philosophy"),
        new ContentField("Phil1Text", "Philosophy 1 Text", ContentFieldType.TextArea, "Philosophy"),
        new ContentField("Phil2Title", "Philosophy 2 Title", ContentFieldType.Text, "Philosophy"),
        new ContentField("Phil2Text", "Philosophy 2 Text", ContentFieldType.TextArea, "Philosophy"),
        new ContentField("Phil3Title", "Philosophy 3 Title", ContentFieldType.Text, "Philosophy"),
        new ContentField("Phil3Text", "Philosophy 3 Text", ContentFieldType.TextArea, "Philosophy")
    };
    private static readonly IReadOnlyList<ContentField> ContactsPageFields = new[]
    {
        new ContentField("MetaTitle", "Meta Title", ContentFieldType.Text, "SEO"),
        new ContentField("HeroImageUrl", "Hero Image", ContentFieldType.Image, "Hero"),
        new ContentField("HeroTitle", "Hero Title", ContentFieldType.Text, "Hero"),
        new ContentField("HeroSubtitle", "Hero Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("Content", "Rich Content", ContentFieldType.RichText, "Hero"),
        new ContentField("TelegramDesc", "Telegram Description", ContentFieldType.TextArea, "Channels"),
        new ContentField("TelegramUrl", "Telegram URL", ContentFieldType.Text, "Channels"),
        new ContentField("TelegramHandle", "Telegram Handle", ContentFieldType.Text, "Channels"),
        new ContentField("WhatsAppDesc", "WhatsApp Description", ContentFieldType.TextArea, "Channels"),
        new ContentField("WhatsAppUrl", "WhatsApp URL", ContentFieldType.Text, "Channels"),
        new ContentField("WhatsAppPhone", "WhatsApp Phone", ContentFieldType.Text, "Channels"),
        new ContentField("InstagramDesc", "Instagram Description", ContentFieldType.TextArea, "Channels"),
        new ContentField("InstagramUrl", "Instagram URL", ContentFieldType.Text, "Channels"),
        new ContentField("InstagramHandle", "Instagram Handle", ContentFieldType.Text, "Channels"),
        new ContentField("YouTubeUrl", "YouTube URL", ContentFieldType.Text, "Channels")
    };
    private static readonly IReadOnlyList<ContentField> CoursePageFields = new[]
    {
        new ContentField("Eyebrow", "Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("H1", "H1", ContentFieldType.Text, "Hero"),
        new ContentField("Intro", "Intro", ContentFieldType.TextArea, "Hero"),
        new ContentField("CardCta", "Card CTA", ContentFieldType.Text, "Catalog")
    };
    private static readonly IReadOnlyList<ContentField> ConsultationPageFields = new[]
    {
        new ContentField("Eyebrow", "Eyebrow", ContentFieldType.Text, "Hero"),
        new ContentField("H1", "H1", ContentFieldType.Text, "Hero"),
        new ContentField("Intro", "Intro", ContentFieldType.TextArea, "Hero")
    };
    private static readonly IReadOnlyList<ContentField> SectionPageFields = new[]
    {
        new ContentField("MetaTitle", "Meta Title", ContentFieldType.Text, "SEO"),
        new ContentField("HeroTitle", "Hero Title", ContentFieldType.Text, "Hero"),
        new ContentField("HeroSubtitle", "Hero Subtitle", ContentFieldType.TextArea, "Hero"),
        new ContentField("HeroImageUrl", "Hero Image", ContentFieldType.Image, "Hero"),
        new ContentField("Content", "Rich Content", ContentFieldType.RichText, "Hero")
    };

    private readonly AppDbContext _db;
    private readonly IConfiguration _config;
    private readonly AdminCmsOptions _options;

    public AdminCmsController(AppDbContext db, IConfiguration config, IOptions<AdminCmsOptions> options)
    {
        _db = db;
        _config = config;
        _options = options.Value;
    }

    [HttpGet("dashboard")]
    public async Task<ActionResult<AdminDashboardDto>> GetDashboard()
    {
        var currentUser = await GetCurrentUserDtoAsync();
        if (currentUser is null)
        {
            return Unauthorized();
        }

        var sections = new List<AdminSectionMetricDto>
        {
            new("courses", "Courses", await _db.Courses.CountAsync(), await _db.Courses.CountAsync(x => x.IsActive)),
            new("consultations", "Consultations", await _db.Consultations.CountAsync(), await _db.Consultations.CountAsync(x => x.IsActive)),
            new("retreats", "Retreats", await _db.Retreats.CountAsync(), await _db.Retreats.CountAsync(x => x.IsActive)),
            new("yagyas", "Yagyas", await _db.Yagyas.CountAsync(), await _db.Yagyas.CountAsync(x => x.IsActive))
        };

        var analyticsProvider = _config["Analytics:Provider"] ?? string.Empty;
        var analyticsDashboardUrl = _config["Analytics:DashboardUrl"];

        return Ok(new AdminDashboardDto(
            currentUser,
            sections,
            await _db.SitePages.CountAsync(),
            await _db.Leads.CountAsync(),
            await _db.Translations.CountAsync(),
            await _db.UiTranslations.CountAsync(),
            analyticsProvider,
            !string.IsNullOrWhiteSpace(analyticsProvider),
            string.IsNullOrWhiteSpace(analyticsDashboardUrl) ? null : analyticsDashboardUrl,
            _options.EnableSampleContentBootstrap));
    }

    [HttpGet("catalog/{section}")]
    public async Task<ActionResult<AdminCatalogSectionDto>> GetCatalog(string section, [FromQuery] string lang = "uk")
    {
        lang = NormalizeLanguage(lang);

        return section.Trim().ToLowerInvariant() switch
        {
            "courses" => Ok(await BuildCoursesCatalogAsync(lang)),
            "consultations" => Ok(await BuildConsultationsCatalogAsync(lang)),
            "retreats" => Ok(await BuildRetreatsCatalogAsync(lang)),
            "yagyas" => Ok(await BuildYagyasCatalogAsync(lang)),
            "pages" => Ok(await BuildPagesCatalogAsync(lang)),
            _ => NotFound()
        };
    }

    [HttpGet("editor/{section}/new")]
    public ActionResult<AdminContentEditorDto> GetNewEditor(string section)
    {
        return CreateEmptyEditor(section) is { } editor
            ? Ok(editor)
            : NotFound();
    }

    [HttpGet("course-editor/new")]
    public ActionResult<AdminCourseEditorDto> GetNewCourseEditor()
    {
        return CreateEmptyEditor("courses") is { } editor
            ? Ok(new AdminCourseEditorDto(editor, new List<AdminCourseModuleEditorDto>()))
            : NotFound();
    }

    [HttpGet("course-editor/{slug}")]
    public async Task<ActionResult<AdminCourseEditorDto>> GetCourseComposer(string slug)
    {
        return await GetCourseComposerAsync(slug) is { } editor
            ? Ok(editor)
            : NotFound();
    }

    [HttpGet("editor/{section}/{slug}")]
    public async Task<ActionResult<AdminContentEditorDto>> GetEditor(string section, string slug)
    {
        return section.Trim().ToLowerInvariant() switch
        {
            "courses" => await GetCourseEditorAsync(slug) is { } courseEditor ? Ok(courseEditor) : NotFound(),
            "consultations" => await GetConsultationEditorAsync(slug) is { } consultationEditor ? Ok(consultationEditor) : NotFound(),
            "retreats" => await GetRetreatEditorAsync(slug) is { } retreatEditor ? Ok(retreatEditor) : NotFound(),
            "yagyas" => await GetYagyaEditorAsync(slug) is { } yagyaEditor ? Ok(yagyaEditor) : NotFound(),
            "pages" => await GetSitePageEditorAsync(slug) is { } pageEditor ? Ok(pageEditor) : NotFound(),
            _ => NotFound()
        };
    }

    [HttpGet("preview/{section}/{slug}")]
    public async Task<ActionResult<AdminContentEditorDto>> GetPreview(string section, string slug)
    {
        // Same as GetEditor but bypasses IsActive/IsDraft filters — admins only
        return section.Trim().ToLowerInvariant() switch
        {
            "courses" => await GetCourseEditorAsync(slug) is { } courseEditor ? Ok(courseEditor) : NotFound(),
            "consultations" => await GetConsultationEditorAsync(slug) is { } consultationEditor ? Ok(consultationEditor) : NotFound(),
            "retreats" => await GetRetreatEditorAsync(slug) is { } retreatEditor ? Ok(retreatEditor) : NotFound(),
            "yagyas" => await GetYagyaEditorAsync(slug) is { } yagyaEditor ? Ok(yagyaEditor) : NotFound(),
            "pages" => await GetSitePageEditorAsync(slug) is { } pageEditor ? Ok(pageEditor) : NotFound(),
            _ => NotFound()
        };
    }

    [HttpPost("editor/{section}")]
    public async Task<ActionResult<AdminContentEditorDto>> CreateEditorContent(string section, [FromBody] AdminContentSaveRequestDto request)
    {
        return section.Trim().ToLowerInvariant() switch
        {
            "courses" => await SaveCourseAsync(null, request),
            "consultations" => await SaveConsultationAsync(null, request),
            "retreats" => await SaveRetreatAsync(null, request),
            "yagyas" => await SaveYagyaAsync(null, request),
            "pages" => await SaveSitePageAsync(null, request),
            _ => NotFound()
        };
    }

    [HttpPost("course-editor")]
    public async Task<ActionResult<AdminCourseEditorDto>> CreateCourseComposer([FromBody] AdminCourseSaveRequestDto request)
    {
        return await SaveCourseComposerAsync(null, request);
    }

    [HttpPut("editor/{section}/{id:guid}")]
    public async Task<ActionResult<AdminContentEditorDto>> UpdateEditorContent(string section, Guid id, [FromBody] AdminContentSaveRequestDto request)
    {
        return section.Trim().ToLowerInvariant() switch
        {
            "courses" => await SaveCourseAsync(id, request),
            "consultations" => await SaveConsultationAsync(id, request),
            "retreats" => await SaveRetreatAsync(id, request),
            "yagyas" => await SaveYagyaAsync(id, request),
            "pages" => await SaveSitePageAsync(id, request),
            _ => NotFound()
        };
    }

    [HttpPut("course-editor/{id:guid}")]
    public async Task<ActionResult<AdminCourseEditorDto>> UpdateCourseComposer(Guid id, [FromBody] AdminCourseSaveRequestDto request)
    {
        return await SaveCourseComposerAsync(id, request);
    }

    [HttpPost("bootstrap-test-content")]
    public async Task<ActionResult<AdminBootstrapResponse>> BootstrapTestContent()
    {
        if (!_options.EnableSampleContentBootstrap)
        {
            return Forbid();
        }

        var createdItems = new List<AdminCatalogItemDto>();
        var now = DateTime.UtcNow.Date;

        if (!await _db.Courses.AnyAsync(x => x.Slug == "sacred-breath"))
        {
            var course = new Course
            {
                Slug = "sacred-breath",
                SortOrder = 10,
                IsActive = true,
                IsOnline = true,
                IsOffline = false
            };

            var module = new CourseModule
            {
                CourseId = course.Id,
                SortOrder = 10
            };

            var lesson = new CourseLesson
            {
                CourseModuleId = module.Id,
                SortOrder = 10
            };

            module.Lessons.Add(lesson);
            course.Modules.Add(module);

            _db.Courses.Add(course);

            AddTri("Course", course.Id, "Title", "Курс осознанного дыхания", "Sacred Breath Course", "Курс усвідомленого дихання");
            AddTri("Course", course.Id, "Subtitle", "Мягкая программа для устойчивой личной практики.", "A grounded program for a steady personal practice.", "М'яка програма для стійкої особистої практики.");
            AddTri("Course", course.Id, "Eyebrow", "Курс", "Course", "Курс");
            AddTri("Course", course.Id, "Description", "Этот тестовый курс показывает, как будет выглядеть заполненная страница через новую админку. Здесь можно редактировать структуру, тексты, медиа и CTA без правок в коде.", "This test course shows how a fully populated page will look through the new admin panel. Structure, copy, media, and CTA can be edited without code changes.", "Цей тестовий курс показує, як виглядатиме заповнена сторінка через нову адмінку. Тут можна редагувати структуру, тексти, медіа та CTA без змін у коді.");
            AddTri("Course", course.Id, "Benefits", "Ясная структура обучения|Живой ритм практики|Опора для самостоятельной дисциплины", "Clear learning structure|A living practice rhythm|Support for independent discipline", "Зрозуміла структура навчання|Живий ритм практики|Опора для самостійної дисципліни");
            AddTri("Course", course.Id, "ImageUrl", "https://images.unsplash.com/photo-1506126613408-eca07ce68773?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1506126613408-eca07ce68773?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1506126613408-eca07ce68773?auto=format&fit=crop&w=1600&q=80");
            AddTri("Course", course.Id, "Duration", "6 недель", "6 weeks", "6 тижнів");
            AddTri("Course", course.Id, "Level", "Базовый", "Foundational", "Базовий");
            AddTri("Course", course.Id, "Format", "Онлайн + записи", "Online + recordings", "Онлайн + записи");
            AddTri("Course", course.Id, "Schedule", "6 встреч", "6 sessions", "6 зустрічей");
            AddTri("Course", course.Id, "ForWhom", "Для новичков~Нужен мягкий и понятный вход в практику|Для продолжающих~Нужна новая структура и регулярность", "For beginners~You need a gentle and clear entry into practice|For returning students~You need a new structure and regular rhythm", "Для новачків~Потрібен м'який та зрозумілий вхід у практику|Для тих, хто продовжує~Потрібна нова структура та регулярність");
            AddTri("Course", course.Id, "CtaHeading", "Открыть программу", "Open the program", "Відкрити програму");
            AddTri("Course", course.Id, "CtaText", "Используйте эту страницу как тестовый шаблон и редактируйте её через админку.", "Use this page as a test template and edit it through the admin panel.", "Використовуйте цю сторінку як тестовий шаблон і редагуйте її через адмінку.");
            AddTri("Course", course.Id, "PresentationImage1Url", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80");
            AddTri("Course", course.Id, "PresentationImage2Url", "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?auto=format&fit=crop&w=1200&q=80");
            AddTri("Course", course.Id, "InstructorName", "Медиша", "Medisha", "Медіша");
            AddTri("Course", course.Id, "InstructorBio", "Проводник практик, который ведёт через ритм, внимание и дыхание.", "A practice guide working through rhythm, attention, and breath.", "Провідниця практик, яка веде через ритм, увагу та дихання.");
            AddTri("Course", course.Id, "InstructorImageUrl", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1494790108377-be9c29b29330?auto=format&fit=crop&w=1200&q=80");

            AddTri("CourseModule", module.Id, "Title", "Основа практики", "Practice Foundation", "Основа практики");
            AddTri("CourseModule", module.Id, "Description", "Блок о ритме дыхания, внимании и личной дисциплине.", "A block about breath rhythm, attention, and personal discipline.", "Блок про ритм дихання, увагу та особисту дисципліну.");
            AddTri("CourseModule", module.Id, "ImageUrl", "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=1200&q=80");

            AddTri("CourseLesson", lesson.Id, "Title", "Дыхание как опора", "Breath as Support", "Дихання як опора");
            AddTri("CourseLesson", lesson.Id, "Theory", "Знакомство с логикой ритма и устойчивости.", "Introduction to rhythm and stability.", "Знайомство з логікою ритму та стійкості.");
            AddTri("CourseLesson", lesson.Id, "Practice", "Короткая ежедневная практика и фиксация состояния.", "Short daily practice and state tracking.", "Коротка щоденна практика та фіксація стану.");
            AddTri("CourseLesson", lesson.Id, "Assignment", "Собрать свой личный ритуал на 10 минут.", "Build a personal 10-minute ritual.", "Зібрати свій особистий 10-хвилинний ритуал.");

            createdItems.Add(new AdminCatalogItemDto(course.Id, course.Slug, "Sacred Breath Course", true, course.SortOrder));
        }

        if (!await _db.Consultations.AnyAsync(x => x.Slug == "clarity-session"))
        {
            var consultation = new Consultation
            {
                Slug = "clarity-session",
                SortOrder = 20,
                IsActive = true,
                IsOnline = true,
                IsOffline = true
            };

            _db.Consultations.Add(consultation);

            AddTri("Consultation", consultation.Id, "Title", "Сессия ясности", "Clarity Session", "Сесія ясності");
            AddTri("Consultation", consultation.Id, "Subtitle", "Личная встреча для настройки направления и следующего шага.", "A private session to clarify direction and the next step.", "Особиста зустріч для налаштування напрямку та наступного кроку.");
            AddTri("Consultation", consultation.Id, "Eyebrow", "Консультация", "Consultation", "Консультація");
            AddTri("Consultation", consultation.Id, "Description", "Тестовая консультация для проверки редактора, CTA и общего визуального ритма страницы.", "A test consultation used to validate the editor, CTA, and the page's visual rhythm.", "Тестова консультація для перевірки редактора, CTA та загального візуального ритму сторінки.");
            AddTri("Consultation", consultation.Id, "Quote", "Ясность начинается там, где заканчивается шум.", "Clarity begins where noise ends.", "Ясність починається там, де закінчується шум.");
            AddTri("Consultation", consultation.Id, "Benefits", "Личное направление|Понимание следующего шага|Фокус на главном", "Personal direction|Clarity on the next step|Focus on what matters", "Особистий напрямок|Розуміння наступного кроку|Фокус на головному");
            AddTri("Consultation", consultation.Id, "ImageUrl", "https://images.unsplash.com/photo-1517841905240-472988babdf9?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1517841905240-472988babdf9?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1517841905240-472988babdf9?auto=format&fit=crop&w=1600&q=80");
            AddTri("Consultation", consultation.Id, "Duration", "60 минут", "60 minutes", "60 хвилин");
            AddTri("Consultation", consultation.Id, "Format", "Онлайн / офлайн", "Online / offline", "Онлайн / офлайн");
            AddTri("Consultation", consultation.Id, "LanguageOffered", "RU / EN / UK", "RU / EN / UK", "RU / EN / UK");
            AddTri("Consultation", consultation.Id, "PriceLabel", "", "", "");
            AddTri("Consultation", consultation.Id, "ForWhom", "Для переходного периода~Когда нужно собрать внутреннюю опору|Для перезапуска~Когда нужно увидеть структуру дальше", "For transition periods~When you need inner grounding|For a reset~When you need to see the next structure", "Для перехідного періоду~Коли потрібно зібрати внутрішню опору|Для перезапуску~Коли потрібно побачити подальшу структуру");
            AddTri("Consultation", consultation.Id, "CtaHeading", "Посмотреть формат работы", "See the format", "Подивитися формат роботи");
            AddTri("Consultation", consultation.Id, "CtaText", "Эту страницу можно наполнить через админку: описание, темы, фото и язык кнопок.", "This page can be filled through the admin panel: description, themes, photos, and button language.", "Цю сторінку можна наповнювати через адмінку: опис, теми, фото та мову кнопок.");

            createdItems.Add(new AdminCatalogItemDto(consultation.Id, consultation.Slug, "Clarity Session", true, consultation.SortOrder));
        }

        if (!await _db.Retreats.AnyAsync(x => x.Slug == "mountain-reset"))
        {
            var retreat = new Retreat
            {
                Slug = "mountain-reset",
                SortOrder = 30,
                IsActive = true,
                EventStartDate = now.AddDays(21),
                EventEndDate = now.AddDays(26)
            };

            var subcategoryA = new RetreatSubcategory
            {
                RetreatId = retreat.Id,
                Slug = "morning-rituals",
                SortOrder = 10,
                IsActive = true
            };

            var subcategoryB = new RetreatSubcategory
            {
                RetreatId = retreat.Id,
                Slug = "silence-walks",
                SortOrder = 20,
                IsActive = true
            };

            retreat.Subcategories.Add(subcategoryA);
            retreat.Subcategories.Add(subcategoryB);
            _db.Retreats.Add(retreat);

            AddTri("Retreat", retreat.Id, "Title", "Горный ретрит перезагрузки", "Mountain Reset Retreat", "Гірський ретрит перезавантаження");
            AddTri("Retreat", retreat.Id, "Subtitle", "Тестовая выездная программа для проверки карточек, дат, секций и медиа.", "A test field program to validate cards, dates, sections, and media.", "Тестова виїзна програма для перевірки карток, дат, секцій та медіа.");
            AddTri("Retreat", retreat.Id, "Eyebrow", "Ретрит", "Retreat", "Ретрит");
            AddTri("Retreat", retreat.Id, "Description", "Эта страница нужна как демонстрация будущего редактора ретритов: описания, блоков, фото, дат и CTA.", "This page is a demo of the future retreat editor: descriptions, blocks, photos, dates, and CTA.", "Ця сторінка потрібна як демонстрація майбутнього редактора ретритів: описів, блоків, фото, дат та CTA.");
            AddTri("Retreat", retreat.Id, "Benefits", "Ритм дня|Практики внимания|Глубокий отдых", "Daily rhythm|Attention practices|Deep rest", "Ритм дня|Практики уваги|Глибокий відпочинок");
            AddTri("Retreat", retreat.Id, "ImageUrl", "https://images.unsplash.com/photo-1500534314209-a25ddb2bd429?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1500534314209-a25ddb2bd429?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1500534314209-a25ddb2bd429?auto=format&fit=crop&w=1600&q=80");
            AddTri("Retreat", retreat.Id, "Duration", "5 дней", "5 days", "5 днів");
            AddTri("Retreat", retreat.Id, "Location", "Карпаты", "Carpathians", "Карпати");
            AddTri("Retreat", retreat.Id, "Format", "Оффлайн", "Offline", "Офлайн");
            AddTri("Retreat", retreat.Id, "PriceLabel", "", "", "");
            AddTri("Retreat", retreat.Id, "ForWhom", "Для перезагрузки~Когда нужен чистый воздух и новый ритм|Для углубления~Когда хочется выйти из суеты и услышать себя", "For a reset~When you need clean air and a new rhythm|For deeper practice~When you want to leave the noise and hear yourself", "Для перезавантаження~Коли потрібні чисте повітря та новий ритм|Для поглиблення~Коли хочеться вийти з метушні та почути себе");
            AddTri("Retreat", retreat.Id, "CtaHeading", "Открыть программу ретрита", "Open the retreat program", "Відкрити програму ретриту");
            AddTri("Retreat", retreat.Id, "CtaText", "Этот тестовый ретрит можно редактировать через админку и использовать как шаблон под реальные программы.", "This test retreat can be edited through the admin panel and used as a template for real programs.", "Цей тестовий ретрит можна редагувати через адмінку та використовувати як шаблон для реальних програм.");

            AddTri("RetreatSubcategory", subcategoryA.Id, "Title", "Утренние ритуалы", "Morning Rituals", "Ранкові ритуали");
            AddTri("RetreatSubcategory", subcategoryA.Id, "Description", "Дыхание, настройка внимания и мягкий вход в день.", "Breath, focus setting, and a gentle entry into the day.", "Дихання, налаштування уваги та м'який вхід у день.");
            AddTri("RetreatSubcategory", subcategoryA.Id, "ImageUrl", "https://images.unsplash.com/photo-1472396961693-142e6e269027?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1472396961693-142e6e269027?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1472396961693-142e6e269027?auto=format&fit=crop&w=1200&q=80");

            AddTri("RetreatSubcategory", subcategoryB.Id, "Title", "Прогулки в тишине", "Silence Walks", "Прогулянки в тиші");
            AddTri("RetreatSubcategory", subcategoryB.Id, "Description", "Пространство для внутренней сборки и спокойного наблюдения.", "Space for inner gathering and calm observation.", "Простір для внутрішнього збирання та спокійного спостереження.");
            AddTri("RetreatSubcategory", subcategoryB.Id, "ImageUrl", "https://images.unsplash.com/photo-1469474968028-56623f02e42e?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1469474968028-56623f02e42e?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1469474968028-56623f02e42e?auto=format&fit=crop&w=1200&q=80");

            createdItems.Add(new AdminCatalogItemDto(retreat.Id, retreat.Slug, "Mountain Reset Retreat", true, retreat.SortOrder));
        }

        if (!await _db.Yagyas.AnyAsync(x => x.Slug == "new-moon-fire"))
        {
            var yagya = new Yagya
            {
                Slug = "new-moon-fire",
                SortOrder = 40,
                IsActive = true,
                EventStartDate = now.AddDays(10),
                EventEndDate = now.AddDays(10)
            };

            var subcategoryA = new YagyaSubcategory
            {
                YagyaId = yagya.Id,
                Slug = "intention-circle",
                SortOrder = 10,
                IsActive = true
            };

            var subcategoryB = new YagyaSubcategory
            {
                YagyaId = yagya.Id,
                Slug = "closing-offering",
                SortOrder = 20,
                IsActive = true
            };

            yagya.Subcategories.Add(subcategoryA);
            yagya.Subcategories.Add(subcategoryB);
            _db.Yagyas.Add(yagya);

            AddTri("Yagya", yagya.Id, "Title", "Огненная ягья новолуния", "New Moon Fire Yagya", "Вогняна яг'я молодика");
            AddTri("Yagya", yagya.Id, "Subtitle", "Тестовая церемония для проверки структуры страницы, подкатегорий и визуального языка.", "A test ceremony to validate page structure, subcategories, and visual language.", "Тестова церемонія для перевірки структури сторінки, підкатегорій та візуальної мови.");
            AddTri("Yagya", yagya.Id, "Eyebrow", "Ягья", "Yagya", "Яг'я");
            AddTri("Yagya", yagya.Id, "Description", "Используйте эту страницу как базовый шаблон для будущих коллективных практик и ритуалов.", "Use this page as a base template for future collective practices and rituals.", "Використовуйте цю сторінку як базовий шаблон для майбутніх колективних практик та ритуалів.");
            AddTri("Yagya", yagya.Id, "Benefits", "Общее намерение|Ритуальный фокус|Пространство присутствия", "Shared intention|Ritual focus|A field of presence", "Спільний намір|Ритуальний фокус|Простір присутності");
            AddTri("Yagya", yagya.Id, "ImageUrl", "https://images.unsplash.com/photo-1508675801627-066ac4346a55?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1508675801627-066ac4346a55?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1508675801627-066ac4346a55?auto=format&fit=crop&w=1600&q=80");
            AddTri("Yagya", yagya.Id, "Duration", "1 вечер", "1 evening", "1 вечір");
            AddTri("Yagya", yagya.Id, "Format", "Оффлайн / трансляция", "Offline / streamed", "Офлайн / трансляція");
            AddTri("Yagya", yagya.Id, "PriceLabel", "", "", "");
            AddTri("Yagya", yagya.Id, "ForWhom", "Для общей практики~Когда важно войти в поле намерения вместе|Для переходов~Когда нужен символический ритуал и сборка внимания", "For shared practice~When it matters to enter a field of intention together|For transitions~When you need symbolic ritual and focused attention", "Для спільної практики~Коли важливо увійти в поле наміру разом|Для переходів~Коли потрібні символічний ритуал і зібрана увага");
            AddTri("Yagya", yagya.Id, "CtaHeading", "Открыть описание ягъи", "Open the yagya outline", "Відкрити опис яг'ї");
            AddTri("Yagya", yagya.Id, "CtaText", "Тестовая ягья покажет, как админка будет собирать короткие события с живым визуальным превью.", "This test yagya shows how the admin panel will compose compact event pages with live visual preview.", "Тестова яг'я покаже, як адмінка буде збирати короткі події з живим візуальним прев'ю.");

            AddTri("YagyaSubcategory", subcategoryA.Id, "Title", "Круг намерения", "Intention Circle", "Коло наміру");
            AddTri("YagyaSubcategory", subcategoryA.Id, "Description", "Формирование общего фокуса перед церемонией.", "Building a shared focus before the ceremony.", "Формування спільного фокусу перед церемонією.");
            AddTri("YagyaSubcategory", subcategoryA.Id, "ImageUrl", "https://images.unsplash.com/photo-1512446733611-9099a758e8a2?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1512446733611-9099a758e8a2?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1512446733611-9099a758e8a2?auto=format&fit=crop&w=1200&q=80");

            AddTri("YagyaSubcategory", subcategoryB.Id, "Title", "Завершающее подношение", "Closing Offering", "Завершальне підношення");
            AddTri("YagyaSubcategory", subcategoryB.Id, "Description", "Финальный жест, который закрепляет прожитое намерение.", "A closing gesture that seals the intention you have lived through.", "Фінальний жест, що закріплює прожитий намір.");
            AddTri("YagyaSubcategory", subcategoryB.Id, "ImageUrl", "https://images.unsplash.com/photo-1504198453319-5ce911bafcde?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1504198453319-5ce911bafcde?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1504198453319-5ce911bafcde?auto=format&fit=crop&w=1200&q=80");

            createdItems.Add(new AdminCatalogItemDto(yagya.Id, yagya.Slug, "New Moon Fire Yagya", true, yagya.SortOrder));
        }

        if (createdItems.Count == 0)
        {
            return Ok(new AdminBootstrapResponse(false, "Test content already exists.", Array.Empty<AdminCatalogItemDto>()));
        }

        await _db.SaveChangesAsync();
        return Ok(new AdminBootstrapResponse(true, "Test content created.", createdItems));
    }

    private async Task<AdminCurrentUserDto?> GetCurrentUserDtoAsync()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var parsedId))
        {
            return null;
        }

        var user = await _db.AdminUsers.FirstOrDefaultAsync(x => x.Id == parsedId);
        if (user is null)
        {
            return null;
        }

        return new AdminCurrentUserDto(user.Id, user.Login);
    }

    private AdminContentEditorDto? CreateEmptyEditor(string section)
    {
        return section.Trim().ToLowerInvariant() switch
        {
            "courses" => BuildEditorDto(
                "courses",
                "Course",
                null,
                string.Empty,
                0,
                true,
                false,
                true,
                true,
                false,
                false,
                null,
                null,
                string.Empty,
                CourseEditorFields,
                CreateEmptyTranslations(CourseEditorFields)),
            "consultations" => BuildEditorDto(
                "consultations",
                "Consultation",
                null,
                string.Empty,
                0,
                true,
                false,
                true,
                true,
                true,
                false,
                null,
                null,
                string.Empty,
                ConsultationEditorFields,
                CreateEmptyTranslations(ConsultationEditorFields)),
            "retreats" => BuildEditorDto(
                "retreats",
                "Retreat",
                null,
                string.Empty,
                0,
                true,
                false,
                false,
                false,
                false,
                true,
                null,
                null,
                string.Empty,
                RetreatEditorFields,
                CreateEmptyTranslations(RetreatEditorFields)),
            "yagyas" => BuildEditorDto(
                "yagyas",
                "Yagya",
                null,
                string.Empty,
                0,
                true,
                false,
                false,
                false,
                false,
                true,
                null,
                null,
                string.Empty,
                YagyaEditorFields,
                CreateEmptyTranslations(YagyaEditorFields)),
            _ => null
        };
    }

    private async Task<AdminContentEditorDto?> GetCourseEditorAsync(string slug)
    {
        var course = await _db.Courses.FirstOrDefaultAsync(x => x.Slug == slug);
        if (course is null)
        {
            return null;
        }

        return await BuildCourseContentEditorAsync(course);
    }

    private async Task<AdminCourseEditorDto?> GetCourseComposerAsync(string slug)
    {
        var course = await _db.Courses
            .Include(x => x.Modules)
            .ThenInclude(module => module.Lessons)
            .FirstOrDefaultAsync(x => x.Slug == slug);

        if (course is null)
        {
            return null;
        }

        var moduleIds = course.Modules.Select(x => x.Id).ToList();
        var lessonIds = course.Modules.SelectMany(x => x.Lessons).Select(x => x.Id).ToList();

        var moduleTranslations = moduleIds.Count == 0
            ? new List<Translation>()
            : await _db.Translations
                .Where(x => x.EntityType == "CourseModule" && moduleIds.Contains(x.EntityId) && EditorLanguages.Contains(x.Language))
                .ToListAsync();

        var lessonTranslations = lessonIds.Count == 0
            ? new List<Translation>()
            : await _db.Translations
                .Where(x => x.EntityType == "CourseLesson" && lessonIds.Contains(x.EntityId) && EditorLanguages.Contains(x.Language))
                .ToListAsync();

        var modules = course.Modules
            .OrderBy(x => x.SortOrder)
            .Select(module => new AdminCourseModuleEditorDto(
                module.Id,
                module.SortOrder,
                BuildTranslationMatrix(CourseModuleEditorFields, moduleTranslations.Where(x => x.EntityId == module.Id)),
                module.Lessons
                    .OrderBy(x => x.SortOrder)
                    .Select(lesson => new AdminCourseLessonEditorDto(
                        lesson.Id,
                        lesson.SortOrder,
                        BuildTranslationMatrix(CourseLessonEditorFields, lessonTranslations.Where(x => x.EntityId == lesson.Id))))
                    .ToList()))
            .ToList();

        return new AdminCourseEditorDto(await BuildCourseContentEditorAsync(course), modules);
    }

    private async Task<AdminContentEditorDto> BuildCourseContentEditorAsync(Course course)
    {

        return BuildEditorDto(
            "courses",
            "Course",
            course.Id,
            course.Slug,
            course.SortOrder,
            course.IsActive,
            course.IsDraft,
            true,
            course.IsOnline,
            course.IsOffline,
            false,
            null,
            null,
            $"/courses/{course.Slug}",
            CourseEditorFields,
            await GetTranslationMatrixAsync("Course", course.Id, CourseEditorFields));
    }

    private async Task<AdminContentEditorDto?> GetConsultationEditorAsync(string slug)
    {
        var consultation = await _db.Consultations.FirstOrDefaultAsync(x => x.Slug == slug);
        if (consultation is null)
        {
            return null;
        }

        return BuildEditorDto(
            "consultations",
            "Consultation",
            consultation.Id,
            consultation.Slug,
            consultation.SortOrder,
            consultation.IsActive,
            consultation.IsDraft,
            true,
            consultation.IsOnline,
            consultation.IsOffline,
            false,
            null,
            null,
            $"/consultations/{consultation.Slug}",
            ConsultationEditorFields,
            await GetTranslationMatrixAsync("Consultation", consultation.Id, ConsultationEditorFields));
    }

    private async Task<AdminContentEditorDto?> GetRetreatEditorAsync(string slug)
    {
        var retreat = await _db.Retreats.FirstOrDefaultAsync(x => x.Slug == slug);
        if (retreat is null)
        {
            return null;
        }

        return BuildEditorDto(
            "retreats",
            "Retreat",
            retreat.Id,
            retreat.Slug,
            retreat.SortOrder,
            retreat.IsActive,
            retreat.IsDraft,
            false,
            false,
            false,
            true,
            retreat.EventStartDate,
            retreat.EventEndDate,
            $"/retreats/{retreat.Slug}",
            RetreatEditorFields,
            await GetTranslationMatrixAsync("Retreat", retreat.Id, RetreatEditorFields));
    }

    private async Task<AdminContentEditorDto?> GetYagyaEditorAsync(string slug)
    {
        var yagya = await _db.Yagyas.FirstOrDefaultAsync(x => x.Slug == slug);
        if (yagya is null)
        {
            return null;
        }

        return BuildEditorDto(
            "yagyas",
            "Yagya",
            yagya.Id,
            yagya.Slug,
            yagya.SortOrder,
            yagya.IsActive,
            yagya.IsDraft,
            false,
            false,
            false,
            true,
            yagya.EventStartDate,
            yagya.EventEndDate,
            $"/yagyas/{yagya.Slug}",
            YagyaEditorFields,
            await GetTranslationMatrixAsync("Yagya", yagya.Id, YagyaEditorFields));
    }

    private async Task<AdminContentEditorDto?> GetSitePageEditorAsync(string slug)
    {
        var page = await _db.SitePages.FirstOrDefaultAsync(x => x.Slug == slug);
        if (page is null)
        {
            return null;
        }

        var fields = GetSitePageFields(page.Slug);

        return BuildEditorDto(
            "pages",
            "Site Page",
            page.Id,
            page.Slug,
            0,
            page.IsActive,
            page.IsDraft,
            false,
            false,
            false,
            false,
            null,
            null,
            page.Slug == "home" ? "/" : $"/{page.Slug}",
            fields,
            await GetTranslationMatrixAsync("SitePage", page.Id, fields));
    }

    private async Task<ActionResult<AdminContentEditorDto>> SaveCourseAsync(Guid? id, AdminContentSaveRequestDto request)
    {
        var (course, error) = await UpsertCourseEntityAsync(id, request);
        if (error is not null)
        {
            return error;
        }

        await _db.SaveChangesAsync();

        return Ok(await GetCourseEditorAsync(course!.Slug));
    }

    private async Task<ActionResult<AdminCourseEditorDto>> SaveCourseComposerAsync(Guid? id, AdminCourseSaveRequestDto request)
    {
        var (course, error) = await UpsertCourseEntityAsync(id, request.Content);
        if (error is not null)
        {
            return error;
        }

        if (id.HasValue)
        {
            await _db.Entry(course!).Collection(x => x.Modules)
                .Query()
                .Include(module => module.Lessons)
                .LoadAsync();
        }

        var syncError = await SyncCourseModulesAsync(course!, request.Modules ?? new List<AdminCourseModuleSaveRequestDto>());
        if (syncError is not null)
        {
            return syncError;
        }

        await _db.SaveChangesAsync();

        return Ok(await GetCourseComposerAsync(course!.Slug));
    }

    private async Task<(Course? Course, ActionResult? Error)> UpsertCourseEntityAsync(Guid? id, AdminContentSaveRequestDto request)
    {
        var slug = NormalizeSlug(request.Slug, "course");
        if (await _db.Courses.AnyAsync(x => x.Slug == slug && (!id.HasValue || x.Id != id.Value)))
        {
            return (null, Conflict("A course with this slug already exists."));
        }

        var course = id.HasValue
            ? await _db.Courses.FirstOrDefaultAsync(x => x.Id == id.Value)
            : null;

        if (id.HasValue && course is null)
        {
            return (null, NotFound());
        }

        course ??= new Course();
        if (!id.HasValue)
        {
            _db.Courses.Add(course);
        }

        course.Slug = slug;
        course.SortOrder = request.SortOrder;
        course.IsActive = request.IsActive;
        course.IsDraft = request.IsDraft;
        course.IsOnline = request.IsOnline;
        course.IsOffline = request.IsOffline;

        await UpsertTranslationsAsync("Course", course.Id, CourseEditorFields, request.Translations);
        return (course, null);
    }

    private async Task<ActionResult?> SyncCourseModulesAsync(Course course, List<AdminCourseModuleSaveRequestDto> requestedModules)
    {
        var existingModules = course.Modules.ToDictionary(module => module.Id);
        var requestedModuleIds = requestedModules
            .Where(module => module.Id.HasValue)
            .Select(module => module.Id!.Value)
            .ToHashSet();

        var modulesToRemove = existingModules.Values
            .Where(module => !requestedModuleIds.Contains(module.Id))
            .ToList();

        foreach (var module in modulesToRemove)
        {
            await RemoveTranslationsAsync("CourseLesson", module.Lessons.Select(lesson => lesson.Id));
            await RemoveTranslationsAsync("CourseModule", new[] { module.Id });
            _db.CourseModules.Remove(module);
        }

        for (var moduleIndex = 0; moduleIndex < requestedModules.Count; moduleIndex++)
        {
            var requestedModule = requestedModules[moduleIndex];
            CourseModule module;

            if (requestedModule.Id.HasValue)
            {
                if (!existingModules.TryGetValue(requestedModule.Id.Value, out module!))
                {
                    return BadRequest("Unknown course module id.");
                }
            }
            else
            {
                module = new CourseModule { CourseId = course.Id };
                _db.CourseModules.Add(module);
                course.Modules.Add(module);
            }

            module.SortOrder = requestedModule.SortOrder == 0 ? (moduleIndex + 1) * 10 : requestedModule.SortOrder;

            await UpsertTranslationsAsync("CourseModule", module.Id, CourseModuleEditorFields, requestedModule.Translations);

            var lessonError = await SyncCourseLessonsAsync(module, requestedModule.Lessons ?? new List<AdminCourseLessonSaveRequestDto>());
            if (lessonError is not null)
            {
                return lessonError;
            }
        }

        return null;
    }

    private async Task<ActionResult?> SyncCourseLessonsAsync(CourseModule module, List<AdminCourseLessonSaveRequestDto> requestedLessons)
    {
        var existingLessons = module.Lessons.ToDictionary(lesson => lesson.Id);
        var requestedLessonIds = requestedLessons
            .Where(lesson => lesson.Id.HasValue)
            .Select(lesson => lesson.Id!.Value)
            .ToHashSet();

        var lessonsToRemove = existingLessons.Values
            .Where(lesson => !requestedLessonIds.Contains(lesson.Id))
            .ToList();

        await RemoveTranslationsAsync("CourseLesson", lessonsToRemove.Select(lesson => lesson.Id));
        foreach (var lesson in lessonsToRemove)
        {
            _db.CourseLessons.Remove(lesson);
        }

        for (var lessonIndex = 0; lessonIndex < requestedLessons.Count; lessonIndex++)
        {
            var requestedLesson = requestedLessons[lessonIndex];
            CourseLesson lesson;

            if (requestedLesson.Id.HasValue)
            {
                if (!existingLessons.TryGetValue(requestedLesson.Id.Value, out lesson!))
                {
                    return BadRequest("Unknown course lesson id.");
                }
            }
            else
            {
                lesson = new CourseLesson { CourseModuleId = module.Id };
                _db.CourseLessons.Add(lesson);
                module.Lessons.Add(lesson);
            }

            lesson.SortOrder = requestedLesson.SortOrder == 0 ? (lessonIndex + 1) * 10 : requestedLesson.SortOrder;
            await UpsertTranslationsAsync("CourseLesson", lesson.Id, CourseLessonEditorFields, requestedLesson.Translations);
        }

        return null;
    }

    private async Task<ActionResult<AdminContentEditorDto>> SaveConsultationAsync(Guid? id, AdminContentSaveRequestDto request)
    {
        var slug = NormalizeSlug(request.Slug, "consultation");
        if (await _db.Consultations.AnyAsync(x => x.Slug == slug && (!id.HasValue || x.Id != id.Value)))
        {
            return Conflict("A consultation with this slug already exists.");
        }

        var consultation = id.HasValue
            ? await _db.Consultations.FirstOrDefaultAsync(x => x.Id == id.Value)
            : null;

        if (id.HasValue && consultation is null)
        {
            return NotFound();
        }

        consultation ??= new Consultation();
        if (!id.HasValue)
        {
            _db.Consultations.Add(consultation);
        }

        consultation.Slug = slug;
        consultation.SortOrder = request.SortOrder;
        consultation.IsActive = request.IsActive;
        consultation.IsDraft = request.IsDraft;
        consultation.IsOnline = request.IsOnline;
        consultation.IsOffline = request.IsOffline;

        await UpsertTranslationsAsync("Consultation", consultation.Id, ConsultationEditorFields, request.Translations);
        await _db.SaveChangesAsync();

        return Ok(await GetConsultationEditorAsync(consultation.Slug));
    }

    private async Task<ActionResult<AdminContentEditorDto>> SaveRetreatAsync(Guid? id, AdminContentSaveRequestDto request)
    {
        var slug = NormalizeSlug(request.Slug, "retreat");
        if (await _db.Retreats.AnyAsync(x => x.Slug == slug && (!id.HasValue || x.Id != id.Value)))
        {
            return Conflict("A retreat with this slug already exists.");
        }

        var retreat = id.HasValue
            ? await _db.Retreats.FirstOrDefaultAsync(x => x.Id == id.Value)
            : null;

        if (id.HasValue && retreat is null)
        {
            return NotFound();
        }

        retreat ??= new Retreat();
        if (!id.HasValue)
        {
            _db.Retreats.Add(retreat);
        }

        retreat.Slug = slug;
        retreat.SortOrder = request.SortOrder;
        retreat.IsActive = request.IsActive;
        retreat.IsDraft = request.IsDraft;
        retreat.EventStartDate = request.EventStartDate;
        retreat.EventEndDate = request.EventEndDate;

        await UpsertTranslationsAsync("Retreat", retreat.Id, RetreatEditorFields, request.Translations);
        await _db.SaveChangesAsync();

        return Ok(await GetRetreatEditorAsync(retreat.Slug));
    }

    private async Task<ActionResult<AdminContentEditorDto>> SaveYagyaAsync(Guid? id, AdminContentSaveRequestDto request)
    {
        var slug = NormalizeSlug(request.Slug, "yagya");
        if (await _db.Yagyas.AnyAsync(x => x.Slug == slug && (!id.HasValue || x.Id != id.Value)))
        {
            return Conflict("A yagya with this slug already exists.");
        }

        var yagya = id.HasValue
            ? await _db.Yagyas.FirstOrDefaultAsync(x => x.Id == id.Value)
            : null;

        if (id.HasValue && yagya is null)
        {
            return NotFound();
        }

        yagya ??= new Yagya();
        if (!id.HasValue)
        {
            _db.Yagyas.Add(yagya);
        }

        yagya.Slug = slug;
        yagya.SortOrder = request.SortOrder;
        yagya.IsActive = request.IsActive;
        yagya.IsDraft = request.IsDraft;
        yagya.EventStartDate = request.EventStartDate;
        yagya.EventEndDate = request.EventEndDate;

        await UpsertTranslationsAsync("Yagya", yagya.Id, YagyaEditorFields, request.Translations);
        await _db.SaveChangesAsync();

        return Ok(await GetYagyaEditorAsync(yagya.Slug));
    }

    private async Task<ActionResult<AdminContentEditorDto>> SaveSitePageAsync(Guid? id, AdminContentSaveRequestDto request)
    {
        var slug = NormalizeSlug(request.Slug, "page");

        var page = id.HasValue
            ? await _db.SitePages.FirstOrDefaultAsync(x => x.Id == id.Value)
            : await _db.SitePages.FirstOrDefaultAsync(x => x.Slug == slug);

        if (id.HasValue && page is null)
        {
            return NotFound();
        }

        if (page is null)
        {
            if (await _db.SitePages.AnyAsync(x => x.Slug == slug))
            {
                return Conflict("A site page with this slug already exists.");
            }

            page = new SitePage { Slug = slug };
            _db.SitePages.Add(page);
        }
        else if (!string.Equals(page.Slug, slug, StringComparison.OrdinalIgnoreCase))
        {
            if (await _db.SitePages.AnyAsync(x => x.Slug == slug && x.Id != page.Id))
            {
                return Conflict("A site page with this slug already exists.");
            }

            page.Slug = slug;
        }

        var fields = GetSitePageFields(page.Slug);

        page.IsActive = request.IsActive;
        page.IsDraft = request.IsDraft;

        await UpsertTranslationsAsync("SitePage", page.Id, fields, request.Translations);
        await _db.SaveChangesAsync();

        return Ok(await GetSitePageEditorAsync(page.Slug));
    }

    private async Task<AdminCatalogSectionDto> BuildCoursesCatalogAsync(string lang)
    {
        var items = await _db.Courses
            .OrderBy(x => x.SortOrder)
            .Include(x => x.Modules)
            .ToListAsync();

        var titles = await GetFieldMapAsync("Course", items.Select(x => x.Id), lang, "Title");

        return new AdminCatalogSectionDto(
            "courses",
            "Courses",
            items.Select(x => new AdminCatalogItemDto(
                x.Id,
                x.Slug,
                titles.GetValueOrDefault(x.Id, x.Slug),
                x.IsActive,
                x.SortOrder,
                $"{x.Modules.Count} module(s)"))
            .ToList(),
            _options.EnableSampleContentBootstrap);
    }

    private async Task<AdminCatalogSectionDto> BuildConsultationsCatalogAsync(string lang)
    {
        var items = await _db.Consultations
            .OrderBy(x => x.SortOrder)
            .ToListAsync();

        var titles = await GetFieldMapAsync("Consultation", items.Select(x => x.Id), lang, "Title");

        return new AdminCatalogSectionDto(
            "consultations",
            "Consultations",
            items.Select(x => new AdminCatalogItemDto(
                x.Id,
                x.Slug,
                titles.GetValueOrDefault(x.Id, x.Slug),
                x.IsActive,
                x.SortOrder,
                BuildFormatMeta(x.IsOnline, x.IsOffline)))
            .ToList(),
            _options.EnableSampleContentBootstrap);
    }

    private async Task<AdminCatalogSectionDto> BuildRetreatsCatalogAsync(string lang)
    {
        var items = await _db.Retreats
            .OrderBy(x => x.EventStartDate ?? DateTime.MaxValue)
            .ThenBy(x => x.SortOrder)
            .ToListAsync();

        var titles = await GetFieldMapAsync("Retreat", items.Select(x => x.Id), lang, "Title");

        return new AdminCatalogSectionDto(
            "retreats",
            "Retreats",
            items.Select(x => new AdminCatalogItemDto(
                x.Id,
                x.Slug,
                titles.GetValueOrDefault(x.Id, x.Slug),
                x.IsActive,
                x.SortOrder,
                BuildDateMeta(x.EventStartDate, x.EventEndDate)))
            .ToList(),
            _options.EnableSampleContentBootstrap);
    }

    private async Task<AdminCatalogSectionDto> BuildYagyasCatalogAsync(string lang)
    {
        var items = await _db.Yagyas
            .OrderBy(x => x.EventStartDate ?? DateTime.MaxValue)
            .ThenBy(x => x.SortOrder)
            .ToListAsync();

        var titles = await GetFieldMapAsync("Yagya", items.Select(x => x.Id), lang, "Title");

        return new AdminCatalogSectionDto(
            "yagyas",
            "Yagyas",
            items.Select(x => new AdminCatalogItemDto(
                x.Id,
                x.Slug,
                titles.GetValueOrDefault(x.Id, x.Slug),
                x.IsActive,
                x.SortOrder,
                BuildDateMeta(x.EventStartDate, x.EventEndDate)))
            .ToList(),
            _options.EnableSampleContentBootstrap);
    }

    private async Task<AdminCatalogSectionDto> BuildPagesCatalogAsync(string lang)
    {
        var items = await _db.SitePages
            .OrderBy(x => x.Slug)
            .ToListAsync();

        var heroTitles = await GetFieldMapAsync("SitePage", items.Select(x => x.Id), lang, "HeroTitle");
        var headingTitles = await GetFieldMapAsync("SitePage", items.Select(x => x.Id), lang, "H1");

        return new AdminCatalogSectionDto(
            "pages",
            "Site Pages",
            items.Select(x => new AdminCatalogItemDto(
                x.Id,
                x.Slug,
                heroTitles.GetValueOrDefault(x.Id) ?? headingTitles.GetValueOrDefault(x.Id) ?? x.Slug,
                true,
                0,
                "Page schema editor"))
            .ToList());
    }

    private async Task<Dictionary<Guid, string>> GetFieldMapAsync(string entityType, IEnumerable<Guid> ids, string lang, string field)
    {
        var idList = ids.Distinct().ToList();
        if (idList.Count == 0)
        {
            return new Dictionary<Guid, string>();
        }

        return await _db.Translations
            .Where(x => x.EntityType == entityType && x.Language == lang && x.Field == field && idList.Contains(x.EntityId))
            .GroupBy(x => x.EntityId)
            .Select(x => new { x.Key, Value = x.Select(y => y.Value).FirstOrDefault() ?? string.Empty })
            .ToDictionaryAsync(x => x.Key, x => x.Value);
    }

    private async Task<Dictionary<string, Dictionary<string, string>>> GetTranslationMatrixAsync(string entityType, Guid entityId, IReadOnlyList<ContentField> fields)
    {
        var matrix = CreateEmptyTranslations(fields);
        var fieldKeys = fields.Select(x => x.Key).Distinct().ToList();

        var translations = await _db.Translations
            .Where(x => x.EntityType == entityType && x.EntityId == entityId && EditorLanguages.Contains(x.Language) && fieldKeys.Contains(x.Field))
            .ToListAsync();

        foreach (var translation in translations)
        {
            matrix[translation.Language][translation.Field] = translation.Value;
        }

        return matrix;
    }

    private static Dictionary<string, Dictionary<string, string>> BuildTranslationMatrix(
        IReadOnlyList<ContentField> fields,
        IEnumerable<Translation> translations)
    {
        var matrix = CreateEmptyTranslations(fields);

        foreach (var translation in translations)
        {
            if (matrix.TryGetValue(translation.Language, out var languageValues) && languageValues.ContainsKey(translation.Field))
            {
                languageValues[translation.Field] = translation.Value;
            }
        }

        return matrix;
    }

    private async Task UpsertTranslationsAsync(
        string entityType,
        Guid entityId,
        IReadOnlyList<ContentField> fields,
        Dictionary<string, Dictionary<string, string>>? requestedTranslations)
    {
        var fieldKeys = fields.Select(x => x.Key).Distinct().ToList();
        var existing = await _db.Translations
            .Where(x => x.EntityType == entityType && x.EntityId == entityId && EditorLanguages.Contains(x.Language) && fieldKeys.Contains(x.Field))
            .ToListAsync();

        foreach (var language in EditorLanguages)
        {
            requestedTranslations ??= new Dictionary<string, Dictionary<string, string>>();
            requestedTranslations.TryGetValue(language, out var languageValues);

            foreach (var field in fieldKeys)
            {
                var value = NormalizeTranslationValue(languageValues, field);
                var current = existing.FirstOrDefault(x => x.Language == language && x.Field == field);

                if (string.IsNullOrWhiteSpace(value))
                {
                    if (current is not null)
                    {
                        _db.Translations.Remove(current);
                    }

                    continue;
                }

                if (current is null)
                {
                    _db.Translations.Add(new Translation
                    {
                        EntityType = entityType,
                        EntityId = entityId,
                        Language = language,
                        Field = field,
                        Value = value
                    });

                    continue;
                }

                current.Value = value;
            }
        }
    }

    private async Task RemoveTranslationsAsync(string entityType, IEnumerable<Guid> entityIds)
    {
        var ids = entityIds.Distinct().ToList();
        if (ids.Count == 0)
        {
            return;
        }

        var translations = await _db.Translations
            .Where(x => x.EntityType == entityType && ids.Contains(x.EntityId))
            .ToListAsync();

        if (translations.Count > 0)
        {
            _db.Translations.RemoveRange(translations);
        }
    }

    private void AddTri(string entityType, Guid entityId, string field, string ru, string en, string uk)
    {
        _db.Translations.Add(new Translation { EntityType = entityType, EntityId = entityId, Field = field, Language = "ru", Value = ru });
        _db.Translations.Add(new Translation { EntityType = entityType, EntityId = entityId, Field = field, Language = "en", Value = en });
        _db.Translations.Add(new Translation { EntityType = entityType, EntityId = entityId, Field = field, Language = "uk", Value = uk });
    }

    private static AdminContentEditorDto BuildEditorDto(
        string sectionKey,
        string label,
        Guid? id,
        string slug,
        int sortOrder,
        bool isActive,
        bool isDraft,
        bool supportsFormatFlags,
        bool isOnline,
        bool isOffline,
        bool supportsEventDates,
        DateTime? eventStartDate,
        DateTime? eventEndDate,
        string publicPath,
        IReadOnlyList<ContentField> fields,
        Dictionary<string, Dictionary<string, string>> translations)
    {
        return new AdminContentEditorDto(
            sectionKey,
            label,
            id,
            slug,
            sortOrder,
            isActive,
            isDraft,
            supportsFormatFlags,
            isOnline,
            isOffline,
            supportsEventDates,
            eventStartDate,
            eventEndDate,
            publicPath,
            EditorLanguages,
            fields,
            translations);
    }

    private static Dictionary<string, Dictionary<string, string>> CreateEmptyTranslations(IReadOnlyList<ContentField> fields)
    {
        return EditorLanguages.ToDictionary(
            language => language,
            _ => fields.ToDictionary(field => field.Key, _ => string.Empty));
    }

    private static IReadOnlyList<ContentField> GetSitePageFields(string slug)
    {
        return slug.Trim().ToLowerInvariant() switch
        {
            "home" => HomePageFields,
            "about" => AboutPageFields,
            "contacts" => ContactsPageFields,
            "courses" => CoursePageFields,
            "consultations" => ConsultationPageFields,
            "retreats" or "yagyas" or "blog" => SectionPageFields,
            _ => SectionPageFields
        };
    }

    private static string NormalizeSlug(string? slug, string fallbackPrefix)
    {
        var value = (slug ?? string.Empty).Trim().ToLowerInvariant();
        value = value.Replace(" ", "-");

        var chars = value
            .Select(ch => char.IsLetterOrDigit(ch) || ch == '-' ? ch : '-')
            .ToArray();

        var normalized = new string(chars);
        while (normalized.Contains("--", StringComparison.Ordinal))
        {
            normalized = normalized.Replace("--", "-", StringComparison.Ordinal);
        }

        normalized = normalized.Trim('-');

        if (!string.IsNullOrWhiteSpace(normalized))
        {
            return normalized;
        }

        var generated = $"{fallbackPrefix}-{Guid.NewGuid():N}";
        return generated[..Math.Min(generated.Length, fallbackPrefix.Length + 9)];
    }

    private static string NormalizeTranslationValue(Dictionary<string, string>? languageValues, string field)
    {
        if (languageValues is null || !languageValues.TryGetValue(field, out var value))
        {
            return string.Empty;
        }

        return value.Trim();
    }

    private static string NormalizeLanguage(string lang) => lang is "ru" or "en" ? lang : "uk";

    private static string BuildFormatMeta(bool isOnline, bool isOffline)
    {
        return (isOnline, isOffline) switch
        {
            (true, true) => "Online / Offline",
            (true, false) => "Online",
            (false, true) => "Offline",
            _ => "Format not set"
        };
    }

    private static string? BuildDateMeta(DateTime? start, DateTime? end)
    {
        if (!start.HasValue)
        {
            return null;
        }

        if (!end.HasValue || end.Value.Date == start.Value.Date)
        {
            return start.Value.ToString("dd.MM.yyyy");
        }

        return $"{start.Value:dd.MM.yyyy} - {end.Value:dd.MM.yyyy}";
    }

    // ─── Leads ───────────────────────────────────────────────────────────────

    [HttpGet("leads")]
    public async Task<ActionResult<AdminLeadsListDto>> GetLeads(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 30,
        [FromQuery] int? status = null)
    {
        var query = _db.Leads.AsQueryable();
        if (status.HasValue)
            query = query.Where(x => (int)x.Status == status.Value);

        var total = await query.CountAsync();
        var items = await query
            .OrderByDescending(x => x.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var courseIds = items.Where(x => x.CourseId.HasValue).Select(x => x.CourseId!.Value).Distinct().ToList();
        var consultIds = items.Where(x => x.ConsultationId.HasValue).Select(x => x.ConsultationId!.Value).Distinct().ToList();
        var retreatIds = items.Where(x => x.RetreatId.HasValue).Select(x => x.RetreatId!.Value).Distinct().ToList();
        var yagyaIds = items.Where(x => x.YagyaId.HasValue).Select(x => x.YagyaId!.Value).Distinct().ToList();

        var courseTitles = await GetFieldMapAsync("course", courseIds, "uk", "Title");
        var consultTitles = await GetFieldMapAsync("consultation", consultIds, "uk", "Title");
        var retreatTitles = await GetFieldMapAsync("retreat", retreatIds, "uk", "Title");
        var yagyaTitles = await GetFieldMapAsync("yagya", yagyaIds, "uk", "Title");

        var dtos = items.Select(l =>
        {
            string? subject = null;
            if (l.CourseId.HasValue) courseTitles.TryGetValue(l.CourseId.Value, out subject);
            else if (l.ConsultationId.HasValue) consultTitles.TryGetValue(l.ConsultationId.Value, out subject);
            else if (l.RetreatId.HasValue) retreatTitles.TryGetValue(l.RetreatId.Value, out subject);
            else if (l.YagyaId.HasValue) yagyaTitles.TryGetValue(l.YagyaId.Value, out subject);

            return new AdminLeadDto(
                l.Id, l.Name, l.ContactDetails, l.Messager, l.Comment,
                l.CreatedAt, l.CourseId, l.ConsultationId, l.RetreatId, l.YagyaId,
                l.TargetFormat, (int)l.Status, l.OperatorNote, subject);
        }).ToList();

        return Ok(new AdminLeadsListDto(dtos, total));
    }

    [HttpPut("leads/{id:guid}")]
    public async Task<ActionResult<AdminLeadDto>> UpdateLead(Guid id, [FromBody] AdminLeadUpdateRequest? body)
    {
        if (body is null) return BadRequest();
        var lead = await _db.Leads.FindAsync(id);
        if (lead is null) return NotFound();

        lead.Status = (LeadStatus)body.Status;
        lead.OperatorNote = body.OperatorNote;
        await _db.SaveChangesAsync();

        return Ok(new AdminLeadDto(
            lead.Id, lead.Name, lead.ContactDetails, lead.Messager, lead.Comment,
            lead.CreatedAt, lead.CourseId, lead.ConsultationId, lead.RetreatId, lead.YagyaId,
            lead.TargetFormat, (int)lead.Status, lead.OperatorNote, null));
    }

    // ─── Media ───────────────────────────────────────────────────────────────

    [HttpGet("media")]
    public async Task<ActionResult<AdminMediaListDto>> ListMedia(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 40,
        [FromQuery] string? q = null)
    {
        var query = _db.MediaFiles.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(x => x.FileName.Contains(q) || (x.AltText != null && x.AltText.Contains(q)));

        var total = await query.CountAsync();
        var items = await query
            .OrderByDescending(x => x.UploadedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var dtos = items.Select(m => new AdminMediaFileDto(
            m.Id, m.FileName, m.ContentType, m.Size, m.UploadedAt, m.AltText, m.StoragePath
        )).ToList();

        return Ok(new AdminMediaListDto(dtos, total));
    }

    [HttpPost("media/upload")]
    [RequestSizeLimit(10 * 1024 * 1024)]
    public async Task<ActionResult<AdminMediaFileDto>> UploadMedia(IFormFile file)
    {
        if (file is null || file.Length == 0) return BadRequest("No file provided.");

        var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp", "image/gif", "image/svg+xml" };
        if (!allowedTypes.Contains(file.ContentType.ToLower()))
            return BadRequest("Only image files are allowed.");

        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        var safeName = $"{Guid.NewGuid()}{ext}";
        var relativePath = $"/media/{DateTime.UtcNow:yyyy/MM}/{safeName}";

        var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var fullDir = Path.Combine(wwwroot, "media", DateTime.UtcNow.ToString("yyyy/MM"));
        Directory.CreateDirectory(fullDir);
        var fullPath = Path.Combine(fullDir, safeName);

        using (var fs = System.IO.File.Create(fullPath))
        {
            await file.CopyToAsync(fs);
        }

        var mediaFile = new MediaFile
        {
            FileName = Path.GetFileName(file.FileName),
            ContentType = file.ContentType,
            Size = file.Length,
            StoragePath = relativePath
        };
        _db.MediaFiles.Add(mediaFile);
        await _db.SaveChangesAsync();

        return Ok(new AdminMediaFileDto(
            mediaFile.Id, mediaFile.FileName, mediaFile.ContentType,
            mediaFile.Size, mediaFile.UploadedAt, mediaFile.AltText, mediaFile.StoragePath));
    }

    [HttpPost("media/upload-url")]
    public async Task<ActionResult<AdminMediaFileDto>> UploadMediaFromUrl([FromBody] UploadFromUrlRequest? body)
    {
        if (body is null || string.IsNullOrWhiteSpace(body.Url)) return BadRequest("URL is required.");
        if (!Uri.TryCreate(body.Url, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttps && uri.Scheme != Uri.UriSchemeHttp))
            return BadRequest("Invalid URL.");

        using var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromSeconds(15);
        using var response = await httpClient.GetAsync(uri);
        if (!response.IsSuccessStatusCode) return BadRequest("Could not download image.");

        var contentType = response.Content.Headers.ContentType?.MediaType ?? "application/octet-stream";
        var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp", "image/gif", "image/svg+xml" };
        if (!allowedTypes.Contains(contentType.ToLower())) return BadRequest("URL does not point to an image.");

        var ext = contentType switch
        {
            "image/jpeg" => ".jpg",
            "image/png" => ".png",
            "image/webp" => ".webp",
            "image/gif" => ".gif",
            _ => ".svg"
        };
        var safeName = $"{Guid.NewGuid()}{ext}";
        var relativePath = $"/media/{DateTime.UtcNow:yyyy/MM}/{safeName}";

        var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var fullDir = Path.Combine(wwwroot, "media", DateTime.UtcNow.ToString("yyyy/MM"));
        Directory.CreateDirectory(fullDir);
        var fullPath = Path.Combine(fullDir, safeName);

        var bytes = await response.Content.ReadAsByteArrayAsync();
        await System.IO.File.WriteAllBytesAsync(fullPath, bytes);

        var fileName = Path.GetFileName(uri.LocalPath);
        if (string.IsNullOrWhiteSpace(fileName) || fileName.Length < 2) fileName = safeName;

        var mediaFile = new MediaFile
        {
            FileName = fileName,
            ContentType = contentType,
            Size = bytes.Length,
            StoragePath = relativePath
        };
        _db.MediaFiles.Add(mediaFile);
        await _db.SaveChangesAsync();

        return Ok(new AdminMediaFileDto(
            mediaFile.Id, mediaFile.FileName, mediaFile.ContentType,
            mediaFile.Size, mediaFile.UploadedAt, mediaFile.AltText, mediaFile.StoragePath));
    }

    [HttpPut("media/{id:guid}/alt")]
    public async Task<ActionResult<AdminMediaFileDto>> UpdateMediaAlt(Guid id, [FromBody] AdminMediaAltUpdateRequest? body)
    {
        if (body is null) return BadRequest();
        var item = await _db.MediaFiles.FindAsync(id);
        if (item is null) return NotFound();
        item.AltText = body.AltText;
        await _db.SaveChangesAsync();
        return Ok(new AdminMediaFileDto(
            item.Id, item.FileName, item.ContentType,
            item.Size, item.UploadedAt, item.AltText, item.StoragePath));
    }

    [HttpDelete("media/{id:guid}")]
    public async Task<IActionResult> DeleteMedia(Guid id)
    {
        var item = await _db.MediaFiles.FindAsync(id);
        if (item is null) return NotFound();

        var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var fullPath = Path.Combine(wwwroot, item.StoragePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
        if (System.IO.File.Exists(fullPath))
            System.IO.File.Delete(fullPath);

        _db.MediaFiles.Remove(item);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // ─── Translation workspace ────────────────────────────────────────────────

    [HttpGet("translations/workspace")]
    public async Task<ActionResult<AdminTranslationWorkspaceDto>> GetTranslationWorkspace()
    {
        var languages = EditorLanguages.ToList();
        var rows = new List<AdminTranslationEntityRowDto>();

        async Task AddEntities<TEntity>(
            IQueryable<TEntity> dbSet,
            string entityType,
            IReadOnlyList<ContentField> fields,
            Func<TEntity, Guid> getId,
            Func<TEntity, string> getSlug) where TEntity : class
        {
            var entities = await dbSet.ToListAsync();
            var ids = entities.Select(getId).ToList();
            var translations = await _db.Translations
                .Where(x => x.EntityType == entityType && ids.Contains(x.EntityId))
                .ToListAsync();

            var fieldKeys = fields.Select(x => x.Key).ToList();

            foreach (var entity in entities)
            {
                var entityId = getId(entity);
                var slug = getSlug(entity);
                var entityTranslations = translations.Where(x => x.EntityId == entityId).ToList();

                var defaultTitle = entityTranslations
                    .Where(x => x.Language == "uk" && x.Field == "Title")
                    .Select(x => x.Value)
                    .FirstOrDefault() ?? slug;

                var coverage = languages.Select(lang =>
                {
                    var filled = entityTranslations
                        .Count(t => t.Language == lang && fieldKeys.Contains(t.Field) && !string.IsNullOrWhiteSpace(t.Value));
                    return new AdminTranslationCoverageDto(lang, fieldKeys.Count, filled);
                }).ToList();

                rows.Add(new AdminTranslationEntityRowDto(entityId, entityType, slug, defaultTitle, coverage));
            }
        }

        await AddEntities(_db.Courses, "course", CourseEditorFields, c => c.Id, c => c.Slug);
        await AddEntities(_db.Consultations, "consultation", ConsultationEditorFields, c => c.Id, c => c.Slug);
        await AddEntities(_db.Retreats, "retreat", RetreatEditorFields, r => r.Id, r => r.Slug);
        await AddEntities(_db.Yagyas, "yagya", YagyaEditorFields, y => y.Id, y => y.Slug);

        var sitePages = await _db.SitePages.ToListAsync();
        foreach (var page in sitePages)
        {
            var fields = GetSitePageFields(page.Slug);
            var fieldKeys = fields.Select(x => x.Key).ToList();
            var entityTranslations = await _db.Translations
                .Where(x => x.EntityType == "SitePage" && x.EntityId == page.Id)
                .ToListAsync();

            var defaultTitle = entityTranslations
                    .Where(x => x.Language == "uk" && x.Field == "HeroTitle")
                    .Select(x => x.Value)
                    .FirstOrDefault() ?? page.Slug;

            var coverage = languages.Select(lang =>
            {
                var filled = entityTranslations
                    .Count(t => t.Language == lang && fieldKeys.Contains(t.Field) && !string.IsNullOrWhiteSpace(t.Value));
                return new AdminTranslationCoverageDto(lang, fieldKeys.Count, filled);
            }).ToList();

            rows.Add(new AdminTranslationEntityRowDto(page.Id, "SitePage", page.Slug, defaultTitle, coverage));
        }

        return Ok(new AdminTranslationWorkspaceDto(rows, languages, rows.Count));
    }

    [HttpGet("translations/ui")]
    public async Task<ActionResult<IReadOnlyList<AdminUiTranslationRowDto>>> GetUiTranslations()
    {
        var all = await _db.UiTranslations.OrderBy(x => x.Key).ToListAsync();
        var grouped = all
            .GroupBy(x => x.Key)
            .Select(g => new AdminUiTranslationRowDto(
                g.Key,
                g.ToDictionary(x => x.Language, x => x.Value)))
            .ToList();
        return Ok(grouped);
    }

    [HttpPost("translations/ui")]
    public async Task<IActionResult> SaveUiTranslations([FromBody] AdminUiTranslationSaveRequest? body)
    {
        if (body is null) return BadRequest();

        foreach (var (key, langMap) in body.Rows)
        {
            foreach (var (lang, value) in langMap)
            {
                var existing = await _db.UiTranslations.FirstOrDefaultAsync(x => x.Key == key && x.Language == lang);
                if (existing is null)
                    _db.UiTranslations.Add(new UiTranslation { Key = key, Language = lang, Value = value });
                else
                    existing.Value = value;
            }
        }

        await _db.SaveChangesAsync();
        return NoContent();
    }
}

public record UploadFromUrlRequest(string Url);