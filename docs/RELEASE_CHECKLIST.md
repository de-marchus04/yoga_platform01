# Release Checklist

Use this checklist before declaring the platform production-ready.

## Security

- `Security__AllowedOrigins__*` contains only real production origins.
- TLS is active on the public domain.
- HSTS is enabled only after HTTPS is verified.
- No development secrets remain in server config files.

## Runtime

- `docker compose up -d --build` works from a clean checkout.
- `dotnet publish Yoga.Client/Yoga.Client.csproj -c Release -o publish --nologo` works from a clean checkout.
- `/health/live` is healthy.
- `/health/ready` is healthy.
- API and client logs show no startup failures.
- `Build Blazor WASM` succeeds on `main`.
- `Deploy Blazor Frontend` succeeds when started from GitHub Actions.
- Vercel alias returns `200` for `/`, `/about`, `/contacts`, `/privacy`, and `/terms`.
- Vercel Git auto-deploy remains disconnected for the public frontend project.

## Data Protection

- Backup script runs successfully.
- Restore script is tested against a fresh database.
- Latest restore drill is documented.

## Product Flows

- Public lead form works.
- Course catalog and course detail pages load from the public API.
- Consultation catalog and detail pages load from the public API.
- Sitemap and health endpoints respond as expected.

## Observability

- Log retention location is defined.
- Error tracking owner is assigned.
- Uptime monitor owner is assigned.
- SSL renewal owner is assigned.

## Handoff

- Deployment guide is current.
- Backup and restore guide is current.
- Service ownership map is current.
- Support boundary is agreed.

## Legal

- Privacy policy is published on the public site.
- Terms of use are published on the public site.
- Legal contact email or process owner is assigned.

## Admin CMS

- Admin account seeded and `AdminPortal__EnableSeedAdminEndpoint` set back to `false`.
- Login to `/admin` returns a session cookie (no 401 after login).
- Dashboard loads without JS errors.
- New draft course can be created; it does NOT appear in public catalog until published.
- Published course appears in public catalog (`GET /api/courses`).
- Draft badge displays correctly; Published badge appears after Publish.
- Preview page (`/admin/preview/courses/{slug}`) renders field matrix for a draft item.
- Retreat and Yagya catalogs also respect `IsDraft` filter (no draft items on public routes).
- Media upload and URL-import work; grid shows new items.
- Lead submitted from public form appears in `/admin/leads` with status "New".
- Translations workspace shows language coverage correctly.
- `AdminCms__EnableSampleContentBootstrap` is `false` in production.

The release is not complete until every item above is either checked or explicitly accepted as deferred risk.
