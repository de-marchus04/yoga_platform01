using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Yoga.Shared.DTOs;

namespace Yoga.Client.Services
{
    public class UserAuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private readonly AuthenticationStateProvider _authStateProvider;
        private const string TokenKey = "yl-user-token";

        public UserAuthService(IHttpClientFactory httpFactory, IJSRuntime js, AuthenticationStateProvider authStateProvider)
        {
            _http = httpFactory.CreateClient("ApiClient");
            _js = js;
            _authStateProvider = authStateProvider;
        }

        public async Task<(bool Success, string? Error)> LoginAsync(string email, string password)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/customer-auth/login",
                    new CustomerLoginRequest(email, password));
                if (!response.IsSuccessStatusCode)
                {
                    var err = await response.Content.ReadFromJsonAsync<JsonElement>();
                    var msg = err.TryGetProperty("message", out var m) ? m.GetString() : "Login failed";
                    return (false, msg);
                }

                var result = await response.Content.ReadFromJsonAsync<CustomerLoginResponse>();
                if (result is null) return (false, "Empty response");

                await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, result.Token);

                if (_authStateProvider is CompositeAuthStateProvider composite)
                    composite.NotifyUserAuthentication(result.Token);
                else if (_authStateProvider is UserAuthStateProvider userProvider)
                    userProvider.NotifyUserAuthentication(result.Token);

                return (true, null);
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public async Task LogoutAsync()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            if (_authStateProvider is CompositeAuthStateProvider composite)
                composite.NotifyLogout();
            else if (_authStateProvider is UserAuthStateProvider userProvider)
                userProvider.NotifyUserLogout();
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }
    }
}
