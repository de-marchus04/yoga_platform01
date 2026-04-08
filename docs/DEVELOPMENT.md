# Local development stack

This repository targets **.NET 8** (`net8.0`). The root [`global.json`](../global.json) requires an **8.0.x** SDK (minimum feature band `8.0.100`, with `rollForward: latestMinor`) so commands do not pick **.NET 9+** when several SDKs are installed. You must still install a .NET 8 SDK alongside a global .NET 10 install if both are present.

## Prerequisites

| Tool | Notes |
|------|--------|
| **.NET SDK 8** | Install from [Download .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or `winget install Microsoft.DotNet.SDK.8`. In the repo root, run `dotnet --version` and confirm 8.0.x. |
| **Node.js 24** | Matches [GitHub Actions](../.github/workflows/deploy.yml) (`setup-node`). |
| **Python 3** | Used by `scripts/inject_public_api_url.py` in CI and manual deploy scripts. |
| **PostgreSQL** | Required to run **Yoga.Api** locally with a real connection string (see `.env` / `docker compose`). |

Optional: use the **Dev Container** ([`.devcontainer`](../.devcontainer/devcontainer.json)) in VS Code or Cursor for a preconfigured Linux environment with .NET 8 (requires Docker).

## Common commands

```bash
# From repository root (respects global.json)
dotnet restore Yoga.Life.Enterprise.sln
dotnet build Yoga.Life.Enterprise.sln -c Release
dotnet test Yoga.Life.Enterprise.sln -c Release --no-build
```

Blazor WASM client only:

```bash
dotnet run --project Yoga.Client/Yoga.Client.csproj
```

Entity Framework CLI (install once per machine):

```bash
dotnet tool update --global dotnet-ef
```

Run migrations from the API project directory (see Yoga.Api README or team runbooks).

## Git author email and Vercel

If Vercel shows **Git Email Invalid** on a deployment, the commit’s author email is missing or not linked to your GitHub (and optionally Vercel) account.

1. Set a real email (the one verified on GitHub):

   ```bash
   git config user.email "you@example.com"
   git config user.name "Your Name"
   ```

2. In GitHub: **Settings → Emails** — ensure that address is listed and verified.

This does not change application behavior; it only affects how Vercel/Git attribute commits.

## Vercel: one production path

Two **separate** triggers create **two** production deployments in quick succession:

- **Git integration**: push to `main` (or connected branch) deploys from Vercel’s Git hook.
- **`vercel deploy` (CLI)**: manual upload from a developer machine.

Both can be valid, but mixing them without intent produces duplicate rows in the deployment list and whichever finished last becomes **Current**.

**Recommended** for this project (see also [DEPLOYMENT.md](./DEPLOYMENT.md)):

- Treat **GitHub Actions** (`Deploy Blazor Frontend` workflow) as the primary path to production static assets.
- Avoid ad-hoc `vercel deploy --prod` for the same project unless you intentionally override or recover from a failed pipeline.

## Continuous integration

On every push and pull request to `main`, the workflow **Build Blazor WASM** (`.github/workflows/deploy.yml`) restores the **solution**, builds it in **Release**, runs **`dotnet test`** (including `Yoga.Api.Tests`), then publishes the Blazor client. Failures in tests block the workflow before the publish artifact is produced.

The **Deploy Blazor Frontend** workflow runs the same solution restore/build/test steps before publishing and uploading to Vercel.
