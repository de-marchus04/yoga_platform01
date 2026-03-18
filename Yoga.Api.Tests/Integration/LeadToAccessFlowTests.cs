using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Yoga.Api.Tests.TestInfrastructure;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Tests.Integration;

public class LeadToAccessFlowTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly TestWebApplicationFactory _factory;

    public LeadToAccessFlowTests(TestWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Lead_To_Customer_To_Grant_To_LiveEvent_Access_Flow_Works()
    {
        await _factory.ResetDatabaseAsync();
        using var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost")
        });

        var leadPayload = new Lead
        {
            Name = "Integration Lead",
            ContactDetails = "integration@example.com",
            Messager = "Telegram",
            Comment = "Need access to live practice",
            TargetFormat = "Online"
        };

        var createLeadResponse = await client.PostAsJsonAsync("/api/leads", leadPayload);
        Assert.Equal(HttpStatusCode.OK, createLeadResponse.StatusCode);
        Assert.True(createLeadResponse.Headers.Contains("X-Trace-Id"));

        var adminToken = await LoginAdminAsync(client);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);

        var leadsPage = await client.GetFromJsonAsync<PaginatedResult<LeadSummaryDto>>("/api/leads?page=1&pageSize=10");
        Assert.NotNull(leadsPage);
        var lead = Assert.Single(leadsPage!.Items, x => x.Name == "Integration Lead");

        var liveEventId = await CreatePublishedLiveEventAsync(client);

        var createCustomerResponse = await client.PostAsJsonAsync($"/api/leads/{lead.Id}/create-customer", new CreateCustomerFromLeadRequest(
            lead.Id,
            "student@example.com",
            "Password123!",
            "Student One",
            "+123456789",
            "Telegram"));
        Assert.Equal(HttpStatusCode.OK, createCustomerResponse.StatusCode);

        var customerId = await ReadGuidPropertyAsync(createCustomerResponse, "customerId");

        var grantResponse = await client.PostAsJsonAsync($"/api/leads/{lead.Id}/grant-access", new GrantAccessFromLeadRequest(
            lead.Id,
            customerId,
            "LiveEvent",
            null,
            null,
            null,
            liveEventId,
            DateTime.UtcNow.AddDays(7),
            "Integration test grant"));
        Assert.Equal(HttpStatusCode.OK, grantResponse.StatusCode);

        var customerLogin = await client.PostAsJsonAsync("/api/customer-auth/login", new CustomerLoginRequest("student@example.com", "Password123!"));
        Assert.Equal(HttpStatusCode.OK, customerLogin.StatusCode);
        var loginResponse = await customerLogin.Content.ReadFromJsonAsync<CustomerLoginResponse>();
        Assert.NotNull(loginResponse);

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse!.Token);

        var watchResponse = await client.GetAsync($"/api/live-events/{liveEventId}/watch");
        Assert.Equal(HttpStatusCode.OK, watchResponse.StatusCode);
        Assert.True(watchResponse.Headers.Contains("X-Trace-Id"));

        var detail = await watchResponse.Content.ReadFromJsonAsync<LiveEventDetailDto>();
        Assert.NotNull(detail);
        Assert.Equal("Integration Event", detail!.Title);
        Assert.Equal("https://zoom.example.com/j/integration", detail.JoinUrl);
    }

    private static async Task<string> LoginAdminAsync(HttpClient client)
    {
        var response = await client.PostAsJsonAsync("/api/auth/login", new LoginRequest("admin", "admin123"));
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
        Assert.NotNull(payload);
        return payload!.Token;
    }

    private static async Task<Guid> CreatePublishedLiveEventAsync(HttpClient client)
    {
        var createResponse = await client.PostAsJsonAsync("/api/live-events", new CreateLiveEventRequest(
            "Integration Event",
            "Integration test event",
            DateTime.UtcNow.AddDays(1),
            DateTime.UtcNow.AddDays(1).AddHours(1),
            "https://zoom.example.com/j/integration",
            "GrantOnly",
            null,
            true));
        Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

        var eventId = await ReadGuidPropertyAsync(createResponse, "id");

        var updateResponse = await client.PutAsJsonAsync($"/api/live-events/{eventId}", new UpdateLiveEventRequest(
            "Integration Event",
            "Integration test event",
            DateTime.UtcNow.AddDays(1),
            DateTime.UtcNow.AddDays(1).AddHours(1),
            "https://zoom.example.com/j/integration",
            null,
            "Scheduled",
            "GrantOnly",
            null,
            true,
            true));

        Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
        return eventId;
    }

    private static async Task<Guid> ReadGuidPropertyAsync(HttpResponseMessage response, string propertyName)
    {
        await using var stream = await response.Content.ReadAsStreamAsync();
        using var json = await JsonDocument.ParseAsync(stream);
        var raw = json.RootElement.GetProperty(propertyName).GetString();
        Assert.True(Guid.TryParse(raw, out var value));
        return value;
    }
}