using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedContentTranslations : Migration
    {
        private static readonly Guid CourseP  = new("22222222-2222-2222-2222-222222222201");
        private static readonly Guid CourseM  = new("22222222-2222-2222-2222-222222222202");
        private static readonly Guid CourseY  = new("22222222-2222-2222-2222-222222222203");
        private static readonly Guid ConsultE = new("33333333-3333-3333-3333-333333333301");
        private static readonly Guid ConsultA = new("33333333-3333-3333-3333-333333333302");
        private static readonly Guid ConsultS = new("33333333-3333-3333-3333-333333333303");
        private static readonly Guid PageAbout    = new("44444444-4444-4444-4444-444444444401");
        private static readonly Guid PageContacts = new("44444444-4444-4444-4444-444444444402");

        // CourseModule IDs
        private static readonly Guid ModP1 = new("dd000000-0000-0000-0000-000000000101");
        private static readonly Guid ModP2 = new("dd000000-0000-0000-0000-000000000102");
        private static readonly Guid ModP3 = new("dd000000-0000-0000-0000-000000000103");
        private static readonly Guid ModP4 = new("dd000000-0000-0000-0000-000000000104");
        private static readonly Guid ModM1 = new("dd000000-0000-0000-0000-000000000201");
        private static readonly Guid ModM2 = new("dd000000-0000-0000-0000-000000000202");
        private static readonly Guid ModM3 = new("dd000000-0000-0000-0000-000000000203");
        private static readonly Guid ModM4 = new("dd000000-0000-0000-0000-000000000204");
        private static readonly Guid ModY1 = new("dd000000-0000-0000-0000-000000000301");
        private static readonly Guid ModY2 = new("dd000000-0000-0000-0000-000000000302");
        private static readonly Guid ModY3 = new("dd000000-0000-0000-0000-000000000303");
        private static readonly Guid ModY4 = new("dd000000-0000-0000-0000-000000000304");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── CourseModules ──────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "CourseModules",
                columns: new[] { "Id", "CourseId", "SortOrder" },
                values: new object[,]
                {
                    { ModP1, CourseP, 1 }, { ModP2, CourseP, 2 }, { ModP3, CourseP, 3 }, { ModP4, CourseP, 4 },
                    { ModM1, CourseM, 1 }, { ModM2, CourseM, 2 }, { ModM3, CourseM, 3 }, { ModM4, CourseM, 4 },
                    { ModY1, CourseY, 1 }, { ModY2, CourseY, 2 }, { ModY3, CourseY, 3 }, { ModY4, CourseY, 4 }
                });

            // ── Course translations ────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    // Pranayama
                    { new Guid("cc000000-0000-0000-0000-000000000001"), CourseP, "Course", "Title",       "ru", "Пранаяма" },
                    { new Guid("cc000000-0000-0000-0000-000000000002"), CourseP, "Course", "ImageUrl",    "ru", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("cc000000-0000-0000-0000-000000000003"), CourseP, "Course", "Duration",    "ru", "8 недель" },
                    { new Guid("cc000000-0000-0000-0000-000000000004"), CourseP, "Course", "Schedule",    "ru", "24" },
                    { new Guid("cc000000-0000-0000-0000-000000000005"), CourseP, "Course", "Format",      "ru", "Онлайн / Офлайн" },
                    { new Guid("cc000000-0000-0000-0000-000000000006"), CourseP, "Course", "Level",       "ru", "Для всех" },
                    { new Guid("cc000000-0000-0000-0000-000000000007"), CourseP, "Course", "Description", "ru", "Пранаяма — это управление жизненной силой через дыхание. В нашем курсе вы освоите как базовые техники, так и продвинутые практики кумбхаки, нади-шодхана и капалабхати.\nКурс подходит как для начинающих, так и для опытных практикующих. Каждый урок строится на принципах безопасности и постепенного углубления." },
                    { new Guid("cc000000-0000-0000-0000-000000000008"), CourseP, "Course", "Benefits",    "ru", "Снижение стресса и тревожности|Улучшение качества сна|Повышение концентрации и ясности ума|Укрепление иммунитета|Глубокое расслабление и восстановление" },
                    { new Guid("cc000000-0000-0000-0000-000000000009"), CourseP, "Course", "ForWhom",     "ru", "Начинающим~Тем, кто хочет впервые познакомиться с дыхательными практиками в безопасной и структурированной среде.|При стрессе и тревоге~Тем, кто ищет проверенные инструменты для управления эмоциональным состоянием и успокоения нервной системы.|Для углубления практики~Опытным практикующим йогу и медитацию, желающим освоить более тонкий слой работы с энергией." },
                    { new Guid("cc000000-0000-0000-0000-000000000010"), CourseP, "Course", "CtaHeading",  "ru", "Готовы начать путь?" },
                    { new Guid("cc000000-0000-0000-0000-000000000011"), CourseP, "Course", "CtaText",     "ru", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке." },
                    // Meditation
                    { new Guid("cc000000-0000-0000-0000-000000000012"), CourseM, "Course", "Title",       "ru", "Медитация" },
                    { new Guid("cc000000-0000-0000-0000-000000000013"), CourseM, "Course", "ImageUrl",    "ru", "https://images.unsplash.com/photo-1508672019048-805c876b67e2?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("cc000000-0000-0000-0000-000000000014"), CourseM, "Course", "Duration",    "ru", "6 недель" },
                    { new Guid("cc000000-0000-0000-0000-000000000015"), CourseM, "Course", "Schedule",    "ru", "20" },
                    { new Guid("cc000000-0000-0000-0000-000000000016"), CourseM, "Course", "Format",      "ru", "Онлайн" },
                    { new Guid("cc000000-0000-0000-0000-000000000017"), CourseM, "Course", "Level",       "ru", "Для всех" },
                    { new Guid("cc000000-0000-0000-0000-000000000018"), CourseM, "Course", "Description", "ru", "Медитация — это не отключение от реальности, а глубокое присутствие в ней. Наш курс построен по принципу от простого к сложному: от концентрации внимания до безобъектной осознанности.\nВы освоите техники из буддийской, ведической и даосской традиций. Каждая практика сопровождается детальными инструкциями и подходит для самостоятельного выполнения дома." },
                    { new Guid("cc000000-0000-0000-0000-000000000019"), CourseM, "Course", "Benefits",    "ru", "Управление тревогой и внутренним диалогом|Развитие осознанности в повседневной жизни|Глубокое расслабление нервной системы|Ясность ума и улучшение памяти|Обретение внутренней устойчивости" },
                    { new Guid("cc000000-0000-0000-0000-000000000020"), CourseM, "Course", "ForWhom",     "ru", "Тем, кто в поиске~Ищущим внутренней опоры и устойчивости в непростое время. Медитация даёт точку отсчёта — независимо от обстоятельств.|Для умственной работы~Тем, кто работает с большим объёмом информации и хочет улучшить концентрацию, память и скорость принятия решений.|Практикующим йогу~Тем, кто уже занимается физической практикой и хочет добавить к ней медитативное измерение для более глубокого эффекта." },
                    { new Guid("cc000000-0000-0000-0000-000000000021"), CourseM, "Course", "CtaHeading",  "ru", "Готовы начать путь?" },
                    { new Guid("cc000000-0000-0000-0000-000000000022"), CourseM, "Course", "CtaText",     "ru", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке." },
                    // Yoga
                    { new Guid("cc000000-0000-0000-0000-000000000023"), CourseY, "Course", "Title",       "ru", "Йога" },
                    { new Guid("cc000000-0000-0000-0000-000000000024"), CourseY, "Course", "ImageUrl",    "ru", "https://images.unsplash.com/photo-1545205597-3d9d02c29597?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("cc000000-0000-0000-0000-000000000025"), CourseY, "Course", "Duration",    "ru", "10 недель" },
                    { new Guid("cc000000-0000-0000-0000-000000000026"), CourseY, "Course", "Schedule",    "ru", "32" },
                    { new Guid("cc000000-0000-0000-0000-000000000027"), CourseY, "Course", "Format",      "ru", "Офлайн" },
                    { new Guid("cc000000-0000-0000-0000-000000000028"), CourseY, "Course", "Level",       "ru", "Базовый+" },
                    { new Guid("cc000000-0000-0000-0000-000000000029"), CourseY, "Course", "Description", "ru", "Йога — это не только гибкость тела. Это система, объединяющая движение, дыхание и внимание в единый поток. Наш курс построен на традиции хатха-йоги с элементами аштанга и кундалини.\nВы научитесь строить стабильную домашнюю практику, работать с травмами и ограничениями тела, а главное — чувствовать себя живым и наполненным после каждого занятия." },
                    { new Guid("cc000000-0000-0000-0000-000000000030"), CourseY, "Course", "Benefits",    "ru", "Гибкость, сила и баланс тела|Коррекция осанки и работа с позвоночником|Снятие хронического напряжения и боли|Интеграция дыхания и движения|Выход на медитативную практику через тело" },
                    { new Guid("cc000000-0000-0000-0000-000000000031"), CourseY, "Course", "ForWhom",     "ru", "Новичкам~Тем, кто хочет начать с нуля под руководством опытного преподавателя и выстроить правильную базу.|При болях в теле~Тем, кто хочет решить проблемы с осанкой, хроническими болями в спине или ограниченной подвижностью суставов.|Для холистического роста~Тем, кто хочет не просто физическую нагрузку, а глубокую практику, объединяющую тело, дыхание и ум." },
                    { new Guid("cc000000-0000-0000-0000-000000000032"), CourseY, "Course", "CtaHeading",  "ru", "Готовы начать путь?" },
                    { new Guid("cc000000-0000-0000-0000-000000000033"), CourseY, "Course", "CtaText",     "ru", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке." }
                });

            // ── Consultation translations ──────────────────────────────────────
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    // Energy
                    { new Guid("cc000000-0000-0000-0000-000000000034"), ConsultE, "Consultation", "Title",           "ru", "Энергетика" },
                    { new Guid("cc000000-0000-0000-0000-000000000035"), ConsultE, "Consultation", "ImageUrl",        "ru", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("cc000000-0000-0000-0000-000000000036"), ConsultE, "Consultation", "Duration",        "ru", "90 минут" },
                    { new Guid("cc000000-0000-0000-0000-000000000037"), ConsultE, "Consultation", "Format",          "ru", "Онлайн" },
                    { new Guid("cc000000-0000-0000-0000-000000000038"), ConsultE, "Consultation", "LanguageOffered", "ru", "Ру/EN" },
                    { new Guid("cc000000-0000-0000-0000-000000000039"), ConsultE, "Consultation", "PriceLabel",      "ru", "От 1 сессии" },
                    { new Guid("cc000000-0000-0000-0000-000000000040"), ConsultE, "Consultation", "Quote",           "ru", "«Равновесие энергии — это не люкс, это основа здоровья» — Ольга Шалетина" },
                    { new Guid("cc000000-0000-0000-0000-000000000041"), ConsultE, "Consultation", "Description",     "ru", "На консультации мы продиагностируем состояние ваших энергетических центров (чакр или нади), выявляем блокировки и создаём индивидуальную практику для восстановления потока.\nЗанятие проходит в формате диалога и практики: пранаяма, мудры, визуализации. Вы получите подробные рекомендации для самостоятельной работы." },
                    { new Guid("cc000000-0000-0000-0000-000000000042"), ConsultE, "Consultation", "Benefits",        "ru", "Диагностика энергетического состояния|Индивидуальная практика для балансировки|Работа с блокировками через дыхание и мантры|Умение самостоятельно поддерживать энергетический баланс" },
                    { new Guid("cc000000-0000-0000-0000-000000000043"), ConsultE, "Consultation", "CtaHeading",      "ru", "Готовы начать?" },
                    { new Guid("cc000000-0000-0000-0000-000000000044"), ConsultE, "Consultation", "CtaText",         "ru", "Оставьте заявку — мы ответим в течение дня и обсудим удобное время." },
                    // Ayurveda
                    { new Guid("cc000000-0000-0000-0000-000000000045"), ConsultA, "Consultation", "Title",           "ru", "Аюрведа" },
                    { new Guid("cc000000-0000-0000-0000-000000000046"), ConsultA, "Consultation", "ImageUrl",        "ru", "https://images.unsplash.com/photo-1584308666744-24d5c474f2ae?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("cc000000-0000-0000-0000-000000000047"), ConsultA, "Consultation", "Duration",        "ru", "2 часа" },
                    { new Guid("cc000000-0000-0000-0000-000000000048"), ConsultA, "Consultation", "Format",          "ru", "Онлайн" },
                    { new Guid("cc000000-0000-0000-0000-000000000049"), ConsultA, "Consultation", "LanguageOffered", "ru", "Ру/EN" },
                    { new Guid("cc000000-0000-0000-0000-000000000050"), ConsultA, "Consultation", "Quote",           "ru", "«Аюрведа — это не диета, это образ жизни, соответствующий вашей природе» — Александр Украинцев" },
                    { new Guid("cc000000-0000-0000-0000-000000000051"), ConsultA, "Consultation", "Description",     "ru", "Аюрведическая диагностика начинается с определения вашего природного типа (доши). Вата, Питта или Кафа — каждый требует индивидуального подхода к питанию, распорядку дня и практикам.\nВы получите детальный письменный отчёт с персональными рекомендациями по питанию, режиму дня, практикам и растениям." },
                    { new Guid("cc000000-0000-0000-0000-000000000052"), ConsultA, "Consultation", "Benefits",        "ru", "Определение вашего доша-типа|Индивидуальный план питания|Рекомендации по режиму дня|Аюрведические практики для вашего типа" },
                    { new Guid("cc000000-0000-0000-0000-000000000053"), ConsultA, "Consultation", "CtaHeading",      "ru", "Готовы начать?" },
                    { new Guid("cc000000-0000-0000-0000-000000000054"), ConsultA, "Consultation", "CtaText",         "ru", "Оставьте заявку — мы ответим в течение дня и обсудим удобное время." },
                    // Spirituality
                    { new Guid("cc000000-0000-0000-0000-000000000055"), ConsultS, "Consultation", "Title",           "ru", "Духовность" },
                    { new Guid("cc000000-0000-0000-0000-000000000056"), ConsultS, "Consultation", "ImageUrl",        "ru", "https://images.unsplash.com/photo-1499209974431-9dddcece7f88?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("cc000000-0000-0000-0000-000000000057"), ConsultS, "Consultation", "Duration",        "ru", "2 часа" },
                    { new Guid("cc000000-0000-0000-0000-000000000058"), ConsultS, "Consultation", "Format",          "ru", "Онлайн" },
                    { new Guid("cc000000-0000-0000-0000-000000000059"), ConsultS, "Consultation", "Quote",           "ru", "«Духовный путь начинается с честного взгляда на себя» — Александр Украинцев" },
                    { new Guid("cc000000-0000-0000-0000-000000000060"), ConsultS, "Consultation", "Description",     "ru", "Индивидуальная работа направлена на то, чтобы помочь вам освободиться от ограничивающих программ, обрести внутреннюю опору и найти собственный путь.\nКаждая сессия — это пространство безоценочного диалога, где вы расскажете о своём пути и получите инструменты для движения вперёд." },
                    { new Guid("cc000000-0000-0000-0000-000000000061"), ConsultS, "Consultation", "Benefits",        "ru", "Осознание жизненного пути и предназначения|Работа с саботирующими убеждениями|Раскрытие внутренних потенциалов|Гармонизация внутреннего и внешнего" },
                    { new Guid("cc000000-0000-0000-0000-000000000062"), ConsultS, "Consultation", "CtaHeading",      "ru", "Готовы начать?" },
                    { new Guid("cc000000-0000-0000-0000-000000000063"), ConsultS, "Consultation", "CtaText",         "ru", "Оставьте заявку — мы ответим в течение дня и обсудим удобное время." }
                });

            // ── SitePage translations ──────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("cc000000-0000-0000-0000-000000000064"), PageAbout,    "SitePage", "HeroTitle",    "ru", "О нас" },
                    { new Guid("cc000000-0000-0000-0000-000000000065"), PageAbout,    "SitePage", "HeroSubtitle", "ru", "Три пути — одна миссия" },
                    { new Guid("cc000000-0000-0000-0000-000000000066"), PageContacts, "SitePage", "HeroTitle",    "ru", "Контакты" },
                    { new Guid("cc000000-0000-0000-0000-000000000067"), PageContacts, "SitePage", "HeroSubtitle", "ru", "Всегда на связи" }
                });

            // ── CourseModule translations ──────────────────────────────────────
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    // Pranayama modules
                    { new Guid("cc000000-0000-0000-0000-000000000068"), ModP1, "CourseModule", "Title",       "ru", "Основы осознанного дыхания" },
                    { new Guid("cc000000-0000-0000-0000-000000000069"), ModP1, "CourseModule", "Description", "ru", "Анатомия дыхания, диафрагмальное дыхание, наблюдение за дыхательным циклом. Практика: полное йогическое дыхание." },
                    { new Guid("cc000000-0000-0000-0000-000000000070"), ModP2, "CourseModule", "Title",       "ru", "Балансирующие техники" },
                    { new Guid("cc000000-0000-0000-0000-000000000071"), ModP2, "CourseModule", "Description", "ru", "Нади-шодхана (поочерёдное дыхание), вилома и анулома пранаяма. Работа с энергетическими каналами." },
                    { new Guid("cc000000-0000-0000-0000-000000000072"), ModP3, "CourseModule", "Title",       "ru", "Активизирующие практики" },
                    { new Guid("cc000000-0000-0000-0000-000000000073"), ModP3, "CourseModule", "Description", "ru", "Капалабхати, бхастрика, сурья-бхедана. Техники для пробуждения и наполнения энергией." },
                    { new Guid("cc000000-0000-0000-0000-000000000074"), ModP4, "CourseModule", "Title",       "ru", "Задержки дыхания (кумбхака)" },
                    { new Guid("cc000000-0000-0000-0000-000000000075"), ModP4, "CourseModule", "Description", "ru", "Антара и бахья кумбхака. Мула-бандха, уддияна-бандха. Интеграция в медитативную практику." },
                    // Meditation modules
                    { new Guid("cc000000-0000-0000-0000-000000000076"), ModM1, "CourseModule", "Title",       "ru", "Природа ума. Базовая концентрация" },
                    { new Guid("cc000000-0000-0000-0000-000000000077"), ModM1, "CourseModule", "Description", "ru", "Как работает внимание. Техника самадхи-шамати: фокус на дыхании, мантре, образе. Развитие устойчивого присутствия." },
                    { new Guid("cc000000-0000-0000-0000-000000000078"), ModM2, "CourseModule", "Title",       "ru", "Медитация осознанности (Випассана)" },
                    { new Guid("cc000000-0000-0000-0000-000000000079"), ModM2, "CourseModule", "Description", "ru", "Наблюдение телесных ощущений, мыслей и эмоций. Практика безоценочного присутствия. Работа с внутренним критиком." },
                    { new Guid("cc000000-0000-0000-0000-000000000080"), ModM3, "CourseModule", "Title",       "ru", "Медитации любящей доброты" },
                    { new Guid("cc000000-0000-0000-0000-000000000081"), ModM3, "CourseModule", "Description", "ru", "Метта и каруна — практики развития сострадания. Работа с трудными отношениями. Культивация радости и принятия." },
                    { new Guid("cc000000-0000-0000-0000-000000000082"), ModM4, "CourseModule", "Title",       "ru", "Интеграция в жизнь" },
                    { new Guid("cc000000-0000-0000-0000-000000000083"), ModM4, "CourseModule", "Description", "ru", "Медитация в движении и повседневных делах. Создание устойчивой практики. Самостоятельная программа на следующие месяцы." },
                    // Yoga modules
                    { new Guid("cc000000-0000-0000-0000-000000000084"), ModY1, "CourseModule", "Title",       "ru", "Основы хатха-йоги" },
                    { new Guid("cc000000-0000-0000-0000-000000000085"), ModY1, "CourseModule", "Description", "ru", "Правильная постановка тела в базовых асанах. Принципы выравнивания. Приветствие солнцу — сурья-намаскар как основа практики." },
                    { new Guid("cc000000-0000-0000-0000-000000000086"), ModY2, "CourseModule", "Title",       "ru", "Работа с позвоночником" },
                    { new Guid("cc000000-0000-0000-0000-000000000087"), ModY2, "CourseModule", "Description", "ru", "Сгибания, разгибания, скручивания и боковые наклоны. Безопасная работа с пояснично-крестцовым отделом. Профилактика и реабилитация." },
                    { new Guid("cc000000-0000-0000-0000-000000000088"), ModY3, "CourseModule", "Title",       "ru", "Баланс и перевёрнутые положения" },
                    { new Guid("cc000000-0000-0000-0000-000000000089"), ModY3, "CourseModule", "Description", "ru", "Стойка на руках, широкоугольная стойка, сарвангасана. Развитие проприоцепции и внутреннего равновесия." },
                    { new Guid("cc000000-0000-0000-0000-000000000090"), ModY4, "CourseModule", "Title",       "ru", "Интеграция. Йога-нидра" },
                    { new Guid("cc000000-0000-0000-0000-000000000091"), ModY4, "CourseModule", "Description", "ru", "Полное расслабление в шавасане и йога-нидре. Построение самостоятельной практики. Ритм жизни как ритм практики." }
                });

            // ── Cleanup stale test translation ────────────────────────────────
            migrationBuilder.Sql(@"DELETE FROM ""Translations"" WHERE ""EntityId"" = 'a0000000-0000-0000-0000-000000004403';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM ""Translations"" WHERE ""Id""::text LIKE 'cc000000-%';
                DELETE FROM ""CourseModules"" WHERE ""Id""::text LIKE 'dd000000-%';
            ");
        }
    }
}
