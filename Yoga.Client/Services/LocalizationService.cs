using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace Yoga.Client.Services;

public class LocalizationService
{
    private static readonly TimeSpan ApiTranslationsTimeout = TimeSpan.FromSeconds(2);

    private readonly HttpClient _http;
    private readonly HttpClient _apiHttp;
    private Dictionary<string, string> _translations = new();
    private bool _initialized = false;

    public string CurrentLang { get; private set; } = "ru";
    public event Action? OnLanguageChanged;

    public LocalizationService(HttpClient http, HttpClient apiHttp)
    {
        _http = http;
        _apiHttp = apiHttp;
    }

    /// <summary>Returns the translation for key, or the key itself as fallback.</summary>
    public string this[string key] =>
        _translations.TryGetValue(key, out var val) ? val : key;

    public async Task InitAsync(IJSRuntime js)
    {
        if (_initialized) return;
        _initialized = true;

        var saved = await js.InvokeAsync<string?>("localStorage.getItem", "yl-lang");
        CurrentLang = saved is "ru" or "uk" or "en" ? saved : "ru";
        await LoadAsync(CurrentLang);
    }

    public async Task SetLanguageAsync(string lang, IJSRuntime js)
    {
        if (lang == CurrentLang && _initialized) return;
        CurrentLang = lang;
        await js.InvokeVoidAsync("localStorage.setItem", "yl-lang", lang);
        await LoadAsync(lang);
        OnLanguageChanged?.Invoke();
    }

    private async Task LoadAsync(string lang)
    {
        // Try loading from API first (PostgreSQL-backed translations)
        try
        {
            using var cts = new CancellationTokenSource(ApiTranslationsTimeout);
            var dict = await _apiHttp.GetFromJsonAsync<Dictionary<string, string>>($"api/translations/ui/{lang}", cts.Token);
            if (dict != null && dict.Count > 0)
            {
                _translations = dict;
                return;
            }
        }
        catch
        {
            // API unavailable or too slow — fall back to static JSON immediately.
        }

        // Fallback: load from static JSON files
        try
        {
            var dict = await _http.GetFromJsonAsync<Dictionary<string, string>>($"i18n/{lang}.json");
            _translations = dict ?? new();
        }
        catch
        {
            _translations = new();
        }
    }
}
