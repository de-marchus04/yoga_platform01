using System.Text;
using System.Text.Json;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Yoga.Api.Data;
using Yoga.Api.Options;
using Yoga.Api.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console());

builder.WebHost.UseSentry(o =>
{
    o.Dsn = builder.Configuration["Sentry:Dsn"] ?? "";
    o.TracesSampleRate = 0.2;
    o.SendDefaultPii = false;
    o.Environment = builder.Environment.EnvironmentName;
});

var isDevelopment = builder.Environment.IsDevelopment() || builder.Environment.IsEnvironment("Testing");

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
        opts.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yoga Enterprise API (public vitrina)", Version = "v1" });
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication
var jwtSecret = builder.Configuration["AdminPortal:JwtSecret"] ?? "default-dev-secret-change-in-production!!";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yoga-api",
            ValidAudience = "yoga-client",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });
builder.Services.AddAuthorization();

builder.Services.Configure<StorageOptions>(builder.Configuration.GetSection(StorageOptions.SectionName));
builder.Services.Configure<SecurityOptions>(builder.Configuration.GetSection(SecurityOptions.SectionName));
builder.Services.Configure<AdminPortalOptions>(builder.Configuration.GetSection(AdminPortalOptions.SectionName));
builder.Services.Configure<ErrorTrackingOptions>(builder.Configuration.GetSection(ErrorTrackingOptions.SectionName));
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
        context.ProblemDetails.Extensions["path"] = context.HttpContext.Request.Path.Value;
    };
});

// Services
builder.Services.AddHttpClient<ITelegramService, TelegramService>();
builder.Services.AddScoped<LocalFileStorageService>();
builder.Services.AddScoped<S3FileStorageService>();
builder.Services.AddScoped<IFileStorageService>(sp =>
{
    var options = sp.GetRequiredService<IOptions<StorageOptions>>().Value;
    return options.Provider.Equals("S3", StringComparison.OrdinalIgnoreCase)
        ? sp.GetRequiredService<S3FileStorageService>()
        : sp.GetRequiredService<LocalFileStorageService>();
});
builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("database", tags: new[] { "ready" })
    .AddCheck<StorageHealthCheck>("storage", tags: new[] { "ready" });

builder.Services.AddCors(options =>
{
    var configuredOrigins = builder.Configuration
        .GetSection(SecurityOptions.SectionName)
        .GetSection(nameof(SecurityOptions.AllowedOrigins))
        .Get<string[]>();

    var allowedOrigins = (configuredOrigins is { Length: > 0 }
            ? configuredOrigins
            : isDevelopment
                ? new[]
                {
                    "http://localhost:5190",
                    "https://localhost:5190",
                    "http://localhost:5293",
                    "https://localhost:5293"
                }
                : Array.Empty<string>())
        .Where(origin => !string.IsNullOrWhiteSpace(origin))
        .Select(origin => origin.Trim().TrimEnd('/'))
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToArray();

    if (!isDevelopment && allowedOrigins.Length == 0)
    {
        throw new InvalidOperationException("Security:AllowedOrigins must be configured for non-development environments.");
    }

    options.AddPolicy("AppCors", policy =>
    {
        if (allowedOrigins.Length == 0)
        {
            return;
        }

        policy.WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Rate Limiting
builder.Services.AddRateLimiter(opts =>
{
    opts.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    opts.AddFixedWindowLimiter("leads", o =>
    {
        o.PermitLimit = 5;
        o.Window = TimeSpan.FromMinutes(1);
        o.QueueLimit = 0;
    });
    opts.AddFixedWindowLimiter("validation", o =>
    {
        o.PermitLimit = 30;
        o.Window = TimeSpan.FromMinutes(1);
        o.QueueLimit = 0;
    });
    opts.AddFixedWindowLimiter("global", o =>
    {
        o.PermitLimit = 100;
        o.Window = TimeSpan.FromMinutes(1);
        o.QueueLimit = 0;
    });
    opts.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 200,
                Window = TimeSpan.FromMinutes(1)
            }));
});

var app = builder.Build();

// Auto-apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (app.Environment.IsEnvironment("Testing"))
        db.Database.EnsureCreated();
    else
    {
        Log.Information("Applying pending EF migrations...");
        db.Database.Migrate();
        Log.Information("Database migrations applied successfully");
    }
}

var startupLogger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Startup");
var startupSecurityOptions = app.Services.GetRequiredService<IOptions<SecurityOptions>>().Value;
var startupErrorTrackingOptions = app.Services.GetRequiredService<IOptions<ErrorTrackingOptions>>().Value;
startupLogger.LogInformation(
    "Application starting. Environment: {Environment}. AllowedOrigins: {AllowedOrigins}. ErrorTrackingEnabled: {ErrorTrackingEnabled}. ErrorTrackingProvider: {ErrorTrackingProvider}",
    app.Environment.EnvironmentName,
    startupSecurityOptions.AllowedOrigins,
    startupErrorTrackingOptions.Enabled,
    startupErrorTrackingOptions.Provider);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();

app.UseExceptionHandler(exceptionApp =>
{
    exceptionApp.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("UnhandledException");
        logger.LogError(
            exceptionFeature?.Error,
            "Unhandled exception for {Method} {Path}. TraceId: {TraceId}",
            context.Request.Method,
            context.Request.Path.Value,
            context.TraceIdentifier);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await Results.Problem(
            title: "Unexpected server error",
            detail: "An unexpected error occurred. Use the traceId for support and diagnostics.",
            statusCode: StatusCodes.Status500InternalServerError,
            extensions: new Dictionary<string, object?>
            {
                ["traceId"] = context.TraceIdentifier,
                ["path"] = context.Request.Path.Value
            }).ExecuteAsync(context);
    });
});

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseSentryTracing();

var securityOptions = app.Services.GetRequiredService<IOptions<SecurityOptions>>().Value;
if (!app.Environment.IsDevelopment() && securityOptions.EnableHsts)
{
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.TryAdd("X-Content-Type-Options", "nosniff");
    context.Response.Headers.TryAdd("X-Frame-Options", "DENY");
    context.Response.Headers.TryAdd("Referrer-Policy", "strict-origin-when-cross-origin");
    context.Response.Headers.TryAdd("Permissions-Policy", "camera=(), microphone=(), geolocation=()");
    context.Response.Headers.TryAdd("Content-Security-Policy",
        "default-src 'self'; script-src 'self' 'unsafe-eval' 'unsafe-inline'; " +
        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com; " +
        "font-src 'self' https://fonts.gstatic.com; " +
        "img-src 'self' data: https: blob:; " +
        "connect-src 'self' https://api.medisha.space; " +
        "frame-ancestors 'none'");
    await next();
});

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseCors("AppCors");

app.UseAuthentication();
app.UseAuthorization();

app.UseRateLimiter();

app.UseStaticFiles();

app.MapControllers();
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false,
    ResponseWriter = WriteHealthResponseAsync
});
app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = registration => registration.Tags.Contains("ready"),
    ResponseWriter = WriteHealthResponseAsync
});

app.Run();

static Task WriteHealthResponseAsync(HttpContext context, HealthReport report)
{
    context.Response.ContentType = "application/json";

    var payload = new
    {
        status = report.Status.ToString(),
        totalDuration = report.TotalDuration.TotalMilliseconds,
        checks = report.Entries.ToDictionary(
            entry => entry.Key,
            entry => new
            {
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description,
                duration = entry.Value.Duration.TotalMilliseconds,
                error = entry.Value.Exception?.Message
            })
    };

    return context.Response.WriteAsync(JsonSerializer.Serialize(payload));
}

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }
