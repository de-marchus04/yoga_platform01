using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Yoga.Api.Data;
using Yoga.Api.Services;
using Yoga.Shared.Models;

namespace Yoga.Api.Tests.TestInfrastructure;

public class TestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private SqliteConnection _connection = null!;

    public TestWebApplicationFactory()
    {
        Environment.SetEnvironmentVariable("JwtSettings__SecretKey", "TestingSecretKeyForJwtTokenGeneration123!");
        Environment.SetEnvironmentVariable("JwtSettings__Issuer", "YogaEnterpriseApi");
        Environment.SetEnvironmentVariable("JwtSettings__Audience", "YogaEnterpriseClient");
        Environment.SetEnvironmentVariable("JwtSettings__ExpiryMinutes", "1440");
        Environment.SetEnvironmentVariable("Security__AllowedOrigins__0", "https://localhost");
        Environment.SetEnvironmentVariable("Security__EnableHsts", "false");
        Environment.SetEnvironmentVariable("ErrorTracking__Enabled", "false");
        Environment.SetEnvironmentVariable("Storage__Provider", "Local");
        Environment.SetEnvironmentVariable("Storage__PublicBaseUrl", "/uploads");
        Environment.SetEnvironmentVariable("Storage__PublicHost", "https://localhost");
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureAppConfiguration((_, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Storage:Provider"] = "Local",
                ["Storage:LocalRootPath"] = Path.Combine(Path.GetTempPath(), "yoga-life-tests", Guid.NewGuid().ToString("N")),
                ["Storage:PublicBaseUrl"] = "/uploads",
                ["Storage:PublicHost"] = "https://localhost"
            });
        });

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
            services.RemoveAll(typeof(AppDbContext));
            services.RemoveAll(typeof(ITelegramService));

            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite(_connection));
            services.AddSingleton<ITelegramService, FakeTelegramService>();
        });
    }

    public async Task InitializeAsync()
    {
        using var scope = Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
    }

    public new async Task DisposeAsync()
    {
        if (_connection != null)
            await _connection.DisposeAsync();
    }

    public async Task ResetDatabaseAsync()
    {
        using var scope = Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
    }

    private sealed class FakeTelegramService : ITelegramService
    {
        public Task SendLeadNotificationAsync(Lead lead) => Task.CompletedTask;
    }
}