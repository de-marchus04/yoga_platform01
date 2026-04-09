# Service Ownership And Handoff

This document defines who owns production operations after the project is transferred to the client. The codebase is a **public vitrina only** (courses, consultations, static pages, lead form) — there is no admin UI or customer cabinet in this repository.

## Ownership Map

- Business owner:
  - owns legal texts, offer terms, pricing policy, and how leads are handled operationally
- Content / operations:
  - responds to leads (e.g. Telegram notifications, email outside this app)
  - updates public content via database (`Translations`, `SitePages`, `Courses`, `Consultations`) or agreed import tools — not via an in-repo admin panel
- Technical owner:
  - owns domain, Cloudflare or DNS, VPS or container host, SSL, backups, restore drills, and monitoring
  - rotates secrets and controls privileged access to infrastructure
- Development contractor:
  - delivers code, deployment instructions, migration path, and agreed stabilization support window
  - does not remain on-call by default after handoff unless a maintenance contract is signed

## Access Matrix

- Domain and DNS: client
- Cloudflare or ingress account: client
- VPS or hosting account: client
- PostgreSQL credentials: client technical owner
- S3 or object storage credentials: client technical owner (if used for public media URLs)
- Repository access: client and contractor during transition window only

## Minimum Handoff Package

- Source repository with tagged release
- Production `.env` created from `.env.example`
- Current deployment guide
- Current backup and restore guide
- Release checklist with accepted risks
- List of active secrets and where each secret is stored
- Contact list for business owner, operations lead, and technical owner

## Support Boundary

The following incidents belong to the client technical owner after handoff:

- DNS, TLS, CDN, and firewall issues
- server disk exhaustion or host-level failures
- PostgreSQL maintenance, backup storage, and restore execution
- S3 bucket policy and object retention issues (if applicable)
- first-line handling of public user questions

The following items typically belong to the contractor only if covered by a support agreement:

- code defects reproducible on the supported release
- migration defects introduced by contractor changes
- agreed feature enhancements
- security patches inside the application codebase

## First 30 Days After Launch

Recommended operating cadence:

1. Daily check of `/health/live`, `/health/ready`, and deployment logs.
2. Daily review of new leads (notification channel configured for production).
3. Weekly backup verification.
4. One restore drill during the first month.
5. One review of object storage costs if public media is served from object storage.

## Exit Criteria For Full Transfer

The project should be considered fully transferred only when all of the following are true:

- client controls hosting, DNS, database, and storage accounts (as used)
- release documentation is current
- backups run on client-owned infrastructure
- at least one restore drill has been completed
- operations team can update public content through the agreed process (DB / scripts / external CMS) without contractor help for routine edits
- support boundary and escalation path are signed off
