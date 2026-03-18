#!/usr/bin/env bash
set -euo pipefail

: "${POSTGRES_HOST:?POSTGRES_HOST is required}"
: "${POSTGRES_PORT:=5432}"
: "${POSTGRES_DB:?POSTGRES_DB is required}"
: "${POSTGRES_USER:?POSTGRES_USER is required}"
: "${POSTGRES_PASSWORD:?POSTGRES_PASSWORD is required}"
: "${BACKUP_DIR:?BACKUP_DIR is required}"

timestamp="$(date +%Y%m%d-%H%M%S)"
backup_file="${BACKUP_DIR}/yoga-life-${timestamp}.dump"

mkdir -p "${BACKUP_DIR}"
export PGPASSWORD="${POSTGRES_PASSWORD}"

pg_dump \
  --format=custom \
  --no-owner \
  --no-privileges \
  --host="${POSTGRES_HOST}" \
  --port="${POSTGRES_PORT}" \
  --username="${POSTGRES_USER}" \
  --dbname="${POSTGRES_DB}" \
  --file="${backup_file}"

echo "Backup created: ${backup_file}"