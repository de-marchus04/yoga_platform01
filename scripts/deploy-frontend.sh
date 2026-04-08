#!/usr/bin/env bash
# Publish Blazor WASM to ./publish, inject public API URL, deploy wwwroot to Vercel production.
set -euo pipefail
ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT"
if [[ -z "${FRONTEND_PUBLIC_API_BASE_URL:-}" ]]; then
  echo "Set FRONTEND_PUBLIC_API_BASE_URL to your public API origin, e.g. https://api.example.com" >&2
  exit 1
fi
dotnet publish Yoga.Client/Yoga.Client.csproj -c Release -o publish --nologo
python3 scripts/inject_public_api_url.py publish/wwwroot/appsettings.json "$FRONTEND_PUBLIC_API_BASE_URL"
cd publish/wwwroot
exec npx --yes vercel@38.0.0 deploy --prod --yes
