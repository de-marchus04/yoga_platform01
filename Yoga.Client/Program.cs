using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Yoga.Client;
using Yoga.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUri = ResolveApiBaseUri(builder);

// Default HTTP client
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Typed API client pointing to our backend API.
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = apiBaseUri;
}).AddHttpMessageHandler<HttpErrorInterceptor>();

// Named HTTP client for API (used by LocalizationService)
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = apiBaseUri;
});

// Theme & Localisation services
builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<LocalizationService>(sp =>
{
    var staticHttp = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    var apiHttp = sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient");
    return new LocalizationService(staticHttp, apiHttp);
});

// SignalR blog hub service (singleton — persists across page navigations)
builder.Services.AddSingleton<BlogHubService>();

// Toast service
builder.Services.AddScoped<ToastService>();

// Modal service
builder.Services.AddScoped<Yoga.Client.Services.ModalService>();

// Catalog State service
builder.Services.AddScoped<Yoga.Client.Services.CatalogStateService>();

// Auth services
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CompositeAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CompositeAuthStateProvider>());
builder.Services.AddScoped<AdminAuthService>();
builder.Services.AddScoped<UserAuthService>();
builder.Services.AddTransient<AdminHttpHandler>();
builder.Services.AddTransient<UserHttpHandler>();
builder.Services.AddTransient<HttpErrorInterceptor>();

// Admin API client with JWT handler and Error Interceptor
builder.Services.AddHttpClient<AdminApiService>(client =>
{
        client.BaseAddress = apiBaseUri;
}).AddHttpMessageHandler<AdminHttpHandler>()
  .AddHttpMessageHandler<HttpErrorInterceptor>();

// User API client with JWT handler
builder.Services.AddHttpClient<UserApiService>(client =>
{
        client.BaseAddress = apiBaseUri;
}).AddHttpMessageHandler<UserHttpHandler>()
  .AddHttpMessageHandler<HttpErrorInterceptor>();

var host = builder.Build();

// Pre-load translations before first render to avoid flash of translation keys
var locService = host.Services.GetRequiredService<LocalizationService>();
var jsRuntime = host.Services.GetRequiredService<Microsoft.JSInterop.IJSRuntime>();
await locService.InitAsync(jsRuntime);

await host.RunAsync();

static Uri ResolveApiBaseUri(WebAssemblyHostBuilder builder)
{
    var config = builder.Configuration;
    var hostBaseUri = new Uri(builder.HostEnvironment.BaseAddress);

    var configuredBaseUrl = config["Api:BaseUrl"];
    if (!string.IsNullOrWhiteSpace(configuredBaseUrl))
    {
        if (Uri.TryCreate(configuredBaseUrl, UriKind.Absolute, out var absoluteUri))
        {
            return EnsureTrailingSlash(absoluteUri);
        }

        return EnsureTrailingSlash(new Uri(hostBaseUri, configuredBaseUrl));
    }

    if (bool.TryParse(config["Api:UseCurrentHost"], out var useCurrentHost) && useCurrentHost)
    {
        var scheme = config["Api:Scheme"];
        var uriBuilder = new UriBuilder(hostBaseUri)
        {
            Path = "/"
        };

        if (!string.IsNullOrWhiteSpace(scheme))
        {
            uriBuilder.Scheme = scheme;
        }

        if (int.TryParse(config["Api:Port"], out var port))
        {
            uriBuilder.Port = port;
        }

        return EnsureTrailingSlash(uriBuilder.Uri);
    }

    return EnsureTrailingSlash(hostBaseUri);
}

static Uri EnsureTrailingSlash(Uri uri)
{
    var value = uri.AbsoluteUri;
    return value.EndsWith('/') ? uri : new Uri(value + "/");
}
