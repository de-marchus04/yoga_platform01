#!/bin/bash
FILE="Yoga.Client/Layout/MainLayout.razor"

awk '
{
    if (/<div class="lang-switcher">/) {
        print "                <LangSwitcher />"
        skip=1
    }
    
    if (skip && /<\/div>/) {
        skip=0
        next
    }
    
    if (!skip) {
        if (/<button class="theme-toggle"/) {
            print "                <ThemeToggle />"
        } else if (!/private async Task SetLang\(string lang\) => await Loc.SetLanguageAsync\(lang, JS\);/ && !/private async Task ToggleTheme\(\) => await Theme.ToggleAsync\(JS\);/) {
            print $0
        }
    }
}' "$FILE" > temp.razor
mv temp.razor "$FILE"
