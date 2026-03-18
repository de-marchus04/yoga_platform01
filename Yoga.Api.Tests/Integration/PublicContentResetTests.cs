using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Yoga.Api.Data;
using Yoga.Api.Tests.TestInfrastructure;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Tests.Integration;

public class PublicContentResetTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly TestWebApplicationFactory _factory;

    public PublicContentResetTests(TestWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Reset_Public_Content_Removes_Only_Public_Content_And_Writes_Audit_Log()
    {
        await _factory.ResetDatabaseAsync();
        await SeedPublicContentAsync();

        using var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost")
        });

        var adminToken = await LoginAdminAsync(client);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

        var preview = await client.GetFromJsonAsync<PublicContentResetPreviewDto>("/api/admin/content/public-reset-preview");
        Assert.NotNull(preview);
        Assert.True(preview!.Courses > 0);
        Assert.True(preview.Consultations > 0);
        Assert.True(preview.Retreats > 0);
        Assert.True(preview.BlogPosts > 0);
        Assert.True(preview.SitePageTranslations > 0);
        Assert.True(preview.EntityTranslations > 0);
        Assert.True(preview.MediaFiles > 0);

        var resetResponse = await client.PostAsync("/api/admin/content/reset-public", null);
        Assert.Equal(HttpStatusCode.OK, resetResponse.StatusCode);

        var result = await resetResponse.Content.ReadFromJsonAsync<PublicContentResetResultDto>();
        Assert.NotNull(result);
        Assert.Equal(preview.Courses, result!.Courses);
        Assert.Equal(preview.Consultations, result.Consultations);
        Assert.Equal(preview.Retreats, result.Retreats);
        Assert.Equal(preview.BlogPosts, result.BlogPosts);

        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        Assert.Empty(db.Courses);
        Assert.Empty(db.CourseModules);
        Assert.Empty(db.Consultations);
        Assert.Empty(db.Retreats);
        Assert.Empty(db.BlogPosts);
        Assert.Empty(db.MediaFiles);
        Assert.Empty(db.Translations.Where(x => x.EntityType == "Course" || x.EntityType == "CourseModule" || x.EntityType == "Consultation" || x.EntityType == "Retreat" || x.EntityType == "BlogPost"));
        Assert.Empty(db.Translations.Where(x => x.EntityType == "SitePage"));
        Assert.NotEmpty(db.UiTranslations);
        Assert.NotEmpty(db.SitePages);
        Assert.NotEmpty(db.AdminAuditLogs.Where(x => x.Action == "PublicContentReset"));
    }

    private async Task SeedPublicContentAsync()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var blogPost = new BlogPost
        {
            Id = Guid.NewGuid(),
            Slug = "integration-public-post",
            Category = "articles",
            IsActive = true,
            PublishedAt = DateTime.UtcNow,
            Sections = ["courses"]
        };

        var homePageId = db.SitePages.Single(x => x.Slug == "home").Id;
        var firstCourseId = db.Courses.Select(x => x.Id).First();

        db.BlogPosts.Add(blogPost);
        db.Translations.AddRange(
            new Translation { EntityType = "BlogPost", EntityId = blogPost.Id, Field = "Title", Language = "ru", Value = "Тестовый пост" },
            new Translation { EntityType = "SitePage", EntityId = homePageId, Field = "HeroTitle", Language = "ru", Value = "Тестовый заголовок" },
            new Translation { EntityType = "Course", EntityId = firstCourseId, Field = "Title", Language = "ru", Value = "Тестовый курс" });
        db.MediaFiles.AddRange(
            new MediaFile { EntityType = "BlogPost", EntityId = blogPost.Id, Url = "/uploads/blog/test.webp", Alt = "Blog test" },
            new MediaFile { EntityType = "SitePage", EntityId = homePageId, Url = "/uploads/site/home.webp", Alt = "Home test" });

        await db.SaveChangesAsync();
    }

    private static async Task<string> LoginAdminAsync(HttpClient client)
    {
        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest("admin", "admin123"));
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
        Assert.NotNull(payload);
        return payload!.Token;
    }
}