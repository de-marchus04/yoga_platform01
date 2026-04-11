using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.JSInterop;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Client.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;

        public ApiService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
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

        public Task<AdminCurrentUserDto?> AdminGetCurrentUserAsync()
            => SendAdminAsync<AdminCurrentUserDto>(HttpMethod.Get, "api/admin/me");

        public Task<AdminDashboardDto?> AdminGetDashboardAsync()
            => SendAdminAsync<AdminDashboardDto>(HttpMethod.Get, "api/admin/cms/dashboard");

        public Task<AdminCatalogSectionDto?> AdminGetCatalogAsync(string section, string lang = "uk")
            => SendAdminAsync<AdminCatalogSectionDto>(HttpMethod.Get, $"api/admin/cms/catalog/{section}?lang={Uri.EscapeDataString(lang)}");

        public Task<AdminContentEditorDto?> AdminGetEditorTemplateAsync(string section)
            => SendAdminAsync<AdminContentEditorDto>(HttpMethod.Get, $"api/admin/cms/editor/{section}/new");

        public Task<AdminContentEditorDto?> AdminGetEditorAsync(string section, string slug)
            => SendAdminAsync<AdminContentEditorDto>(HttpMethod.Get, $"api/admin/cms/editor/{section}/{Uri.EscapeDataString(slug)}");

        public Task<AdminContentEditorDto?> AdminGetPreviewAsync(string section, string slug)
            => SendAdminAsync<AdminContentEditorDto>(HttpMethod.Get, $"api/admin/cms/preview/{section}/{Uri.EscapeDataString(slug)}");

        public Task<AdminContentEditorDto?> AdminCreateEditorContentAsync(string section, AdminContentSaveRequestDto request)
            => SendAdminAsync<AdminContentEditorDto>(HttpMethod.Post, $"api/admin/cms/editor/{section}", request);

        public Task<AdminContentEditorDto?> AdminUpdateEditorContentAsync(string section, Guid id, AdminContentSaveRequestDto request)
            => SendAdminAsync<AdminContentEditorDto>(HttpMethod.Put, $"api/admin/cms/editor/{section}/{id}", request);

        public Task<AdminCourseEditorDto?> AdminGetNewCourseEditorAsync()
            => SendAdminAsync<AdminCourseEditorDto>(HttpMethod.Get, "api/admin/cms/course-editor/new");

        public Task<AdminCourseEditorDto?> AdminGetCourseEditorAsync(string slug)
            => SendAdminAsync<AdminCourseEditorDto>(HttpMethod.Get, $"api/admin/cms/course-editor/{Uri.EscapeDataString(slug)}");

        public Task<AdminCourseEditorDto?> AdminCreateCourseEditorAsync(AdminCourseSaveRequestDto request)
            => SendAdminAsync<AdminCourseEditorDto>(HttpMethod.Post, "api/admin/cms/course-editor", request);

        public Task<AdminCourseEditorDto?> AdminUpdateCourseEditorAsync(Guid id, AdminCourseSaveRequestDto request)
            => SendAdminAsync<AdminCourseEditorDto>(HttpMethod.Put, $"api/admin/cms/course-editor/{id}", request);

        public Task<AdminBootstrapResponse?> AdminBootstrapSampleContentAsync()
            => SendAdminAsync<AdminBootstrapResponse>(HttpMethod.Post, "api/admin/cms/bootstrap-test-content");

        // --- Leads ---
        public Task<AdminLeadsListDto?> AdminGetLeadsAsync(int page = 1, int pageSize = 30, int? status = null)
        {
            var url = $"api/admin/cms/leads?page={page}&pageSize={pageSize}";
            if (status.HasValue) url += $"&status={status.Value}";
            return SendAdminAsync<AdminLeadsListDto>(HttpMethod.Get, url);
        }

        public Task<AdminLeadDto?> AdminUpdateLeadAsync(Guid id, AdminLeadUpdateRequest request)
            => SendAdminAsync<AdminLeadDto>(HttpMethod.Put, $"api/admin/cms/leads/{id}", request);

        // --- Media ---
        public Task<AdminMediaListDto?> AdminGetMediaAsync(int page = 1, int pageSize = 40, string? q = null)
        {
            var url = $"api/admin/cms/media?page={page}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(q)) url += $"&q={Uri.EscapeDataString(q)}";
            return SendAdminAsync<AdminMediaListDto>(HttpMethod.Get, url);
        }

        public async Task<AdminMediaFileDto?> AdminUploadMediaAsync(Stream fileStream, string fileName, string contentType)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, "api/admin/cms/media/upload");
                var token = await GetAdminTokenAsync();
                if (!string.IsNullOrWhiteSpace(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(fileStream), "file", fileName);
                request.Content = content;

                using var response = await _http.SendAsync(request);
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadFromJsonAsync<AdminMediaFileDto>();
            }
            catch { return null; }
        }

        public Task<AdminMediaFileDto?> AdminUploadMediaFromUrlAsync(string imageUrl)
            => SendAdminAsync<AdminMediaFileDto>(HttpMethod.Post, "api/admin/cms/media/upload-url", new { Url = imageUrl });

        public Task<AdminMediaFileDto?> AdminUpdateMediaAltAsync(Guid id, string? altText)
            => SendAdminAsync<AdminMediaFileDto>(HttpMethod.Put, $"api/admin/cms/media/{id}/alt", new AdminMediaAltUpdateRequest(altText));

        public async Task<bool> AdminDeleteMediaAsync(Guid id)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Delete, $"api/admin/cms/media/{id}");
                var token = await GetAdminTokenAsync();
                if (!string.IsNullOrWhiteSpace(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await _http.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        // --- Translations ---
        public Task<AdminTranslationWorkspaceDto?> AdminGetTranslationWorkspaceAsync()
            => SendAdminAsync<AdminTranslationWorkspaceDto>(HttpMethod.Get, "api/admin/cms/translations/workspace");

        public Task<IReadOnlyList<AdminUiTranslationRowDto>?> AdminGetUiTranslationsAsync()
            => SendAdminAsync<IReadOnlyList<AdminUiTranslationRowDto>>(HttpMethod.Get, "api/admin/cms/translations/ui");

        public async Task<bool> AdminSaveUiTranslationsAsync(Dictionary<string, Dictionary<string, string>> rows)
        {
            var result = await SendAdminAsync<object>(HttpMethod.Post, "api/admin/cms/translations/ui",
                new AdminUiTranslationSaveRequest(rows));
            return true;
        }

        private async Task<T?> SendAdminAsync<T>(HttpMethod method, string url, object? body = null)
        {
            try
            {
                using var request = new HttpRequestMessage(method, url);
                var token = await GetAdminTokenAsync();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                if (body is not null)
                {
                    request.Content = JsonContent.Create(body);
                }

                using var response = await _http.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    return default;
                }

                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch
            {
                return default;
            }
        }

        private async Task<string?> GetAdminTokenAsync()
        {
            try
            {
                return await _js.InvokeAsync<string?>("localStorage.getItem", "yl-admin-token");
            }
            catch
            {
                return null;
            }
        }
    }
}
