#!/bin/bash
FILE="Yoga.Client/Layout/MainLayout.razor"

# Desktop lang-switcher
sed -i '/<div class="lang-switcher">/,/<\/div>/c\                <LangSwitcher />' $FILE

# Mobile lang-switcher 
sed -i '/<div class="lang-switcher">/,/<\/div>/c\                <LangSwitcher />' $FILE

# Both theme toggles
sed -i 's/<button class="theme-toggle" @onclick="ToggleTheme">@(Theme.IsDark ? "☀" : "☾")<\/button>/<ThemeToggle \/>/g' $FILE

# Remove methods SetLang and ToggleTheme
sed -i '/private async Task SetLang(string lang) => await Loc.SetLanguageAsync(lang, JS);/d' $FILE
sed -i '/private async Task ToggleTheme() => await Theme.ToggleAsync(JS);/d' $FILE
