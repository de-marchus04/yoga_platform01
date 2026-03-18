# Public Content Reset Runbook

This runbook defines the safe execution procedure for clearing public content from the platform while preserving admin, customer, premium, and access-control data.

## Purpose

Use the public content reset only when you need to turn the site into a clean public template shell or remove all existing public-facing catalog content before a controlled refill.

The reset removes:

- courses
- course modules
- consultations
- retreats
- blog posts
- translations for public site pages
- translations for public entities
- media files linked to those public entities and pages

The reset does not remove:

- admin users
- customers
- subscriptions
- access grants
- premium resources
- live events
- UI translations
- public route skeletons stored as SitePage records

## Preconditions

Do not execute the reset until all of the following are true:

1. A fresh PostgreSQL backup has been created successfully.
2. The latest restore drill has been validated or the backup has at least been checked for size and completion.
3. The operator understands that public pages will immediately switch to placeholder/template states.
4. The operator has access to the admin audit page.
5. A refill plan exists for the content that must be added back after reset.

## Required References

- [docs/BACKUP_RESTORE.md](docs/BACKUP_RESTORE.md)
- [docs/DEPLOYMENT.md](docs/DEPLOYMENT.md)
- [scripts/backup_postgres.sh](scripts/backup_postgres.sh)
- [scripts/restore_postgres.sh](scripts/restore_postgres.sh)

## Step 1 — Create Backup

Run the database backup before touching the reset action.

Example:

```bash
export POSTGRES_HOST=127.0.0.1
export POSTGRES_PORT=5432
export POSTGRES_DB=YogaLifeEnterpriseDb
export POSTGRES_USER=postgres
export POSTGRES_PASSWORD='strong-password'
export BACKUP_DIR=/var/backups/yoga-life

./scripts/backup_postgres.sh
```

Record the produced dump file path.

## Step 2 — Review Preview Counts

Open the admin dashboard and review the public content reset preview block.

Confirm that the counts look expected for:

- courses
- modules
- consultations
- retreats
- blog posts
- site page translations
- entity translations
- media files

If the counts are unexpectedly high or unexpectedly zero, stop and investigate before continuing.

## Step 3 — Execute Reset

In the admin dashboard:

1. Click `Удалить публичный контент`
2. Read the confirmation summary
3. Confirm the deletion

The action calls the admin endpoint that performs a scoped reset and writes an audit log entry.

## Step 4 — Immediate Post-Reset Checks

After the reset completes, verify all of the following:

1. The dashboard preview counts dropped to zero or to the expected residual values.
2. The audit page contains a `PublicContentReset` entry.
3. Public routes still open:
   - `/`
   - `/about`
   - `/contacts`
   - `/courses`
   - `/consultations`
   - `/blog`
   - `/retreats`
4. Detail routes now render safe placeholder or empty states instead of failing.
5. Customer and premium/live areas still work.

## Step 5 — Refill Order

Recommended refill order after reset:

1. Site pages: home, about, contacts, courses, consultations, blog, retreats
2. Courses and course modules
3. Consultations
4. Retreats
5. Blog posts
6. Public media assets

Do not assume that placeholder text is publish-ready content. It is only a safe template shell.

## Rollback

If the reset was executed too early or content was removed by mistake:

1. Do not restore over the live production database immediately.
2. Create a fresh restore database.
3. Restore the backup into the fresh database.
4. Validate the restored content in an isolated environment.
5. Decide whether to restore selected content manually or perform a full database rollback under incident control.

Example restore command:

```bash
export POSTGRES_HOST=127.0.0.1
export POSTGRES_PORT=5432
export POSTGRES_DB=YogaLifeEnterpriseDb_restore
export POSTGRES_USER=postgres
export POSTGRES_PASSWORD='strong-password'

./scripts/restore_postgres.sh /var/backups/yoga-life/yoga-life-20260318-210000.dump
```

## Audit Expectations

The audit log should contain a `PublicContentReset` action with summary counters for deleted public entities and media.

If no audit entry exists after reset, treat the action as operationally incomplete and investigate before continuing with refill or handoff.

## Operational Notes

- Use the reset during a controlled maintenance window when possible.
- Inform content owners before execution.
- If a client handoff is planned, perform the reset only after the template and refill strategy are approved.
- Treat the reset as a destructive action even though route skeletons remain intact.
