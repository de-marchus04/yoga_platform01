using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Yoga.Api.Tests.TestInfrastructure;
using Yoga.Shared.Models;

namespace Yoga.Api.Tests.Integration;

public class LeadsApiTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly TestWebApplicationFactory _factory;

    public LeadsApiTests(TestWebApplicationFactory factory) => _factory = factory;

    [Fact]
    public async Task PostLead_Returns_Ok()
    {
        await _factory.ResetDatabaseAsync();
        using var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost")
        });

        var lead = new Lead
        {
            Name = "Test User",
            ContactDetails = "+380501112233",
            Messager = "Phone",
            Comment = "Hello"
        };

        var response = await client.PostAsJsonAsync("/api/leads", lead);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
