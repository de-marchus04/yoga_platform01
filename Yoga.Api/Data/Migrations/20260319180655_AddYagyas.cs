using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddYagyas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yagyas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    PriceLabel = table.Column<string>(type: "text", nullable: true),
                    Program = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yagyas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SitePages",
                columns: new[] { "Id", "Slug" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444408"), "yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                column: "Value",
                value: "Пранавидья");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                column: "Value",
                value: "Pranavidya");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                column: "Value",
                value: "Пранавід'я");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                column: "Value",
                value: "Для подростков");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                column: "Value",
                value: "For Teenagers");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                column: "Value",
                value: "Для підлітків");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000040"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas", "Ягьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000041"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas", "Yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000042"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas", "Яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000043"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas.upcoming", "Предстоящие" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000044"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas.upcoming", "Upcoming" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000045"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas.upcoming", "Майбутні" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000046"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas.past", "Прошедшие" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000047"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas.past", "Past" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000048"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.yagyas.past", "Минулі" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000049"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000050"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000051"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000052"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.articles", "Статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000053"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.articles", "Articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000054"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.articles", "Статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000055"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.videos", "Видео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000056"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.videos", "Videos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000057"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.videos", "Відео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000058"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.photos", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000059"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.photos", "Photos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000060"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.photos", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000061"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.about", "О нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000062"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.about", "About" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000063"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.about", "Про нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000064"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.contacts", "Контакты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000065"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.contacts", "Contact" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000066"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.contacts", "Контакти" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000067"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "footer.copy", "© 2026 Yoga.Life Enterprise. Возврат к истокам." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000068"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "footer.copy", "© 2026 Yoga.Life Enterprise. A return to origins." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000069"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "footer.copy", "© 2026 Yoga.Life Enterprise. Повернення до витоків." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000070"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.title", "Yoga.Life | Авторские Ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000071"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.title", "Yoga.Life | Author-Led Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000072"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.title", "Yoga.Life | Авторські Ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000073"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.eyebrow", "Yoga · Life · Enterprise" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000074"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.eyebrow", "Yoga · Life · Enterprise" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000075"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.eyebrow", "Yoga · Life · Enterprise" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000076"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.line1", "Возврат" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000077"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.line1", "Return" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000078"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.line1", "Повернення" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000079"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.em", "к себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000080"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.em", "to yourself" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000081"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.em", "до себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000082"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.text", "Авторские ретриты и программы обучения. Погружение в тишину, практики осознанности и полное обновление." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000083"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.text", "Author-led retreats and training programmes. A plunge into stillness, mindfulness practices and complete renewal." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000084"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.text", "Авторські ретрити та навчальні програми. Занурення в тишу, практики усвідомленості та повне оновлення." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000085"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.cta", "Записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000086"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.cta", "Sign up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000087"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.cta", "Записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000088"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.retreats", "Ретритов" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000089"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.retreats", "Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000090"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.retreats", "Ретритів" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000091"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.members", "Участников" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000092"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.members", "Participants" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000093"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.members", "Учасників" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000094"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.countries", "Стран" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000095"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.countries", "Countries" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000096"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.countries", "Країн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000097"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.years", "Лет практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000098"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.years", "Years of practice" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000099"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.years", "Років практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000100"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.eyebrow", "Программы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000101"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.eyebrow", "Programmes" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000102"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.eyebrow", "Програми" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000103"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.h2", "Ближайшие ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000104"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.h2", "Upcoming Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000105"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.h2", "Найближчі ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000106"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.loading", "Загрузка расписания..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000107"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.loading", "Loading schedule..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000108"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.loading", "Завантаження розкладу..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000109"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.empty", "Нет доступных ретритов в данный момент." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000110"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.empty", "No retreats currently available." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000111"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.empty", "Немає доступних ретритів на даний момент." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000112"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.cta", "Хочу сюда" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000113"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.cta", "I want to go" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000114"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.cta", "Хочу сюди" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000115"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.eyebrow", "Что мы предлагаем" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000116"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.eyebrow", "What we offer" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000117"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.eyebrow", "Що ми пропонуємо" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000118"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.h2", "Направления" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000119"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.h2", "Directions" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000120"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.h2", "Напрямки" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000121"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01", "01" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000122"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01", "01" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000123"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01", "01" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000124"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.h3", "Курсы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000125"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.h3", "Courses" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000126"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.h3", "Курси" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000127"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.text", "Пранаяма, медитация, йога — системные программы для углублённой практики в любом темпе." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000128"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.text", "Pranayama, meditation, yoga — structured programmes for deepening your practice at your own pace." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000129"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.text", "Пранаяма, медитація, йога — системні програми для поглибленої практики в будь-якому темпі." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000130"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.link", "Смотреть курсы →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000131"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.link", "View courses →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000132"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.link", "Дивитися курси →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000133"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02", "02" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000134"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02", "02" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000135"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02", "02" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000136"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.h3", "Консультации" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000137"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.h3", "Consultations" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000138"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.h3", "Консультації" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000139"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.text", "Индивидуальный разбор по энергетике, аюрведе и духовным практикам с личным куратором." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000140"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.text", "Individual session on energetics, Ayurveda and spiritual practices with a personal mentor." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000141"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.text", "Індивідуальний розбір з енергетики, аюрведи та духовних практик з особистим куратором." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000142"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.link", "Записаться →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000143"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.link", "Book a session →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000144"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.link", "Записатися →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000145"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03", "03" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000146"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03", "03" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000147"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03", "03" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000148"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.h3", "Ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000149"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.h3", "Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000150"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.h3", "Ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000151"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.text", "Выездные программы в Черногории, Индии и других локациях. От 7 до 21 дня полного погружения." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000152"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.text", "Immersive programmes in Montenegro, India and beyond. From 7 to 21 days of full immersion." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000153"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.text", "Виїзні програми в Чорногорії, Індії та інших локаціях. Від 7 до 21 дня повного занурення." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000154"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.link", "Все ретриты →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000155"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.link", "All retreats →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000156"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.link", "Всі ретрити →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000157"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line1", "«Йога — это не то, что вы делаете на коврике." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000158"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line1", "«Yoga is not what you do on the mat." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000159"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line1", "«Йога — це не те, що ви робите на килимку." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000160"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line2", "Это то, кем вы становитесь — за его пределами.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000161"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line2", "It is who you become — beyond it.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000162"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line2", "Це те, ким ви стаєте — за його межами.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000163"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.by", "— Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000164"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.by", "— Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000165"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.by", "— Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000166"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow1", "Формат I" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000167"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow1", "Format I" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000168"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow1", "Формат I" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000169"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.1", "Онлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000170"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.1", "Online" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000171"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.1", "Онлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000172"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text1", "Практикуйте из любой точки мира. Живые сессии, записи, индивидуальная обратная связь от куратора в вашем ритме." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000173"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text1", "Practice from anywhere in the world. Live sessions, recordings, personal feedback from your mentor at your own pace." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000174"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text1", "Практикуйте з будь-якої точки світу. Живі сесії, записи, індивідуальний зворотній зв'язок від куратора у вашому ритмі." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000175"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta1", "Онлайн-курсы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000176"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta1", "Online courses" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000177"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta1", "Онлайн-курси" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000178"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow2", "Формат II" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000179"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow2", "Format II" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000180"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow2", "Формат II" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000181"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.2", "Офлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000182"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.2", "In-person" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000183"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.2", "Офлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000184"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text2", "Живое присутствие и глубокое взаимодействие. Ретриты и интенсивы в сакральных местах силы." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000185"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text2", "Real presence and deep connection. Retreats and intensives in sacred places of power." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000186"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text2", "Жива присутність і глибока взаємодія. Ретрити та інтенсиви в сакральних місцях сили." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000187"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta2", "Ретриты и выезды" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000188"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta2", "Retreats & travel" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000189"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta2", "Ретрити і виїзди" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000190"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.eyebrow", "Отзывы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000191"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.eyebrow", "Reviews" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000192"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.eyebrow", "Відгуки" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000193"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.h2", "Говорят участники" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000194"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.h2", "What participants say" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000195"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.h2", "Говорять учасники" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000196"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.quote", "«После ретрита в Черногории я впервые за несколько лет почувствовала, что тело и голова — в одном месте. Это был настоящий перезапуск.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000197"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.quote", "«After the Montenegro retreat I felt, for the first time in years, that my body and mind were in the same place. It was a true reset.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000198"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.quote", "«Після ретриту в Чорногорії я вперше за кілька років відчула, що тіло і голова — в одному місці. Це був справжній перезапуск.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000199"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.name", "Анна К." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000200"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.name", "Anna K." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000201"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.name", "Анна К." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000202"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.program", "Ретрит «Черногория, сентябрь»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000203"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.program", "Retreat 'Montenegro, September'" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000204"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.program", "Ретрит «Чорногорія, вересень»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000205"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.quote", "«Курс по пранаяме изменил моё отношение к дыханию и к жизни в целом. Простые техники, которые работают каждый день.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000206"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.quote", "«The pranayama course changed my relationship with breathing — and with life itself. Simple techniques that work every single day.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000207"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.quote", "«Курс з пранаями змінив моє ставлення до дихання і до життя загалом. Прості техніки, які працюють щодня.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000208"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.name", "Михаил Р." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000209"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.name", "Mikhail R." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000210"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.name", "Михайло Р." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000211"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.program", "Курс «Пранаяма: базовый»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000212"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.program", "Course 'Pranayama: Foundations'" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000213"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.program", "Курс «Пранаяма: базовий»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000214"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.quote", "«Индивидуальная консультация по аюрведе дала мне план на год вперёд — питание, режим, практики. Всё чётко и без лишней эзотерики.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000215"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.quote", "«The Ayurveda consultation gave me a year-long plan — nutrition, daily routine, practices. Clear and without unnecessary mysticism.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000216"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.quote", "«Індивідуальна консультація з аюрведи дала мені план на рік вперед — харчування, режим, практики. Все чітко і без зайвої езотерики.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000217"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.name", "Светлана В." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000218"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.name", "Svetlana V." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000219"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.name", "Світлана В." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000220"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.program", "Консультация «Аюрведа»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000221"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.program", "Consultation 'Ayurveda'" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000222"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.program", "Консультація «Аюрведа»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000223"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.eyebrow", "Из блога" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000224"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.eyebrow", "From the blog" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000225"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.eyebrow", "З блогу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000226"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.h2", "Статьи и размышления" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000227"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.h2", "Articles & reflections" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000228"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.h2", "Статті та роздуми" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000229"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.tag", "Практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000230"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.tag", "Practice" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000231"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.tag", "Практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000232"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.h3", "Пранаяма для начинающих: 5 техник, которые изменят качество сна" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000233"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.h3", "Pranayama for beginners: 5 techniques that will transform your sleep" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000234"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.h3", "Пранаяма для початківців: 5 технік, які змінять якість сну" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000235"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.text", "Простые дыхательные упражнения, которые можно выполнять лёжа в постели — без коврика и специального оборудования." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000236"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.text", "Simple breathing exercises you can do lying in bed — no mat or special equipment required." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000237"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.text", "Прості дихальні вправи, які можна виконувати лежачи в ліжку — без килимка і спеціального обладнання." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000238"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.tag", "Философия" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000239"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.tag", "Philosophy" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000240"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.tag", "Філософія" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000241"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.h3", "Ахимса в повседневности: как принцип ненасилия работает вне коврика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000242"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.h3", "Ahimsa in daily life: how the non-violence principle works off the mat" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000243"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.h3", "Ахімса у повсякденності: як принцип ненасилля працює поза килимком" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000244"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.text", "О том, как одно из базовых правил йоги можно применять в разговорах, питании и отношении к себе." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000245"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.text", "How one of yoga's foundational rules can be applied in conversations, diet and your relationship with yourself." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000246"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.text", "Про те, як одне з базових правил йоги можна застосовувати в розмовах, харчуванні та ставленні до себе." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000247"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.tag", "Ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000248"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.tag", "Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000249"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.tag", "Ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000250"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.h3", "Почему 7 дней тишины меняют больше, чем год терапии" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000251"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.h3", "Why 7 days of silence changes more than a year of therapy" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000252"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.h3", "Чому 7 днів тиші змінюють більше, ніж рік терапії" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000253"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.text", "Личный опыт и разбор механизмов: что происходит с нервной системой в условиях глубокой тишины и отрыва от привычной среды." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000254"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.text", "Personal experience and analysis: what happens to the nervous system in conditions of deep silence and disconnection from everyday life." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000255"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.text", "Особистий досвід і розбір механізмів: що відбувається з нервовою системою в умовах глибокої тиші та відриву від звичного середовища." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000256"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.readmore", "Читать →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000257"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.readmore", "Read →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000258"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.readmore", "Читати →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000259"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.all", "Все статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000260"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.all", "All articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000261"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.all", "Всі статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000262"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.eyebrow", "Следующий шаг" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000263"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.eyebrow", "Next step" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000264"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.eyebrow", "Наступний крок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000265"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.h2", "Готовы к изменениям?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000266"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.h2", "Ready for change?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000267"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.h2", "Готові до змін?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000268"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.text", "Оставьте заявку — мы подберём программу, которая подойдёт именно вам." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000269"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.text", "Leave a request — we'll find the programme that's right for you." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000270"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.text", "Залиште заявку — ми підберемо програму, яка підійде саме вам." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000271"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.btn", "Хочу попасть на программу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000272"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.btn", "I want to join a programme" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000273"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.btn", "Хочу потрапити на програму" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000274"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.title", "Курсы | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000275"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.title", "Courses | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000276"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.title", "Курси | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000277"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h1", "Курсы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000278"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h1", "Courses" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000279"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h1", "Курси" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000280"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.sub", "Выберите направление." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000281"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.sub", "Choose a direction." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000282"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.sub", "Оберіть напрямок." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000283"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.title", "Пранавидья | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000284"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.title", "Pranavidya | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000285"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.title", "Пранавід'я | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000286"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.h1", "Пранавидья" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000287"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.h1", "Pranavidya" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000288"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.h1", "Пранавід'я" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000289"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.title", "Медитация | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000290"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.title", "Meditation | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000291"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.title", "Медитація | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000292"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.h1", "Медитация" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000293"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.h1", "Meditation" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000294"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.h1", "Медитація" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000295"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.title", "Йога | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000296"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.title", "Yoga | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000297"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.title", "Йога | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000298"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.h1", "Йога" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000299"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.h1", "Yoga" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000300"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.h1", "Йога" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000301"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.title", "Консультации | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000302"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.title", "Consultations | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000303"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.title", "Консультації | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000304"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h1", "Консультации" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000305"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h1", "Consultations" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000306"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h1", "Консультації" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000307"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.title", "Энергетика | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000308"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.title", "Energetics | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000309"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.title", "Енергетика | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000310"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.h1", "Энергетика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000311"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.h1", "Energetics" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000312"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.h1", "Енергетика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000313"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.title", "Для подростков | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000314"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.title", "For Teenagers | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000315"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.title", "Для підлітків | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000316"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.h1", "Для подростков" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000317"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.h1", "For Teenagers" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000318"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.h1", "Для підлітків" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000319"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.title", "Духовность | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000320"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.title", "Spirituality | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000321"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.title", "Духовність | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000322"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.h1", "Духовность" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000323"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.h1", "Spirituality" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000324"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.h1", "Духовність" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000325"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.title", "Актуальные ретриты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000326"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.title", "Current Retreats | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000327"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.title", "Актуальні ретрити | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000328"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.h1", "Актуальные ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000329"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.h1", "Current Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000330"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.h1", "Актуальні ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000331"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.title", "Предстоящие ретриты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000332"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.title", "Upcoming Retreats | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000333"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.title", "Майбутні ретрити | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000334"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.h1", "Предстоящие ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000335"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.h1", "Upcoming Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000336"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.h1", "Майбутні ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000337"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.title", "Прошедшие ретриты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000338"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.title", "Past Retreats | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000339"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.title", "Минулі ретрити | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000340"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.h1", "Прошедшие ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000341"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.h1", "Past Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000342"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.h1", "Минулі ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000343"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.title", "Ягьи | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000344"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.title", "Yagyas | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000345"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.title", "Яг'ї | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000346"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.h1", "Ягьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000347"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.h1", "Yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000348"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.h1", "Яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000349"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.eyebrow", "Огненные практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000350"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.eyebrow", "Fire ceremonies" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000351"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.eyebrow", "Вогняні практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000352"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.intro", "Предстоящие и прошедшие ягьи с описанием намерения, формата участия и ключевых дат." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000353"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.intro", "Upcoming and past yagyas with the intention, format and key dates." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000354"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.intro", "Майбутні та минулі яг'ї з описом наміру, формату участі та ключових дат." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000355"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.title", "Предстоящие ягьи | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000356"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.title", "Upcoming Yagyas | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000357"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.title", "Майбутні яг'ї | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000358"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.h1", "Предстоящие ягьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000359"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.h1", "Upcoming Yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000360"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.h1", "Майбутні яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000361"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.intro", "Ближайшие церемонии, к которым можно присоединиться сейчас." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000362"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.intro", "The next ceremonies you can join now." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000363"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.upcoming.intro", "Найближчі церемонії, до яких можна долучитися зараз." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000364"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.title", "Прошедшие ягьи | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000365"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.title", "Past Yagyas | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000366"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.title", "Минулі яг'ї | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000367"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.h1", "Прошедшие ягьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000368"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.h1", "Past Yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000369"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.h1", "Минулі яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000370"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.intro", "Архив проведённых ягий с программой, местом и основным фокусом церемонии." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000371"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.intro", "Archive of completed yagyas with program, location and ceremony focus." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000372"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.past.intro", "Архів проведених яг'ї з програмою, локацією та головним фокусом церемонії." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000373"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.empty", "Ягьи пока не опубликованы." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000374"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.empty", "No yagyas have been published yet." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000375"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.empty", "Яг'ї ще не опубліковані." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000376"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.card.cta", "Оставить заявку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000377"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.card.cta", "Send request" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000378"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagyas.card.cta", "Залишити заявку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000379"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.loading", "Загрузка..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000380"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.loading", "Loading..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000381"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.loading", "Завантаження..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000382"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.back", "Все ягьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000383"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.back", "All yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000384"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.back", "Усі яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000385"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.about_eyebrow", "О церемонии" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000386"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.about_eyebrow", "About the ceremony" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000387"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.about_eyebrow", "Про церемонію" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000388"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.about_h2", "Описание и намерение" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000389"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.about_h2", "Description and intention" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000390"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.about_h2", "Опис і намір" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000391"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.program_eyebrow", "Программа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000392"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.program_eyebrow", "Program" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000393"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.program_eyebrow", "Програма" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000394"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.program_h2", "Как проходит ягья" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000395"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.program_h2", "How the yagya unfolds" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000396"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.program_h2", "Як проходить яг'я" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000397"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.booking_h3", "Присоединиться к ягье" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000398"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.booking_h3", "Join the yagya" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000399"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.booking_h3", "Долучитися до яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000400"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_eyebrow", "Другие ягьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000401"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_eyebrow", "Other yagyas" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000402"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_eyebrow", "Інші яг'ї" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000403"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_h2", "Смотрите также" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000404"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_h2", "See also" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000405"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_h2", "Дивіться також" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000406"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_cta", "Подробнее →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000407"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_cta", "Learn more →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000408"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.yagya.detail.other_cta", "Детальніше →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000409"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.title", "Блог | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000410"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.title", "Blog | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000411"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.title", "Блог | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000412"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h1", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000413"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h1", "Blog" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000414"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h1", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000415"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.title", "Статьи | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000416"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.title", "Articles | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000417"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.title", "Статті | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000418"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.h1", "Статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000419"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.h1", "Articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000420"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.h1", "Статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000421"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.title", "Видео | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000422"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.title", "Videos | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000423"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.title", "Відео | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000424"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.h1", "Видео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000425"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.h1", "Videos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000426"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.h1", "Відео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000427"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.title", "Фото | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000428"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.title", "Photos | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000429"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.title", "Фото | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000430"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.h1", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000431"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.h1", "Photos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000432"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.h1", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000433"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.title", "О нас | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000434"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.title", "About | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000435"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.title", "Про нас | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000436"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.h1", "О нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000437"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.h1", "About Us" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000438"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.h1", "Про нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000439"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.title", "Контакты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000440"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.title", "Contact | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000441"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.title", "Контакти | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000442"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.h1", "Контакты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000443"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.h1", "Contact" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000444"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.h1", "Контакти" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000445"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.heading", "Записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000446"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.heading", "Sign Up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000447"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.heading", "Записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000448"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.subtext", "Оставьте свои контакты, и мы свяжемся с вами для уточнения деталей." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000449"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.subtext", "Leave your details and we'll be in touch to confirm." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000450"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.subtext", "Залиште контакти — ми зв'яжемось для уточнення деталей." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000451"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.context_prefix", "Запись на" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000452"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.context_prefix", "Sign up for" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000453"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.context_prefix", "Запис на" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000454"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.name", "Ваше имя" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000455"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.name", "Your name" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000456"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.name", "Ваше ім'я" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000457"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.messenger", "В каком мессенджере связаться?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000458"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.messenger", "Preferred messenger" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000459"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.messenger", "Месенджер для зв'язку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000460"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.phone_call", "Звонок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000461"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.phone_call", "Phone call" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000462"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.phone_call", "Дзвінок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000463"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.contact", "Номер телефона или Никнейм" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000464"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.contact", "Phone number or username" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000465"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.contact", "Номер телефону або нікнейм" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000466"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.comment", "Комментарий (пожелания, вопросы)" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000467"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.comment", "Comment (wishes, questions)" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000468"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.comment", "Коментар (побажання, питання)" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000469"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submit", "Оставить заявку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000470"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submit", "Submit request" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000471"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submit", "Залишити заявку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000472"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submitting", "Отправляем..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000473"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submitting", "Sending..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000474"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submitting", "Надсилаємо..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000475"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.success", "Спасибо! Ваша заявка успешно отправлена. Мы скоро свяжемся с вами." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000476"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.success", "Thank you! Your request has been sent. We'll be in touch soon." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000477"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.success", "Дякуємо! Вашу заявку надіслано. Ми скоро зв'яжемось." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000478"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.eyebrow", "О программе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000479"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.eyebrow", "About the programme" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000480"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.eyebrow", "Про програму" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000481"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.h2", "Что вас ждёт" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000482"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.h2", "What awaits you" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000483"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.h2", "Що на вас чекає" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000484"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.benefits.h4", "Что вы получите" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000485"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.benefits.h4", "What you'll gain" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000486"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.benefits.h4", "Що ви отримаєте" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000487"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.eyebrow", "Программа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000488"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.eyebrow", "Programme" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000489"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.eyebrow", "Програма" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000490"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.h2", "Структура курса" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000491"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.h2", "Course structure" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000492"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.h2", "Структура курсу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000493"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.eyebrow", "Для кого" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000494"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.eyebrow", "For whom" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000495"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.eyebrow", "Для кого" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000496"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.h2", "Кому подойдёт" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000497"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.h2", "Who is it for" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000498"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.h2", "Кому підійде" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000499"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.eyebrow", "Следующий шаг" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000500"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.eyebrow", "Next step" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000501"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.eyebrow", "Наступний крок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000502"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.h2", "Готовы начать путь?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000503"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.h2", "Ready to begin?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000504"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.h2", "Готові розпочати шлях?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000505"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.text", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000506"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.text", "Submit a request — we'll reply within the day with details on the next intake." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000507"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.text", "Залиште заявку — ми відповімо протягом дня." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000508"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.btn", "Хочу записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000509"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.btn", "I want to sign up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000510"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.btn", "Хочу записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000511"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.back_to_list", "← Назад к списку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000512"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.back_to_list", "← Back to list" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000513"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.back_to_list", "← Назад до списку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000514"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.eyebrow", "Направления обучения" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000515"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.eyebrow", "Learning directions" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000516"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.eyebrow", "Напрями навчання" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000517"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h2", "Выберите свой путь" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000518"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h2", "Choose your path" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000519"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h2", "Оберіть свій шлях" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000520"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.intro", "Три авторские программы — от дыхания до глубинной трансформации." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000521"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.intro", "Three proprietary programmes — from breathwork to deep transformation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000522"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.intro", "Три авторські програми — від дихання до глибинної трансформації." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000523"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.eyebrow", "Дыхательные практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000524"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.eyebrow", "Breathing practices" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000525"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.eyebrow", "Дихальні практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000526"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.tagline", "Сила вдоха — сила жизни" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000527"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.tagline", "The power of breath — the power of life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000528"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.tagline", "Сила вдиху — сила життя" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000529"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.text", "Научитесь управлять дыханием и откройте новые горизонты сознания." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000530"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.text", "Learn to harness your breath and unlock new horizons of consciousness." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000531"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.text", "Навчіться управляти диханням та відкрийте нові горизонти свідомості." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000532"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.eyebrow", "Медитативные практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000533"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.eyebrow", "Meditative practices" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000534"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.eyebrow", "Медитативні практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000535"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.tagline", "Тишина как инструмент" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000536"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.tagline", "Silence as a tool" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000537"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.tagline", "Тиша як інструмент" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000538"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.text", "Освойте техники медитации и найдите покой в любой ситуации." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000539"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.text", "Master meditation techniques and find stillness in any situation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000540"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.text", "Опануйте техніки медитації та знайдіть спокій у будь-якій ситуації." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000541"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.eyebrow", "Йога-практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000542"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.eyebrow", "Yoga practice" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000543"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.eyebrow", "Йога-практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000544"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.tagline", "Тело как отражение духа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000545"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.tagline", "Body as a reflection of spirit" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000546"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.tagline", "Тіло як відображення духу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000547"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.text", "Комплексная практика асан, пранаямы и медитации для целостной трансформации." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000548"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.text", "A complete practice of asanas, pranayama and meditation for holistic transformation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000549"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.text", "Комплексна практика асан, пранаями та медитації для цілісної трансформації." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000550"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.cta", "Подробнее →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000551"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.cta", "Learn more →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000552"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.cta", "Детальніше →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000553"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.eyebrow", "Индивидуальная работа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000554"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.eyebrow", "Individual work" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000555"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.eyebrow", "Індивідуальна робота" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000556"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h2", "Личное сопровождение" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000557"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h2", "Personal guidance" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000558"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h2", "Особистий супровід" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000559"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.intro", "Три направления персональных консультаций с нашими специалистами." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000560"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.intro", "Three areas of personal consultations with our specialists." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000561"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.intro", "Три напрями персональних консультацій з нашими фахівцями." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000562"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.eyebrow", "Работа с энергией" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000563"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.eyebrow", "Energy work" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000564"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.eyebrow", "Робота з енергією" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000565"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.tagline", "Восстановить баланс сил" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000566"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.tagline", "Restore the balance of energies" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000567"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.tagline", "Відновити баланс сил" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000568"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.text", "Диагностика и балансировка энергетических центров через пранаяму и медитацию." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000569"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.text", "Diagnosis and balancing of energy centres through pranayama and meditation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000570"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.text", "Діагностика та балансування енергетичних центрів через пранаяму та медитацію." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000571"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.eyebrow", "Аюрведическая диагностика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000572"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.eyebrow", "Ayurvedic diagnosis" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000573"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.eyebrow", "Аюрведична діагностика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000574"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.tagline", "Природная мудрость здоровья" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000575"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.tagline", "Natural wisdom of health" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000576"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.tagline", "Природна мудрість здоров'я" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000577"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.text", "Определение вашего доши-типа и составление персональных рекомендаций." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000578"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.text", "Determine your dosha type and receive personalised recommendations." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000579"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.text", "Визначення вашого типу доші та складання персональних рекомендацій." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000580"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.eyebrow", "Духовное развитие" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000581"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.eyebrow", "Spiritual development" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000582"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.eyebrow", "Духовний розвиток" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000583"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.tagline", "Путь к истинному себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000584"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.tagline", "Path to the true self" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000585"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.tagline", "Шлях до справжнього себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000586"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.text", "Индивидуальная работа с убеждениями, страхами и духовными вопросами." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000587"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.text", "Individual work with beliefs, fears and spiritual questions." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000588"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.text", "Індивідуальна робота з переконаннями, страхами та духовними питаннями." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000589"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.cta", "Записаться →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000590"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.cta", "Book →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000591"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.cta", "Записатися →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000592"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.eyebrow", "Мы — Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000593"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.eyebrow", "We are Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000594"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.eyebrow", "Ми — Yoga.Life" });

            migrationBuilder.InsertData(
                table: "UiTranslations",
                columns: new[] { "Id", "Key", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000595"), "page.about.founders.h2", "ru", "Три пути — одна миссия" },
                    { new Guid("b0000000-0000-0000-0000-000000000596"), "page.about.founders.h2", "en", "Three paths — one mission" },
                    { new Guid("b0000000-0000-0000-0000-000000000597"), "page.about.founders.h2", "uk", "Три шляхи — одна місія" },
                    { new Guid("b0000000-0000-0000-0000-000000000598"), "page.about.philosophy.eyebrow", "ru", "Принципы" },
                    { new Guid("b0000000-0000-0000-0000-000000000599"), "page.about.philosophy.eyebrow", "en", "Principles" },
                    { new Guid("b0000000-0000-0000-0000-000000000600"), "page.about.philosophy.eyebrow", "uk", "Принципи" },
                    { new Guid("b0000000-0000-0000-0000-000000000601"), "page.about.philosophy.h2", "ru", "Философия проекта" },
                    { new Guid("b0000000-0000-0000-0000-000000000602"), "page.about.philosophy.h2", "en", "Project philosophy" },
                    { new Guid("b0000000-0000-0000-0000-000000000603"), "page.about.philosophy.h2", "uk", "Філософія проекту" },
                    { new Guid("b0000000-0000-0000-0000-000000000604"), "page.contacts.eyebrow", "ru", "Всегда на связи" },
                    { new Guid("b0000000-0000-0000-0000-000000000605"), "page.contacts.eyebrow", "en", "Always in touch" },
                    { new Guid("b0000000-0000-0000-0000-000000000606"), "page.contacts.eyebrow", "uk", "Завжди на зв'язку" },
                    { new Guid("b0000000-0000-0000-0000-000000000607"), "page.contacts.info.h2", "ru", "Давайте познакомимся" },
                    { new Guid("b0000000-0000-0000-0000-000000000608"), "page.contacts.info.h2", "en", "Let's connect" },
                    { new Guid("b0000000-0000-0000-0000-000000000609"), "page.contacts.info.h2", "uk", "Давайте познайомимось" },
                    { new Guid("b0000000-0000-0000-0000-000000000610"), "page.contacts.social.eyebrow", "ru", "Социальные сети" },
                    { new Guid("b0000000-0000-0000-0000-000000000611"), "page.contacts.social.eyebrow", "en", "Social media" },
                    { new Guid("b0000000-0000-0000-0000-000000000612"), "page.contacts.social.eyebrow", "uk", "Соціальні мережі" },
                    { new Guid("b0000000-0000-0000-0000-000000000613"), "page.contacts.social.h2", "ru", "Присоединяйтесь к нам" },
                    { new Guid("b0000000-0000-0000-0000-000000000614"), "page.contacts.social.h2", "en", "Join us online" },
                    { new Guid("b0000000-0000-0000-0000-000000000615"), "page.contacts.social.h2", "uk", "Приєднуйтесь до нас" },
                    { new Guid("b0000000-0000-0000-0000-000000000616"), "page.retreats.eyebrow", "ru", "Ближайшие программы" },
                    { new Guid("b0000000-0000-0000-0000-000000000617"), "page.retreats.eyebrow", "en", "Upcoming programmes" },
                    { new Guid("b0000000-0000-0000-0000-000000000618"), "page.retreats.eyebrow", "uk", "Найближчі програми" },
                    { new Guid("b0000000-0000-0000-0000-000000000619"), "page.retreats.actual.intro", "ru", "Открытые ретриты, на которые сейчас можно записаться." },
                    { new Guid("b0000000-0000-0000-0000-000000000620"), "page.retreats.actual.intro", "en", "Open retreats you can register for right now." },
                    { new Guid("b0000000-0000-0000-0000-000000000621"), "page.retreats.actual.intro", "uk", "Відкриті ретрити, на які зараз можна записатись." },
                    { new Guid("b0000000-0000-0000-0000-000000000622"), "page.retreats.upcoming.intro", "ru", "Предстоящие ретриты — запишитесь заранее и получите лучшие условия." },
                    { new Guid("b0000000-0000-0000-0000-000000000623"), "page.retreats.upcoming.intro", "en", "Upcoming retreats — register early for the best terms." },
                    { new Guid("b0000000-0000-0000-0000-000000000624"), "page.retreats.upcoming.intro", "uk", "Майбутні ретрити — запишіться заздалегідь для найкращих умов." },
                    { new Guid("b0000000-0000-0000-0000-000000000625"), "page.retreats.past.intro", "ru", "История наших программ. Каждый ретрит — это особенная история." },
                    { new Guid("b0000000-0000-0000-0000-000000000626"), "page.retreats.past.intro", "en", "A record of our past programmes. Each retreat is a unique story." },
                    { new Guid("b0000000-0000-0000-0000-000000000627"), "page.retreats.past.intro", "uk", "Історія наших програм. Кожен ретрит — це особлива історія." },
                    { new Guid("b0000000-0000-0000-0000-000000000628"), "page.retreats.card.location", "ru", "Местоположение" },
                    { new Guid("b0000000-0000-0000-0000-000000000629"), "page.retreats.card.location", "en", "Location" },
                    { new Guid("b0000000-0000-0000-0000-000000000630"), "page.retreats.card.location", "uk", "Місцезнаходження" },
                    { new Guid("b0000000-0000-0000-0000-000000000631"), "page.retreats.card.dates", "ru", "Даты" },
                    { new Guid("b0000000-0000-0000-0000-000000000632"), "page.retreats.card.dates", "en", "Dates" },
                    { new Guid("b0000000-0000-0000-0000-000000000633"), "page.retreats.card.dates", "uk", "Дати" },
                    { new Guid("b0000000-0000-0000-0000-000000000634"), "page.retreats.card.cta", "ru", "Записаться" },
                    { new Guid("b0000000-0000-0000-0000-000000000635"), "page.retreats.card.cta", "en", "Sign up" },
                    { new Guid("b0000000-0000-0000-0000-000000000636"), "page.retreats.card.cta", "uk", "Записатися" },
                    { new Guid("b0000000-0000-0000-0000-000000000637"), "page.retreats.empty", "ru", "Ретриты не найдены." },
                    { new Guid("b0000000-0000-0000-0000-000000000638"), "page.retreats.empty", "en", "No retreats found." },
                    { new Guid("b0000000-0000-0000-0000-000000000639"), "page.retreats.empty", "uk", "Ретрити не знайдено." },
                    { new Guid("b0000000-0000-0000-0000-000000000640"), "page.blog.eyebrow", "ru", "Знания и вдохновение" },
                    { new Guid("b0000000-0000-0000-0000-000000000641"), "page.blog.eyebrow", "en", "Knowledge and inspiration" },
                    { new Guid("b0000000-0000-0000-0000-000000000642"), "page.blog.eyebrow", "uk", "Знання та натхнення" },
                    { new Guid("b0000000-0000-0000-0000-000000000643"), "page.blog.h2", "ru", "Исследуйте темы" },
                    { new Guid("b0000000-0000-0000-0000-000000000644"), "page.blog.h2", "en", "Explore topics" },
                    { new Guid("b0000000-0000-0000-0000-000000000645"), "page.blog.h2", "uk", "Досліджуйте теми" },
                    { new Guid("b0000000-0000-0000-0000-000000000646"), "page.blog.articles.eyebrow", "ru", "Авторские статьи" },
                    { new Guid("b0000000-0000-0000-0000-000000000647"), "page.blog.articles.eyebrow", "en", "Articles" },
                    { new Guid("b0000000-0000-0000-0000-000000000648"), "page.blog.articles.eyebrow", "uk", "Авторські статті" },
                    { new Guid("b0000000-0000-0000-0000-000000000649"), "page.blog.articles.intro", "ru", "Глубокие материалы о практике, философии и образе жизни." },
                    { new Guid("b0000000-0000-0000-0000-000000000650"), "page.blog.articles.intro", "en", "In-depth material on practice, philosophy and lifestyle." },
                    { new Guid("b0000000-0000-0000-0000-000000000651"), "page.blog.articles.intro", "uk", "Глибокі матеріали про практику, філософію та спосіб життя." },
                    { new Guid("b0000000-0000-0000-0000-000000000652"), "page.blog.videos.eyebrow", "ru", "Видеоматериалы" },
                    { new Guid("b0000000-0000-0000-0000-000000000653"), "page.blog.videos.eyebrow", "en", "Video content" },
                    { new Guid("b0000000-0000-0000-0000-000000000654"), "page.blog.videos.eyebrow", "uk", "Відеоматеріали" },
                    { new Guid("b0000000-0000-0000-0000-000000000655"), "page.blog.videos.intro", "ru", "Практические уроки и вдохновляющие записи с наших ретритов." },
                    { new Guid("b0000000-0000-0000-0000-000000000656"), "page.blog.videos.intro", "en", "Practical lessons and inspiring recordings from our retreats." },
                    { new Guid("b0000000-0000-0000-0000-000000000657"), "page.blog.videos.intro", "uk", "Практичні уроки та надихаючі записи з наших ретритів." },
                    { new Guid("b0000000-0000-0000-0000-000000000658"), "page.blog.photos.eyebrow", "ru", "Галерея" },
                    { new Guid("b0000000-0000-0000-0000-000000000659"), "page.blog.photos.eyebrow", "en", "Gallery" },
                    { new Guid("b0000000-0000-0000-0000-000000000660"), "page.blog.photos.eyebrow", "uk", "Галерея" },
                    { new Guid("b0000000-0000-0000-0000-000000000661"), "page.blog.photos.intro", "ru", "Моменты из жизни нашего сообщества." },
                    { new Guid("b0000000-0000-0000-0000-000000000662"), "page.blog.photos.intro", "en", "Moments from the life of our community." },
                    { new Guid("b0000000-0000-0000-0000-000000000663"), "page.blog.photos.intro", "uk", "Моменти з життя нашої спільноти." },
                    { new Guid("b0000000-0000-0000-0000-000000000664"), "page.blog.readmore", "ru", "Читать →" },
                    { new Guid("b0000000-0000-0000-0000-000000000665"), "page.blog.readmore", "en", "Read →" },
                    { new Guid("b0000000-0000-0000-0000-000000000666"), "page.blog.readmore", "uk", "Читати →" },
                    { new Guid("b0000000-0000-0000-0000-000000000667"), "page.blog.empty", "ru", "Публикации пока не добавлены." },
                    { new Guid("b0000000-0000-0000-0000-000000000668"), "page.blog.empty", "en", "No posts have been added yet." },
                    { new Guid("b0000000-0000-0000-0000-000000000669"), "page.blog.empty", "uk", "Публікації ще не додані." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yagyas");

            migrationBuilder.DeleteData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444408"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000595"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000596"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000597"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000598"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000599"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000600"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000601"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000602"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000603"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000604"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000605"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000606"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000607"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000608"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000609"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000610"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000611"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000612"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000613"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000614"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000615"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000616"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000617"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000618"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000619"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000620"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000621"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000622"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000623"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000624"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000625"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000626"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000627"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000628"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000629"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000630"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000631"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000632"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000633"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000634"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000635"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000636"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000637"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000638"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000639"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000640"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000641"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000642"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000643"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000644"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000645"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000646"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000647"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000648"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000649"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000650"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000651"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000652"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000653"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000654"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000655"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000656"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000657"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000658"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000659"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000660"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000661"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000662"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000663"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000664"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000665"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000666"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000667"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000668"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000669"));

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                column: "Value",
                value: "Пранаяма");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                column: "Value",
                value: "Pranayama");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                column: "Value",
                value: "Пранаяма");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                column: "Value",
                value: "Аюрведа");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                column: "Value",
                value: "Ayurveda");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                column: "Value",
                value: "Аюрведа");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000040"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000041"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog", "Blog" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000042"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000043"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.articles", "Статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000044"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.articles", "Articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000045"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.articles", "Статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000046"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.videos", "Видео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000047"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.videos", "Videos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000048"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.videos", "Відео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000049"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.photos", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000050"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.photos", "Photos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000051"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.blog.photos", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000052"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.about", "О нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000053"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.about", "About" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000054"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.about", "Про нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000055"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.contacts", "Контакты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000056"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.contacts", "Contact" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000057"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.contacts", "Контакти" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000058"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "footer.copy", "© 2026 Yoga.Life Enterprise. Возврат к истокам." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000059"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "footer.copy", "© 2026 Yoga.Life Enterprise. A return to origins." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000060"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "footer.copy", "© 2026 Yoga.Life Enterprise. Повернення до витоків." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000061"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.title", "Yoga.Life | Авторские Ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000062"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.title", "Yoga.Life | Author-Led Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000063"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.title", "Yoga.Life | Авторські Ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000064"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.eyebrow", "Yoga · Life · Enterprise" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000065"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.eyebrow", "Yoga · Life · Enterprise" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000066"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.eyebrow", "Yoga · Life · Enterprise" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000067"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.line1", "Возврат" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000068"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.line1", "Return" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000069"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.line1", "Повернення" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000070"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.em", "к себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000071"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.em", "to yourself" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000072"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.h1.em", "до себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000073"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.text", "Авторские ретриты и программы обучения. Погружение в тишину, практики осознанности и полное обновление." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000074"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.text", "Author-led retreats and training programmes. A plunge into stillness, mindfulness practices and complete renewal." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000075"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.text", "Авторські ретрити та навчальні програми. Занурення в тишу, практики усвідомленості та повне оновлення." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000076"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.cta", "Записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000077"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.cta", "Sign up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000078"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.hero.cta", "Записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000079"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.retreats", "Ретритов" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000080"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.retreats", "Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000081"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.retreats", "Ретритів" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000082"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.members", "Участников" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000083"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.members", "Participants" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000084"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.members", "Учасників" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000085"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.countries", "Стран" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000086"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.countries", "Countries" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000087"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.countries", "Країн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000088"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.years", "Лет практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000089"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.years", "Years of practice" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000090"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.stats.years", "Років практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000091"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.eyebrow", "Программы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000092"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.eyebrow", "Programmes" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000093"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.eyebrow", "Програми" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000094"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.h2", "Ближайшие ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000095"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.h2", "Upcoming Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000096"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.h2", "Найближчі ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000097"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.loading", "Загрузка расписания..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000098"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.loading", "Loading schedule..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000099"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.loading", "Завантаження розкладу..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000100"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.empty", "Нет доступных ретритов в данный момент." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000101"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.empty", "No retreats currently available." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000102"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.empty", "Немає доступних ретритів на даний момент." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000103"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.cta", "Хочу сюда" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000104"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.cta", "I want to go" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000105"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.retreats.cta", "Хочу сюди" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000106"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.eyebrow", "Что мы предлагаем" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000107"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.eyebrow", "What we offer" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000108"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.eyebrow", "Що ми пропонуємо" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000109"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.h2", "Направления" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000110"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.h2", "Directions" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000111"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.h2", "Напрямки" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000112"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01", "01" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000113"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01", "01" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000114"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01", "01" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000115"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.h3", "Курсы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000116"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.h3", "Courses" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000117"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.h3", "Курси" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000118"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.text", "Пранаяма, медитация, йога — системные программы для углублённой практики в любом темпе." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000119"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.text", "Pranayama, meditation, yoga — structured programmes for deepening your practice at your own pace." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000120"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.text", "Пранаяма, медитація, йога — системні програми для поглибленої практики в будь-якому темпі." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000121"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.link", "Смотреть курсы →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000122"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.link", "View courses →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000123"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.01.link", "Дивитися курси →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000124"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02", "02" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000125"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02", "02" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000126"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02", "02" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000127"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.h3", "Консультации" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000128"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.h3", "Consultations" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000129"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.h3", "Консультації" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000130"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.text", "Индивидуальный разбор по энергетике, аюрведе и духовным практикам с личным куратором." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000131"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.text", "Individual session on energetics, Ayurveda and spiritual practices with a personal mentor." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000132"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.text", "Індивідуальний розбір з енергетики, аюрведи та духовних практик з особистим куратором." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000133"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.link", "Записаться →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000134"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.link", "Book a session →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000135"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.02.link", "Записатися →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000136"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03", "03" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000137"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03", "03" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000138"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03", "03" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000139"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.h3", "Ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000140"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.h3", "Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000141"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.h3", "Ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000142"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.text", "Выездные программы в Черногории, Индии и других локациях. От 7 до 21 дня полного погружения." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000143"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.text", "Immersive programmes in Montenegro, India and beyond. From 7 to 21 days of full immersion." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000144"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.text", "Виїзні програми в Чорногорії, Індії та інших локаціях. Від 7 до 21 дня повного занурення." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000145"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.link", "Все ретриты →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000146"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.link", "All retreats →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000147"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.directions.03.link", "Всі ретрити →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000148"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line1", "«Йога — это не то, что вы делаете на коврике." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000149"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line1", "«Yoga is not what you do on the mat." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000150"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line1", "«Йога — це не те, що ви робите на килимку." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000151"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line2", "Это то, кем вы становитесь — за его пределами.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000152"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line2", "It is who you become — beyond it.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000153"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.line2", "Це те, ким ви стаєте — за його межами.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000154"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.by", "— Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000155"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.by", "— Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000156"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.quote.by", "— Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000157"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow1", "Формат I" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000158"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow1", "Format I" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000159"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow1", "Формат I" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000160"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.1", "Онлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000161"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.1", "Online" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000162"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.1", "Онлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000163"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text1", "Практикуйте из любой точки мира. Живые сессии, записи, индивидуальная обратная связь от куратора в вашем ритме." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000164"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text1", "Practice from anywhere in the world. Live sessions, recordings, personal feedback from your mentor at your own pace." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000165"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text1", "Практикуйте з будь-якої точки світу. Живі сесії, записи, індивідуальний зворотній зв'язок від куратора у вашому ритмі." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000166"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta1", "Онлайн-курсы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000167"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta1", "Online courses" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000168"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta1", "Онлайн-курси" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000169"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow2", "Формат II" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000170"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow2", "Format II" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000171"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.eyebrow2", "Формат II" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000172"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.2", "Офлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000173"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.2", "In-person" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000174"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.h2.2", "Офлайн" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000175"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text2", "Живое присутствие и глубокое взаимодействие. Ретриты и интенсивы в сакральных местах силы." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000176"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text2", "Real presence and deep connection. Retreats and intensives in sacred places of power." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000177"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.text2", "Жива присутність і глибока взаємодія. Ретрити та інтенсиви в сакральних місцях сили." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000178"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta2", "Ретриты и выезды" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000179"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta2", "Retreats & travel" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000180"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.formats.cta2", "Ретрити і виїзди" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000181"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.eyebrow", "Отзывы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000182"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.eyebrow", "Reviews" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000183"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.eyebrow", "Відгуки" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000184"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.h2", "Говорят участники" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000185"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.h2", "What participants say" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000186"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.h2", "Говорять учасники" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000187"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.quote", "«После ретрита в Черногории я впервые за несколько лет почувствовала, что тело и голова — в одном месте. Это был настоящий перезапуск.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000188"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.quote", "«After the Montenegro retreat I felt, for the first time in years, that my body and mind were in the same place. It was a true reset.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000189"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.quote", "«Після ретриту в Чорногорії я вперше за кілька років відчула, що тіло і голова — в одному місці. Це був справжній перезапуск.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000190"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.name", "Анна К." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000191"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.name", "Anna K." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000192"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.name", "Анна К." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000193"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.program", "Ретрит «Черногория, сентябрь»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000194"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.program", "Retreat 'Montenegro, September'" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000195"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.1.program", "Ретрит «Чорногорія, вересень»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000196"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.quote", "«Курс по пранаяме изменил моё отношение к дыханию и к жизни в целом. Простые техники, которые работают каждый день.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000197"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.quote", "«The pranayama course changed my relationship with breathing — and with life itself. Simple techniques that work every single day.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000198"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.quote", "«Курс з пранаями змінив моє ставлення до дихання і до життя загалом. Прості техніки, які працюють щодня.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000199"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.name", "Михаил Р." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000200"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.name", "Mikhail R." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000201"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.name", "Михайло Р." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000202"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.program", "Курс «Пранаяма: базовый»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000203"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.program", "Course 'Pranayama: Foundations'" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000204"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.2.program", "Курс «Пранаяма: базовий»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000205"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.quote", "«Индивидуальная консультация по аюрведе дала мне план на год вперёд — питание, режим, практики. Всё чётко и без лишней эзотерики.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000206"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.quote", "«The Ayurveda consultation gave me a year-long plan — nutrition, daily routine, practices. Clear and without unnecessary mysticism.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000207"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.quote", "«Індивідуальна консультація з аюрведи дала мені план на рік вперед — харчування, режим, практики. Все чітко і без зайвої езотерики.»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000208"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.name", "Светлана В." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000209"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.name", "Svetlana V." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000210"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.name", "Світлана В." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000211"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.program", "Консультация «Аюрведа»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000212"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.program", "Consultation 'Ayurveda'" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000213"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.reviews.3.program", "Консультація «Аюрведа»" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000214"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.eyebrow", "Из блога" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000215"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.eyebrow", "From the blog" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000216"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.eyebrow", "З блогу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000217"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.h2", "Статьи и размышления" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000218"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.h2", "Articles & reflections" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000219"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.h2", "Статті та роздуми" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000220"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.tag", "Практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000221"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.tag", "Practice" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000222"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.tag", "Практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000223"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.h3", "Пранаяма для начинающих: 5 техник, которые изменят качество сна" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000224"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.h3", "Pranayama for beginners: 5 techniques that will transform your sleep" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000225"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.h3", "Пранаяма для початківців: 5 технік, які змінять якість сну" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000226"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.text", "Простые дыхательные упражнения, которые можно выполнять лёжа в постели — без коврика и специального оборудования." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000227"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.text", "Simple breathing exercises you can do lying in bed — no mat or special equipment required." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000228"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.1.text", "Прості дихальні вправи, які можна виконувати лежачи в ліжку — без килимка і спеціального обладнання." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000229"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.tag", "Философия" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000230"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.tag", "Philosophy" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000231"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.tag", "Філософія" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000232"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.h3", "Ахимса в повседневности: как принцип ненасилия работает вне коврика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000233"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.h3", "Ahimsa in daily life: how the non-violence principle works off the mat" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000234"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.h3", "Ахімса у повсякденності: як принцип ненасилля працює поза килимком" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000235"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.text", "О том, как одно из базовых правил йоги можно применять в разговорах, питании и отношении к себе." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000236"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.text", "How one of yoga's foundational rules can be applied in conversations, diet and your relationship with yourself." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000237"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.2.text", "Про те, як одне з базових правил йоги можна застосовувати в розмовах, харчуванні та ставленні до себе." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000238"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.tag", "Ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000239"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.tag", "Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000240"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.tag", "Ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000241"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.h3", "Почему 7 дней тишины меняют больше, чем год терапии" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000242"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.h3", "Why 7 days of silence changes more than a year of therapy" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000243"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.h3", "Чому 7 днів тиші змінюють більше, ніж рік терапії" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000244"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.text", "Личный опыт и разбор механизмов: что происходит с нервной системой в условиях глубокой тишины и отрыва от привычной среды." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000245"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.text", "Personal experience and analysis: what happens to the nervous system in conditions of deep silence and disconnection from everyday life." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000246"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.3.text", "Особистий досвід і розбір механізмів: що відбувається з нервовою системою в умовах глибокої тиші та відриву від звичного середовища." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000247"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.readmore", "Читать →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000248"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.readmore", "Read →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000249"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.readmore", "Читати →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000250"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.all", "Все статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000251"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.all", "All articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000252"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.blog.all", "Всі статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000253"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.eyebrow", "Следующий шаг" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000254"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.eyebrow", "Next step" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000255"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.eyebrow", "Наступний крок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000256"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.h2", "Готовы к изменениям?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000257"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.h2", "Ready for change?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000258"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.h2", "Готові до змін?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000259"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.text", "Оставьте заявку — мы подберём программу, которая подойдёт именно вам." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000260"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.text", "Leave a request — we'll find the programme that's right for you." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000261"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.text", "Залиште заявку — ми підберемо програму, яка підійде саме вам." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000262"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.btn", "Хочу попасть на программу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000263"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.btn", "I want to join a programme" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000264"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.home.cta.btn", "Хочу потрапити на програму" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000265"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.title", "Курсы | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000266"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.title", "Courses | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000267"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.title", "Курси | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000268"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h1", "Курсы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000269"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h1", "Courses" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000270"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h1", "Курси" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000271"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.sub", "Выберите направление." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000272"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.sub", "Choose a direction." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000273"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.sub", "Оберіть напрямок." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000274"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.title", "Пранаяма | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000275"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.title", "Pranayama | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000276"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.title", "Пранаяма | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000277"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.h1", "Пранаяма" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000278"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.h1", "Pranayama" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000279"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.pranayama.h1", "Пранаяма" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000280"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.title", "Медитация | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000281"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.title", "Meditation | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000282"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.title", "Медитація | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000283"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.h1", "Медитация" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000284"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.h1", "Meditation" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000285"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.meditation.h1", "Медитація" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000286"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.title", "Йога | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000287"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.title", "Yoga | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000288"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.title", "Йога | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000289"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.h1", "Йога" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000290"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.h1", "Yoga" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000291"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.yoga.h1", "Йога" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000292"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.title", "Консультации | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000293"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.title", "Consultations | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000294"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.title", "Консультації | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000295"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h1", "Консультации" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000296"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h1", "Consultations" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000297"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h1", "Консультації" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000298"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.title", "Энергетика | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000299"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.title", "Energetics | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000300"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.title", "Енергетика | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000301"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.h1", "Энергетика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000302"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.h1", "Energetics" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000303"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.energy.h1", "Енергетика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000304"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.title", "Аюрведа | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000305"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.title", "Ayurveda | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000306"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.title", "Аюрведа | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000307"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.h1", "Аюрведа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000308"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.h1", "Ayurveda" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000309"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.ayurveda.h1", "Аюрведа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000310"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.title", "Духовность | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000311"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.title", "Spirituality | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000312"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.title", "Духовність | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000313"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.h1", "Духовность" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000314"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.h1", "Spirituality" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000315"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.spirituality.h1", "Духовність" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000316"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.title", "Актуальные ретриты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000317"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.title", "Current Retreats | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000318"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.title", "Актуальні ретрити | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000319"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.h1", "Актуальные ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000320"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.h1", "Current Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000321"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.h1", "Актуальні ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000322"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.title", "Предстоящие ретриты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000323"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.title", "Upcoming Retreats | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000324"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.title", "Майбутні ретрити | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000325"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.h1", "Предстоящие ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000326"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.h1", "Upcoming Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000327"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.h1", "Майбутні ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000328"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.title", "Прошедшие ретриты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000329"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.title", "Past Retreats | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000330"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.title", "Минулі ретрити | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000331"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.h1", "Прошедшие ретриты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000332"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.h1", "Past Retreats" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000333"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.h1", "Минулі ретрити" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000334"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.title", "Блог | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000335"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.title", "Blog | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000336"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.title", "Блог | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000337"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h1", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000338"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h1", "Blog" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000339"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h1", "Блог" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000340"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.title", "Статьи | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000341"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.title", "Articles | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000342"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.title", "Статті | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000343"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.h1", "Статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000344"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.h1", "Articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000345"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.h1", "Статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000346"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.title", "Видео | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000347"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.title", "Videos | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000348"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.title", "Відео | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000349"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.h1", "Видео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000350"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.h1", "Videos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000351"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.h1", "Відео" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000352"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.title", "Фото | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000353"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.title", "Photos | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000354"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.title", "Фото | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000355"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.h1", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000356"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.h1", "Photos" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000357"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.h1", "Фото" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000358"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.title", "О нас | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000359"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.title", "About | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000360"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.title", "Про нас | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000361"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.h1", "О нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000362"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.h1", "About Us" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000363"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.h1", "Про нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000364"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.title", "Контакты | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000365"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.title", "Contact | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000366"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.title", "Контакти | Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000367"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.h1", "Контакты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000368"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.h1", "Contact" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000369"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.h1", "Контакти" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000370"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.heading", "Записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000371"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.heading", "Sign Up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000372"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.heading", "Записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000373"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.subtext", "Оставьте свои контакты, и мы свяжемся с вами для уточнения деталей." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000374"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.subtext", "Leave your details and we'll be in touch to confirm." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000375"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.subtext", "Залиште контакти — ми зв'яжемось для уточнення деталей." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000376"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.context_prefix", "Запись на" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000377"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.context_prefix", "Sign up for" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000378"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.context_prefix", "Запис на" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000379"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.name", "Ваше имя" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000380"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.name", "Your name" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000381"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.name", "Ваше ім'я" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000382"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.messenger", "В каком мессенджере связаться?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000383"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.messenger", "Preferred messenger" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000384"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.messenger", "Месенджер для зв'язку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000385"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.phone_call", "Звонок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000386"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.phone_call", "Phone call" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000387"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.phone_call", "Дзвінок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000388"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.contact", "Номер телефона или Никнейм" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000389"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.contact", "Phone number or username" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000390"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.contact", "Номер телефону або нікнейм" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000391"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.comment", "Комментарий (пожелания, вопросы)" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000392"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.comment", "Comment (wishes, questions)" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000393"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.comment", "Коментар (побажання, питання)" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000394"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submit", "Оставить заявку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000395"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submit", "Submit request" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000396"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submit", "Залишити заявку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000397"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submitting", "Отправляем..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000398"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submitting", "Sending..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000399"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.submitting", "Надсилаємо..." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000400"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.success", "Спасибо! Ваша заявка успешно отправлена. Мы скоро свяжемся с вами." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000401"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.success", "Thank you! Your request has been sent. We'll be in touch soon." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000402"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "form.success", "Дякуємо! Вашу заявку надіслано. Ми скоро зв'яжемось." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000403"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.eyebrow", "О программе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000404"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.eyebrow", "About the programme" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000405"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.eyebrow", "Про програму" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000406"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.h2", "Что вас ждёт" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000407"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.h2", "What awaits you" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000408"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.overview.h2", "Що на вас чекає" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000409"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.benefits.h4", "Что вы получите" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000410"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.benefits.h4", "What you'll gain" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000411"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.benefits.h4", "Що ви отримаєте" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000412"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.eyebrow", "Программа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000413"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.eyebrow", "Programme" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000414"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.eyebrow", "Програма" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000415"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.h2", "Структура курса" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000416"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.h2", "Course structure" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000417"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.program.h2", "Структура курсу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000418"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.eyebrow", "Для кого" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000419"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.eyebrow", "For whom" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000420"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.eyebrow", "Для кого" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000421"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.h2", "Кому подойдёт" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000422"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.h2", "Who is it for" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000423"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.forwhom.h2", "Кому підійде" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000424"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.eyebrow", "Следующий шаг" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000425"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.eyebrow", "Next step" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000426"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.eyebrow", "Наступний крок" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000427"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.h2", "Готовы начать путь?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000428"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.h2", "Ready to begin?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000429"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.h2", "Готові розпочати шлях?" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000430"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.text", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000431"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.text", "Submit a request — we'll reply within the day with details on the next intake." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000432"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.text", "Залиште заявку — ми відповімо протягом дня." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000433"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.btn", "Хочу записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000434"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.btn", "I want to sign up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000435"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.cta.btn", "Хочу записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000436"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.back_to_list", "← Назад к списку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000437"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.back_to_list", "← Back to list" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000438"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "section.back_to_list", "← Назад до списку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000439"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.eyebrow", "Направления обучения" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000440"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.eyebrow", "Learning directions" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000441"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.eyebrow", "Напрями навчання" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000442"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h2", "Выберите свой путь" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000443"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h2", "Choose your path" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000444"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.h2", "Оберіть свій шлях" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000445"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.intro", "Три авторские программы — от дыхания до глубинной трансформации." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000446"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.intro", "Three proprietary programmes — from breathwork to deep transformation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000447"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.intro", "Три авторські програми — від дихання до глибинної трансформації." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000448"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.eyebrow", "Дыхательные практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000449"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.eyebrow", "Breathing practices" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000450"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.eyebrow", "Дихальні практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000451"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.tagline", "Сила вдоха — сила жизни" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000452"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.tagline", "The power of breath — the power of life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000453"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.tagline", "Сила вдиху — сила життя" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000454"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.text", "Научитесь управлять дыханием и откройте новые горизонты сознания." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000455"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.text", "Learn to harness your breath and unlock new horizons of consciousness." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000456"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.pranayama.text", "Навчіться управляти диханням та відкрийте нові горизонти свідомості." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000457"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.eyebrow", "Медитативные практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000458"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.eyebrow", "Meditative practices" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000459"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.eyebrow", "Медитативні практики" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000460"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.tagline", "Тишина как инструмент" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000461"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.tagline", "Silence as a tool" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000462"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.tagline", "Тиша як інструмент" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000463"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.text", "Освойте техники медитации и найдите покой в любой ситуации." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000464"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.text", "Master meditation techniques and find stillness in any situation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000465"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.meditation.text", "Опануйте техніки медитації та знайдіть спокій у будь-якій ситуації." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000466"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.eyebrow", "Йога-практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000467"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.eyebrow", "Yoga practice" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000468"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.eyebrow", "Йога-практика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000469"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.tagline", "Тело как отражение духа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000470"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.tagline", "Body as a reflection of spirit" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000471"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.tagline", "Тіло як відображення духу" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000472"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.text", "Комплексная практика асан, пранаямы и медитации для целостной трансформации." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000473"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.text", "A complete practice of asanas, pranayama and meditation for holistic transformation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000474"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.yoga.text", "Комплексна практика асан, пранаями та медитації для цілісної трансформації." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000475"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.cta", "Подробнее →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000476"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.cta", "Learn more →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000477"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.courses.card.cta", "Детальніше →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000478"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.eyebrow", "Индивидуальная работа" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000479"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.eyebrow", "Individual work" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000480"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.eyebrow", "Індивідуальна робота" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000481"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h2", "Личное сопровождение" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000482"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h2", "Personal guidance" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000483"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.h2", "Особистий супровід" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000484"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.intro", "Три направления персональных консультаций с нашими специалистами." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000485"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.intro", "Three areas of personal consultations with our specialists." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000486"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.intro", "Три напрями персональних консультацій з нашими фахівцями." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000487"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.eyebrow", "Работа с энергией" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000488"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.eyebrow", "Energy work" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000489"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.eyebrow", "Робота з енергією" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000490"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.tagline", "Восстановить баланс сил" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000491"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.tagline", "Restore the balance of energies" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000492"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.tagline", "Відновити баланс сил" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000493"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.text", "Диагностика и балансировка энергетических центров через пранаяму и медитацию." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000494"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.text", "Diagnosis and balancing of energy centres through pranayama and meditation." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000495"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.energy.text", "Діагностика та балансування енергетичних центрів через пранаяму та медитацію." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000496"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.eyebrow", "Аюрведическая диагностика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000497"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.eyebrow", "Ayurvedic diagnosis" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000498"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.eyebrow", "Аюрведична діагностика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000499"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.tagline", "Природная мудрость здоровья" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000500"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.tagline", "Natural wisdom of health" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000501"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.tagline", "Природна мудрість здоров'я" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000502"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.text", "Определение вашего доши-типа и составление персональных рекомендаций." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000503"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.text", "Determine your dosha type and receive personalised recommendations." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000504"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.ayurveda.text", "Визначення вашого типу доші та складання персональних рекомендацій." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000505"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.eyebrow", "Духовное развитие" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000506"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.eyebrow", "Spiritual development" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000507"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.eyebrow", "Духовний розвиток" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000508"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.tagline", "Путь к истинному себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000509"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.tagline", "Path to the true self" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000510"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.tagline", "Шлях до справжнього себе" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000511"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.text", "Индивидуальная работа с убеждениями, страхами и духовными вопросами." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000512"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.text", "Individual work with beliefs, fears and spiritual questions." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000513"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.spirituality.text", "Індивідуальна робота з переконаннями, страхами та духовними питаннями." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000514"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.cta", "Записаться →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000515"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.cta", "Book →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000516"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.consultations.card.cta", "Записатися →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000517"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.eyebrow", "Мы — Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000518"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.eyebrow", "We are Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000519"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.eyebrow", "Ми — Yoga.Life" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000520"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.h2", "Три пути — одна миссия" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000521"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.h2", "Three paths — one mission" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000522"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.founders.h2", "Три шляхи — одна місія" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000523"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.philosophy.eyebrow", "Принципы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000524"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.philosophy.eyebrow", "Principles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000525"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.philosophy.eyebrow", "Принципи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000526"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.philosophy.h2", "Философия проекта" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000527"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.philosophy.h2", "Project philosophy" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000528"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.about.philosophy.h2", "Філософія проекту" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000529"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.eyebrow", "Всегда на связи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000530"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.eyebrow", "Always in touch" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000531"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.eyebrow", "Завжди на зв'язку" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000532"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.info.h2", "Давайте познакомимся" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000533"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.info.h2", "Let's connect" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000534"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.info.h2", "Давайте познайомимось" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000535"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.social.eyebrow", "Социальные сети" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000536"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.social.eyebrow", "Social media" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000537"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.social.eyebrow", "Соціальні мережі" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000538"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.social.h2", "Присоединяйтесь к нам" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000539"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.social.h2", "Join us online" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000540"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.contacts.social.h2", "Приєднуйтесь до нас" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000541"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.eyebrow", "Ближайшие программы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000542"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.eyebrow", "Upcoming programmes" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000543"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.eyebrow", "Найближчі програми" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000544"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.intro", "Открытые ретриты, на которые сейчас можно записаться." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000545"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.intro", "Open retreats you can register for right now." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000546"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.actual.intro", "Відкриті ретрити, на які зараз можна записатись." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000547"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.intro", "Предстоящие ретриты — запишитесь заранее и получите лучшие условия." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000548"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.intro", "Upcoming retreats — register early for the best terms." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000549"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.upcoming.intro", "Майбутні ретрити — запишіться заздалегідь для найкращих умов." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000550"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.intro", "История наших программ. Каждый ретрит — это особенная история." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000551"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.intro", "A record of our past programmes. Each retreat is a unique story." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000552"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.past.intro", "Історія наших програм. Кожен ретрит — це особлива історія." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000553"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.location", "Местоположение" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000554"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.location", "Location" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000555"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.location", "Місцезнаходження" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000556"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.dates", "Даты" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000557"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.dates", "Dates" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000558"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.dates", "Дати" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000559"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.cta", "Записаться" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000560"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.cta", "Sign up" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000561"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.card.cta", "Записатися" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000562"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.empty", "Ретриты не найдены." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000563"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.empty", "No retreats found." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000564"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.retreats.empty", "Ретрити не знайдено." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000565"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.eyebrow", "Знания и вдохновение" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000566"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.eyebrow", "Knowledge and inspiration" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000567"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.eyebrow", "Знання та натхнення" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000568"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h2", "Исследуйте темы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000569"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h2", "Explore topics" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000570"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.h2", "Досліджуйте теми" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000571"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.eyebrow", "Авторские статьи" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000572"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.eyebrow", "Articles" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000573"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.eyebrow", "Авторські статті" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000574"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.intro", "Глубокие материалы о практике, философии и образе жизни." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000575"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.intro", "In-depth material on practice, philosophy and lifestyle." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000576"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.articles.intro", "Глибокі матеріали про практику, філософію та спосіб життя." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000577"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.eyebrow", "Видеоматериалы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000578"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.eyebrow", "Video content" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000579"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.eyebrow", "Відеоматеріали" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000580"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.intro", "Практические уроки и вдохновляющие записи с наших ретритов." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000581"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.intro", "Practical lessons and inspiring recordings from our retreats." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000582"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.videos.intro", "Практичні уроки та надихаючі записи з наших ретритів." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000583"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.eyebrow", "Галерея" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000584"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.eyebrow", "Gallery" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000585"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.eyebrow", "Галерея" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000586"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.intro", "Моменты из жизни нашего сообщества." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000587"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.intro", "Moments from the life of our community." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000588"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.photos.intro", "Моменти з життя нашої спільноти." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000589"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.readmore", "Читать →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000590"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.readmore", "Read →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000591"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.readmore", "Читати →" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000592"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.empty", "Публикации пока не добавлены." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000593"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.empty", "No posts have been added yet." });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000594"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "page.blog.empty", "Публікації ще не додані." });
        }
    }
}
