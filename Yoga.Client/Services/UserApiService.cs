using System.Net.Http.Json;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Client.Services
{
    /// <summary>API service for authenticated customer cabinet operations.</summary>
    public class UserApiService
    {
        private readonly HttpClient _http;

        public UserApiService(HttpClient http) => _http = http;

        // ── Profile ──
        public async Task<CustomerDto?> GetMeAsync() =>
            await _http.GetFromJsonAsync<CustomerDto>("api/customer-auth/me");

        public async Task<bool> UpdateProfileAsync(CustomerProfileDto dto)
        {
            var r = await _http.PutAsJsonAsync("api/customer-auth/profile", dto);
            return r.IsSuccessStatusCode;
        }

        public async Task<(bool Success, string? Error)> ChangePasswordAsync(string current, string newPwd)
        {
            var r = await _http.PostAsJsonAsync("api/customer-auth/change-password",
                new CustomerChangePasswordRequest(current, newPwd));
            if (r.IsSuccessStatusCode) return (true, null);
            return (false, "Could not change password");
        }

        // ── Dashboard ──
        public async Task<MyDashboardDto?> GetDashboardAsync() =>
            await _http.GetFromJsonAsync<MyDashboardDto>("api/my/dashboard");

        // ── Access Grants ──
        public async Task<List<AccessGrantDto>> GetMyGrantsAsync() =>
            await _http.GetFromJsonAsync<List<AccessGrantDto>>("api/my/grants") ?? new();

        // ── Leads history ──
        public async Task<List<LeadSummaryDto>> GetMyLeadsAsync() =>
            await _http.GetFromJsonAsync<List<LeadSummaryDto>>("api/my/leads") ?? new();

        // ── Events ──
        public async Task<List<LiveEventDto>> GetMyEventsAsync() =>
            await _http.GetFromJsonAsync<List<LiveEventDto>>("api/my/events") ?? new();

        public async Task<LiveEventDetailDto?> WatchEventAsync(Guid id) =>
            await _http.GetFromJsonAsync<LiveEventDetailDto>($"api/live-events/{id}/watch");

        public async Task<LiveEventDetailDto?> GetLiveEventAccessAsync(Guid id) =>
            await _http.GetFromJsonAsync<LiveEventDetailDto>($"api/live-events/{id}/watch");

        // ── Premium Library ──
        public async Task<List<PremiumResourceDto>> GetPremiumResourcesAsync() =>
            await _http.GetFromJsonAsync<List<PremiumResourceDto>>("api/premium-resources") ?? new();

        // ── Course content (cabinet) ──
        public async Task<CourseDto?> GetMyCourseAsync(Guid courseId)
        {
            var r = await _http.GetAsync($"api/my/courses/{courseId}");
            if (!r.IsSuccessStatusCode) return null;
            return await r.Content.ReadFromJsonAsync<CourseDto>();
        }

        public async Task<ProtectedMediaAccessDto?> GetPremiumResourceAccessAsync(Guid id) =>
            await _http.GetFromJsonAsync<ProtectedMediaAccessDto>($"api/premium-resources/{id}/access");

        // ── Public events ──
        public async Task<List<LiveEventDto>> GetPublishedEventsAsync() =>
            await _http.GetFromJsonAsync<List<LiveEventDto>>("api/live-events") ?? new();

        // ── Password Reset ──
        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var r = await _http.PostAsJsonAsync("api/customer-auth/forgot-password",
                new ForgotPasswordRequest(email));
            return r.IsSuccessStatusCode;
        }

        public async Task<(bool Success, string? Error)> ResetPasswordAsync(string token, string newPassword)
        {
            var r = await _http.PostAsJsonAsync("api/customer-auth/reset-password",
                new ResetPasswordRequest(token, newPassword));
            if (r.IsSuccessStatusCode) return (true, null);
            return (false, "Недействительная или истёкшая ссылка");
        }

        // ── Access Check ──
        public async Task<AccessCheckResult?> CheckAccessAsync(Guid? courseId, Guid? consultationId)
        {
            var qs = new List<string>();
            if (courseId != null) qs.Add($"courseId={courseId}");
            if (consultationId != null) qs.Add($"consultationId={consultationId}");
            var r = await _http.GetAsync($"api/my/access-check?{string.Join("&", qs)}");
            if (!r.IsSuccessStatusCode) return null;
            return await r.Content.ReadFromJsonAsync<AccessCheckResult>();
        }
    }
}
