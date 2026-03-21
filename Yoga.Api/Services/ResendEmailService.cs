using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Yoga.Api.Services
{
    public class ResendEmailService : IEmailService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly ILogger<ResendEmailService> _logger;

        public ResendEmailService(IConfiguration config, IHttpClientFactory httpFactory, ILogger<ResendEmailService> logger)
        {
            _http = httpFactory.CreateClient("Resend");
            _apiKey = config["Resend:ApiKey"] ?? "";
            _fromEmail = config["Resend:FromEmail"] ?? "noreply@medisha.space";
            _fromName = config["Resend:FromName"] ?? "Shakti Ashram";
            _logger = logger;
        }

        public async Task SendPasswordResetAsync(string toEmail, string toName, string resetUrl)
        {
            var html = $"""
            <div style="font-family:'Jost',Helvetica,Arial,sans-serif;max-width:560px;margin:0 auto;padding:40px 24px;color:#1e1c1a">
                <h2 style="font-family:'Cormorant Garamond',Georgia,serif;color:#8C6B3A;font-weight:500;margin-bottom:16px">Сброс пароля</h2>
                <p>Здравствуйте, {toName}!</p>
                <p>Вы запросили сброс пароля. Нажмите кнопку ниже для установки нового пароля:</p>
                <div style="text-align:center;margin:32px 0">
                    <a href="{resetUrl}" style="display:inline-block;padding:14px 32px;background:#8C6B3A;color:#fff;text-decoration:none;border-radius:8px;font-weight:500">Установить новый пароль</a>
                </div>
                <p style="font-size:0.85rem;color:#888">Ссылка действительна 1 час. Если вы не запрашивали сброс, проигнорируйте это письмо.</p>
            </div>
            """;

            await SendAsync(toEmail, "Сброс пароля — Shakti Ashram", html);
        }

        public async Task SendWelcomeAsync(string toEmail, string toName)
        {
            var html = $"""
            <div style="font-family:'Jost',Helvetica,Arial,sans-serif;max-width:560px;margin:0 auto;padding:40px 24px;color:#1e1c1a">
                <h2 style="font-family:'Cormorant Garamond',Georgia,serif;color:#8C6B3A;font-weight:500;margin-bottom:16px">Добро пожаловать!</h2>
                <p>Здравствуйте, {toName}!</p>
                <p>Ваш аккаунт в Shakti Ashram успешно создан. Теперь вы можете войти в личный кабинет:</p>
                <div style="text-align:center;margin:32px 0">
                    <a href="https://www.medisha.space/account/login" style="display:inline-block;padding:14px 32px;background:#8C6B3A;color:#fff;text-decoration:none;border-radius:8px;font-weight:500">Войти в кабинет</a>
                </div>
            </div>
            """;

            await SendAsync(toEmail, "Добро пожаловать в Shakti Ashram", html);
        }

        public async Task SendAccessGrantedAsync(string toEmail, string toName, string productName)
        {
            var html = $"""
            <div style="font-family:'Jost',Helvetica,Arial,sans-serif;max-width:560px;margin:0 auto;padding:40px 24px;color:#1e1c1a">
                <h2 style="font-family:'Cormorant Garamond',Georgia,serif;color:#8C6B3A;font-weight:500;margin-bottom:16px">Доступ открыт</h2>
                <p>Здравствуйте, {toName}!</p>
                <p>Вам предоставлен доступ к: <strong>{productName}</strong></p>
                <div style="text-align:center;margin:32px 0">
                    <a href="https://www.medisha.space/account/products" style="display:inline-block;padding:14px 32px;background:#8C6B3A;color:#fff;text-decoration:none;border-radius:8px;font-weight:500">Перейти к продукту</a>
                </div>
            </div>
            """;

            await SendAsync(toEmail, $"Доступ к «{productName}» — Shakti Ashram", html);
        }

        private async Task SendAsync(string to, string subject, string html)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                _logger.LogWarning("Resend API key not configured — email to {To} not sent", to);
                return;
            }

            var payload = new
            {
                from = $"{_fromName} <{_fromEmail}>",
                to = new[] { to },
                subject,
                html
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.resend.com/emails")
            {
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            try
            {
                var response = await _http.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Resend API error {Status}: {Body}", response.StatusCode, body);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email via Resend to {To}", to);
            }
        }
    }
}
