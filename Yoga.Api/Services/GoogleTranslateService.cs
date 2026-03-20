using System.Text.Json;
using System.Web;

namespace Yoga.Api.Services
{
    public class GoogleTranslateService
    {
        private readonly HttpClient _http;

        public GoogleTranslateService(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        }

        /// <summary>
        /// Translate text from one language to another using Google's free endpoint.
        /// Handles pipe-separated values (Benefits) and tilde-separated ForWhom items.
        /// </summary>
        public async Task<string> TranslateAsync(string text, string from, string to)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            // Pipe-separated compound fields (Benefits, ForWhom)
            if (text.Contains('|') && !text.Contains('<'))
            {
                var parts = text.Split('|');
                var translated = new List<string>();
                foreach (var part in parts)
                {
                    if (part.Contains('~'))
                    {
                        var segments = part.Split('~', 2);
                        var tTitle = await TranslateSingleAsync(segments[0].Trim(), from, to);
                        var tText = segments.Length > 1 ? await TranslateSingleAsync(segments[1].Trim(), from, to) : "";
                        translated.Add($"{tTitle}~{tText}");
                    }
                    else
                    {
                        translated.Add(await TranslateSingleAsync(part.Trim(), from, to));
                    }
                }
                return string.Join("|", translated);
            }

            return await TranslateSingleAsync(text, from, to);
        }

        private async Task<string> TranslateSingleAsync(string text, string from, string to)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            var encoded = HttpUtility.UrlEncode(text);
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={from}&tl={to}&dt=t&q={encoded}";

            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            // Response structure: [[["translated","original",...],...],...] 
            var root = doc.RootElement;
            var sb = new System.Text.StringBuilder();
            foreach (var segment in root[0].EnumerateArray())
            {
                if (segment.GetArrayLength() > 0)
                    sb.Append(segment[0].GetString());
            }
            return sb.ToString();
        }
    }
}
