# Release Checklist

Use this checklist before declaring the platform production-ready.

## Security

- `JWT_SECRET_KEY` is unique, secret, and at least 32 characters.
- `Security__AllowedOrigins__*` contains only real production origins.
- TLS is active on the public domain.
- HSTS is enabled only after HTTPS is verified.
- No development secrets remain in server config files.

## Runtime

- `docker compose up -d --build` works from a clean checkout.
- `/health/live` is healthy.
- `/health/ready` is healthy.
- API and client logs show no startup failures.

## Data Protection

- Backup script runs successfully.
- Restore script is tested against a fresh database.
- Latest restore drill is documented.

## Product Flows

- Public lead form works.
- Admin can process a lead.
- Admin can create a customer from a lead.
- Admin can grant or revoke access.
- Admin can upload premium media and live recordings.
- Admin audit page shows recent actions.
- Customer can access premium resources.
- Customer can access live event recordings.

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