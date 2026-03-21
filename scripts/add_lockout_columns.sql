-- Phase 3: Add login lockout columns to Customers table
-- Run on production DB: psql -U postgres -h localhost -d YogaLifeEnterpriseDb

BEGIN;

ALTER TABLE "Customers" ADD COLUMN IF NOT EXISTS "FailedLoginAttempts" integer NOT NULL DEFAULT 0;
ALTER TABLE "Customers" ADD COLUMN IF NOT EXISTS "LockoutEndUtc" timestamp with time zone;

COMMIT;
