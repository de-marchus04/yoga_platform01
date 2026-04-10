# Publish Blazor WASM to ./publish, inject public API URL, deploy wwwroot to Vercel production.
# Usage:  .\scripts\deploy-frontend.ps1 -PublicApiBaseUrl "https://api.medisha.space"
param(
    [Parameter(Mandatory = $true)]
    [string] $PublicApiBaseUrl
)
$ErrorActionPreference = "Stop"
$Root = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
Set-Location $Root
if ($PublicApiBaseUrl -notmatch '^https://') {
    Write-Error "PublicApiBaseUrl must be an absolute https:// origin."
}
dotnet publish Yoga.Client/Yoga.Client.csproj -c Release -o publish --nologo
$appSettingsPath = Join-Path $Root "publish\wwwroot\appsettings.json"
$appSettings = Get-Content $appSettingsPath -Raw | ConvertFrom-Json
if (-not $appSettings.Api) {
    $appSettings | Add-Member -NotePropertyName Api -NotePropertyValue ([pscustomobject]@{})
}
$normalizedPublicApiBaseUrl = $PublicApiBaseUrl.TrimEnd('/') + "/"
$appSettings.Api | Add-Member -Force -NotePropertyName PublicBaseUrl -NotePropertyValue $normalizedPublicApiBaseUrl
$json = $appSettings | ConvertTo-Json -Depth 10
[System.IO.File]::WriteAllText($appSettingsPath, $json + "`n", [System.Text.UTF8Encoding]::new($false))
Set-Location publish/wwwroot
npx --yes vercel@41.4.1 deploy --prod --yes
