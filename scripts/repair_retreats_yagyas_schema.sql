ALTER TABLE IF EXISTS "Retreats"
    ADD COLUMN IF NOT EXISTS "Slug" character varying(64) NOT NULL DEFAULT '';

ALTER TABLE IF EXISTS "Retreats"
    ADD COLUMN IF NOT EXISTS "SortOrder" integer NOT NULL DEFAULT 0;

ALTER TABLE IF EXISTS "Retreats"
    ADD COLUMN IF NOT EXISTS "EventStartDate" timestamp with time zone;

ALTER TABLE IF EXISTS "Retreats"
    ADD COLUMN IF NOT EXISTS "EventEndDate" timestamp with time zone;

UPDATE "Retreats"
SET "EventStartDate" = COALESCE("EventStartDate", "StartDate"),
    "EventEndDate" = COALESCE("EventEndDate", "EndDate");

UPDATE "Retreats"
SET "Slug" = lower("Id"::text)
WHERE "Slug" = '';

WITH ordered_retreats AS (
    SELECT "Id", row_number() OVER (ORDER BY COALESCE("EventStartDate", "StartDate"), "Id") AS row_num
    FROM "Retreats"
)
UPDATE "Retreats" r
SET "SortOrder" = ordered_retreats.row_num
FROM ordered_retreats
WHERE r."Id" = ordered_retreats."Id"
  AND r."SortOrder" = 0;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Retreats_Slug"
    ON "Retreats" ("Slug");

ALTER TABLE IF EXISTS "Yagyas"
    ADD COLUMN IF NOT EXISTS "Slug" character varying(64) NOT NULL DEFAULT '';

ALTER TABLE IF EXISTS "Yagyas"
    ADD COLUMN IF NOT EXISTS "SortOrder" integer NOT NULL DEFAULT 0;

ALTER TABLE IF EXISTS "Yagyas"
    ADD COLUMN IF NOT EXISTS "EventStartDate" timestamp with time zone;

ALTER TABLE IF EXISTS "Yagyas"
    ADD COLUMN IF NOT EXISTS "EventEndDate" timestamp with time zone;

UPDATE "Yagyas"
SET "EventStartDate" = COALESCE("EventStartDate", "StartDate"),
    "EventEndDate" = COALESCE("EventEndDate", "EndDate");

UPDATE "Yagyas"
SET "Slug" = lower("Id"::text)
WHERE "Slug" = '';

WITH ordered_yagyas AS (
    SELECT "Id", row_number() OVER (ORDER BY COALESCE("EventStartDate", "StartDate"), "Id") AS row_num
    FROM "Yagyas"
)
UPDATE "Yagyas" y
SET "SortOrder" = ordered_yagyas.row_num
FROM ordered_yagyas
WHERE y."Id" = ordered_yagyas."Id"
  AND y."SortOrder" = 0;

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Yagyas_Slug"
    ON "Yagyas" ("Slug");