using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Yoga.Client;
using Yoga.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Default HTTP client
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Typed API client pointing to our backend API (using http locally to avoid SSL cert issues in browser)
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5293/"); 
}).AddHttpMessageHandler<HttpErrorInterceptor>();

// Named HTTP client for API (used by LocalizationService)
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5293/");
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
    client.BaseAddress = new Uri("http://localhost:5293/");
}).AddHttpMessageHandler<AdminHttpHandler>()
  .AddHttpMessageHandler<HttpErrorInterceptor>();

// User API client with JWT handler
builder.Services.AddHttpClient<UserApiService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5293/");
}).AddHttpMessageHandler<UserHttpHandler>()
  .AddHttpMessageHandler<HttpErrorInterceptor>();

await builder.Build().RunAsync();
