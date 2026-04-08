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
$py = Get-Command python3 -ErrorAction SilentlyContinue
if (-not $py) { $py = Get-Command python -ErrorAction SilentlyContinue }
if (-not $py) { Write-Error "Python is required to patch appsettings.json (python or python3 on PATH)." }
& $py.Source scripts/inject_public_api_url.py publish/wwwroot/appsettings.json $PublicApiBaseUrl
# Match Vercel project "Root Directory" (publish_fresh/wwwroot) so CLI does not error.
New-Item -ItemType Directory -Force -Path publish_fresh | Out-Null
if (Test-Path publish_fresh/wwwroot) { Remove-Item -Recurse -Force publish_fresh/wwwroot }
Copy-Item -Recurse -Force publish/wwwroot publish_fresh/wwwroot
Set-Location publish_fresh/wwwroot
npx --yes vercel@41.4.1 deploy --prod --yes
