using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInnerPageTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$CdbcoRNcyyUQ7a4w66mmV.RASPBRAqKooB4CP3p/aT6wqEngUf.Y.");

            migrationBuilder.InsertData(
                table: "UiTranslations",
                columns: new[] { "Id", "Key", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000370"), "form.heading", "ru", "Записаться" },
                    { new Guid("b0000000-0000-0000-0000-000000000371"), "form.heading", "en", "Sign Up" },
                    { new Guid("b0000000-0000-0000-0000-000000000372"), "form.heading", "uk", "Записатися" },
                    { new Guid("b0000000-0000-0000-0000-000000000373"), "form.subtext", "ru", "Оставьте свои контакты, и мы свяжемся с вами для уточнения деталей." },
                    { new Guid("b0000000-0000-0000-0000-000000000374"), "form.subtext", "en", "Leave your details and we'll be in touch to confirm." },
                    { new Guid("b0000000-0000-0000-0000-000000000375"), "form.subtext", "uk", "Залиште контакти — ми зв'яжемось для уточнення деталей." },
                    { new Guid("b0000000-0000-0000-0000-000000000376"), "form.context_prefix", "ru", "Запись на" },
                    { new Guid("b0000000-0000-0000-0000-000000000377"), "form.context_prefix", "en", "Sign up for" },
                    { new Guid("b0000000-0000-0000-0000-000000000378"), "form.context_prefix", "uk", "Запис на" },
                    { new Guid("b0000000-0000-0000-0000-000000000379"), "form.name", "ru", "Ваше имя" },
                    { new Guid("b0000000-0000-0000-0000-000000000380"), "form.name", "en", "Your name" },
                    { new Guid("b0000000-0000-0000-0000-000000000381"), "form.name", "uk", "Ваше ім'я" },
                    { new Guid("b0000000-0000-0000-0000-000000000382"), "form.messenger", "ru", "В каком мессенджере связаться?" },
                    { new Guid("b0000000-0000-0000-0000-000000000383"), "form.messenger", "en", "Preferred messenger" },
                    { new Guid("b0000000-0000-0000-0000-000000000384"), "form.messenger", "uk", "Месенджер для зв'язку" },
                    { new Guid("b0000000-0000-0000-0000-000000000385"), "form.phone_call", "ru", "Звонок" },
                    { new Guid("b0000000-0000-0000-0000-000000000386"), "form.phone_call", "en", "Phone call" },
                    { new Guid("b0000000-0000-0000-0000-000000000387"), "form.phone_call", "uk", "Дзвінок" },
                    { new Guid("b0000000-0000-0000-0000-000000000388"), "form.contact", "ru", "Номер телефона или Никнейм" },
                    { new Guid("b0000000-0000-0000-0000-000000000389"), "form.contact", "en", "Phone number or username" },
                    { new Guid("b0000000-0000-0000-0000-000000000390"), "form.contact", "uk", "Номер телефону або нікнейм" },
                    { new Guid("b0000000-0000-0000-0000-000000000391"), "form.comment", "ru", "Комментарий (пожелания, вопросы)" },
                    { new Guid("b0000000-0000-0000-0000-000000000392"), "form.comment", "en", "Comment (wishes, questions)" },
                    { new Guid("b0000000-0000-0000-0000-000000000393"), "form.comment", "uk", "Коментар (побажання, питання)" },
                    { new Guid("b0000000-0000-0000-0000-000000000394"), "form.submit", "ru", "Оставить заявку" },
                    { new Guid("b0000000-0000-0000-0000-000000000395"), "form.submit", "en", "Submit request" },
                    { new Guid("b0000000-0000-0000-0000-000000000396"), "form.submit", "uk", "Залишити заявку" },
                    { new Guid("b0000000-0000-0000-0000-000000000397"), "form.submitting", "ru", "Отправляем..." },
                    { new Guid("b0000000-0000-0000-0000-000000000398"), "form.submitting", "en", "Sending..." },
                    { new Guid("b0000000-0000-0000-0000-000000000399"), "form.submitting", "uk", "Надсилаємо..." },
                    { new Guid("b0000000-0000-0000-0000-000000000400"), "form.success", "ru", "Спасибо! Ваша заявка успешно отправлена. Мы скоро свяжемся с вами." },
                    { new Guid("b0000000-0000-0000-0000-000000000401"), "form.success", "en", "Thank you! Your request has been sent. We'll be in touch soon." },
                    { new Guid("b0000000-0000-0000-0000-000000000402"), "form.success", "uk", "Дякуємо! Вашу заявку надіслано. Ми скоро зв'яжемось." },
                    { new Guid("b0000000-0000-0000-0000-000000000403"), "section.overview.eyebrow", "ru", "О программе" },
                    { new Guid("b0000000-0000-0000-0000-000000000404"), "section.overview.eyebrow", "en", "About the programme" },
                    { new Guid("b0000000-0000-0000-0000-000000000405"), "section.overview.eyebrow", "uk", "Про програму" },
                    { new Guid("b0000000-0000-0000-0000-000000000406"), "section.overview.h2", "ru", "Что вас ждёт" },
                    { new Guid("b0000000-0000-0000-0000-000000000407"), "section.overview.h2", "en", "What awaits you" },
                    { new Guid("b0000000-0000-0000-0000-000000000408"), "section.overview.h2", "uk", "Що на вас чекає" },
                    { new Guid("b0000000-0000-0000-0000-000000000409"), "section.benefits.h4", "ru", "Что вы получите" },
                    { new Guid("b0000000-0000-0000-0000-000000000410"), "section.benefits.h4", "en", "What you'll gain" },
                    { new Guid("b0000000-0000-0000-0000-000000000411"), "section.benefits.h4", "uk", "Що ви отримаєте" },
                    { new Guid("b0000000-0000-0000-0000-000000000412"), "section.program.eyebrow", "ru", "Программа" },
                    { new Guid("b0000000-0000-0000-0000-000000000413"), "section.program.eyebrow", "en", "Programme" },
                    { new Guid("b0000000-0000-0000-0000-000000000414"), "section.program.eyebrow", "uk", "Програма" },
                    { new Guid("b0000000-0000-0000-0000-000000000415"), "section.program.h2", "ru", "Структура курса" },
                    { new Guid("b0000000-0000-0000-0000-000000000416"), "section.program.h2", "en", "Course structure" },
                    { new Guid("b0000000-0000-0000-0000-000000000417"), "section.program.h2", "uk", "Структура курсу" },
                    { new Guid("b0000000-0000-0000-0000-000000000418"), "section.forwhom.eyebrow", "ru", "Для кого" },
                    { new Guid("b0000000-0000-0000-0000-000000000419"), "section.forwhom.eyebrow", "en", "For whom" },
                    { new Guid("b0000000-0000-0000-0000-000000000420"), "section.forwhom.eyebrow", "uk", "Для кого" },
                    { new Guid("b0000000-0000-0000-0000-000000000421"), "section.forwhom.h2", "ru", "Кому подойдёт" },
                    { new Guid("b0000000-0000-0000-0000-000000000422"), "section.forwhom.h2", "en", "Who is it for" },
                    { new Guid("b0000000-0000-0000-0000-000000000423"), "section.forwhom.h2", "uk", "Кому підійде" },
                    { new Guid("b0000000-0000-0000-0000-000000000424"), "section.cta.eyebrow", "ru", "Следующий шаг" },
                    { new Guid("b0000000-0000-0000-0000-000000000425"), "section.cta.eyebrow", "en", "Next step" },
                    { new Guid("b0000000-0000-0000-0000-000000000426"), "section.cta.eyebrow", "uk", "Наступний крок" },
                    { new Guid("b0000000-0000-0000-0000-000000000427"), "section.cta.h2", "ru", "Готовы начать путь?" },
                    { new Guid("b0000000-0000-0000-0000-000000000428"), "section.cta.h2", "en", "Ready to begin?" },
                    { new Guid("b0000000-0000-0000-0000-000000000429"), "section.cta.h2", "uk", "Готові розпочати шлях?" },
                    { new Guid("b0000000-0000-0000-0000-000000000430"), "section.cta.text", "ru", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке." },
                    { new Guid("b0000000-0000-0000-0000-000000000431"), "section.cta.text", "en", "Submit a request — we'll reply within the day with details on the next intake." },
                    { new Guid("b0000000-0000-0000-0000-000000000432"), "section.cta.text", "uk", "Залиште заявку — ми відповімо протягом дня." },
                    { new Guid("b0000000-0000-0000-0000-000000000433"), "section.cta.btn", "ru", "Хочу записаться" },
                    { new Guid("b0000000-0000-0000-0000-000000000434"), "section.cta.btn", "en", "I want to sign up" },
                    { new Guid("b0000000-0000-0000-0000-000000000435"), "section.cta.btn", "uk", "Хочу записатися" },
                    { new Guid("b0000000-0000-0000-0000-000000000436"), "section.back_to_list", "ru", "← Назад к списку" },
                    { new Guid("b0000000-0000-0000-0000-000000000437"), "section.back_to_list", "en", "← Back to list" },
                    { new Guid("b0000000-0000-0000-0000-000000000438"), "section.back_to_list", "uk", "← Назад до списку" },
                    { new Guid("b0000000-0000-0000-0000-000000000439"), "page.courses.eyebrow", "ru", "Направления обучения" },
                    { new Guid("b0000000-0000-0000-0000-000000000440"), "page.courses.eyebrow", "en", "Learning directions" },
                    { new Guid("b0000000-0000-0000-0000-000000000441"), "page.courses.eyebrow", "uk", "Напрями навчання" },
                    { new Guid("b0000000-0000-0000-0000-000000000442"), "page.courses.h2", "ru", "Выберите свой путь" },
                    { new Guid("b0000000-0000-0000-0000-000000000443"), "page.courses.h2", "en", "Choose your path" },
                    { new Guid("b0000000-0000-0000-0000-000000000444"), "page.courses.h2", "uk", "Оберіть свій шлях" },
                    { new Guid("b0000000-0000-0000-0000-000000000445"), "page.courses.intro", "ru", "Три авторские программы — от дыхания до глубинной трансформации." },
                    { new Guid("b0000000-0000-0000-0000-000000000446"), "page.courses.intro", "en", "Three proprietary programmes — from breathwork to deep transformation." },
                    { new Guid("b0000000-0000-0000-0000-000000000447"), "page.courses.intro", "uk", "Три авторські програми — від дихання до глибинної трансформації." },
                    { new Guid("b0000000-0000-0000-0000-000000000448"), "page.courses.card.pranayama.eyebrow", "ru", "Дыхательные практики" },
                    { new Guid("b0000000-0000-0000-0000-000000000449"), "page.courses.card.pranayama.eyebrow", "en", "Breathing practices" },
                    { new Guid("b0000000-0000-0000-0000-000000000450"), "page.courses.card.pranayama.eyebrow", "uk", "Дихальні практики" },
                    { new Guid("b0000000-0000-0000-0000-000000000451"), "page.courses.card.pranayama.tagline", "ru", "Сила вдоха — сила жизни" },
                    { new Guid("b0000000-0000-0000-0000-000000000452"), "page.courses.card.pranayama.tagline", "en", "The power of breath — the power of life" },
                    { new Guid("b0000000-0000-0000-0000-000000000453"), "page.courses.card.pranayama.tagline", "uk", "Сила вдиху — сила життя" },
                    { new Guid("b0000000-0000-0000-0000-000000000454"), "page.courses.card.pranayama.text", "ru", "Научитесь управлять дыханием и откройте новые горизонты сознания." },
                    { new Guid("b0000000-0000-0000-0000-000000000455"), "page.courses.card.pranayama.text", "en", "Learn to harness your breath and unlock new horizons of consciousness." },
                    { new Guid("b0000000-0000-0000-0000-000000000456"), "page.courses.card.pranayama.text", "uk", "Навчіться управляти диханням та відкрийте нові горизонти свідомості." },
                    { new Guid("b0000000-0000-0000-0000-000000000457"), "page.courses.card.meditation.eyebrow", "ru", "Медитативные практики" },
                    { new Guid("b0000000-0000-0000-0000-000000000458"), "page.courses.card.meditation.eyebrow", "en", "Meditative practices" },
                    { new Guid("b0000000-0000-0000-0000-000000000459"), "page.courses.card.meditation.eyebrow", "uk", "Медитативні практики" },
                    { new Guid("b0000000-0000-0000-0000-000000000460"), "page.courses.card.meditation.tagline", "ru", "Тишина как инструмент" },
                    { new Guid("b0000000-0000-0000-0000-000000000461"), "page.courses.card.meditation.tagline", "en", "Silence as a tool" },
                    { new Guid("b0000000-0000-0000-0000-000000000462"), "page.courses.card.meditation.tagline", "uk", "Тиша як інструмент" },
                    { new Guid("b0000000-0000-0000-0000-000000000463"), "page.courses.card.meditation.text", "ru", "Освойте техники медитации и найдите покой в любой ситуации." },
                    { new Guid("b0000000-0000-0000-0000-000000000464"), "page.courses.card.meditation.text", "en", "Master meditation techniques and find stillness in any situation." },
                    { new Guid("b0000000-0000-0000-0000-000000000465"), "page.courses.card.meditation.text", "uk", "Опануйте техніки медитації та знайдіть спокій у будь-якій ситуації." },
                    { new Guid("b0000000-0000-0000-0000-000000000466"), "page.courses.card.yoga.eyebrow", "ru", "Йога-практика" },
                    { new Guid("b0000000-0000-0000-0000-000000000467"), "page.courses.card.yoga.eyebrow", "en", "Yoga practice" },
                    { new Guid("b0000000-0000-0000-0000-000000000468"), "page.courses.card.yoga.eyebrow", "uk", "Йога-практика" },
                    { new Guid("b0000000-0000-0000-0000-000000000469"), "page.courses.card.yoga.tagline", "ru", "Тело как отражение духа" },
                    { new Guid("b0000000-0000-0000-0000-000000000470"), "page.courses.card.yoga.tagline", "en", "Body as a reflection of spirit" },
                    { new Guid("b0000000-0000-0000-0000-000000000471"), "page.courses.card.yoga.tagline", "uk", "Тіло як відображення духу" },
                    { new Guid("b0000000-0000-0000-0000-000000000472"), "page.courses.card.yoga.text", "ru", "Комплексная практика асан, пранаямы и медитации для целостной трансформации." },
                    { new Guid("b0000000-0000-0000-0000-000000000473"), "page.courses.card.yoga.text", "en", "A complete practice of asanas, pranayama and meditation for holistic transformation." },
                    { new Guid("b0000000-0000-0000-0000-000000000474"), "page.courses.card.yoga.text", "uk", "Комплексна практика асан, пранаями та медитації для цілісної трансформації." },
                    { new Guid("b0000000-0000-0000-0000-000000000475"), "page.courses.card.cta", "ru", "Подробнее →" },
                    { new Guid("b0000000-0000-0000-0000-000000000476"), "page.courses.card.cta", "en", "Learn more →" },
                    { new Guid("b0000000-0000-0000-0000-000000000477"), "page.courses.card.cta", "uk", "Детальніше →" },
                    { new Guid("b0000000-0000-0000-0000-000000000478"), "page.consultations.eyebrow", "ru", "Индивидуальная работа" },
                    { new Guid("b0000000-0000-0000-0000-000000000479"), "page.consultations.eyebrow", "en", "Individual work" },
                    { new Guid("b0000000-0000-0000-0000-000000000480"), "page.consultations.eyebrow", "uk", "Індивідуальна робота" },
                    { new Guid("b0000000-0000-0000-0000-000000000481"), "page.consultations.h2", "ru", "Личное сопровождение" },
                    { new Guid("b0000000-0000-0000-0000-000000000482"), "page.consultations.h2", "en", "Personal guidance" },
                    { new Guid("b0000000-0000-0000-0000-000000000483"), "page.consultations.h2", "uk", "Особистий супровід" },
                    { new Guid("b0000000-0000-0000-0000-000000000484"), "page.consultations.intro", "ru", "Три направления персональных консультаций с нашими специалистами." },
                    { new Guid("b0000000-0000-0000-0000-000000000485"), "page.consultations.intro", "en", "Three areas of personal consultations with our specialists." },
                    { new Guid("b0000000-0000-0000-0000-000000000486"), "page.consultations.intro", "uk", "Три напрями персональних консультацій з нашими фахівцями." },
                    { new Guid("b0000000-0000-0000-0000-000000000487"), "page.consultations.card.energy.eyebrow", "ru", "Работа с энергией" },
                    { new Guid("b0000000-0000-0000-0000-000000000488"), "page.consultations.card.energy.eyebrow", "en", "Energy work" },
                    { new Guid("b0000000-0000-0000-0000-000000000489"), "page.consultations.card.energy.eyebrow", "uk", "Робота з енергією" },
                    { new Guid("b0000000-0000-0000-0000-000000000490"), "page.consultations.card.energy.tagline", "ru", "Восстановить баланс сил" },
                    { new Guid("b0000000-0000-0000-0000-000000000491"), "page.consultations.card.energy.tagline", "en", "Restore the balance of energies" },
                    { new Guid("b0000000-0000-0000-0000-000000000492"), "page.consultations.card.energy.tagline", "uk", "Відновити баланс сил" },
                    { new Guid("b0000000-0000-0000-0000-000000000493"), "page.consultations.card.energy.text", "ru", "Диагностика и балансировка энергетических центров через пранаяму и медитацию." },
                    { new Guid("b0000000-0000-0000-0000-000000000494"), "page.consultations.card.energy.text", "en", "Diagnosis and balancing of energy centres through pranayama and meditation." },
                    { new Guid("b0000000-0000-0000-0000-000000000495"), "page.consultations.card.energy.text", "uk", "Діагностика та балансування енергетичних центрів через пранаяму та медитацію." },
                    { new Guid("b0000000-0000-0000-0000-000000000496"), "page.consultations.card.ayurveda.eyebrow", "ru", "Аюрведическая диагностика" },
                    { new Guid("b0000000-0000-0000-0000-000000000497"), "page.consultations.card.ayurveda.eyebrow", "en", "Ayurvedic diagnosis" },
                    { new Guid("b0000000-0000-0000-0000-000000000498"), "page.consultations.card.ayurveda.eyebrow", "uk", "Аюрведична діагностика" },
                    { new Guid("b0000000-0000-0000-0000-000000000499"), "page.consultations.card.ayurveda.tagline", "ru", "Природная мудрость здоровья" },
                    { new Guid("b0000000-0000-0000-0000-000000000500"), "page.consultations.card.ayurveda.tagline", "en", "Natural wisdom of health" },
                    { new Guid("b0000000-0000-0000-0000-000000000501"), "page.consultations.card.ayurveda.tagline", "uk", "Природна мудрість здоров'я" },
                    { new Guid("b0000000-0000-0000-0000-000000000502"), "page.consultations.card.ayurveda.text", "ru", "Определение вашего доши-типа и составление персональных рекомендаций." },
                    { new Guid("b0000000-0000-0000-0000-000000000503"), "page.consultations.card.ayurveda.text", "en", "Determine your dosha type and receive personalised recommendations." },
                    { new Guid("b0000000-0000-0000-0000-000000000504"), "page.consultations.card.ayurveda.text", "uk", "Визначення вашого типу доші та складання персональних рекомендацій." },
                    { new Guid("b0000000-0000-0000-0000-000000000505"), "page.consultations.card.spirituality.eyebrow", "ru", "Духовное развитие" },
                    { new Guid("b0000000-0000-0000-0000-000000000506"), "page.consultations.card.spirituality.eyebrow", "en", "Spiritual development" },
                    { new Guid("b0000000-0000-0000-0000-000000000507"), "page.consultations.card.spirituality.eyebrow", "uk", "Духовний розвиток" },
                    { new Guid("b0000000-0000-0000-0000-000000000508"), "page.consultations.card.spirituality.tagline", "ru", "Путь к истинному себе" },
                    { new Guid("b0000000-0000-0000-0000-000000000509"), "page.consultations.card.spirituality.tagline", "en", "Path to the true self" },
                    { new Guid("b0000000-0000-0000-0000-000000000510"), "page.consultations.card.spirituality.tagline", "uk", "Шлях до справжнього себе" },
                    { new Guid("b0000000-0000-0000-0000-000000000511"), "page.consultations.card.spirituality.text", "ru", "Индивидуальная работа с убеждениями, страхами и духовными вопросами." },
                    { new Guid("b0000000-0000-0000-0000-000000000512"), "page.consultations.card.spirituality.text", "en", "Individual work with beliefs, fears and spiritual questions." },
                    { new Guid("b0000000-0000-0000-0000-000000000513"), "page.consultations.card.spirituality.text", "uk", "Індивідуальна робота з переконаннями, страхами та духовними питаннями." },
                    { new Guid("b0000000-0000-0000-0000-000000000514"), "page.consultations.card.cta", "ru", "Записаться →" },
                    { new Guid("b0000000-0000-0000-0000-000000000515"), "page.consultations.card.cta", "en", "Book →" },
                    { new Guid("b0000000-0000-0000-0000-000000000516"), "page.consultations.card.cta", "uk", "Записатися →" },
                    { new Guid("b0000000-0000-0000-0000-000000000517"), "page.about.founders.eyebrow", "ru", "Мы — Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000518"), "page.about.founders.eyebrow", "en", "We are Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000519"), "page.about.founders.eyebrow", "uk", "Ми — Yoga.Life" },
                    { new Guid("b0000000-0000-0000-0000-000000000520"), "page.about.founders.h2", "ru", "Три пути — одна миссия" },
                    { new Guid("b0000000-0000-0000-0000-000000000521"), "page.about.founders.h2", "en", "Three paths — one mission" },
                    { new Guid("b0000000-0000-0000-0000-000000000522"), "page.about.founders.h2", "uk", "Три шляхи — одна місія" },
                    { new Guid("b0000000-0000-0000-0000-000000000523"), "page.about.philosophy.eyebrow", "ru", "Принципы" },
                    { new Guid("b0000000-0000-0000-0000-000000000524"), "page.about.philosophy.eyebrow", "en", "Principles" },
                    { new Guid("b0000000-0000-0000-0000-000000000525"), "page.about.philosophy.eyebrow", "uk", "Принципи" },
                    { new Guid("b0000000-0000-0000-0000-000000000526"), "page.about.philosophy.h2", "ru", "Философия проекта" },
                    { new Guid("b0000000-0000-0000-0000-000000000527"), "page.about.philosophy.h2", "en", "Project philosophy" },
                    { new Guid("b0000000-0000-0000-0000-000000000528"), "page.about.philosophy.h2", "uk", "Філософія проекту" },
                    { new Guid("b0000000-0000-0000-0000-000000000529"), "page.contacts.eyebrow", "ru", "Всегда на связи" },
                    { new Guid("b0000000-0000-0000-0000-000000000530"), "page.contacts.eyebrow", "en", "Always in touch" },
                    { new Guid("b0000000-0000-0000-0000-000000000531"), "page.contacts.eyebrow", "uk", "Завжди на зв'язку" },
                    { new Guid("b0000000-0000-0000-0000-000000000532"), "page.contacts.info.h2", "ru", "Давайте познакомимся" },
                    { new Guid("b0000000-0000-0000-0000-000000000533"), "page.contacts.info.h2", "en", "Let's connect" },
                    { new Guid("b0000000-0000-0000-0000-000000000534"), "page.contacts.info.h2", "uk", "Давайте познайомимось" },
                    { new Guid("b0000000-0000-0000-0000-000000000535"), "page.contacts.social.eyebrow", "ru", "Социальные сети" },
                    { new Guid("b0000000-0000-0000-0000-000000000536"), "page.contacts.social.eyebrow", "en", "Social media" },
                    { new Guid("b0000000-0000-0000-0000-000000000537"), "page.contacts.social.eyebrow", "uk", "Соціальні мережі" },
                    { new Guid("b0000000-0000-0000-0000-000000000538"), "page.contacts.social.h2", "ru", "Присоединяйтесь к нам" },
                    { new Guid("b0000000-0000-0000-0000-000000000539"), "page.contacts.social.h2", "en", "Join us online" },
                    { new Guid("b0000000-0000-0000-0000-000000000540"), "page.contacts.social.h2", "uk", "Приєднуйтесь до нас" },
                    { new Guid("b0000000-0000-0000-0000-000000000541"), "page.retreats.eyebrow", "ru", "Ближайшие программы" },
                    { new Guid("b0000000-0000-0000-0000-000000000542"), "page.retreats.eyebrow", "en", "Upcoming programmes" },
                    { new Guid("b0000000-0000-0000-0000-000000000543"), "page.retreats.eyebrow", "uk", "Найближчі програми" },
                    { new Guid("b0000000-0000-0000-0000-000000000544"), "page.retreats.actual.intro", "ru", "Открытые ретриты, на которые сейчас можно записаться." },
                    { new Guid("b0000000-0000-0000-0000-000000000545"), "page.retreats.actual.intro", "en", "Open retreats you can register for right now." },
                    { new Guid("b0000000-0000-0000-0000-000000000546"), "page.retreats.actual.intro", "uk", "Відкриті ретрити, на які зараз можна записатись." },
                    { new Guid("b0000000-0000-0000-0000-000000000547"), "page.retreats.upcoming.intro", "ru", "Предстоящие ретриты — запишитесь заранее и получите лучшие условия." },
                    { new Guid("b0000000-0000-0000-0000-000000000548"), "page.retreats.upcoming.intro", "en", "Upcoming retreats — register early for the best terms." },
                    { new Guid("b0000000-0000-0000-0000-000000000549"), "page.retreats.upcoming.intro", "uk", "Майбутні ретрити — запишіться заздалегідь для найкращих умов." },
                    { new Guid("b0000000-0000-0000-0000-000000000550"), "page.retreats.past.intro", "ru", "История наших программ. Каждый ретрит — это особенная история." },
                    { new Guid("b0000000-0000-0000-0000-000000000551"), "page.retreats.past.intro", "en", "A record of our past programmes. Each retreat is a unique story." },
                    { new Guid("b0000000-0000-0000-0000-000000000552"), "page.retreats.past.intro", "uk", "Історія наших програм. Кожен ретрит — це особлива історія." },
                    { new Guid("b0000000-0000-0000-0000-000000000553"), "page.retreats.card.location", "ru", "Местоположение" },
                    { new Guid("b0000000-0000-0000-0000-000000000554"), "page.retreats.card.location", "en", "Location" },
                    { new Guid("b0000000-0000-0000-0000-000000000555"), "page.retreats.card.location", "uk", "Місцезнаходження" },
                    { new Guid("b0000000-0000-0000-0000-000000000556"), "page.retreats.card.dates", "ru", "Даты" },
                    { new Guid("b0000000-0000-0000-0000-000000000557"), "page.retreats.card.dates", "en", "Dates" },
                    { new Guid("b0000000-0000-0000-0000-000000000558"), "page.retreats.card.dates", "uk", "Дати" },
                    { new Guid("b0000000-0000-0000-0000-000000000559"), "page.retreats.card.cta", "ru", "Записаться" },
                    { new Guid("b0000000-0000-0000-0000-000000000560"), "page.retreats.card.cta", "en", "Sign up" },
                    { new Guid("b0000000-0000-0000-0000-000000000561"), "page.retreats.card.cta", "uk", "Записатися" },
                    { new Guid("b0000000-0000-0000-0000-000000000562"), "page.retreats.empty", "ru", "Ретриты не найдены." },
                    { new Guid("b0000000-0000-0000-0000-000000000563"), "page.retreats.empty", "en", "No retreats found." },
                    { new Guid("b0000000-0000-0000-0000-000000000564"), "page.retreats.empty", "uk", "Ретрити не знайдено." },
                    { new Guid("b0000000-0000-0000-0000-000000000565"), "page.blog.eyebrow", "ru", "Знания и вдохновение" },
                    { new Guid("b0000000-0000-0000-0000-000000000566"), "page.blog.eyebrow", "en", "Knowledge and inspiration" },
                    { new Guid("b0000000-0000-0000-0000-000000000567"), "page.blog.eyebrow", "uk", "Знання та натхнення" },
                    { new Guid("b0000000-0000-0000-0000-000000000568"), "page.blog.h2", "ru", "Исследуйте темы" },
                    { new Guid("b0000000-0000-0000-0000-000000000569"), "page.blog.h2", "en", "Explore topics" },
                    { new Guid("b0000000-0000-0000-0000-000000000570"), "page.blog.h2", "uk", "Досліджуйте теми" },
                    { new Guid("b0000000-0000-0000-0000-000000000571"), "page.blog.articles.eyebrow", "ru", "Авторские статьи" },
                    { new Guid("b0000000-0000-0000-0000-000000000572"), "page.blog.articles.eyebrow", "en", "Articles" },
                    { new Guid("b0000000-0000-0000-0000-000000000573"), "page.blog.articles.eyebrow", "uk", "Авторські статті" },
                    { new Guid("b0000000-0000-0000-0000-000000000574"), "page.blog.articles.intro", "ru", "Глубокие материалы о практике, философии и образе жизни." },
                    { new Guid("b0000000-0000-0000-0000-000000000575"), "page.blog.articles.intro", "en", "In-depth material on practice, philosophy and lifestyle." },
                    { new Guid("b0000000-0000-0000-0000-000000000576"), "page.blog.articles.intro", "uk", "Глибокі матеріали про практику, філософію та спосіб життя." },
                    { new Guid("b0000000-0000-0000-0000-000000000577"), "page.blog.videos.eyebrow", "ru", "Видеоматериалы" },
                    { new Guid("b0000000-0000-0000-0000-000000000578"), "page.blog.videos.eyebrow", "en", "Video content" },
                    { new Guid("b0000000-0000-0000-0000-000000000579"), "page.blog.videos.eyebrow", "uk", "Відеоматеріали" },
                    { new Guid("b0000000-0000-0000-0000-000000000580"), "page.blog.videos.intro", "ru", "Практические уроки и вдохновляющие записи с наших ретритов." },
                    { new Guid("b0000000-0000-0000-0000-000000000581"), "page.blog.videos.intro", "en", "Practical lessons and inspiring recordings from our retreats." },
                    { new Guid("b0000000-0000-0000-0000-000000000582"), "page.blog.videos.intro", "uk", "Практичні уроки та надихаючі записи з наших ретритів." },
                    { new Guid("b0000000-0000-0000-0000-000000000583"), "page.blog.photos.eyebrow", "ru", "Галерея" },
                    { new Guid("b0000000-0000-0000-0000-000000000584"), "page.blog.photos.eyebrow", "en", "Gallery" },
                    { new Guid("b0000000-0000-0000-0000-000000000585"), "page.blog.photos.eyebrow", "uk", "Галерея" },
                    { new Guid("b0000000-0000-0000-0000-000000000586"), "page.blog.photos.intro", "ru", "Моменты из жизни нашего сообщества." },
                    { new Guid("b0000000-0000-0000-0000-000000000587"), "page.blog.photos.intro", "en", "Moments from the life of our community." },
                    { new Guid("b0000000-0000-0000-0000-000000000588"), "page.blog.photos.intro", "uk", "Моменти з життя нашої спільноти." },
                    { new Guid("b0000000-0000-0000-0000-000000000589"), "page.blog.readmore", "ru", "Читать →" },
                    { new Guid("b0000000-0000-0000-0000-000000000590"), "page.blog.readmore", "en", "Read →" },
                    { new Guid("b0000000-0000-0000-0000-000000000591"), "page.blog.readmore", "uk", "Читати →" },
                    { new Guid("b0000000-0000-0000-0000-000000000592"), "page.blog.empty", "ru", "Публикации пока не добавлены." },
                    { new Guid("b0000000-0000-0000-0000-000000000593"), "page.blog.empty", "en", "No posts have been added yet." },
                    { new Guid("b0000000-0000-0000-0000-000000000594"), "page.blog.empty", "uk", "Публікації ще не додані." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000370"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000371"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000372"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000373"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000374"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000375"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000376"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000377"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000378"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000379"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000380"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000381"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000382"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000383"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000384"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000385"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000386"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000387"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000388"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000389"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000390"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000391"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000392"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000393"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000394"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000395"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000396"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000397"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000398"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000399"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000400"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000401"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000402"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000403"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000404"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000405"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000406"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000407"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000408"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000409"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000410"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000411"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000412"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000413"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000414"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000415"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000416"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000417"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000418"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000419"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000420"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000421"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000422"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000423"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000424"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000425"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000426"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000427"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000428"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000429"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000430"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000431"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000432"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000433"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000434"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000435"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000436"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000437"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000438"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000439"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000440"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000441"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000442"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000443"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000444"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000445"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000446"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000447"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000448"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000449"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000450"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000451"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000452"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000453"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000454"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000455"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000456"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000457"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000458"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000459"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000460"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000461"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000462"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000463"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000464"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000465"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000466"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000467"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000468"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000469"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000470"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000471"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000472"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000473"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000474"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000475"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000476"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000477"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000478"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000479"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000480"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000481"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000482"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000483"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000484"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000485"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000486"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000487"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000488"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000489"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000490"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000491"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000492"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000493"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000494"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000495"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000496"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000497"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000498"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000499"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000500"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000501"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000502"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000503"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000504"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000505"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000506"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000507"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000508"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000509"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000510"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000511"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000512"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000513"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000514"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000515"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000516"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000517"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000518"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000519"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000520"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000521"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000522"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000523"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000524"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000525"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000526"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000527"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000528"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000529"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000530"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000531"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000532"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000533"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000534"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000535"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000536"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000537"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000538"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000539"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000540"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000541"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000542"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000543"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000544"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000545"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000546"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000547"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000548"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000549"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000550"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000551"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000552"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000553"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000554"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000555"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000556"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000557"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000558"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000559"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000560"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000561"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000562"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000563"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000564"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000565"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000566"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000567"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000568"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000569"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000570"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000571"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000572"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000573"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000574"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000575"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000576"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000577"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000578"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000579"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000580"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000581"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000582"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000583"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000584"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000585"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000586"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000587"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000588"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000589"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000590"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000591"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000592"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000593"));

            migrationBuilder.DeleteData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000594"));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$pWze5mwxiEzQYqeAC1YKU.THt/qAoSCtLKrBpW9xqRgT1c8UoIA7i");
        }
    }
}
