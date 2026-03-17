using Microsoft.JSInterop;

namespace Yoga.Client.Services;

public class ThemeService
{
    public bool IsDark { get; private set; }
    public event Action? OnThemeChanged;

    private bool _initialized = false;

    public async Task InitAsync(IJSRuntime js)
    {
        if (_initialized) return;
        _initialized = true;

        var saved = await js.InvokeAsync<string?>("localStorage.getItem", "yl-theme");
        IsDark = saved == "dark";
        // FOUC prevention script already applied data-theme on load,
        // but we re-apply here to keep Blazor's DOM state in sync.
        await ApplyAsync(js);
    }

    public async Task ToggleAsync(IJSRuntime js)
    {
        IsDark = !IsDark;
        await ApplyAsync(js);
        OnThemeChanged?.Invoke();
    }

    private async Task ApplyAsync(IJSRuntime js)
    {
        var theme = IsDark ? "dark" : "light";
        await js.InvokeVoidAsync("ylSetTheme", theme);
    }
}
