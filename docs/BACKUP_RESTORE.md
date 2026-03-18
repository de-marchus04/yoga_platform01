# Backup And Restore

This document defines the minimum database backup and restore procedure for the first production release.

## Scope

- Source of truth: PostgreSQL.
- Application media stored in S3-compatible storage must be backed up separately by storage lifecycle rules or bucket replication.
- This playbook covers database backup and restore only.

## Backup Targets

- Keep daily logical backups with `pg_dump`.
- Keep at least 7 daily backups and 4 weekly backups.
- Store backups outside the app host on mounted storage or object storage.
- Encrypt backup storage at the infrastructure level whenever possible.

## Required Environment Variables

- `POSTGRES_HOST`
- `POSTGRES_PORT`
- `POSTGRES_DB`
- `POSTGRES_USER`
- `POSTGRES_PASSWORD`
- `BACKUP_DIR`

## Backup Command

Use [scripts/backup_postgres.sh](../scripts/backup_postgres.sh) from the project root.

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

## Restore Command

Use [scripts/restore_postgres.sh](../scripts/restore_postgres.sh) from the project root.

Example:

```bash
export POSTGRES_HOST=127.0.0.1
export POSTGRES_PORT=5432
export POSTGRES_DB=YogaLifeEnterpriseDb_restore
export POSTGRES_USER=postgres
export POSTGRES_PASSWORD='strong-password'

./scripts/restore_postgres.sh /var/backups/yoga-life/yoga-life-20260318-210000.dump
```

## Restore Drill

Run this before calling the platform release-ready:

1. Create a fresh restore database.
2. Restore the latest backup into that database.
3. Start the API against the restored database in an isolated environment.
4. Verify these entities exist and are coherent:
   - admin users
   - customers
   - subscriptions
   - access grants
   - premium resources
   - live events
   - audit logs
5. Verify customer login and premium/live access against the restored environment.

## RTO And RPO

- Initial target RPO: 24 hours.
- Initial target RTO: under 2 hours.

## Operational Notes

- Do not restore over the live production database without an explicit incident decision.
- Always validate the backup file size and restore logs.
- If storage provider metadata or private media access rules are changed later, expand this playbook to include object storage integrity checks.