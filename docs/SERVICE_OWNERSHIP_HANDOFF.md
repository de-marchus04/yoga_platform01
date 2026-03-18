# Service Ownership And Handoff

This document defines who owns production operations after the project is transferred to the client.

## Ownership Map

- Business owner:
  - owns legal texts, offer terms, pricing policy, and approval rules for leads
  - decides who may access premium materials and live events
- Content/admin team:
  - processes leads and customers in admin UI
  - uploads premium media and live recordings
  - reviews audit logs for sensitive admin actions
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
- S3 or object storage credentials: client technical owner
- Admin UI superuser accounts: business owner or delegated operations lead
- Repository admin rights: client and contractor during transition window only

## Minimum Handoff Package

- Source repository with tagged release
- Production `.env` created from `.env.example`
- Current deployment guide
- Current backup and restore guide
- Release checklist with accepted risks
- List of active secrets and where each secret is stored
- Contact list for business owner, admin lead, and technical owner

## Support Boundary

The following incidents belong to the client technical owner after handoff:

- DNS, TLS, CDN, and firewall issues
- server disk exhaustion or host-level failures
- PostgreSQL maintenance, backup storage, and restore execution
- S3 bucket policy and object retention issues
- first-line user support and access complaints

The following items typically belong to the contractor only if covered by a support agreement:

- code defects reproducible on the supported release
- migration defects introduced by contractor changes
- agreed feature enhancements
- security patches inside the application codebase

## First 30 Days After Launch

Recommended operating cadence:

1. Daily check of `/health/live`, `/health/ready`, and deployment logs.
2. Daily review of new leads and failed customer access complaints.
3. Weekly backup verification and audit log review.
4. One restore drill during the first month.
5. One review of object storage costs and large media usage.

## Exit Criteria For Full Transfer

The project should be considered fully transferred only when all of the following are true:

- client controls hosting, DNS, database, and storage accounts
- release documentation is current
- backups run on client-owned infrastructure
- at least one restore drill has been completed
- at least two client-side administrators can work in admin UI without contractor help
- support boundary and escalation path are signed off
