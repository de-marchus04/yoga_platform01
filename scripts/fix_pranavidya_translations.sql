-- ============================================================
-- Add Subtitle + Eyebrow translations for the pranavidya course
-- Course ID: 22222222-2222-2222-2222-222222222201
-- Run via: docker exec yoga-postgres psql -U postgres -d YogaLifeEnterpriseDb -f /path/to/this.sql
-- ============================================================

BEGIN;

-- Remove old wrong-cased entries if they exist (from seed_test_content.sql v1 & v2 which used lowercase field names)
DELETE FROM "Translations"
WHERE "EntityType" = 'Course'
  AND "EntityId" = '22222222-2222-2222-2222-222222222201'
  AND "Field" IN ('title', 'description');  -- lowercase — API reads PascalCase, unused

-- Add/update Subtitle (shown in course card and hero)
INSERT INTO "Translations" ("Id", "EntityType", "EntityId", "Field", "Language", "Value")
VALUES
  (gen_random_uuid(), 'Course', '22222222-2222-2222-2222-222222222201', 'Subtitle', 'ru', 'Искусство управления жизненной энергией через дыхание'),
  (gen_random_uuid(), 'Course', '22222222-2222-2222-2222-222222222201', 'Subtitle', 'en', 'The art of controlling life energy through breath'),
  (gen_random_uuid(), 'Course', '22222222-2222-2222-2222-222222222201', 'Subtitle', 'uk', 'Мистецтво управління життєвою енергією через дихання'),
  (gen_random_uuid(), 'Course', '22222222-2222-2222-2222-222222222201', 'Eyebrow', 'ru', 'Дыхательные практики'),
  (gen_random_uuid(), 'Course', '22222222-2222-2222-2222-222222222201', 'Eyebrow', 'en', 'Breathing Practices'),
  (gen_random_uuid(), 'Course', '22222222-2222-2222-2222-222222222201', 'Eyebrow', 'uk', 'Дихальні практики')
ON CONFLICT DO NOTHING;

COMMIT;
