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
- GitHub Actions builds the publish artifact first and then deploys that artifact to Vercel through a dedicated workflow.
- The public alias must point to a static deploy created from `publish/wwwroot`, not to a root repository deploy.
- Manual `vercel deploy` is a fallback procedure, not the primary release path.

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

1. Trigger the frontend deployment workflow by pushing `main`.

Expected automation:

- `Build Blazor WASM` creates the `publish/wwwroot` artifact.
- `Deploy Blazor Frontend` downloads that artifact and publishes it to Vercel.

1. If the automatic frontend deployment is unavailable, use the fallback manual procedure:

```bash
dotnet publish Yoga.Client/Yoga.Client.csproj -c Release -o publish --nologo
cd publish/wwwroot
vercel deploy --prod --yes
```

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

Then push the updated `main` branch so GitHub Actions can deploy the frontend artifact automatically.

If the deploy workflow is unavailable, use the manual fallback:

```bash
dotnet publish Yoga.Client/Yoga.Client.csproj -c Release -o publish --nologo
cd publish/wwwroot
vercel deploy --prod --yes
```

After upgrade:

1. Check API logs.
2. Check client logs.
3. Open admin login.
4. Verify one customer cabinet flow.
5. Verify the Vercel alias returns `200` for `/`, `/about`, `/contacts`, `/privacy`, `/terms`, and `/account/login`.
6. Verify the `Deploy Blazor Frontend` workflow completed successfully.

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
