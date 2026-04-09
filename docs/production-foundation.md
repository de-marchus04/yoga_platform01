# Production Foundation

This document defines the initial production-ready foundation for the platform.

## Current runtime shape

- Frontend and API are intended to run behind the same public origin.
- PostgreSQL remains the source of truth for application data.
- Media upload now goes through a storage service abstraction instead of direct controller-level file writes.
- Health endpoints are available for orchestration and monitoring.

## Health endpoints

- `GET /health/live` — liveness probe for container orchestration.
- `GET /health/ready` — readiness probe including database and storage checks.

## Storage policy

- Short term provider: local filesystem via storage abstraction.
- Target provider: S3-compatible object storage.
- Database stores metadata and URLs only.
- Growing media must move out of the app container before production scale.
- The API now supports provider selection through `Storage:Provider` with `Local` and `S3` implementations.

## Required production environment inputs

- `ConnectionStrings__DefaultConnection`
- `Security__AllowedOrigins__0`
- `TelegramSettings__BotToken`
- `TelegramSettings__ChatId`
- `Storage__Provider`
- `Storage__LocalRootPath`
- `Storage__PublicBaseUrl`
- `Storage__PublicHost`
- `Storage__BucketName`
- `Storage__ServiceUrl`
- `Storage__Region`
- `Storage__AccessKey`
- `Storage__SecretKey`
- `Storage__ForcePathStyle`
- `Storage__KeyPrefix`
- `Storage__SignedUrlLifetimeMinutes`

## Security baseline

- API CORS is no longer open by default. Production environments must set `Security__AllowedOrigins__*` explicitly.
- The public vitrina API does not expose JWT-authenticated user flows; protect infrastructure secrets (database, storage, Telegram) as usual.
- API and client reverse proxy add baseline security headers: `X-Content-Type-Options`, `X-Frame-Options`, `Referrer-Policy`, and `Permissions-Policy`.
- Forwarded headers are enabled so the API can respect proxy-provided scheme and client IP information.
- `EnableHsts` should stay enabled outside development when TLS termination is in place.

## Observability baseline

- Every API response now includes `X-Trace-Id` for request correlation.
- Unhandled server errors return a structured problem response with `traceId` and `path` fields.
- Request completion is logged in a structured form with method, path, status code, latency, and trace id.
- External error tracking is represented by the `ErrorTracking` config section so production environment variables can be introduced without changing the API contract.

## Production notes

- `docker-compose.yml` should be driven from a real `.env` file or a secrets manager.
- For multiple public domains, add `Security__AllowedOrigins__1`, `Security__AllowedOrigins__2`, and so on.
- TLS certificate management is still handled by the public ingress layer; the included nginx config currently adds security headers but does not provision certificates by itself.

## Operational documents

- Deployment runbook: [docs/DEPLOYMENT.md](DEPLOYMENT.md)
- Backup and restore playbook: [docs/BACKUP_RESTORE.md](BACKUP_RESTORE.md)
- Release gate: [docs/RELEASE_CHECKLIST.md](RELEASE_CHECKLIST.md)

## Next implementation steps

1. Add centralized logging and error tracking.
2. Add backup automation and a restore playbook.
3. Add minimum automated tests for public API flows (e.g. leads, catalog endpoints).
4. Add server-side download proxy if signed URL distribution must stay fully opaque to the browser.
