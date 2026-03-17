using System.Net.Http.Json;
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

        /// <summary>Base API URL for use by SignalR hub connection.</summary>
        public string ApiBaseUrl => _http.BaseAddress?.AbsoluteUri.TrimEnd('/') ?? "http://localhost:5293";

        // Retreats
        public async Task<List<RetreatDto>> GetActiveRetreatsAsync(string lang = "ru")
        {
            var result = await _http.GetFromJsonAsync<List<RetreatDto>>($"api/retreats?lang={lang}");
            return result ?? new List<RetreatDto>();
        }

        public async Task<List<RetreatDto>> GetUpcomingRetreatsAsync(string lang = "ru")
        {
            var result = await _http.GetFromJsonAsync<List<RetreatDto>>($"api/retreats/upcoming?lang={lang}");
            return result ?? new List<RetreatDto>();
        }

        public async Task<List<RetreatDto>> GetPastRetreatsAsync(string lang = "ru")
        {
            var result = await _http.GetFromJsonAsync<List<RetreatDto>>($"api/retreats/past?lang={lang}");
            return result ?? new List<RetreatDto>();
        }

        public async Task<RetreatDto?> GetRetreatByIdAsync(Guid id, string lang = "ru")
        {
            return await _http.GetFromJsonAsync<RetreatDto>($"api/retreats/{id}?lang={lang}");
        }

        // Leads
        public async Task<bool> SubmitLeadAsync(Lead lead)
        {
            var response = await _http.PostAsJsonAsync("api/leads", lead);
            return response.IsSuccessStatusCode;
        }

        // Courses
        public async Task<List<CourseDto>> GetCoursesAsync(string lang = "ru")
        {
            var result = await _http.GetFromJsonAsync<List<CourseDto>>($"api/courses?lang={lang}");
            return result ?? new();
        }

        public async Task<CourseDto?> GetCourseAsync(string slug, string lang = "ru")
        {
            return await _http.GetFromJsonAsync<CourseDto>($"api/courses/{slug}?lang={lang}");
        }

        // Consultations
        public async Task<List<ConsultationDto>> GetConsultationsAsync(string lang = "ru")
        {
            var result = await _http.GetFromJsonAsync<List<ConsultationDto>>($"api/consultations?lang={lang}");
            return result ?? new();
        }

        public async Task<ConsultationDto?> GetConsultationAsync(string slug, string lang = "ru")
        {
            return await _http.GetFromJsonAsync<ConsultationDto>($"api/consultations/{slug}?lang={lang}");
        }

        // Blog
        public async Task<List<BlogPostDto>> GetBlogPostsAsync(string lang = "ru", string? category = null, string? section = null, Guid? relatedEntityId = null)
        {
            var url = $"api/blog?lang={lang}";
            if (!string.IsNullOrEmpty(category)) url += $"&category={category}";
            if (!string.IsNullOrEmpty(section)) url += $"&section={section}";
            if (relatedEntityId.HasValue) url += $"&relatedEntityId={relatedEntityId}";
            var result = await _http.GetFromJsonAsync<List<BlogPostDto>>(url);
            return result ?? new();
        }

        public async Task<BlogPostDto?> GetBlogPostAsync(string slug, string lang = "ru")
        {
            return await _http.GetFromJsonAsync<BlogPostDto>($"api/blog/{slug}?lang={lang}");
        }

        // Site Pages
        public async Task<SitePageDto?> GetSitePageAsync(string slug, string lang = "ru")
        {
            return await _http.GetFromJsonAsync<SitePageDto>($"api/sitepages/{slug}?lang={lang}");
        }
    }
}
