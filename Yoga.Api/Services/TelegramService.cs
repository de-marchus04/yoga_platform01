using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Yoga.Shared.Models;

namespace Yoga.Api.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ILogger<TelegramService> _logger;

        public TelegramService(HttpClient httpClient, IConfiguration config, ILogger<TelegramService> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;
        }

        public async Task SendLeadNotificationAsync(Lead lead)
        {
            var botToken = _config["TelegramSettings:BotToken"];
            var chatId = _config["TelegramSettings:ChatId"];

            if (string.IsNullOrEmpty(botToken) || string.IsNullOrEmpty(chatId) || botToken == "YOUR_TELEGRAM_BOT_TOKEN_HERE")
            {
                _logger.LogWarning("Telegram is not configured. Skipping notification.");
                return;
            }

            var message = $"🔔 <b>Новая заявка!</b>\n\n" +
                          $"<b>Имя:</b> {lead.Name}\n" +
                          $"<b>Контакты:</b> {lead.ContactDetails}\n" +
                          $"<b>Мессенджер:</b> {lead.Messager}\n" +
                          $"<b>Комментарий:</b> {lead.Comment}\n";

            var url = $"https://api.telegram.org/bot{botToken}/sendMessage";
            var payload = new
            {
                chat_id = chatId,
                text = message,
                parse_mode = "HTML"
            };

            var response = await _httpClient.PostAsJsonAsync(url, payload);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to send Telegram notification.");
            }
        }
    }
}
