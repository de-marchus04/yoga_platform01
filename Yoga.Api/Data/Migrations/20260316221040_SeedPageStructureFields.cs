using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPageStructureFields : Migration
    {
        private static readonly Guid PageAbout    = new("44444444-4444-4444-4444-444444444401");
        private static readonly Guid PageContacts = new("44444444-4444-4444-4444-444444444402");

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$WYfVNHALKATmgNSgBkBzvOeubWRjeyc0P/m4miaB4MyMbLAF7t/pK");

            // ── About page structured fields ───────────────────────────────────
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("ee000000-0000-0000-0000-000000000001"), PageAbout, "SitePage", "HeroImageUrl",    "ru", "https://images.unsplash.com/photo-1506126613408-eca07ce68773?auto=format&fit=crop&w=1600&q=80" },
                    { new Guid("ee000000-0000-0000-0000-000000000002"), PageAbout, "SitePage", "Founder1Name",    "ru", "Ольга Шалетина" },
                    { new Guid("ee000000-0000-0000-0000-000000000003"), PageAbout, "SitePage", "Founder1Role",    "ru", "Автор методик · Инструктор · 15+ лет практики" },
                    { new Guid("ee000000-0000-0000-0000-000000000004"), PageAbout, "SitePage", "Founder1Text1",   "ru", "Ольга начала путь йоги в 20 лет — и с тех пор не останавливалась. За 15+ лет практики и преподавания она разработала авторские программы оздоровления через дыхание, которые прошли более 300 студентов." },
                    { new Guid("ee000000-0000-0000-0000-000000000005"), PageAbout, "SitePage", "Founder1Text2",   "ru", "Специализация — пранаяма, йога-нидра и работа с хроническим стрессом. Её классы сочетают строгость традиции с теплотой живого присутствия." },
                    { new Guid("ee000000-0000-0000-0000-000000000006"), PageAbout, "SitePage", "Founder1ImageUrl","ru", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=600&q=80" },
                    { new Guid("ee000000-0000-0000-0000-000000000007"), PageAbout, "SitePage", "Founder2Name",    "ru", "Александр Украинцев" },
                    { new Guid("ee000000-0000-0000-0000-000000000008"), PageAbout, "SitePage", "Founder2Role",    "ru", "Учитель · Духовный наставник · 25+ лет опыта" },
                    { new Guid("ee000000-0000-0000-0000-000000000009"), PageAbout, "SitePage", "Founder2Text1",   "ru", "Александр изучает йогу и ведическую философию более 25 лет. Он провёл свыше 40 ретритов в России, Европе и Азии, а его наставничество глубоко уходит корнями в традицию крийя-йоги." },
                    { new Guid("ee000000-0000-0000-0000-000000000010"), PageAbout, "SitePage", "Founder2Text2",   "ru", "Его подход — не набор техник, а целостный путь: от физического тела к самому тонкому. Каждый ретрит под его руководством становится точкой отсчёта новой жизни." },
                    { new Guid("ee000000-0000-0000-0000-000000000011"), PageAbout, "SitePage", "Founder2ImageUrl","ru", "https://images.unsplash.com/photo-1566753323558-f4e0952af115?auto=format&fit=crop&w=600&q=80" },
                    { new Guid("ee000000-0000-0000-0000-000000000012"), PageAbout, "SitePage", "Founder3Name",    "ru", "Дмитрий Державин" },
                    { new Guid("ee000000-0000-0000-0000-000000000013"), PageAbout, "SitePage", "Founder3Role",    "ru", "Создатель платформы · Разработчик" },
                    { new Guid("ee000000-0000-0000-0000-000000000014"), PageAbout, "SitePage", "Founder3Text1",   "ru", "Дмитрий создал технологическую основу Yoga.Life Enterprise — систему, которая объединяет учителей и студентов со всего мира в единое пространство практики и роста." },
                    { new Guid("ee000000-0000-0000-0000-000000000015"), PageAbout, "SitePage", "Founder3Text2",   "ru", "Его видение: технологии должны служить духовному развитию, а не отвлекать от него. Платформа строится на принципах простоты, красоты и функциональности." },
                    { new Guid("ee000000-0000-0000-0000-000000000016"), PageAbout, "SitePage", "Founder3ImageUrl","ru", "https://images.unsplash.com/photo-1519085360753-af0119f7cbe7?auto=format&fit=crop&w=600&q=80" },
                    { new Guid("ee000000-0000-0000-0000-000000000017"), PageAbout, "SitePage", "Phil1Title",      "ru", "Присутствие" },
                    { new Guid("ee000000-0000-0000-0000-000000000018"), PageAbout, "SitePage", "Phil1Text",       "ru", "Каждая практика начинается с момента здесь и сейчас. Мы создаём пространство, где тело и ум обретают покой." },
                    { new Guid("ee000000-0000-0000-0000-000000000019"), PageAbout, "SitePage", "Phil2Title",      "ru", "Традиция" },
                    { new Guid("ee000000-0000-0000-0000-000000000020"), PageAbout, "SitePage", "Phil2Text",       "ru", "Наши методики уходят корнями в многовековые практики йоги, аюрведы и ведической философии." },
                    { new Guid("ee000000-0000-0000-0000-000000000021"), PageAbout, "SitePage", "Phil3Title",      "ru", "Трансформация" },
                    { new Guid("ee000000-0000-0000-0000-000000000022"), PageAbout, "SitePage", "Phil3Text",       "ru", "Мы не просто учим асанам — мы помогаем переосмыслить жизнь через осознанное движение, дыхание и тишину." },
                    { new Guid("ee000000-0000-0000-0000-000000000023"), PageAbout, "SitePage", "MetaTitle",       "ru", "О нас — Yoga.Life Enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000024"), PageAbout, "SitePage", "MetaDescription", "ru", "Познакомьтесь с основателями и философией Yoga.Life Enterprise" },
                    // ── Contacts page structured fields ───────────────────────
                    { new Guid("ee000000-0000-0000-0000-000000000025"), PageContacts, "SitePage", "TelegramUrl",     "ru", "https://t.me/yogalife_enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000026"), PageContacts, "SitePage", "TelegramHandle",  "ru", "@yogalife_enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000027"), PageContacts, "SitePage", "TelegramDesc",    "ru", "Самый быстрый способ связаться с нами. Отвечаем в течение часа." },
                    { new Guid("ee000000-0000-0000-0000-000000000028"), PageContacts, "SitePage", "WhatsAppUrl",     "ru", "https://wa.me/79000000000" },
                    { new Guid("ee000000-0000-0000-0000-000000000029"), PageContacts, "SitePage", "WhatsAppPhone",   "ru", "+7 (900) 000-00-00" },
                    { new Guid("ee000000-0000-0000-0000-000000000030"), PageContacts, "SitePage", "WhatsAppDesc",    "ru", "Голосовые и текстовые сообщения. Удобно для развёрнутых вопросов." },
                    { new Guid("ee000000-0000-0000-0000-000000000031"), PageContacts, "SitePage", "InstagramUrl",    "ru", "https://instagram.com/yogalife_enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000032"), PageContacts, "SitePage", "InstagramHandle", "ru", "@yogalife_enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000033"), PageContacts, "SitePage", "InstagramDesc",   "ru", "Следите за нашими практиками, ретритами и вдохновляющим контентом." },
                    { new Guid("ee000000-0000-0000-0000-000000000034"), PageContacts, "SitePage", "YouTubeUrl",      "ru", "https://youtube.com/@yogalife_enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000035"), PageContacts, "SitePage", "YouTubeHandle",   "ru", "@yogalife_enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000036"), PageContacts, "SitePage", "MetaTitle",       "ru", "Контакты — Yoga.Life Enterprise" },
                    { new Guid("ee000000-0000-0000-0000-000000000037"), PageContacts, "SitePage", "MetaDescription", "ru", "Свяжитесь с нами через Telegram, WhatsApp, Instagram или YouTube" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 37; i++)
                migrationBuilder.DeleteData(
                    table: "Translations",
                    keyColumn: "Id",
                    keyValue: new Guid($"ee000000-0000-0000-0000-{i:D12}"));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$TWHj6xcZn/mQzlCWOyEZrekpKR6Hnx.vBj/ZNdsa7YfIsV1l3WfNy");
        }
    }
}
