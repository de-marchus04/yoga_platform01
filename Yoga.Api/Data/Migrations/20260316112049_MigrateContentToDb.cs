using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrateContentToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Retreats",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceLabel",
                table: "Retreats",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    MediaUrl = table.Column<string>(type: "text", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Alt = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SitePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Field = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UiTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiTranslations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$pWze5mwxiEzQYqeAC1YKU.THt/qAoSCtLKrBpW9xqRgT1c8UoIA7i");

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "IsActive", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333301"), true, "energy", 1 },
                    { new Guid("33333333-3333-3333-3333-333333333302"), true, "ayurveda", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333303"), true, "spirituality", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsActive", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), true, "pranayama", 1 },
                    { new Guid("22222222-2222-2222-2222-222222222202"), true, "meditation", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222203"), true, "yoga", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ImageUrl", "PriceLabel" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "SitePages",
                columns: new[] { "Id", "Slug" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444401"), "about" },
                    { new Guid("44444444-4444-4444-4444-444444444402"), "contacts" }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("a0000001-0001-0001-0001-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Title", "ru", "Ретрит в Черногории: Возврат к себе" },
                    { new Guid("a0000001-0001-0001-0001-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Description", "ru", "Погружение в себя на берегу Адриатического моря. Практики тишины, йога 2 раза в день, авторское меню и детокс." },
                    { new Guid("a0000001-0001-0001-0001-000000000003"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Location", "ru", "Будва, Черногория" },
                    { new Guid("a0000001-0001-0001-0001-000000000004"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Title", "en", "Retreat in Montenegro: Return to Yourself" },
                    { new Guid("a0000001-0001-0001-0001-000000000005"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Description", "en", "A deep dive into yourself on the shores of the Adriatic Sea. Silence practices, yoga twice a day, a curated menu and detox." },
                    { new Guid("a0000001-0001-0001-0001-000000000006"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Location", "en", "Budva, Montenegro" },
                    { new Guid("a0000001-0001-0001-0001-000000000007"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Title", "uk", "Ретрит у Чорногорії: Повернення до себе" },
                    { new Guid("a0000001-0001-0001-0001-000000000008"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Description", "uk", "Занурення в себе на березі Адріатичного моря. Практики тиші, йога 2 рази на день, авторське меню та детокс." },
                    { new Guid("a0000001-0001-0001-0001-000000000009"), new Guid("11111111-1111-1111-1111-111111111111"), "Retreat", "Location", "uk", "Будва, Чорногорія" }
                });

            migrationBuilder.InsertData(
                table: "UiTranslations",
                columns: new[] { "Id", "Key", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), "nav.home", "ru", "Главная" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), "nav.home", "en", "Home" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), "nav.home", "uk", "Головна" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), "nav.courses", "ru", "Курсы" },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), "nav.courses", "en", "Courses" },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), "nav.courses", "uk", "Курси" },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), "nav.courses.pranayama", "ru", "Пранаяма" },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), "nav.courses.pranayama", "en", "Pranayama" },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), "nav.courses.pranayama", "uk", "Пранаяма" },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), "nav.courses.meditation", "ru", "Медитация" },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), "nav.courses.meditation", "en", "Meditation" },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), "nav.courses.meditation", "uk", "Медитація" },
                    { new Guid("b0000000-0000-0000-0000-000000000013"), "nav.courses.yoga", "ru", "Йога" },
                    { new Guid("b0000000-0000-0000-0000-000000000014"), "nav.courses.yoga", "en", "Yoga" },
                    { new Guid("b0000000-0000-0000-0000-000000000015"), "nav.courses.yoga", "uk", "Йога" },
                    { new Guid("b0000000-0000-0000-0000-000000000016"), "nav.consultations", "ru", "Консультации" },
                    { new Guid("b0000000-0000-0000-0000-000000000017"), "nav.consultations", "en", "Consultations" },
                    { new Guid("b0000000-0000-0000-0000-000000000018"), "nav.consultations", "uk", "Консультації" },
                    { new Guid("b0000000-0000-0000-0000-000000000019"), "nav.consultations.energy", "ru", "Энергетика" },
                    { new Guid("b0000000-0000-0000-0000-000000000020"), "nav.consultations.energy", "en", "Energetics" },
                    { new Guid("b0000000-0000-0000-0000-000000000021"), "nav.consultations.energy", "uk", "Енергетика" },
                    { new Guid("b0000000-0000-0000-0000-000000000022"), "nav.consultations.ayurveda", "ru", "Аюрведа" },
                    { new Guid("b0000000-0000-0000-0000-000000000023"), "nav.consultations.ayurveda", "en", "Ayurveda" },
                    { new Guid("b0000000-0000-0000-0000-000000000024"), "nav.consultations.ayurveda", "uk", "Аюрведа" },
                    { new Guid("b0000000-0000-0000-0000-000000000025"), "nav.consultations.spirituality", "ru", "Духовность" },
                    { new Guid("b0000000-0000-0000-0000-000000000026"), "nav.consultations.spirituality", "en", "Spirituality" },
                    { new Guid("b0000000-0000-0000-0000-000000000027"), "nav.consultations.spirituality", "uk", "Духовність" },
                    { new Guid("b0000000-0000-0000-0000-000000000028"), "nav.retreats", "ru", "Ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000029"), "nav.retreats", "en", "Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000030"), "nav.retreats", "uk", "Ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000031"), "nav.retreats.actual", "ru", "Актуальные" },
                    { new Guid("b0000000-0000-0000-0000-000000000032"), "nav.retreats.actual", "en", "Current" },
                    { new Guid("b0000000-0000-0000-0000-000000000033"), "nav.retreats.actual", "uk", "Актуальні" },
                    { new Guid("b0000000-0000-0000-0000-000000000034"), "nav.retreats.upcoming", "ru", "Предстоящие" },
                    { new Guid("b0000000-0000-0000-0000-000000000035"), "nav.retreats.upcoming", "en", "Upcoming" },
                    { new Guid("b0000000-0000-0000-0000-000000000036"), "nav.retreats.upcoming", "uk", "Майбутні" },
                    { new Guid("b0000000-0000-0000-0000-000000000037"), "nav.retreats.past", "ru", "Прошедшие" },
                    { new Guid("b0000000-0000-0000-0000-000000000038"), "nav.retreats.past", "en", "Past" },
                    { new Guid("b0000000-0000-0000-0000-000000000039"), "nav.retreats.past", "uk", "Минулі" },
                    { new Guid("b0000000-0000-0000-0000-000000000040"), "nav.blog", "ru", "Блог" },
                    { new Guid("b0000000-0000-0000-0000-000000000041"), "nav.blog", "en", "Blog" },
                    { new Guid("b0000000-0000-0000-0000-000000000042"), "nav.blog", "uk", "Блог" },
                    { new Guid("b0000000-0000-0000-0000-000000000043"), "nav.blog.articles", "ru", "Статьи" },
                    { new Guid("b0000000-0000-0000-0000-000000000044"), "nav.blog.articles", "en", "Articles" },
                    { new Guid("b0000000-0000-0000-0000-000000000045"), "nav.blog.articles", "uk", "Статті" },
                    { new Guid("b0000000-0000-0000-0000-000000000046"), "nav.blog.videos", "ru", "Видео" },
                    { new Guid("b0000000-0000-0000-0000-000000000047"), "nav.blog.videos", "en", "Videos" },
                    { new Guid("b0000000-0000-0000-0000-000000000048"), "nav.blog.videos", "uk", "Відео" },
                    { new Guid("b0000000-0000-0000-0000-000000000049"), "nav.blog.photos", "ru", "Фото" },
                    { new Guid("b0000000-0000-0000-0000-000000000050"), "nav.blog.photos", "en", "Photos" },
                    { new Guid("b0000000-0000-0000-0000-000000000051"), "nav.blog.photos", "uk", "Фото" },
                    { new Guid("b0000000-0000-0000-0000-000000000052"), "nav.about", "ru", "О нас" },
                    { new Guid("b0000000-0000-0000-0000-000000000053"), "nav.about", "en", "About" },
                    { new Guid("b0000000-0000-0000-0000-000000000054"), "nav.about", "uk", "Про нас" },
                    { new Guid("b0000000-0000-0000-0000-000000000055"), "nav.contacts", "ru", "Контакты" },
                    { new Guid("b0000000-0000-0000-0000-000000000056"), "nav.contacts", "en", "Contact" },
                    { new Guid("b0000000-0000-0000-0000-000000000057"), "nav.contacts", "uk", "Контакти" },
                    { new Guid("b0000000-0000-0000-0000-000000000058"), "footer.copy", "ru", "© 2026 Yoga.Life Enterprise. Возврат к истокам." },
                    { new Guid("b0000000-0000-0000-0000-000000000059"), "footer.copy", "en", "© 2026 Yoga.Life Enterprise. A return to origins." },
                    { new Guid("b0000000-0000-0000-0000-000000000060"), "footer.copy", "uk", "© 2026 Yoga.Life Enterprise. Повернення до витоків." },
                    { new Guid("b0000000-0000-0000-0000-000000000061"), "page.home.title", "ru", "Yoga.Life | Авторские Ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000062"), "page.home.title", "en", "Yoga.Life | Author-Led Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000063"), "page.home.title", "uk", "Yoga.Life | Авторські Ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000064"), "page.home.hero.eyebrow", "ru", "Yoga · Life · Enterprise" },
                    { new Guid("b0000000-0000-0000-0000-000000000065"), "page.home.hero.eyebrow", "en", "Yoga · Life · Enterprise" },
                    { new Guid("b0000000-0000-0000-0000-000000000066"), "page.home.hero.eyebrow", "uk", "Yoga · Life · Enterprise" },
                    { new Guid("b0000000-0000-0000-0000-000000000067"), "page.home.hero.h1.line1", "ru", "Возврат" },
                    { new Guid("b0000000-0000-0000-0000-000000000068"), "page.home.hero.h1.line1", "en", "Return" },
                    { new Guid("b0000000-0000-0000-0000-000000000069"), "page.home.hero.h1.line1", "uk", "Повернення" },
                    { new Guid("b0000000-0000-0000-0000-000000000070"), "page.home.hero.h1.em", "ru", "к себе" },
                    { new Guid("b0000000-0000-0000-0000-000000000071"), "page.home.hero.h1.em", "en", "to yourself" },
                    { new Guid("b0000000-0000-0000-0000-000000000072"), "page.home.hero.h1.em", "uk", "до себе" },
                    { new Guid("b0000000-0000-0000-0000-000000000073"), "page.home.hero.text", "ru", "Авторские ретриты и программы обучения. Погружение в тишину, практики осознанности и полное обновление." },
                    { new Guid("b0000000-0000-0000-0000-000000000074"), "page.home.hero.text", "en", "Author-led retreats and training programmes. A plunge into stillness, mindfulness practices and complete renewal." },
                    { new Guid("b0000000-0000-0000-0000-000000000075"), "page.home.hero.text", "uk", "Авторські ретрити та навчальні програми. Занурення в тишу, практики усвідомленості та повне оновлення." },
                    { new Guid("b0000000-0000-0000-0000-000000000076"), "page.home.hero.cta", "ru", "Записаться" },
                    { new Guid("b0000000-0000-0000-0000-000000000077"), "page.home.hero.cta", "en", "Sign up" },
                    { new Guid("b0000000-0000-0000-0000-000000000078"), "page.home.hero.cta", "uk", "Записатися" },
                    { new Guid("b0000000-0000-0000-0000-000000000079"), "page.home.stats.retreats", "ru", "Ретритов" },
                    { new Guid("b0000000-0000-0000-0000-000000000080"), "page.home.stats.retreats", "en", "Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000081"), "page.home.stats.retreats", "uk", "Ретритів" },
                    { new Guid("b0000000-0000-0000-0000-000000000082"), "page.home.stats.members", "ru", "Участников" },
                    { new Guid("b0000000-0000-0000-0000-000000000083"), "page.home.stats.members", "en", "Participants" },
                    { new Guid("b0000000-0000-0000-0000-000000000084"), "page.home.stats.members", "uk", "Учасників" },
                    { new Guid("b0000000-0000-0000-0000-000000000085"), "page.home.stats.countries", "ru", "Стран" },
                    { new Guid("b0000000-0000-0000-0000-000000000086"), "page.home.stats.countries", "en", "Countries" },
                    { new Guid("b0000000-0000-0000-0000-000000000087"), "page.home.stats.countries", "uk", "Країн" },
                    { new Guid("b0000000-0000-0000-0000-000000000088"), "page.home.stats.years", "ru", "Лет практики" },
                    { new Guid("b0000000-0000-0000-0000-000000000089"), "page.home.stats.years", "en", "Years of practice" },
                    { new Guid("b0000000-0000-0000-0000-000000000090"), "page.home.stats.years", "uk", "Років практики" },
                    { new Guid("b0000000-0000-0000-0000-000000000091"), "page.home.retreats.eyebrow", "ru", "Программы" },
                    { new Guid("b0000000-0000-0000-0000-000000000092"), "page.home.retreats.eyebrow", "en", "Programmes" },
                    { new Guid("b0000000-0000-0000-0000-000000000093"), "page.home.retreats.eyebrow", "uk", "Програми" },
                    { new Guid("b0000000-0000-0000-0000-000000000094"), "page.home.retreats.h2", "ru", "Ближайшие ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000095"), "page.home.retreats.h2", "en", "Upcoming Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000096"), "page.home.retreats.h2", "uk", "Найближчі ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000097"), "page.home.retreats.loading", "ru", "Загрузка расписания..." },
                    { new Guid("b0000000-0000-0000-0000-000000000098"), "page.home.retreats.loading", "en", "Loading schedule..." },
                    { new Guid("b0000000-0000-0000-0000-000000000099"), "page.home.retreats.loading", "uk", "Завантаження розкладу..." },
                    { new Guid("b0000000-0000-0000-0000-000000000100"), "page.home.retreats.empty", "ru", "Нет доступных ретритов в данный момент." },
                    { new Guid("b0000000-0000-0000-0000-000000000101"), "page.home.retreats.empty", "en", "No retreats currently available." },
                    { new Guid("b0000000-0000-0000-0000-000000000102"), "page.home.retreats.empty", "uk", "Немає доступних ретритів на даний момент." },
                    { new Guid("b0000000-0000-0000-0000-000000000103"), "page.home.retreats.cta", "ru", "Хочу сюда" },
                    { new Guid("b0000000-0000-0000-0000-000000000104"), "page.home.retreats.cta", "en", "I want to go" },
                    { new Guid("b0000000-0000-0000-0000-000000000105"), "page.home.retreats.cta", "uk", "Хочу сюди" },
                    { new Guid("b0000000-0000-0000-0000-000000000106"), "page.home.directions.eyebrow", "ru", "Что мы предлагаем" },
                    { new Guid("b0000000-0000-0000-0000-000000000107"), "page.home.directions.eyebrow", "en", "What we offer" },
                    { new Guid("b0000000-0000-0000-0000-000000000108"), "page.home.directions.eyebrow", "uk", "Що ми пропонуємо" },
                    { new Guid("b0000000-0000-0000-0000-000000000109"), "page.home.directions.h2", "ru", "Направления" },
                    { new Guid("b0000000-0000-0000-0000-000000000110"), "page.home.directions.h2", "en", "Directions" },
                    { new Guid("b0000000-0000-0000-0000-000000000111"), "page.home.directions.h2", "uk", "Напрямки" },
                    { new Guid("b0000000-0000-0000-0000-000000000112"), "page.home.directions.01", "ru", "01" },
                    { new Guid("b0000000-0000-0000-0000-000000000113"), "page.home.directions.01", "en", "01" },
                    { new Guid("b0000000-0000-0000-0000-000000000114"), "page.home.directions.01", "uk", "01" },
                    { new Guid("b0000000-0000-0000-0000-000000000115"), "page.home.directions.01.h3", "ru", "Курсы" },
                    { new Guid("b0000000-0000-0000-0000-000000000116"), "page.home.directions.01.h3", "en", "Courses" },
                    { new Guid("b0000000-0000-0000-0000-000000000117"), "page.home.directions.01.h3", "uk", "Курси" },
                    { new Guid("b0000000-0000-0000-0000-000000000118"), "page.home.directions.01.text", "ru", "Пранаяма, медитация, йога — системные программы для углублённой практики в любом темпе." },
                    { new Guid("b0000000-0000-0000-0000-000000000119"), "page.home.directions.01.text", "en", "Pranayama, meditation, yoga — structured programmes for deepening your practice at your own pace." },
                    { new Guid("b0000000-0000-0000-0000-000000000120"), "page.home.directions.01.text", "uk", "Пранаяма, медитація, йога — системні програми для поглибленої практики в будь-якому темпі." },
                    { new Guid("b0000000-0000-0000-0000-000000000121"), "page.home.directions.01.link", "ru", "Смотреть курсы →" },
                    { new Guid("b0000000-0000-0000-0000-000000000122"), "page.home.directions.01.link", "en", "View courses →" },
                    { new Guid("b0000000-0000-0000-0000-000000000123"), "page.home.directions.01.link", "uk", "Дивитися курси →" },
                    { new Guid("b0000000-0000-0000-0000-000000000124"), "page.home.directions.02", "ru", "02" },
                    { new Guid("b0000000-0000-0000-0000-000000000125"), "page.home.directions.02", "en", "02" },
                    { new Guid("b0000000-0000-0000-0000-000000000126"), "page.home.directions.02", "uk", "02" },
                    { new Guid("b0000000-0000-0000-0000-000000000127"), "page.home.directions.02.h3", "ru", "Консультации" },
                    { new Guid("b0000000-0000-0000-0000-000000000128"), "page.home.directions.02.h3", "en", "Consultations" },
                    { new Guid("b0000000-0000-0000-0000-000000000129"), "page.home.directions.02.h3", "uk", "Консультації" },
                    { new Guid("b0000000-0000-0000-0000-000000000130"), "page.home.directions.02.text", "ru", "Индивидуальный разбор по энергетике, аюрведе и духовным практикам с личным куратором." },
                    { new Guid("b0000000-0000-0000-0000-000000000131"), "page.home.directions.02.text", "en", "Individual session on energetics, Ayurveda and spiritual practices with a personal mentor." },
                    { new Guid("b0000000-0000-0000-0000-000000000132"), "page.home.directions.02.text", "uk", "Індивідуальний розбір з енергетики, аюрведи та духовних практик з особистим куратором." },
                    { new Guid("b0000000-0000-0000-0000-000000000133"), "page.home.directions.02.link", "ru", "Записаться →" },
                    { new Guid("b0000000-0000-0000-0000-000000000134"), "page.home.directions.02.link", "en", "Book a session →" },
                    { new Guid("b0000000-0000-0000-0000-000000000135"), "page.home.directions.02.link", "uk", "Записатися →" },
                    { new Guid("b0000000-0000-0000-0000-000000000136"), "page.home.directions.03", "ru", "03" },
                    { new Guid("b0000000-0000-0000-0000-000000000137"), "page.home.directions.03", "en", "03" },
                    { new Guid("b0000000-0000-0000-0000-000000000138"), "page.home.directions.03", "uk", "03" },
                    { new Guid("b0000000-0000-0000-0000-000000000139"), "page.home.directions.03.h3", "ru", "Ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000140"), "page.home.directions.03.h3", "en", "Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000141"), "page.home.directions.03.h3", "uk", "Ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000142"), "page.home.directions.03.text", "ru", "Выездные программы в Черногории, Индии и других локациях. От 7 до 21 дня полного погружения." },
                    { new Guid("b0000000-0000-0000-0000-000000000143"), "page.home.directions.03.text", "en", "Immersive programmes in Montenegro, India and beyond. From 7 to 21 days of full immersion." },
                    { new Guid("b0000000-0000-0000-0000-000000000144"), "page.home.directions.03.text", "uk", "Виїзні програми в Чорногорії, Індії та інших локаціях. Від 7 до 21 дня повного занурення." },
                    { new Guid("b0000000-0000-0000-0000-000000000145"), "page.home.directions.03.link", "ru", "Все ретриты →" },
                    { new Guid("b0000000-0000-0000-0000-000000000146"), "page.home.directions.03.link", "en", "All retreats →" },
                    { new Guid("b0000000-0000-0000-0000-000000000147"), "page.home.directions.03.link", "uk", "Всі ретрити →" },
                    { new Guid("b0000000-0000-0000-0000-000000000148"), "page.home.quote.line1", "ru", "«Йога — это не то, что вы делаете на коврике." },
                    { new Guid("b0000000-0000-0000-0000-000000000149"), "page.home.quote.line1", "en", "«Yoga is not what you do on the mat." },
                    { new Guid("b0000000-0000-0000-0000-000000000150"), "page.home.quote.line1", "uk", "«Йога — це не те, що ви робите на килимку." },
                    { new Guid("b0000000-0000-0000-0000-000000000151"), "page.home.quote.line2", "ru", "Это то, кем вы становитесь — за его пределами.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000152"), "page.home.quote.line2", "en", "It is who you become — beyond it.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000153"), "page.home.quote.line2", "uk", "Це те, ким ви стаєте — за його межами.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000154"), "page.home.quote.by", "ru", "— Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000155"), "page.home.quote.by", "en", "— Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000156"), "page.home.quote.by", "uk", "— Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000157"), "page.home.formats.eyebrow1", "ru", "Формат I" },
                    { new Guid("b0000000-0000-0000-0000-000000000158"), "page.home.formats.eyebrow1", "en", "Format I" },
                    { new Guid("b0000000-0000-0000-0000-000000000159"), "page.home.formats.eyebrow1", "uk", "Формат I" },
                    { new Guid("b0000000-0000-0000-0000-000000000160"), "page.home.formats.h2.1", "ru", "Онлайн" },
                    { new Guid("b0000000-0000-0000-0000-000000000161"), "page.home.formats.h2.1", "en", "Online" },
                    { new Guid("b0000000-0000-0000-0000-000000000162"), "page.home.formats.h2.1", "uk", "Онлайн" },
                    { new Guid("b0000000-0000-0000-0000-000000000163"), "page.home.formats.text1", "ru", "Практикуйте из любой точки мира. Живые сессии, записи, индивидуальная обратная связь от куратора в вашем ритме." },
                    { new Guid("b0000000-0000-0000-0000-000000000164"), "page.home.formats.text1", "en", "Practice from anywhere in the world. Live sessions, recordings, personal feedback from your mentor at your own pace." },
                    { new Guid("b0000000-0000-0000-0000-000000000165"), "page.home.formats.text1", "uk", "Практикуйте з будь-якої точки світу. Живі сесії, записи, індивідуальний зворотній зв'язок від куратора у вашому ритмі." },
                    { new Guid("b0000000-0000-0000-0000-000000000166"), "page.home.formats.cta1", "ru", "Онлайн-курсы" },
                    { new Guid("b0000000-0000-0000-0000-000000000167"), "page.home.formats.cta1", "en", "Online courses" },
                    { new Guid("b0000000-0000-0000-0000-000000000168"), "page.home.formats.cta1", "uk", "Онлайн-курси" },
                    { new Guid("b0000000-0000-0000-0000-000000000169"), "page.home.formats.eyebrow2", "ru", "Формат II" },
                    { new Guid("b0000000-0000-0000-0000-000000000170"), "page.home.formats.eyebrow2", "en", "Format II" },
                    { new Guid("b0000000-0000-0000-0000-000000000171"), "page.home.formats.eyebrow2", "uk", "Формат II" },
                    { new Guid("b0000000-0000-0000-0000-000000000172"), "page.home.formats.h2.2", "ru", "Офлайн" },
                    { new Guid("b0000000-0000-0000-0000-000000000173"), "page.home.formats.h2.2", "en", "In-person" },
                    { new Guid("b0000000-0000-0000-0000-000000000174"), "page.home.formats.h2.2", "uk", "Офлайн" },
                    { new Guid("b0000000-0000-0000-0000-000000000175"), "page.home.formats.text2", "ru", "Живое присутствие и глубокое взаимодействие. Ретриты и интенсивы в сакральных местах силы." },
                    { new Guid("b0000000-0000-0000-0000-000000000176"), "page.home.formats.text2", "en", "Real presence and deep connection. Retreats and intensives in sacred places of power." },
                    { new Guid("b0000000-0000-0000-0000-000000000177"), "page.home.formats.text2", "uk", "Жива присутність і глибока взаємодія. Ретрити та інтенсиви в сакральних місцях сили." },
                    { new Guid("b0000000-0000-0000-0000-000000000178"), "page.home.formats.cta2", "ru", "Ретриты и выезды" },
                    { new Guid("b0000000-0000-0000-0000-000000000179"), "page.home.formats.cta2", "en", "Retreats & travel" },
                    { new Guid("b0000000-0000-0000-0000-000000000180"), "page.home.formats.cta2", "uk", "Ретрити і виїзди" },
                    { new Guid("b0000000-0000-0000-0000-000000000181"), "page.home.reviews.eyebrow", "ru", "Отзывы" },
                    { new Guid("b0000000-0000-0000-0000-000000000182"), "page.home.reviews.eyebrow", "en", "Reviews" },
                    { new Guid("b0000000-0000-0000-0000-000000000183"), "page.home.reviews.eyebrow", "uk", "Відгуки" },
                    { new Guid("b0000000-0000-0000-0000-000000000184"), "page.home.reviews.h2", "ru", "Говорят участники" },
                    { new Guid("b0000000-0000-0000-0000-000000000185"), "page.home.reviews.h2", "en", "What participants say" },
                    { new Guid("b0000000-0000-0000-0000-000000000186"), "page.home.reviews.h2", "uk", "Говорять учасники" },
                    { new Guid("b0000000-0000-0000-0000-000000000187"), "page.home.reviews.1.quote", "ru", "«После ретрита в Черногории я впервые за несколько лет почувствовала, что тело и голова — в одном месте. Это был настоящий перезапуск.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000188"), "page.home.reviews.1.quote", "en", "«After the Montenegro retreat I felt, for the first time in years, that my body and mind were in the same place. It was a true reset.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000189"), "page.home.reviews.1.quote", "uk", "«Після ретриту в Чорногорії я вперше за кілька років відчула, що тіло і голова — в одному місці. Це був справжній перезапуск.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000190"), "page.home.reviews.1.name", "ru", "Анна К." },
                    { new Guid("b0000000-0000-0000-0000-000000000191"), "page.home.reviews.1.name", "en", "Anna K." },
                    { new Guid("b0000000-0000-0000-0000-000000000192"), "page.home.reviews.1.name", "uk", "Анна К." },
                    { new Guid("b0000000-0000-0000-0000-000000000193"), "page.home.reviews.1.program", "ru", "Ретрит «Черногория, сентябрь»" },
                    { new Guid("b0000000-0000-0000-0000-000000000194"), "page.home.reviews.1.program", "en", "Retreat 'Montenegro, September'" },
                    { new Guid("b0000000-0000-0000-0000-000000000195"), "page.home.reviews.1.program", "uk", "Ретрит «Чорногорія, вересень»" },
                    { new Guid("b0000000-0000-0000-0000-000000000196"), "page.home.reviews.2.quote", "ru", "«Курс по пранаяме изменил моё отношение к дыханию и к жизни в целом. Простые техники, которые работают каждый день.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000197"), "page.home.reviews.2.quote", "en", "«The pranayama course changed my relationship with breathing — and with life itself. Simple techniques that work every single day.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000198"), "page.home.reviews.2.quote", "uk", "«Курс з пранаями змінив моє ставлення до дихання і до життя загалом. Прості техніки, які працюють щодня.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000199"), "page.home.reviews.2.name", "ru", "Михаил Р." },
                    { new Guid("b0000000-0000-0000-0000-000000000200"), "page.home.reviews.2.name", "en", "Mikhail R." },
                    { new Guid("b0000000-0000-0000-0000-000000000201"), "page.home.reviews.2.name", "uk", "Михайло Р." },
                    { new Guid("b0000000-0000-0000-0000-000000000202"), "page.home.reviews.2.program", "ru", "Курс «Пранаяма: базовый»" },
                    { new Guid("b0000000-0000-0000-0000-000000000203"), "page.home.reviews.2.program", "en", "Course 'Pranayama: Foundations'" },
                    { new Guid("b0000000-0000-0000-0000-000000000204"), "page.home.reviews.2.program", "uk", "Курс «Пранаяма: базовий»" },
                    { new Guid("b0000000-0000-0000-0000-000000000205"), "page.home.reviews.3.quote", "ru", "«Индивидуальная консультация по аюрведе дала мне план на год вперёд — питание, режим, практики. Всё чётко и без лишней эзотерики.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000206"), "page.home.reviews.3.quote", "en", "«The Ayurveda consultation gave me a year-long plan — nutrition, daily routine, practices. Clear and without unnecessary mysticism.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000207"), "page.home.reviews.3.quote", "uk", "«Індивідуальна консультація з аюрведи дала мені план на рік вперед — харчування, режим, практики. Все чітко і без зайвої езотерики.»" },
                    { new Guid("b0000000-0000-0000-0000-000000000208"), "page.home.reviews.3.name", "ru", "Светлана В." },
                    { new Guid("b0000000-0000-0000-0000-000000000209"), "page.home.reviews.3.name", "en", "Svetlana V." },
                    { new Guid("b0000000-0000-0000-0000-000000000210"), "page.home.reviews.3.name", "uk", "Світлана В." },
                    { new Guid("b0000000-0000-0000-0000-000000000211"), "page.home.reviews.3.program", "ru", "Консультация «Аюрведа»" },
                    { new Guid("b0000000-0000-0000-0000-000000000212"), "page.home.reviews.3.program", "en", "Consultation 'Ayurveda'" },
                    { new Guid("b0000000-0000-0000-0000-000000000213"), "page.home.reviews.3.program", "uk", "Консультація «Аюрведа»" },
                    { new Guid("b0000000-0000-0000-0000-000000000214"), "page.home.blog.eyebrow", "ru", "Из блога" },
                    { new Guid("b0000000-0000-0000-0000-000000000215"), "page.home.blog.eyebrow", "en", "From the blog" },
                    { new Guid("b0000000-0000-0000-0000-000000000216"), "page.home.blog.eyebrow", "uk", "З блогу" },
                    { new Guid("b0000000-0000-0000-0000-000000000217"), "page.home.blog.h2", "ru", "Статьи и размышления" },
                    { new Guid("b0000000-0000-0000-0000-000000000218"), "page.home.blog.h2", "en", "Articles & reflections" },
                    { new Guid("b0000000-0000-0000-0000-000000000219"), "page.home.blog.h2", "uk", "Статті та роздуми" },
                    { new Guid("b0000000-0000-0000-0000-000000000220"), "page.home.blog.1.tag", "ru", "Практика" },
                    { new Guid("b0000000-0000-0000-0000-000000000221"), "page.home.blog.1.tag", "en", "Practice" },
                    { new Guid("b0000000-0000-0000-0000-000000000222"), "page.home.blog.1.tag", "uk", "Практика" },
                    { new Guid("b0000000-0000-0000-0000-000000000223"), "page.home.blog.1.h3", "ru", "Пранаяма для начинающих: 5 техник, которые изменят качество сна" },
                    { new Guid("b0000000-0000-0000-0000-000000000224"), "page.home.blog.1.h3", "en", "Pranayama for beginners: 5 techniques that will transform your sleep" },
                    { new Guid("b0000000-0000-0000-0000-000000000225"), "page.home.blog.1.h3", "uk", "Пранаяма для початківців: 5 технік, які змінять якість сну" },
                    { new Guid("b0000000-0000-0000-0000-000000000226"), "page.home.blog.1.text", "ru", "Простые дыхательные упражнения, которые можно выполнять лёжа в постели — без коврика и специального оборудования." },
                    { new Guid("b0000000-0000-0000-0000-000000000227"), "page.home.blog.1.text", "en", "Simple breathing exercises you can do lying in bed — no mat or special equipment required." },
                    { new Guid("b0000000-0000-0000-0000-000000000228"), "page.home.blog.1.text", "uk", "Прості дихальні вправи, які можна виконувати лежачи в ліжку — без килимка і спеціального обладнання." },
                    { new Guid("b0000000-0000-0000-0000-000000000229"), "page.home.blog.2.tag", "ru", "Философия" },
                    { new Guid("b0000000-0000-0000-0000-000000000230"), "page.home.blog.2.tag", "en", "Philosophy" },
                    { new Guid("b0000000-0000-0000-0000-000000000231"), "page.home.blog.2.tag", "uk", "Філософія" },
                    { new Guid("b0000000-0000-0000-0000-000000000232"), "page.home.blog.2.h3", "ru", "Ахимса в повседневности: как принцип ненасилия работает вне коврика" },
                    { new Guid("b0000000-0000-0000-0000-000000000233"), "page.home.blog.2.h3", "en", "Ahimsa in daily life: how the non-violence principle works off the mat" },
                    { new Guid("b0000000-0000-0000-0000-000000000234"), "page.home.blog.2.h3", "uk", "Ахімса у повсякденності: як принцип ненасилля працює поза килимком" },
                    { new Guid("b0000000-0000-0000-0000-000000000235"), "page.home.blog.2.text", "ru", "О том, как одно из базовых правил йоги можно применять в разговорах, питании и отношении к себе." },
                    { new Guid("b0000000-0000-0000-0000-000000000236"), "page.home.blog.2.text", "en", "How one of yoga's foundational rules can be applied in conversations, diet and your relationship with yourself." },
                    { new Guid("b0000000-0000-0000-0000-000000000237"), "page.home.blog.2.text", "uk", "Про те, як одне з базових правил йоги можна застосовувати в розмовах, харчуванні та ставленні до себе." },
                    { new Guid("b0000000-0000-0000-0000-000000000238"), "page.home.blog.3.tag", "ru", "Ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000239"), "page.home.blog.3.tag", "en", "Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000240"), "page.home.blog.3.tag", "uk", "Ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000241"), "page.home.blog.3.h3", "ru", "Почему 7 дней тишины меняют больше, чем год терапии" },
                    { new Guid("b0000000-0000-0000-0000-000000000242"), "page.home.blog.3.h3", "en", "Why 7 days of silence changes more than a year of therapy" },
                    { new Guid("b0000000-0000-0000-0000-000000000243"), "page.home.blog.3.h3", "uk", "Чому 7 днів тиші змінюють більше, ніж рік терапії" },
                    { new Guid("b0000000-0000-0000-0000-000000000244"), "page.home.blog.3.text", "ru", "Личный опыт и разбор механизмов: что происходит с нервной системой в условиях глубокой тишины и отрыва от привычной среды." },
                    { new Guid("b0000000-0000-0000-0000-000000000245"), "page.home.blog.3.text", "en", "Personal experience and analysis: what happens to the nervous system in conditions of deep silence and disconnection from everyday life." },
                    { new Guid("b0000000-0000-0000-0000-000000000246"), "page.home.blog.3.text", "uk", "Особистий досвід і розбір механізмів: що відбувається з нервовою системою в умовах глибокої тиші та відриву від звичного середовища." },
                    { new Guid("b0000000-0000-0000-0000-000000000247"), "page.home.blog.readmore", "ru", "Читать →" },
                    { new Guid("b0000000-0000-0000-0000-000000000248"), "page.home.blog.readmore", "en", "Read →" },
                    { new Guid("b0000000-0000-0000-0000-000000000249"), "page.home.blog.readmore", "uk", "Читати →" },
                    { new Guid("b0000000-0000-0000-0000-000000000250"), "page.home.blog.all", "ru", "Все статьи" },
                    { new Guid("b0000000-0000-0000-0000-000000000251"), "page.home.blog.all", "en", "All articles" },
                    { new Guid("b0000000-0000-0000-0000-000000000252"), "page.home.blog.all", "uk", "Всі статті" },
                    { new Guid("b0000000-0000-0000-0000-000000000253"), "page.home.cta.eyebrow", "ru", "Следующий шаг" },
                    { new Guid("b0000000-0000-0000-0000-000000000254"), "page.home.cta.eyebrow", "en", "Next step" },
                    { new Guid("b0000000-0000-0000-0000-000000000255"), "page.home.cta.eyebrow", "uk", "Наступний крок" },
                    { new Guid("b0000000-0000-0000-0000-000000000256"), "page.home.cta.h2", "ru", "Готовы к изменениям?" },
                    { new Guid("b0000000-0000-0000-0000-000000000257"), "page.home.cta.h2", "en", "Ready for change?" },
                    { new Guid("b0000000-0000-0000-0000-000000000258"), "page.home.cta.h2", "uk", "Готові до змін?" },
                    { new Guid("b0000000-0000-0000-0000-000000000259"), "page.home.cta.text", "ru", "Оставьте заявку — мы подберём программу, которая подойдёт именно вам." },
                    { new Guid("b0000000-0000-0000-0000-000000000260"), "page.home.cta.text", "en", "Leave a request — we'll find the programme that's right for you." },
                    { new Guid("b0000000-0000-0000-0000-000000000261"), "page.home.cta.text", "uk", "Залиште заявку — ми підберемо програму, яка підійде саме вам." },
                    { new Guid("b0000000-0000-0000-0000-000000000262"), "page.home.cta.btn", "ru", "Хочу попасть на программу" },
                    { new Guid("b0000000-0000-0000-0000-000000000263"), "page.home.cta.btn", "en", "I want to join a programme" },
                    { new Guid("b0000000-0000-0000-0000-000000000264"), "page.home.cta.btn", "uk", "Хочу потрапити на програму" },
                    { new Guid("b0000000-0000-0000-0000-000000000265"), "page.courses.title", "ru", "Курсы | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000266"), "page.courses.title", "en", "Courses | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000267"), "page.courses.title", "uk", "Курси | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000268"), "page.courses.h1", "ru", "Курсы" },
                    { new Guid("b0000000-0000-0000-0000-000000000269"), "page.courses.h1", "en", "Courses" },
                    { new Guid("b0000000-0000-0000-0000-000000000270"), "page.courses.h1", "uk", "Курси" },
                    { new Guid("b0000000-0000-0000-0000-000000000271"), "page.courses.sub", "ru", "Выберите направление." },
                    { new Guid("b0000000-0000-0000-0000-000000000272"), "page.courses.sub", "en", "Choose a direction." },
                    { new Guid("b0000000-0000-0000-0000-000000000273"), "page.courses.sub", "uk", "Оберіть напрямок." },
                    { new Guid("b0000000-0000-0000-0000-000000000274"), "page.courses.pranayama.title", "ru", "Пранаяма | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000275"), "page.courses.pranayama.title", "en", "Pranayama | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000276"), "page.courses.pranayama.title", "uk", "Пранаяма | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000277"), "page.courses.pranayama.h1", "ru", "Пранаяма" },
                    { new Guid("b0000000-0000-0000-0000-000000000278"), "page.courses.pranayama.h1", "en", "Pranayama" },
                    { new Guid("b0000000-0000-0000-0000-000000000279"), "page.courses.pranayama.h1", "uk", "Пранаяма" },
                    { new Guid("b0000000-0000-0000-0000-000000000280"), "page.courses.meditation.title", "ru", "Медитация | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000281"), "page.courses.meditation.title", "en", "Meditation | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000282"), "page.courses.meditation.title", "uk", "Медитація | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000283"), "page.courses.meditation.h1", "ru", "Медитация" },
                    { new Guid("b0000000-0000-0000-0000-000000000284"), "page.courses.meditation.h1", "en", "Meditation" },
                    { new Guid("b0000000-0000-0000-0000-000000000285"), "page.courses.meditation.h1", "uk", "Медитація" },
                    { new Guid("b0000000-0000-0000-0000-000000000286"), "page.courses.yoga.title", "ru", "Йога | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000287"), "page.courses.yoga.title", "en", "Yoga | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000288"), "page.courses.yoga.title", "uk", "Йога | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000289"), "page.courses.yoga.h1", "ru", "Йога" },
                    { new Guid("b0000000-0000-0000-0000-000000000290"), "page.courses.yoga.h1", "en", "Yoga" },
                    { new Guid("b0000000-0000-0000-0000-000000000291"), "page.courses.yoga.h1", "uk", "Йога" },
                    { new Guid("b0000000-0000-0000-0000-000000000292"), "page.consultations.title", "ru", "Консультации | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000293"), "page.consultations.title", "en", "Consultations | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000294"), "page.consultations.title", "uk", "Консультації | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000295"), "page.consultations.h1", "ru", "Консультации" },
                    { new Guid("b0000000-0000-0000-0000-000000000296"), "page.consultations.h1", "en", "Consultations" },
                    { new Guid("b0000000-0000-0000-0000-000000000297"), "page.consultations.h1", "uk", "Консультації" },
                    { new Guid("b0000000-0000-0000-0000-000000000298"), "page.consultations.energy.title", "ru", "Энергетика | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000299"), "page.consultations.energy.title", "en", "Energetics | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000300"), "page.consultations.energy.title", "uk", "Енергетика | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000301"), "page.consultations.energy.h1", "ru", "Энергетика" },
                    { new Guid("b0000000-0000-0000-0000-000000000302"), "page.consultations.energy.h1", "en", "Energetics" },
                    { new Guid("b0000000-0000-0000-0000-000000000303"), "page.consultations.energy.h1", "uk", "Енергетика" },
                    { new Guid("b0000000-0000-0000-0000-000000000304"), "page.consultations.ayurveda.title", "ru", "Аюрведа | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000305"), "page.consultations.ayurveda.title", "en", "Ayurveda | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000306"), "page.consultations.ayurveda.title", "uk", "Аюрведа | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000307"), "page.consultations.ayurveda.h1", "ru", "Аюрведа" },
                    { new Guid("b0000000-0000-0000-0000-000000000308"), "page.consultations.ayurveda.h1", "en", "Ayurveda" },
                    { new Guid("b0000000-0000-0000-0000-000000000309"), "page.consultations.ayurveda.h1", "uk", "Аюрведа" },
                    { new Guid("b0000000-0000-0000-0000-000000000310"), "page.consultations.spirituality.title", "ru", "Духовность | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000311"), "page.consultations.spirituality.title", "en", "Spirituality | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000312"), "page.consultations.spirituality.title", "uk", "Духовність | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000313"), "page.consultations.spirituality.h1", "ru", "Духовность" },
                    { new Guid("b0000000-0000-0000-0000-000000000314"), "page.consultations.spirituality.h1", "en", "Spirituality" },
                    { new Guid("b0000000-0000-0000-0000-000000000315"), "page.consultations.spirituality.h1", "uk", "Духовність" },
                    { new Guid("b0000000-0000-0000-0000-000000000316"), "page.retreats.actual.title", "ru", "Актуальные ретриты | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000317"), "page.retreats.actual.title", "en", "Current Retreats | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000318"), "page.retreats.actual.title", "uk", "Актуальні ретрити | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000319"), "page.retreats.actual.h1", "ru", "Актуальные ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000320"), "page.retreats.actual.h1", "en", "Current Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000321"), "page.retreats.actual.h1", "uk", "Актуальні ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000322"), "page.retreats.upcoming.title", "ru", "Предстоящие ретриты | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000323"), "page.retreats.upcoming.title", "en", "Upcoming Retreats | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000324"), "page.retreats.upcoming.title", "uk", "Майбутні ретрити | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000325"), "page.retreats.upcoming.h1", "ru", "Предстоящие ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000326"), "page.retreats.upcoming.h1", "en", "Upcoming Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000327"), "page.retreats.upcoming.h1", "uk", "Майбутні ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000328"), "page.retreats.past.title", "ru", "Прошедшие ретриты | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000329"), "page.retreats.past.title", "en", "Past Retreats | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000330"), "page.retreats.past.title", "uk", "Минулі ретрити | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000331"), "page.retreats.past.h1", "ru", "Прошедшие ретриты" },
                    { new Guid("b0000000-0000-0000-0000-000000000332"), "page.retreats.past.h1", "en", "Past Retreats" },
                    { new Guid("b0000000-0000-0000-0000-000000000333"), "page.retreats.past.h1", "uk", "Минулі ретрити" },
                    { new Guid("b0000000-0000-0000-0000-000000000334"), "page.blog.title", "ru", "Блог | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000335"), "page.blog.title", "en", "Blog | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000336"), "page.blog.title", "uk", "Блог | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000337"), "page.blog.h1", "ru", "Блог" },
                    { new Guid("b0000000-0000-0000-0000-000000000338"), "page.blog.h1", "en", "Blog" },
                    { new Guid("b0000000-0000-0000-0000-000000000339"), "page.blog.h1", "uk", "Блог" },
                    { new Guid("b0000000-0000-0000-0000-000000000340"), "page.blog.articles.title", "ru", "Статьи | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000341"), "page.blog.articles.title", "en", "Articles | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000342"), "page.blog.articles.title", "uk", "Статті | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000343"), "page.blog.articles.h1", "ru", "Статьи" },
                    { new Guid("b0000000-0000-0000-0000-000000000344"), "page.blog.articles.h1", "en", "Articles" },
                    { new Guid("b0000000-0000-0000-0000-000000000345"), "page.blog.articles.h1", "uk", "Статті" },
                    { new Guid("b0000000-0000-0000-0000-000000000346"), "page.blog.videos.title", "ru", "Видео | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000347"), "page.blog.videos.title", "en", "Videos | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000348"), "page.blog.videos.title", "uk", "Відео | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000349"), "page.blog.videos.h1", "ru", "Видео" },
                    { new Guid("b0000000-0000-0000-0000-000000000350"), "page.blog.videos.h1", "en", "Videos" },
                    { new Guid("b0000000-0000-0000-0000-000000000351"), "page.blog.videos.h1", "uk", "Відео" },
                    { new Guid("b0000000-0000-0000-0000-000000000352"), "page.blog.photos.title", "ru", "Фото | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000353"), "page.blog.photos.title", "en", "Photos | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000354"), "page.blog.photos.title", "uk", "Фото | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000355"), "page.blog.photos.h1", "ru", "Фото" },
                    { new Guid("b0000000-0000-0000-0000-000000000356"), "page.blog.photos.h1", "en", "Photos" },
                    { new Guid("b0000000-0000-0000-0000-000000000357"), "page.blog.photos.h1", "uk", "Фото" },
                    { new Guid("b0000000-0000-0000-0000-000000000358"), "page.about.title", "ru", "О нас | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000359"), "page.about.title", "en", "About | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000360"), "page.about.title", "uk", "Про нас | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000361"), "page.about.h1", "ru", "О нас" },
                    { new Guid("b0000000-0000-0000-0000-000000000362"), "page.about.h1", "en", "About Us" },
                    { new Guid("b0000000-0000-0000-0000-000000000363"), "page.about.h1", "uk", "Про нас" },
                    { new Guid("b0000000-0000-0000-0000-000000000364"), "page.contacts.title", "ru", "Контакты | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000365"), "page.contacts.title", "en", "Contact | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000366"), "page.contacts.title", "uk", "Контакти | Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000367"), "page.contacts.h1", "ru", "Контакты" },
                    { new Guid("b0000000-0000-0000-0000-000000000368"), "page.contacts.h1", "en", "Contact" },
                    { new Guid("b0000000-0000-0000-0000-000000000369"), "page.contacts.h1", "uk", "Контакти" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_CourseId",
                table: "CourseModules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_EntityType_EntityId_SortOrder",
                table: "MediaFiles",
                columns: new[] { "EntityType", "EntityId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Translations_EntityType_EntityId_Field_Language",
                table: "Translations",
                columns: new[] { "EntityType", "EntityId", "Field", "Language" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UiTranslations_Key_Language",
                table: "UiTranslations",
                columns: new[] { "Key", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "CourseModules");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "SitePages");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "UiTranslations");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Retreats");

            migrationBuilder.DropColumn(
                name: "PriceLabel",
                table: "Retreats");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$fUcO6uH0vWdcWDHlIWcbNefVk.AgrmB3xDWs6EjPZM1ZFVnNYSppy");
        }
    }
}
