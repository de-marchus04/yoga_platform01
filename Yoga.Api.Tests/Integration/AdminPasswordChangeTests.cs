using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Yoga.Api.Data;
using Yoga.Api.Tests.TestInfrastructure;
using Yoga.Shared.DTOs;

namespace Yoga.Api.Tests.Integration;

public class AdminPasswordChangeTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly TestWebApplicationFactory _factory;

    public AdminPasswordChangeTests(TestWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Admin_Can_Change_Own_Password_And_Audit_Is_Written()
    {
        await _factory.ResetDatabaseAsync();

        using var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost")
        });

        var adminToken = await LoginAsync(client, "admin", "admin123");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

        var changeResponse = await client.PostAsJsonAsync("/api/admin/users/change-password", new ChangePasswordRequest(
            "admin123",
            "AdminPassword456!"));

        Assert.Equal(HttpStatusCode.NoContent, changeResponse.StatusCode);

        var oldLoginResponse = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest("admin", "admin123"));
        Assert.Equal(HttpStatusCode.Unauthorized, oldLoginResponse.StatusCode);

        var newToken = await LoginAsync(client, "admin", "AdminPassword456!");
        Assert.False(string.IsNullOrWhiteSpace(newToken));

        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Assert.NotEmpty(db.AdminAuditLogs.Where(x => x.Action == "admin-password-changed"));
    }

    private static async Task<string> LoginAsync(HttpClient client, string username, string password)
    {
        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest(username, password));
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
        Assert.NotNull(payload);
        return payload!.Token;
    }
}