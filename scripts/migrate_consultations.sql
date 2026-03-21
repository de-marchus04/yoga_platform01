-- Phase 1: Migrate consultations from old slugs to new ones
-- Run on production DB: psql -U postgres -h localhost -d YogaLifeEnterpriseDb -f migrate_consultations.sql

BEGIN;

-- 1. Deactivate old consultations
UPDATE "Consultations" SET "IsActive" = false WHERE "Slug" IN ('energy', 'ayurveda', 'spirituality');

-- 2. Insert new consultations (skip if they already exist)
INSERT INTO "Consultations" ("Id", "Slug", "SortOrder", "IsActive", "IsOnline", "IsOffline", "LiveEventId")
VALUES
  ('33333333-3333-3333-3333-333333333304', 'spiritual-development', 1, true, true, true, NULL),
  ('33333333-3333-3333-3333-333333333305', 'youth', 2, true, true, true, NULL),
  ('33333333-3333-3333-3333-333333333306', 'personal', 3, true, true, true, NULL)
ON CONFLICT ("Id") DO UPDATE SET "IsActive" = true, "Slug" = EXCLUDED."Slug", "SortOrder" = EXCLUDED."SortOrder";

-- 3. Insert translations for new consultations (RU)
INSERT INTO "Translations" ("Id", "EntityType", "EntityId", "Field", "Language", "Value") VALUES
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Title', 'ru', 'Духовное развитие'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Subtitle', 'ru', 'Путь к осознанности и гармонии'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Eyebrow', 'ru', 'Духовные практики'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Description', 'ru', 'Индивидуальное сопровождение на пути духовного роста. Работа с медитацией, мантрами, энергетическими практиками и осознанностью в повседневной жизни.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Quote', 'ru', 'Духовное развитие — это не побег от реальности, а глубокое погружение в неё.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Benefits', 'ru', 'Глубокая медитативная практика|Работа с энергетическими центрами|Индивидуальная программа развития|Поддержка на каждом этапе пути'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Duration', 'ru', '60 минут'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Format', 'ru', 'Онлайн / Офлайн'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'LanguageOffered', 'ru', 'Русский, Английский'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'CtaHeading', 'ru', 'Готовы начать свой путь?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'CtaText', 'ru', 'Запишитесь на консультацию и сделайте первый шаг к осознанной жизни.'),

  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Title', 'ru', 'Для молодёжи'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Subtitle', 'ru', 'Поддержка и развитие для подростков и молодых людей'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Eyebrow', 'ru', 'Молодёжная программа'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Description', 'ru', 'Специальная программа для подростков и молодых людей. Помогаем справиться со стрессом, найти внутренний баланс и развить эмоциональную устойчивость через йогу и медитацию.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Quote', 'ru', 'Молодость — лучшее время, чтобы заложить фундамент осознанной жизни.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Benefits', 'ru', 'Управление стрессом и эмоциями|Техники концентрации и внимания|Развитие уверенности в себе|Здоровые привычки на всю жизнь'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Duration', 'ru', '45 минут'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Format', 'ru', 'Онлайн / Офлайн'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'LanguageOffered', 'ru', 'Русский, Украинский'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'CtaHeading', 'ru', 'Хотите записать ребёнка?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'CtaText', 'ru', 'Оставьте заявку, и мы подберём подходящую программу.'),

  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Title', 'ru', 'Личные вопросы'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Subtitle', 'ru', 'Индивидуальная работа с жизненными ситуациями'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Eyebrow', 'ru', 'Персональная консультация'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Description', 'ru', 'Персональная консультация для тех, кто ищет ответы на важные жизненные вопросы. Работа с отношениями, карьерными решениями, внутренними конфликтами и поиском предназначения.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Quote', 'ru', 'Каждый вопрос — это дверь к новому пониманию себя.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Benefits', 'ru', 'Прояснение жизненных ситуаций|Работа с отношениями|Поиск предназначения|Внутренняя гармония и баланс'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Duration', 'ru', '60 минут'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Format', 'ru', 'Онлайн / Офлайн'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'LanguageOffered', 'ru', 'Русский, Английский'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'CtaHeading', 'ru', 'Нужна помощь?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'CtaText', 'ru', 'Запишитесь на персональную консультацию — первый шаг к переменам.')
ON CONFLICT ("EntityType", "EntityId", "Field", "Language") DO UPDATE SET "Value" = EXCLUDED."Value";

-- 4. Insert translations for new consultations (EN)
INSERT INTO "Translations" ("Id", "EntityType", "EntityId", "Field", "Language", "Value") VALUES
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Title', 'en', 'Spiritual Development'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Subtitle', 'en', 'A path to awareness and harmony'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Eyebrow', 'en', 'Spiritual practices'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Description', 'en', 'Individual guidance on the path of spiritual growth. Working with meditation, mantras, energy practices and mindfulness in everyday life.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Quote', 'en', 'Spiritual development is not an escape from reality, but a deep dive into it.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Benefits', 'en', 'Deep meditative practice|Work with energy centres|Individual development programme|Support at every stage'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Duration', 'en', '60 minutes'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Format', 'en', 'Online / Offline'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'LanguageOffered', 'en', 'Russian, English'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'CtaHeading', 'en', 'Ready to start your journey?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'CtaText', 'en', 'Book a consultation and take the first step towards a conscious life.'),

  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Title', 'en', 'Youth Programme'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Subtitle', 'en', 'Support and development for teenagers and young people'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Eyebrow', 'en', 'Youth programme'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Description', 'en', 'A special programme for teenagers and young people. We help manage stress, find inner balance and develop emotional resilience through yoga and meditation.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Quote', 'en', 'Youth is the best time to lay the foundation for a mindful life.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Benefits', 'en', 'Stress and emotion management|Focus and attention techniques|Building self-confidence|Healthy habits for life'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Duration', 'en', '45 minutes'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Format', 'en', 'Online / Offline'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'LanguageOffered', 'en', 'Russian, Ukrainian'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'CtaHeading', 'en', 'Want to enrol your child?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'CtaText', 'en', 'Leave a request and we will find a suitable programme.'),

  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Title', 'en', 'Personal Questions'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Subtitle', 'en', 'Individual work with life situations'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Eyebrow', 'en', 'Personal consultation'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Description', 'en', 'A personal consultation for those seeking answers to important life questions. Work with relationships, career decisions, inner conflicts and finding purpose.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Quote', 'en', 'Every question is a door to a new understanding of yourself.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Benefits', 'en', 'Clarity on life situations|Relationship work|Finding purpose|Inner harmony and balance'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Duration', 'en', '60 minutes'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Format', 'en', 'Online / Offline'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'LanguageOffered', 'en', 'Russian, English'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'CtaHeading', 'en', 'Need guidance?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'CtaText', 'en', 'Book a personal consultation — the first step towards change.')
ON CONFLICT ("EntityType", "EntityId", "Field", "Language") DO UPDATE SET "Value" = EXCLUDED."Value";

-- 5. Insert translations for new consultations (UK)
INSERT INTO "Translations" ("Id", "EntityType", "EntityId", "Field", "Language", "Value") VALUES
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Title', 'uk', 'Духовний розвиток'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Subtitle', 'uk', 'Шлях до усвідомленості та гармонії'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Eyebrow', 'uk', 'Духовні практики'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Description', 'uk', 'Індивідуальний супровід на шляху духовного зростання. Робота з медитацією, мантрами, енергетичними практиками та усвідомленістю у повсякденному житті.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Quote', 'uk', 'Духовний розвиток — це не втеча від реальності, а глибоке занурення в неї.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Benefits', 'uk', 'Глибока медитативна практика|Робота з енергетичними центрами|Індивідуальна програма розвитку|Підтримка на кожному етапі шляху'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Duration', 'uk', '60 хвилин'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'Format', 'uk', 'Онлайн / Офлайн'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'LanguageOffered', 'uk', 'Російська, Англійська'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'CtaHeading', 'uk', 'Готові розпочати свій шлях?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333304', 'CtaText', 'uk', 'Запишіться на консультацію та зробіть перший крок до усвідомленого життя.'),

  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Title', 'uk', 'Для молоді'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Subtitle', 'uk', 'Підтримка та розвиток для підлітків та молоді'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Eyebrow', 'uk', 'Молодіжна програма'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Description', 'uk', 'Спеціальна програма для підлітків та молоді. Допомагаємо впоратися зі стресом, знайти внутрішній баланс та розвинути емоційну стійкість через йогу та медитацію.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Quote', 'uk', 'Молодість — найкращий час, щоб закласти фундамент усвідомленого життя.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Benefits', 'uk', 'Управління стресом та емоціями|Техніки концентрації та уваги|Розвиток впевненості в собі|Здорові звички на все життя'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Duration', 'uk', '45 хвилин'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'Format', 'uk', 'Онлайн / Офлайн'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'LanguageOffered', 'uk', 'Російська, Українська'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'CtaHeading', 'uk', 'Хочете записати дитину?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333305', 'CtaText', 'uk', 'Залиште заявку, і ми підберемо відповідну програму.'),

  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Title', 'uk', 'Особисті питання'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Subtitle', 'uk', 'Індивідуальна робота з життєвими ситуаціями'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Eyebrow', 'uk', 'Персональна консультація'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Description', 'uk', 'Персональна консультація для тих, хто шукає відповіді на важливі життєві питання. Робота з відносинами, кар''єрними рішеннями, внутрішніми конфліктами та пошуком призначення.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Quote', 'uk', 'Кожне питання — це двері до нового розуміння себе.'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Benefits', 'uk', 'Прояснення життєвих ситуацій|Робота з відносинами|Пошук призначення|Внутрішня гармонія та баланс'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Duration', 'uk', '60 хвилин'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'Format', 'uk', 'Онлайн / Офлайн'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'LanguageOffered', 'uk', 'Російська, Англійська'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'CtaHeading', 'uk', 'Потрібна допомога?'),
  (gen_random_uuid(), 'Consultation', '33333333-3333-3333-3333-333333333306', 'CtaText', 'uk', 'Запишіться на персональну консультацію — перший крок до змін.')
ON CONFLICT ("EntityType", "EntityId", "Field", "Language") DO UPDATE SET "Value" = EXCLUDED."Value";

-- 6. Add new UiTranslations for nav (if not already present from API)
INSERT INTO "UiTranslations" ("Id", "Key", "Language", "Value") VALUES
  (gen_random_uuid(), 'nav.consultations.spiritual_development', 'ru', 'Духовное развитие'),
  (gen_random_uuid(), 'nav.consultations.spiritual_development', 'en', 'Spiritual Development'),
  (gen_random_uuid(), 'nav.consultations.spiritual_development', 'uk', 'Духовний розвиток'),
  (gen_random_uuid(), 'nav.consultations.youth', 'ru', 'Молодежь'),
  (gen_random_uuid(), 'nav.consultations.youth', 'en', 'Youth'),
  (gen_random_uuid(), 'nav.consultations.youth', 'uk', 'Молодь'),
  (gen_random_uuid(), 'nav.consultations.personal', 'ru', 'Личные вопросы'),
  (gen_random_uuid(), 'nav.consultations.personal', 'en', 'Personal Questions'),
  (gen_random_uuid(), 'nav.consultations.personal', 'uk', 'Особисті питання')
ON CONFLICT ("Key", "Language") DO UPDATE SET "Value" = EXCLUDED."Value";

COMMIT;
