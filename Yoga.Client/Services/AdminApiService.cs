using System.Net.Http.Json;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Client.Services
{
    public class AdminApiService
    {
        private readonly HttpClient _http;

        public AdminApiService(HttpClient http)
        {
            _http = http;
        }

        // Dashboard
        public async Task<DashboardDto?> GetDashboardAsync()
        {
            return await _http.GetFromJsonAsync<DashboardDto>("api/admin/dashboard");
        }

        public async Task<PublicContentResetPreviewDto?> GetPublicContentResetPreviewAsync()
        {
            return await _http.GetFromJsonAsync<PublicContentResetPreviewDto>("api/admin/content/public-reset-preview");
        }

        public async Task<PublicContentResetResultDto?> ResetPublicContentAsync()
        {
            var response = await _http.PostAsync("api/admin/content/reset-public", null);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PublicContentResetResultDto>();
        }

        // Leads
        public async Task<PaginatedResult<LeadSummaryDto>?> GetLeadsAsync(int page = 1, int pageSize = 20, string? filter = null)
        {
            var url = $"api/leads?page={page}&pageSize={pageSize}";
            if (!string.IsNullOrEmpty(filter)) url += $"&filter={filter}";
            return await _http.GetFromJsonAsync<PaginatedResult<LeadSummaryDto>>(url);
        }

        public async Task<bool> MarkLeadProcessedAsync(Guid id, bool processed)
        {
            var response = await _http.PutAsync($"api/leads/{id}/process?processed={processed}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateLeadStatusAsync(Guid id, string status)
        {
            var response = await _http.PutAsJsonAsync($"api/leads/{id}/status", status);
            return response.IsSuccessStatusCode;
        }
        
        public async Task<bool> UpdateLeadNotesAsync(Guid id, string notes)
        {
            var response = await _http.PutAsJsonAsync($"api/leads/{id}/notes", notes);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLeadAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/leads/{id}");
            return response.IsSuccessStatusCode;
        }

        // Retreats (admin)
        public async Task<List<Retreat>> GetAllRetreatsAsync()
        {
            return await _http.GetFromJsonAsync<List<Retreat>>("api/retreats/all") ?? new();
        }

        public async Task<HttpResponseMessage> CreateRetreatAsync(Retreat retreat)
        {
            return await _http.PostAsJsonAsync("api/retreats", retreat);
        }

        public async Task<HttpResponseMessage> UpdateRetreatAsync(Guid id, Retreat retreat)
        {
            return await _http.PutAsJsonAsync($"api/retreats/{id}", retreat);
        }

        public async Task<bool> DeleteRetreatAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/retreats/{id}");
            return response.IsSuccessStatusCode;
        }

        // Blog (admin)
        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _http.GetFromJsonAsync<List<BlogPost>>("api/blog/all") ?? new();
        }

        public async Task<HttpResponseMessage> CreateBlogPostAsync(BlogPost post)
        {
            return await _http.PostAsJsonAsync("api/blog", post);
        }

        public async Task<HttpResponseMessage> UpdateBlogPostAsync(Guid id, BlogPost post)
        {
            return await _http.PutAsJsonAsync($"api/blog/{id}", post);
        }

        public async Task<bool> DeleteBlogPostAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/blog/{id}");
            return response.IsSuccessStatusCode;
        }

        // Translations
        public async Task<List<Translation>> GetEntityTranslationsAsync(string entityType, Guid entityId)
        {
            return await _http.GetFromJsonAsync<List<Translation>>($"api/translations/{entityType}/{entityId}/all") ?? new();
        }

        public async Task<HttpResponseMessage> UpsertEntityTranslationAsync(Translation translation)
        {
            return await _http.PutAsJsonAsync("api/translations/entity", translation);
        }

        // Courses (admin)
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _http.GetFromJsonAsync<List<Course>>("api/courses/all") ?? new();
        }

        public async Task<HttpResponseMessage> CreateCourseAsync(Course course)
        {
            return await _http.PostAsJsonAsync("api/courses", course);
        }

        public async Task<HttpResponseMessage> UpdateCourseAsync(Guid id, Course course)
        {
            return await _http.PutAsJsonAsync($"api/courses/{id}", course);
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/courses/{id}");
            return response.IsSuccessStatusCode;
        }

        // Consultations (admin)
        public async Task<List<Consultation>> GetAllConsultationsAsync()
        {
            return await _http.GetFromJsonAsync<List<Consultation>>("api/consultations/all") ?? new();
        }

        public async Task<HttpResponseMessage> CreateConsultationAsync(Consultation item)
        {
            return await _http.PostAsJsonAsync("api/consultations", item);
        }

        public async Task<HttpResponseMessage> UpdateConsultationAsync(Guid id, Consultation item)
        {
            return await _http.PutAsJsonAsync($"api/consultations/{id}", item);
        }

        public async Task<bool> DeleteConsultationAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/consultations/{id}");
            return response.IsSuccessStatusCode;
        }

        // Site Pages (admin)
        public async Task<List<SitePage>> GetAllSitePagesAsync()
        {
            return await _http.GetFromJsonAsync<List<SitePage>>("api/sitepages") ?? new();
        }

        public async Task<bool> CreateSitePageAsync(SitePage page)
        {
            var response = await _http.PostAsJsonAsync("api/sitepages", page);
            return response.IsSuccessStatusCode;
        }

        // Media
        public async Task<List<MediaFile>> GetAllMediaAsync(string? entityType = null)
        {
            var url = string.IsNullOrEmpty(entityType) ? "api/media" : $"api/media?entityType={entityType}";
            return await _http.GetFromJsonAsync<List<MediaFile>>(url) ?? new();
        }

        public async Task<MediaFile?> UploadMediaAsync(MultipartFormDataContent content)
        {
            var response = await _http.PostAsync("api/media/upload", content);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<MediaFile>();
            return null;
        }

        public async Task<bool> UpdateMediaAsync(MediaFile media)
        {
            var response = await _http.PutAsJsonAsync($"api/media/{media.Id}", media);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMediaAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/media/{id}");
            return response.IsSuccessStatusCode;
        }

        // Admin users
        public async Task<List<AdminUserDto>> GetAdminUsersAsync()
        {
            return await _http.GetFromJsonAsync<List<AdminUserDto>>("api/admin/users") ?? new();
        }

        public async Task<HttpResponseMessage> CreateAdminUserAsync(CreateAdminUserRequest request)
        {
            return await _http.PostAsJsonAsync("api/admin/users", request);
        }

        public async Task<(bool Success, string? Error)> ChangeAdminPasswordAsync(ChangePasswordRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/admin/users/change-password", request);
            if (response.IsSuccessStatusCode)
                return (true, null);

            try
            {
                var payload = await response.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();
                if (payload.TryGetProperty("message", out var message))
                    return (false, message.GetString());
            }
            catch
            {
            }

            return (false, $"Ошибка: {response.StatusCode}");
        }

        public async Task<bool> DeleteAdminUserAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/admin/users/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PaginatedResult<AdminAuditLogDto>?> GetAuditLogsAsync(
            int page = 1,
            int pageSize = 50,
            string? action = null,
            string? entityType = null,
            Guid? entityId = null)
        {
            var parameters = new List<string>
            {
                $"page={page}",
                $"pageSize={pageSize}"
            };

            if (!string.IsNullOrWhiteSpace(action))
                parameters.Add($"action={Uri.EscapeDataString(action)}");

            if (!string.IsNullOrWhiteSpace(entityType))
                parameters.Add($"entityType={Uri.EscapeDataString(entityType)}");

            if (entityId.HasValue)
                parameters.Add($"entityId={entityId.Value}");

            var url = $"api/admin/audit?{string.Join("&", parameters)}";
            return await _http.GetFromJsonAsync<PaginatedResult<AdminAuditLogDto>>(url);
        }

        // ── Customers ──

        public async Task<List<CustomerDto>> GetCustomersAsync(int page = 1, int pageSize = 20, string? search = null)
        {
            var url = $"api/admin/customers?page={page}&pageSize={pageSize}";
            if (!string.IsNullOrEmpty(search)) url += $"&search={Uri.EscapeDataString(search)}";
            return await _http.GetFromJsonAsync<List<CustomerDto>>(url) ?? new();
        }

        public async Task<CustomerDto?> GetCustomerAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<CustomerDto>($"api/admin/customers/{id}");
        }

        public async Task<(bool Success, string? Error)> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var r = await _http.PostAsJsonAsync("api/admin/customers", request);
            if (r.IsSuccessStatusCode) return (true, null);
            var err = await r.Content.ReadAsStringAsync();
            return (false, err);
        }

        public async Task<bool> ToggleCustomerActiveAsync(Guid id, bool isActive)
        {
            var r = await _http.PutAsync($"api/admin/customers/{id}/toggle-active?isActive={isActive}", null);
            return r.IsSuccessStatusCode;
        }

        public async Task<bool> CreateSubscriptionAsync(CreateSubscriptionRequest request)
        {
            var r = await _http.PostAsJsonAsync($"api/admin/customers/{request.CustomerId}/subscription", request);
            return r.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveSubscriptionAsync(Guid customerId)
        {
            var r = await _http.DeleteAsync($"api/admin/customers/{customerId}/subscription");
            return r.IsSuccessStatusCode;
        }

        // ── Access Grants ──

        public async Task<List<AccessGrantDto>> GetAccessGrantsAsync(int page = 1, int pageSize = 20, Guid? customerId = null)
        {
            var url = $"api/admin/access?page={page}&pageSize={pageSize}";
            if (customerId.HasValue) url += $"&customerId={customerId}";
            return await _http.GetFromJsonAsync<List<AccessGrantDto>>(url) ?? new();
        }

        public async Task<bool> CreateAccessGrantAsync(CreateAccessGrantRequest request)
        {
            var r = await _http.PostAsJsonAsync("api/admin/access", request);
            return r.IsSuccessStatusCode;
        }

        public async Task<bool> RevokeAccessGrantAsync(Guid id)
        {
            var r = await _http.PutAsync($"api/admin/access/{id}/revoke", null);
            return r.IsSuccessStatusCode;
        }

        // ── Premium Resources ──

        public async Task<List<PremiumResourceDto>> GetAllPremiumResourcesAsync()
        {
            return await _http.GetFromJsonAsync<List<PremiumResourceDto>>("api/premium-resources/all") ?? new();
        }

        public async Task<HttpResponseMessage> CreatePremiumResourceAsync(CreatePremiumResourceRequest request)
        {
            return await _http.PostAsJsonAsync("api/premium-resources", request);
        }

        public async Task<HttpResponseMessage> UpdatePremiumResourceAsync(Guid id, CreatePremiumResourceRequest request)
        {
            return await _http.PutAsJsonAsync($"api/premium-resources/{id}", request);
        }

        public async Task<bool> DeletePremiumResourceAsync(Guid id)
        {
            var r = await _http.DeleteAsync($"api/premium-resources/{id}");
            return r.IsSuccessStatusCode;
        }

        // ── Live Events ──

        public async Task<List<LiveEventDto>> GetAllLiveEventsAsync()
        {
            return await _http.GetFromJsonAsync<List<LiveEventDto>>("api/live-events/all") ?? new();
        }

        public async Task<LiveEventDetailDto?> GetLiveEventDetailAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<LiveEventDetailDto>($"api/live-events/admin/{id}");
        }

        public async Task<HttpResponseMessage> CreateLiveEventAsync(CreateLiveEventRequest request)
        {
            return await _http.PostAsJsonAsync("api/live-events", request);
        }

        public async Task<HttpResponseMessage> UpdateLiveEventAsync(Guid id, UpdateLiveEventRequest request)
        {
            return await _http.PutAsJsonAsync($"api/live-events/{id}", request);
        }

        public async Task<bool> DeleteLiveEventAsync(Guid id)
        {
            var r = await _http.DeleteAsync($"api/live-events/{id}");
            return r.IsSuccessStatusCode;
        }

        // ── Lead → Customer ──

        public async Task<(bool Success, string? Error)> CreateCustomerFromLeadAsync(Guid leadId, CreateCustomerFromLeadRequest request)
        {
            var r = await _http.PostAsJsonAsync($"api/leads/{leadId}/create-customer", request);
            if (r.IsSuccessStatusCode) return (true, null);
            var err = await r.Content.ReadAsStringAsync();
            return (false, err);
        }

        public async Task<bool> GrantAccessFromLeadAsync(Guid leadId, GrantAccessFromLeadRequest request)
        {
            var r = await _http.PostAsJsonAsync($"api/leads/{leadId}/grant-access", request);
            return r.IsSuccessStatusCode;
        }
    }
}
