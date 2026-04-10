-- ============================================================
-- Slug migration for production Retreats and Yagyas tables
-- Run BEFORE: git pull && docker compose up -d --build
--
-- Usage:
--   psql <connection_string> -f scripts/migrate_slugs.sql
--
-- Safe to run multiple times (idempotent).
-- ============================================================

BEGIN;

-- --------------------------------
-- 1. Add Slug column if not exists
-- --------------------------------
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns
        WHERE table_name = 'Retreats' AND column_name = 'Slug'
    ) THEN
        ALTER TABLE "Retreats" ADD COLUMN "Slug" varchar(64) NOT NULL DEFAULT '';
    END IF;
END$$;

DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns
        WHERE table_name = 'Yagyas' AND column_name = 'Slug'
    ) THEN
        ALTER TABLE "Yagyas" ADD COLUMN "Slug" varchar(64) NOT NULL DEFAULT '';
    END IF;
END$$;

-- --------------------------------
-- 2. Assign slugs to known production records
-- --------------------------------

-- Retreats
UPDATE "Retreats"
SET "Slug" = 'vesenniy-retrit-v-gorah'
WHERE "Id" = 'bb000002-0000-0000-0000-000000000001' AND ("Slug" = '' OR "Slug" IS NULL);

UPDATE "Retreats"
SET "Slug" = 'retrit-u-chornohorii'
WHERE "Id" = '11111111-1111-1111-1111-111111111111' AND ("Slug" = '' OR "Slug" IS NULL);

UPDATE "Retreats"
SET "Slug" = 'osenniy-retrit-tishiny'
WHERE "Id" = 'bb000002-0000-0000-0000-000000000002' AND ("Slug" = '' OR "Slug" IS NULL);

-- Yagyas
UPDATE "Yagyas"
SET "Slug" = 'ganesha-yagya'
WHERE "Id" = 'cc000003-0000-0000-0000-000000000001' AND ("Slug" = '' OR "Slug" IS NULL);

UPDATE "Yagyas"
SET "Slug" = 'lakshmi-yagya'
WHERE "Id" = 'cc000003-0000-0000-0000-000000000002' AND ("Slug" = '' OR "Slug" IS NULL);

-- --------------------------------
-- 3. Create partial unique index (only for non-empty slugs)
--    Safe to run if index already exists — wrapped in DO block
-- --------------------------------
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM pg_indexes
        WHERE tablename = 'Retreats' AND indexname = 'IX_Retreats_Slug_nonempty'
    ) THEN
        CREATE UNIQUE INDEX "IX_Retreats_Slug_nonempty"
        ON "Retreats" ("Slug")
        WHERE "Slug" != '';
    END IF;
END$$;

DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM pg_indexes
        WHERE tablename = 'Yagyas' AND indexname = 'IX_Yagyas_Slug_nonempty'
    ) THEN
        CREATE UNIQUE INDEX "IX_Yagyas_Slug_nonempty"
        ON "Yagyas" ("Slug")
        WHERE "Slug" != '';
    END IF;
END$$;

COMMIT;

-- --------------------------------
-- Verify
-- --------------------------------
SELECT 'Retreats slugs:' AS info;
SELECT "Id", "Slug" FROM "Retreats" ORDER BY "Slug";

SELECT 'Yagyas slugs:' AS info;
SELECT "Id", "Slug" FROM "Yagyas" ORDER BY "Slug";
