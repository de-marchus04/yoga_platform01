using System.Net.Http.Json;
using System.Text.Json;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Client.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public string ApiBaseUrl => _http.BaseAddress?.AbsoluteUri.TrimEnd('/') ?? string.Empty;

        public string ResolveMediaUrl(string? url)
        {
            if (string.IsNullOrEmpty(url) || url.StartsWith("http")) return url ?? "";
            return ApiBaseUrl + url;
        }

        private async Task<T?> GetSafeAsync<T>(string url)
        {
            try
            {
                return await _http.GetFromJsonAsync<T>(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[YLE] GET {url} HttpRequestException: {ex.Message}");
                return default;
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"[YLE] GET {url} TaskCanceledException: {ex.Message}");
                return default;
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"[YLE] GET {url} NotSupportedException: {ex.Message}");
                return default;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[YLE] GET {url} JsonException: {ex.Message}");
                return default;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[YLE] GET {url} InvalidOperationException: {ex.Message}");
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[YLE] GET {url} {ex.GetType().Name}: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> SubmitLeadAsync(Lead lead)
        {
            var response = await _http.PostAsJsonAsync("api/leads", lead);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CourseDto>> GetCoursesAsync(string lang = "uk")
        {
            var result = await GetSafeAsync<List<CourseDto>>($"api/courses?lang={lang}");
            return result ?? new();
        }

        public async Task<CourseDto?> GetCourseAsync(string slug, string lang = "uk")
        {
            return await GetSafeAsync<CourseDto>($"api/courses/{slug}?lang={lang}");
        }

        public async Task<List<ConsultationDto>> GetConsultationsAsync(string lang = "uk")
        {
            var result = await GetSafeAsync<List<ConsultationDto>>($"api/consultations?lang={lang}");
            return result ?? new();
        }

        public async Task<ConsultationDto?> GetConsultationAsync(string slug, string lang = "uk")
        {
            return await GetSafeAsync<ConsultationDto>($"api/consultations/{slug}?lang={lang}");
        }

        public async Task<SitePageDto?> GetSitePageAsync(string slug, string lang = "uk")
        {
            return await GetSafeAsync<SitePageDto>($"api/sitepages/{slug}?lang={lang}");
        }

        public async Task<bool> ValidateEmailDomainAsync(string domain)
        {
            try
            {
                var result = await GetSafeAsync<EmailValidationResult>(
                    $"api/validate-email?domain={Uri.EscapeDataString(domain)}");
                return result?.Valid ?? true;
            }
            catch
            {
                return true;
            }
        }

        private record EmailValidationResult(bool Valid, string? Reason = null);

        // --- Retreats ---
        public async Task<List<RetreatDto>> GetRetreatsAsync(string lang = "uk", string? period = null)
        {
            var url = $"api/retreats?lang={lang}";
            if (!string.IsNullOrEmpty(period)) url += $"&period={period}";
            var result = await GetSafeAsync<List<RetreatDto>>(url);
            return result ?? new();
        }

        public async Task<RetreatDto?> GetRetreatAsync(string slug, string lang = "uk")
        {
            return await GetSafeAsync<RetreatDto>($"api/retreats/{slug}?lang={lang}");
        }

        // --- Yagyas ---
        public async Task<List<YagyaDto>> GetYagyasAsync(string lang = "uk", string? period = null)
        {
            var url = $"api/yagyas?lang={lang}";
            if (!string.IsNullOrEmpty(period)) url += $"&period={period}";
            var result = await GetSafeAsync<List<YagyaDto>>(url);
            return result ?? new();
        }

        public async Task<YagyaDto?> GetYagyaAsync(string slug, string lang = "uk")
        {
            return await GetSafeAsync<YagyaDto>($"api/yagyas/{slug}?lang={lang}");
        }

        // --- Admin Auth ---
        public async Task<AdminLoginResponse?> AdminLoginAsync(string login, string password)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/admin/login", new AdminLoginRequest(login, password));
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadFromJsonAsync<AdminLoginResponse>();
            }
            catch
            {
                return null;
            }
        }
    }
}
