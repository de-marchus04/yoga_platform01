using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialVitrina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsOnline = table.Column<bool>(type: "boolean", nullable: false),
                    IsOffline = table.Column<bool>(type: "boolean", nullable: false)
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
                    Slug = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsOnline = table.Column<bool>(type: "boolean", nullable: false),
                    IsOffline = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContactDetails = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Messager = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: true),
                    ConsultationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TargetFormat = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SitePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
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
                    EntityType = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Field = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Language = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
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
                    Key = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Language = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CourseLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseModuleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseLessons_CourseModules_CourseModuleId",
                        column: x => x.CourseModuleId,
                        principalTable: "CourseModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "IsActive", "IsOffline", "IsOnline", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333301"), true, true, true, "spiritual-development", 1 },
                    { new Guid("33333333-3333-3333-3333-333333333302"), true, true, true, "youth", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333303"), true, true, true, "personal", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsActive", "IsOffline", "IsOnline", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), true, true, true, "pranavidya", 1 },
                    { new Guid("22222222-2222-2222-2222-222222222202"), true, true, true, "meditation", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222203"), true, true, true, "yoga", 3 }
                });

            migrationBuilder.InsertData(
                table: "SitePages",
                columns: new[] { "Id", "Slug" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444401"), "about" },
                    { new Guid("44444444-4444-4444-4444-444444444402"), "contacts" },
                    { new Guid("44444444-4444-4444-4444-444444444403"), "home" },
                    { new Guid("44444444-4444-4444-4444-444444444404"), "courses" },
                    { new Guid("44444444-4444-4444-4444-444444444405"), "consultations" }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000001"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Title", "ru", "Пранавидья" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000002"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Title", "en", "Pranavidya" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000003"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Title", "uk", "Пранавід'я" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000004"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Subtitle", "ru", "Дыхание как опора практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000005"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Subtitle", "en", "Breath as the foundation of practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000006"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Subtitle", "uk", "Дихання як опора практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000007"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Eyebrow", "ru", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000008"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Eyebrow", "en", "Course" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000009"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Eyebrow", "uk", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000010"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Description", "ru", "Системная работа с пранаямой: от базовых техник до устойчивой самопрактики." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000011"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Description", "en", "Structured pranayama work: from foundational techniques to a steady self-practice." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000012"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Description", "uk", "Системна робота з пранаямою: від базових технік до стійкої самопрактики." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000013"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Benefits", "ru", "Спокойнее нервная система|Больше энергии днём|Улучшенный сон" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000014"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Benefits", "en", "A calmer nervous system|More daytime energy|Better sleep" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000015"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Benefits", "uk", "Спокійніша нервова система|Більше енергії вдень|Кращий сон" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000016"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ImageUrl", "ru", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000017"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ImageUrl", "en", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000018"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ImageUrl", "uk", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000019"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Duration", "ru", "8 недель" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000020"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Duration", "en", "8 weeks" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000021"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Duration", "uk", "8 тижнів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000022"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Level", "ru", "От новичка до уверенной практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000023"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Level", "en", "From beginner to confident practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000024"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Level", "uk", "Від новачка до впевненої практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000025"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Format", "ru", "Онлайн и офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000026"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Format", "en", "Online and in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000027"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Format", "uk", "Онлайн і офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000028"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Schedule", "ru", "2 занятия в неделю + самостоятельная практика" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000029"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Schedule", "en", "Two sessions per week + self-practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000030"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Schedule", "uk", "2 заняття на тиждень + самостійна практика" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000031"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ForWhom", "ru", "Новичкам~Безопасный вход в практику|Практикующим~Углубление и стабилизация дыхания" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000032"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ForWhom", "en", "Beginners~A safe entry into practice|Experienced practitioners~Deepening and stabilising the breath" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000033"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ForWhom", "uk", "Новачкам~Безпечний вхід у практику|Практикуючим~Поглиблення та стабілізація дихання" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000034"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaHeading", "ru", "Начать с пранаямы" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000035"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaHeading", "en", "Start with pranayama" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000036"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaHeading", "uk", "Почати з пранаями" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000037"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaText", "ru", "Оставьте заявку — подберём формат и ответим на вопросы." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000038"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaText", "en", "Leave a request — we'll suggest a format and answer your questions." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000039"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaText", "uk", "Залиште заявку — підберемо формат і відповімо на питання." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000040"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Title", "ru", "Медитация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000041"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Title", "en", "Meditation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000042"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Title", "uk", "Медитація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000043"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Subtitle", "ru", "Тишина, устойчивость, ясность" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000044"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Subtitle", "en", "Stillness, stability, clarity" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000045"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Subtitle", "uk", "Тиша, стійкість, ясність" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000046"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Eyebrow", "ru", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000047"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Eyebrow", "en", "Course" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000048"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Eyebrow", "uk", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000049"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Description", "ru", "Пошаговое освоение медитативных техник для повседневной жизни." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000050"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Description", "en", "Step-by-step meditation skills for everyday life." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000051"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Description", "uk", "Покрокове освоєння медитативних технік для повсякденного життя." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000052"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Benefits", "ru", "Меньше реактивности|Больше присутствия|Ясность решений" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000053"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Benefits", "en", "Less reactivity|More presence|Clearer decisions" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000054"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Benefits", "uk", "Менше реактивності|Більше присутності|Ясність рішень" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000055"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ImageUrl", "ru", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000056"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ImageUrl", "en", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000057"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ImageUrl", "uk", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000058"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Duration", "ru", "6 недель" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000059"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Duration", "en", "6 weeks" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000060"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Duration", "uk", "6 тижнів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000061"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Level", "ru", "Подходит любому уровню" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000062"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Level", "en", "All levels welcome" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000063"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Level", "uk", "Підходить будь-якому рівню" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000064"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Format", "ru", "Онлайн и офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000065"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Format", "en", "Online and in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000066"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Format", "uk", "Онлайн і офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000067"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Schedule", "ru", "Еженедельные встречи и короткие ежедневные практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000068"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Schedule", "en", "Weekly meetings and short daily practices" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000069"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Schedule", "uk", "Щотижневі зустрічі та короткі щоденні практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000070"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ForWhom", "ru", "Занятым людям~Короткие практики встроены в день|Искателям глубины~Разбор опыта с куратором" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000071"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ForWhom", "en", "Busy people~Short practices that fit the day|Seekers of depth~Guided reflection with a mentor" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000072"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ForWhom", "uk", "Зайнятим людям~Короткі практики вбудовані в день|Шукачам глибини~Розбір досвіду з куратором" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000073"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaHeading", "ru", "Попробовать медитацию" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000074"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaHeading", "en", "Try meditation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000075"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaHeading", "uk", "Спробувати медитацію" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000076"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaText", "ru", "Расскажем, с чего начать именно вам." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000077"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaText", "en", "We'll suggest where to start for you." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000078"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaText", "uk", "Розповімо, з чого почати саме вам." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000079"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Title", "ru", "Йога" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000080"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Title", "en", "Yoga" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000081"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Title", "uk", "Йога" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000082"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Subtitle", "ru", "Тело, дыхание, внимание" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000083"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Subtitle", "en", "Body, breath, attention" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000084"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Subtitle", "uk", "Тіло, дихання, увага" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000085"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Eyebrow", "ru", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000086"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Eyebrow", "en", "Course" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000087"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Eyebrow", "uk", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000088"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Description", "ru", "Комплексная практика: асаны, пранаяма и элементы медитации." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000089"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Description", "en", "A complete practice: asana, pranayama and elements of meditation." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000090"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Description", "uk", "Комплексна практика: асани, пранаяма та елементи медитації." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000091"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Benefits", "ru", "Сила и гибкость|Ровное дыхание|Больше осознанности" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000092"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Benefits", "en", "Strength and flexibility|Steady breath|More mindfulness" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000093"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Benefits", "uk", "Сила та гнучкість|Рівне дихання|Більше усвідомленості" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000094"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ImageUrl", "ru", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000095"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ImageUrl", "en", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000096"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ImageUrl", "uk", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000097"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Duration", "ru", "10 недель" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000098"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Duration", "en", "10 weeks" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000099"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Duration", "uk", "10 тижнів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000100"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Level", "ru", "От основ к цельной практике" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000101"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Level", "en", "From foundations to an integrated practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000102"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Level", "uk", "Від основ до цілісної практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000103"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Format", "ru", "Онлайн и офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000104"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Format", "en", "Online and in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000105"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Format", "uk", "Онлайн і офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000106"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Schedule", "ru", "2 практики в неделю" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000107"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Schedule", "en", "Two practices per week" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000108"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Schedule", "uk", "2 практики на тиждень" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000109"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ForWhom", "ru", "Новичкам~Безопасный старт|Опытным~Тонкая настройка практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000110"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ForWhom", "en", "Beginners~A safe start|Experienced~Fine-tuning your practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000111"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ForWhom", "uk", "Новачкам~Безпечний старт|Досвідченим~Тонке налаштування практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000112"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaHeading", "ru", "Погрузиться в йогу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000113"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaHeading", "en", "Dive into yoga" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000114"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaHeading", "uk", "Зануритися в йогу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000115"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaText", "ru", "Подберём интенсивность и формат под ваш запрос." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000116"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaText", "en", "We'll match intensity and format to your goals." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000117"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaText", "uk", "Підберемо інтенсивність і формат під ваш запит." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000118"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Title", "ru", "Духовное развитие" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000119"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Title", "en", "Spiritual development" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000120"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Title", "uk", "Духовний розвиток" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000121"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Subtitle", "ru", "Опора, ясность, личный ритм" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000122"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Subtitle", "en", "Support, clarity, your own pace" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000123"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Subtitle", "uk", "Опора, ясність, особистий ритм" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000124"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Eyebrow", "ru", "Консультация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000125"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Eyebrow", "en", "Consultation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000126"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Eyebrow", "uk", "Консультація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000127"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Description", "ru", "Индивидуальная работа с вопросами смысла, ценностей и внутреннего роста." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000128"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Description", "en", "One-to-one work on meaning, values and inner growth." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000129"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Description", "uk", "Індивідуальна робота з питаннями сенсу, цінностей та внутрішнього росту." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000130"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Quote", "ru", "«Место, где можно говорить честно — без оценки и спешки.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000131"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Quote", "en", "«A space to speak honestly — without judgement or rush.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000132"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Quote", "uk", "«Місце, де можна говорити чесно — без оцінки та поспіху.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000133"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Benefits", "ru", "Ясность направления|Опора в сложные периоды|Интеграция практики в жизнь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000134"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Benefits", "en", "Clarity of direction|Support in difficult periods|Integrating practice into life" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000135"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Benefits", "uk", "Ясність напрямку|Опора у складні періоди|Інтеграція практики в життя" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000136"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ImageUrl", "ru", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000137"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ImageUrl", "en", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000138"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ImageUrl", "uk", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000139"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Duration", "ru", "60–90 минут" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000140"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Duration", "en", "60–90 minutes" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000141"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Duration", "uk", "60–90 хвилин" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000142"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Format", "ru", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000143"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Format", "en", "Online / in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000144"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Format", "uk", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000145"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "LanguageOffered", "ru", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000146"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "LanguageOffered", "en", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000147"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "LanguageOffered", "uk", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000148"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000149"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000150"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000151"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ForWhom", "ru", "В переломные моменты~Нужен взгляд со стороны|Ищущим глубину~Связать практику и жизнь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000152"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ForWhom", "en", "At turning points~An outside perspective|Seeking depth~Connecting practice and life" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000153"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ForWhom", "uk", "У переломні моменти~Потрібен погляд збоку|Шукачам глибини~Зв'язати практику і життя" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000154"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaHeading", "ru", "Записаться на сессию" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000155"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaHeading", "en", "Book a session" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000156"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaHeading", "uk", "Записатися на сесію" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000157"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaText", "ru", "Оставьте контакты — предложим время и формат." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000158"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaText", "en", "Leave your contacts — we'll suggest time and format." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000159"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaText", "uk", "Залиште контакти — запропонуємо час і формат." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000160"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Title", "ru", "Для подростков" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000161"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Title", "en", "For teenagers" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000162"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Title", "uk", "Для підлітків" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000163"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Subtitle", "ru", "Опора, границы, уважение к росту" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000164"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Subtitle", "en", "Support, boundaries, respect for growth" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000165"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Subtitle", "uk", "Опора, межі, повага до зростання" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000166"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Eyebrow", "ru", "Консультация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000167"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Eyebrow", "en", "Consultation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000168"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Eyebrow", "uk", "Консультація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000169"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Description", "ru", "Бережный формат разговора о телесных, эмоциональных и социальных темах." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000170"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Description", "en", "A careful conversation about body, emotions and social life." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000171"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Description", "uk", "Обережний формат розмови про тілесні, емоційні та соціальні теми." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000172"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Quote", "ru", "«Подростку нужен взрослый, который слышит, а не оценивает.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000173"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Quote", "en", "«Teenagers need adults who listen, not judge.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000174"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Quote", "uk", "«Підлітку потрібен дорослий, який чує, а не оцінює.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000175"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Benefits", "ru", "Безопасное пространство|Язык, понятный подростку|Совместные шаги с семьёй при необходимости" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000176"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Benefits", "en", "A safe space|Language that fits teens|Family steps when needed" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000177"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Benefits", "uk", "Безпечний простір|Мова, зрозуміла підлітку|Спільні кроки з родиною за потреби" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000178"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ImageUrl", "ru", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000179"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ImageUrl", "en", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000180"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ImageUrl", "uk", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000181"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Duration", "ru", "50–60 минут" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000182"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Duration", "en", "50–60 minutes" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000183"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Duration", "uk", "50–60 хвилин" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000184"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Format", "ru", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000185"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Format", "en", "Online / in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000186"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Format", "uk", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000187"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "LanguageOffered", "ru", "RU / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000188"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "LanguageOffered", "en", "RU / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000189"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "LanguageOffered", "uk", "RU / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000190"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000191"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000192"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000193"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ForWhom", "ru", "Подросткам 12–17~И их родителям при согласии" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000194"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ForWhom", "en", "Teens 12–17~And their parents when agreed" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000195"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ForWhom", "uk", "Підліткам 12–17~І їхнім батькам за згодою" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000196"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaHeading", "ru", "Записаться" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000197"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaHeading", "en", "Book" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000198"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaHeading", "uk", "Записатися" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000199"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaText", "ru", "Коротко опишите запрос — подскажем следующий шаг." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000200"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaText", "en", "Briefly describe your request — we'll suggest the next step." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000201"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaText", "uk", "Коротко опишіть запит — підкажемо наступний крок." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000202"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Title", "ru", "Личные вопросы" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000203"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Title", "en", "Personal questions" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000204"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Title", "uk", "Особисті питання" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000205"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Subtitle", "ru", "Конфиденциально и по делу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000206"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Subtitle", "en", "Confidential and practical" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000207"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Subtitle", "uk", "Конфіденційно і по суті" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000208"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Eyebrow", "ru", "Консультация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000209"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Eyebrow", "en", "Consultation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000210"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Eyebrow", "uk", "Консультація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000211"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Description", "ru", "Разбор личной ситуации: отношения, решения, нагрузка, поиск баланса." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000212"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Description", "en", "Working through a personal situation: relationships, decisions, load, balance." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000213"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Description", "uk", "Розбір особистої ситуації: стосунки, рішення, навантаження, баланс." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000214"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Quote", "ru", "«Иногда нужен час, чтобы разложить всё по полочкам.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000215"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Quote", "en", "«Sometimes you need an hour to sort things out.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000216"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Quote", "uk", "«Іноді потрібна година, щоб розкласти все по поличках.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000217"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Benefits", "ru", "Структура вопроса|Варианты шагов|Поддержка после сессии" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000218"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Benefits", "en", "A clearer question|Options for next steps|Follow-up support" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000219"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Benefits", "uk", "Структура питання|Варіанти кроків|Підтримка після сесії" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000220"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ImageUrl", "ru", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000221"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ImageUrl", "en", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000222"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ImageUrl", "uk", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000223"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Duration", "ru", "60 минут" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000224"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Duration", "en", "60 minutes" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000225"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Duration", "uk", "60 хвилин" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000226"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Format", "ru", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000227"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Format", "en", "Online / in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000228"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Format", "uk", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000229"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "LanguageOffered", "ru", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000230"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "LanguageOffered", "en", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000231"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "LanguageOffered", "uk", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000232"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000233"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000234"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000235"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ForWhom", "ru", "Сложный выбор~Разобрать варианты|Усталость и перегруз~Найти опору" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000236"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ForWhom", "en", "Hard choices~Sorting options|Fatigue and overload~Finding footing" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000237"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ForWhom", "uk", "Складний вибір~Розібрати варіанти|Втома та перевантаження~Знайти опору" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000238"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaHeading", "ru", "Записаться" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000239"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaHeading", "en", "Book" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000240"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaHeading", "uk", "Записатися" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000241"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaText", "ru", "Напишите, что хотите разобрать — ответим с вариантами времени." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000242"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaText", "en", "Tell us what you'd like to unpack — we'll reply with time options." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000243"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaText", "uk", "Напишіть, що хочете розібрати — відповімо з варіантами часу." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_Slug",
                table: "Consultations",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_CourseModuleId",
                table: "CourseLessons",
                column: "CourseModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_CourseId",
                table: "CourseModules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Slug",
                table: "Courses",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SitePages_Slug",
                table: "SitePages",
                column: "Slug",
                unique: true);

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
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "CourseLessons");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "SitePages");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "UiTranslations");

            migrationBuilder.DropTable(
                name: "CourseModules");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
