BEGIN;

DELETE FROM "UiTranslations"
WHERE "Key" LIKE 'page.home.%';

INSERT INTO "UiTranslations" ("Id", "Key", "Language", "Value") VALUES
  (gen_random_uuid(), 'page.retreats.card.cta', 'uk', 'Детальніше →'),
  (gen_random_uuid(), 'page.retreats.card.cta', 'ru', 'Подробнее →'),
  (gen_random_uuid(), 'page.retreats.card.cta', 'en', 'Learn more →'),
  (gen_random_uuid(), 'page.yagyas.card.cta', 'uk', 'Детальніше →'),
  (gen_random_uuid(), 'page.yagyas.card.cta', 'ru', 'Подробнее →'),
  (gen_random_uuid(), 'page.yagyas.card.cta', 'en', 'Learn more →'),
  (gen_random_uuid(), 'section.cta.btn', 'uk', 'Детальніше'),
  (gen_random_uuid(), 'section.cta.btn', 'ru', 'Подробнее'),
  (gen_random_uuid(), 'section.cta.btn', 'en', 'Learn more'),
  (gen_random_uuid(), 'form.context_prefix', 'uk', 'Щодо'),
  (gen_random_uuid(), 'form.context_prefix', 'ru', 'По поводу'),
  (gen_random_uuid(), 'form.context_prefix', 'en', 'About'),
  (gen_random_uuid(), 'form.heading', 'uk', 'Дізнатися більше'),
  (gen_random_uuid(), 'form.heading', 'ru', 'Узнать подробнее'),
  (gen_random_uuid(), 'form.heading', 'en', 'Learn more'),
  (gen_random_uuid(), 'form.signup_prefix', 'uk', 'Щодо'),
  (gen_random_uuid(), 'form.signup_prefix', 'ru', 'По поводу'),
  (gen_random_uuid(), 'form.signup_prefix', 'en', 'About'),
  (gen_random_uuid(), 'page.retreats.title', 'uk', 'Ретрити | shakti.ashram'),
  (gen_random_uuid(), 'page.retreats.title', 'ru', 'Ретриты | shakti.ashram'),
  (gen_random_uuid(), 'page.retreats.title', 'en', 'Retreats | shakti.ashram'),
  (gen_random_uuid(), 'page.yagyas.title', 'uk', 'Ягʼї | shakti.ashram'),
  (gen_random_uuid(), 'page.yagyas.title', 'ru', 'Ягьи | shakti.ashram'),
  (gen_random_uuid(), 'page.yagyas.title', 'en', 'Yagyas | shakti.ashram')
ON CONFLICT ("Key", "Language") DO UPDATE SET "Value" = EXCLUDED."Value";

UPDATE "UiTranslations"
SET "Value" = replace("Value", 'Yoga.Life', 'shakti.ashram')
WHERE "Key" LIKE 'page.%.title'
  AND "Value" LIKE '%Yoga.Life%';

UPDATE "Translations"
SET "Value" = CASE
  WHEN "EntityType" = 'Retreat' AND "Language" = 'uk' THEN 'Ретрит'
  WHEN "EntityType" = 'Retreat' AND "Language" = 'ru' THEN 'Ретрит'
  WHEN "EntityType" = 'Retreat' AND "Language" = 'en' THEN 'Retreat'
  WHEN "EntityType" = 'Yagya' AND "Language" = 'uk' THEN 'Ягʼя'
  WHEN "EntityType" = 'Yagya' AND "Language" = 'ru' THEN 'Ягья'
  WHEN "EntityType" = 'Yagya' AND "Language" = 'en' THEN 'Yagya'
  ELSE "Value"
END
WHERE "Field" = 'Eyebrow'
  AND "EntityType" IN ('Retreat', 'Yagya');

UPDATE "Translations"
SET "Value" = 'https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80'
WHERE "EntityType" = 'Yagya'
  AND "Field" = 'ImageUrl'
  AND "Value" = 'https://images.unsplash.com/photo-1604187350996-2374defa3750?w=800&q=80';

UPDATE "Yagyas"
SET "ImageUrl" = 'https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80'
WHERE "ImageUrl" = 'https://images.unsplash.com/photo-1604187350996-2374defa3750?w=800&q=80';

COMMIT;