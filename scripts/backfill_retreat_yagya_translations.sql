WITH langs AS (
    SELECT unnest(ARRAY['ru', 'uk', 'en']) AS lang
),
retreat_base AS (
    SELECT r."Id" AS entity_id,
           l.lang,
           COALESCE(NULLIF(r."Title", ''), 'Retreat') AS title,
           COALESCE(NULLIF(r."Description", ''), '') AS description,
           COALESCE(NULLIF(r."ImageUrl", ''), '') AS image_url,
           COALESCE(NULLIF(r."Location", ''), '') AS location,
           COALESCE(NULLIF(r."PriceLabel", ''), '') AS price_label,
           CASE l.lang
               WHEN 'uk' THEN 'Ретрит'
               WHEN 'en' THEN 'Retreat'
               ELSE 'Ретрит'
           END AS eyebrow,
           CASE l.lang
               WHEN 'uk' THEN 'Детальніше про ретрит'
               WHEN 'en' THEN 'Learn more about the retreat'
               ELSE 'Подробнее о ретрите'
           END AS cta_heading,
           CASE l.lang
               WHEN 'uk' THEN 'Перегляньте деталі програми та зв''яжіться з нами, якщо хочете взяти участь.'
               WHEN 'en' THEN 'Review the programme details and contact us if you would like to participate.'
               ELSE 'Посмотрите детали программы и свяжитесь с нами, если хотите участвовать.'
           END AS cta_text
    FROM "Retreats" r
    CROSS JOIN langs l
),
retreat_values AS (
    SELECT entity_id, lang, field, value
    FROM retreat_base
    CROSS JOIN LATERAL (
        VALUES
            ('Title', title),
            ('Subtitle', description),
            ('Eyebrow', eyebrow),
            ('Description', description),
            ('ImageUrl', image_url),
            ('Location', location),
            ('PriceLabel', price_label),
            ('CtaHeading', cta_heading),
            ('CtaText', cta_text)
    ) AS mapped(field, value)
    WHERE value <> ''
),
yagya_base AS (
    SELECT y."Id" AS entity_id,
           l.lang,
           COALESCE(NULLIF(y."Title", ''), 'Yagya') AS title,
           COALESCE(NULLIF(y."Description", ''), '') AS description,
           COALESCE(NULLIF(y."ImageUrl", ''), '') AS image_url,
           COALESCE(NULLIF(y."Location", ''), '') AS format_text,
           COALESCE(NULLIF(y."PriceLabel", ''), '') AS price_label,
           CASE l.lang
               WHEN 'uk' THEN 'Ягʼя'
               WHEN 'en' THEN 'Yagya'
               ELSE 'Ягья'
           END AS eyebrow,
           CASE l.lang
               WHEN 'uk' THEN 'Детальніше про ягʼю'
               WHEN 'en' THEN 'Learn more about the yagya'
               ELSE 'Подробнее о ягье'
           END AS cta_heading,
           CASE l.lang
               WHEN 'uk' THEN 'Перегляньте деталі події та зв''яжіться з нами, якщо хочете взяти участь.'
               WHEN 'en' THEN 'Review the event details and contact us if you would like to participate.'
               ELSE 'Посмотрите детали события и свяжитесь с нами, если хотите участвовать.'
           END AS cta_text
    FROM "Yagyas" y
    CROSS JOIN langs l
),
yagya_values AS (
    SELECT entity_id, lang, field, value
    FROM yagya_base
    CROSS JOIN LATERAL (
        VALUES
            ('Title', title),
            ('Subtitle', description),
            ('Eyebrow', eyebrow),
            ('Description', description),
            ('ImageUrl', image_url),
            ('Format', format_text),
            ('PriceLabel', price_label),
            ('CtaHeading', cta_heading),
            ('CtaText', cta_text)
    ) AS mapped(field, value)
    WHERE value <> ''
),
all_values AS (
    SELECT 'Retreat'::text AS entity_type, entity_id, lang, field, value FROM retreat_values
    UNION ALL
    SELECT 'Yagya'::text AS entity_type, entity_id, lang, field, value FROM yagya_values
),
prepared AS (
    SELECT (
               substr(md5(entity_type || entity_id::text || field || lang), 1, 8) || '-' ||
               substr(md5(entity_type || entity_id::text || field || lang), 9, 4) || '-4' ||
               substr(md5(entity_type || entity_id::text || field || lang), 14, 3) || '-8' ||
               substr(md5(entity_type || entity_id::text || field || lang), 18, 3) || '-' ||
               substr(md5(entity_type || entity_id::text || field || lang), 21, 12)
           )::uuid AS id,
           entity_type,
           entity_id,
           field,
           lang,
           value
    FROM all_values
)
INSERT INTO "Translations" ("Id", "EntityType", "EntityId", "Field", "Language", "Value")
SELECT id, entity_type, entity_id, field, lang, value
FROM prepared
ON CONFLICT ("EntityType", "EntityId", "Field", "Language") DO UPDATE
SET "Value" = EXCLUDED."Value"
WHERE COALESCE("Translations"."Value", '') = '';