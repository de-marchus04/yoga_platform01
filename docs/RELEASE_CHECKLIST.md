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

The release is not complete until every item above is either checked or explicitly accepted as deferred risk.
