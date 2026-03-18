using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Yoga.Shared.DTOs;

namespace Yoga.Client.Services
{
    public class AdminAuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private readonly AuthenticationStateProvider _authStateProvider;

        private const string TokenKey = "yl-admin-token";

        public AdminAuthService(IHttpClientFactory httpFactory, IJSRuntime js, AuthenticationStateProvider authStateProvider)
        {
            _http = httpFactory.CreateClient("ApiClient");
            _js = js;
            _authStateProvider = authStateProvider;
        }

        public async Task<(bool Success, string? Error)> LoginAsync(string username, string password)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/login", new LoginRequest(username, password));
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<JsonElement>();
                    var msg = error.TryGetProperty("message", out var m) ? m.GetString() : "Login failed";
                    return (false, msg);
                }

                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (result is null) return (false, "Empty response");

                await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, result.Token);
                if (_authStateProvider is CompositeAuthStateProvider composite)
                    composite.NotifyAdminAuthentication(result.Token);
                else if (_authStateProvider is AdminAuthStateProvider admin)
                    admin.NotifyUserAuthentication(result.Token);

                return (true, null);
            }
            catch (HttpRequestException)
            {
                return (false, "Не удалось связаться с API администратора. Проверьте, что frontend развернут с корректным Api.PublicBaseUrl и что backend доступен по HTTPS.");
            }
            catch (TaskCanceledException)
            {
                return (false, "Запрос к API администратора превысил таймаут. Проверьте доступность backend и сетевые настройки.");
            }
            catch (JsonException)
            {
                return (false, "API администратора вернул некорректный ответ. Обычно это означает, что frontend обращается не к backend, а к HTML-странице или proxy-заглушке.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task LogoutAsync()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            if (_authStateProvider is CompositeAuthStateProvider composite)
                composite.NotifyLogout();
            else if (_authStateProvider is AdminAuthStateProvider admin)
                admin.NotifyUserLogout();
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);
        }
    }
}
