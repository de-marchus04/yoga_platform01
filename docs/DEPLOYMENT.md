# Deployment Guide

This guide describes the baseline deployment model for the first production release.

## Target Topology

- Public edge: Cloudflare or equivalent DNS and SSL proxy.
- Application host: one VPS or container host.
- Runtime: Docker Compose.
- Database: PostgreSQL.
- Storage: S3-compatible object storage for growing media.
- Public frontend hosting: Vercel static hosting from published Blazor output.

## Final Deployment Model

Production is split into two separate delivery paths:

- API and database run on the main host through Docker Compose.
- The Blazor frontend is published as static files and deployed to Vercel from `publish/wwwroot`.

Important operating rule:

- The Vercel project `yoga-life-enterprise` must stay disconnected from direct Git auto-deploy for this repository.
- GitHub Actions builds the publish artifact automatically, and frontend deployment is executed through a dedicated GitHub Actions workflow.
- The public alias must point to a static deploy created from `publish/wwwroot`, not to a root repository deploy.
- Manual `vercel deploy` is a fallback procedure, not the primary release path.
- Fully automatic push-triggered Vercel deployment should only be enabled after the repository secret `VERCEL_TOKEN` is replaced with a token that has access to the `de-marchus04's projects` team.

Frontend runtime rule:

- The static frontend must be deployed with a real absolute backend URL injected into `publish/wwwroot/appsettings.json` as `Api.PublicBaseUrl`.
- The repository GitHub Actions variable `FRONTEND_PUBLIC_API_BASE_URL` is the source of truth for that value in the Vercel deploy workflow.
- Use an absolute HTTPS origin like `https://api.example.com`.
- Do not leave `Api.PublicBaseUrl` empty when the frontend is hosted on Vercel or any host different from the API.

## Required Secrets And Variables

Create a real `.env` file on the server based on [.env.example](../.env.example).

Minimum required values:

- `POSTGRES_USER`
- `POSTGRES_PASSWORD`
- `POSTGRES_DB`
- `JWT_SECRET_KEY`
- `JWT_ISSUER`
- `JWT_AUDIENCE`
- `APP_ORIGIN`
- `TELEGRAM_BOT_TOKEN`
- `TELEGRAM_CHAT_ID`

Required GitHub Actions variable for frontend deploy:

- `FRONTEND_PUBLIC_API_BASE_URL=https://your-public-api-origin`

Post-deploy checks:

- **Required:** `curl` against the **`*.vercel.app` URL** returned for this deployment (with optional `VERCEL_PROTECTION_BYPASS_SECRET` if Deployment Protection returns 401). This proves the bundle you just uploaded is live.
- **Optional** (`continue-on-error`): if `FRONTEND_PUBLIC_API_BASE_URL` is `https://api.example.com`, the workflow also tries `https://www.example.com/`, or use variable `FRONTEND_SMOKE_URL`. A **404 on www** means the custom domain is not assigned to this Vercel project or DNS is wrong — fix under Vercel → **Project → Domains**; it does **not** fail the job.

Secret `VERCEL_PROTECTION_BYPASS_SECRET`: Vercel → **Deployment Protection** → automation bypass; sent as `x-vercel-protection-bypass`. [Docs](https://vercel.com/docs/deployment-protection/methods-to-bypass-deployment-protection/protection-bypass-automation).

If production is **auth-protected**, the workflow still **passes**: HTTP **401/403** on smoke routes is treated as OK (deploy succeeded; CI cannot see HTML without bypass).

`vercel.json` uses a final `/(.*) → /index.html` SPA fallback; Vercel serves real files (`app.css`, `_framework/*`) first. Do not use an `Accept: text/html`-only rewrite — `curl` and Vercel previews use `Accept: */*` and would get **404** on deep links.

Required GitHub Actions **secret** for frontend deploy:

- `VERCEL_TOKEN` — create at [vercel.com/account/tokens](https://vercel.com/account/tokens). The account you are logged into when you create the token **must be a member of the Vercel team** that owns the project; otherwise deploy fails with `scope-not-accessible` / “You do not have access to the specified account” ([details](https://err.sh/vercel/scope-not-accessible)).

Optional repository **Variables** (override defaults baked into the workflow):

- `VERCEL_ORG_ID` — Team ID from Vercel (starts with `team_…`), if the default in the workflow is wrong for your token.
- `VERCEL_PROJECT_ID` — Project ID (starts with `prj_…`).

### Vercel: `scope-not-accessible` / no access to specified account

This is **not** a Blazor or routing bug: the token cannot deploy under the **team scope** passed to the CLI.

1. In Vercel, open the team that owns **yoga-life-enterprise** (or your production project).
2. Confirm your user is on that team (Owner / Member).
3. Log out of Vercel, log back in as that user, create a **new** token, paste it into GitHub → Settings → Secrets → `VERCEL_TOKEN`.
4. If the project moved to another team, set `VERCEL_ORG_ID` and `VERCEL_PROJECT_ID` in GitHub → Settings → Variables to match **Project Settings → General** on Vercel.

Until this is fixed, CI will fail at the deploy step and production will not update.

### Vercel: Root Directory

Keep **Root Directory** in Vercel → Project → Settings → General **empty** (default). The workflow and scripts deploy the **contents** of `publish/wwwroot` (the Blazor publish output). If you set Root Directory to a subpath (e.g. `publish_fresh/wwwroot`), that path must exist on the machine running `vercel deploy` or CI will fail.

Optional but recommended media values for production API environment:

- `Storage__Provider=S3`
- `Storage__BucketName`
- `Storage__ServiceUrl` or `Storage__Region`
- `Storage__AccessKey`
- `Storage__SecretKey`
- `Storage__PublicHost`
- `Storage__KeyPrefix`

## First Deployment

1. Provision the host and install Docker plus Docker Compose.
2. Copy the repository to the server.
3. Create the production `.env` file.
4. Confirm DNS points to the host.
5. Start the API stack:

```bash
docker compose up -d --build
```

1. Trigger the frontend deployment workflow from the GitHub Actions tab.

Current GitHub Actions flow:

- `Build Blazor WASM` creates the `publish/wwwroot` artifact.
- `Deploy Blazor Frontend` rebuilds the frontend, injects `FRONTEND_PUBLIC_API_BASE_URL` into the published runtime config, and publishes the static bundle to Vercel using `amondnet/vercel-action` (no fragile parsing of CLI stdout). After deploy, the workflow checks that `/app.css` is served as `text/css` so a broken SPA rewrite cannot slip through unnoticed.

1. If the automatic frontend deployment is unavailable, use the repository scripts (same inject logic as CI):

```bash
export FRONTEND_PUBLIC_API_BASE_URL="https://your-public-api-origin"
bash scripts/deploy-frontend.sh
```

On Windows (PowerShell), from the repo root:

```powershell
.\scripts\deploy-frontend.ps1 -PublicApiBaseUrl "https://your-public-api-origin"
```

You must be logged into Vercel CLI (`vercel login`) or have `VERCEL_TOKEN` in the environment for non-interactive use.

1. Verify:
   - frontend loads from the public domain
   - `/api/*` routes resolve through nginx
   - `/health/live` returns healthy
   - `/health/ready` returns healthy

## Upgrade Procedure

```bash
git pull
docker compose up -d --build
```

Then run `Deploy Blazor Frontend` from the GitHub Actions tab to publish the frontend without using a local terminal.

If the deploy workflow is unavailable, use `scripts/deploy-frontend.sh` or `scripts/deploy-frontend.ps1` as described above.

After upgrade:

1. Check API logs.
2. Check client logs.
3. Open admin login.
4. Verify one customer cabinet flow.
5. Verify the Vercel alias returns `200` for `/`, `/about`, `/contacts`, `/privacy`, `/terms`, and `/account/login`.
6. Open the published `appsettings.json` and confirm `Api.PublicBaseUrl` points to the production API origin.
7. Verify the `Deploy Blazor Frontend` workflow completed successfully.

## Rollback Procedure

1. Stop the updated stack.
2. Checkout the previous known-good revision.
3. Rebuild and restart with Docker Compose.
4. If a schema issue is involved, restore the previous database backup into a separate database first and validate before touching production.

## TLS Notes

- The included nginx config provides proxying and security headers.
- TLS certificate management should be terminated by the public ingress layer or a production-specific reverse proxy setup.
- Do not enable HSTS on a domain until HTTPS is stable and permanent.

## Release Smoke Test

After deployment, verify:

1. Admin login.
2. Lead creation from public site.
3. Lead processing in admin area.
4. Customer creation or linking.
5. Premium resource access.
6. Live event watch flow.
7. Audit page visibility.
8. Public Vercel routes resolve without `404`.
