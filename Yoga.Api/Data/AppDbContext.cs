using System.Linq;
using Microsoft.EntityFrameworkCore;
using Yoga.Shared.Models;

namespace Yoga.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Lead> Leads => Set<Lead>();
        public DbSet<Translation> Translations => Set<Translation>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseModule> CourseModules => Set<CourseModule>();
        public DbSet<CourseLesson> CourseLessons => Set<CourseLesson>();
        public DbSet<Consultation> Consultations => Set<Consultation>();
        public DbSet<Retreat> Retreats => Set<Retreat>();
        public DbSet<RetreatSubcategory> RetreatSubcategories => Set<RetreatSubcategory>();
        public DbSet<Yagya> Yagyas => Set<Yagya>();
        public DbSet<YagyaSubcategory> YagyaSubcategories => Set<YagyaSubcategory>();
        public DbSet<SitePage> SitePages => Set<SitePage>();
        public DbSet<UiTranslation> UiTranslations => Set<UiTranslation>();
        public DbSet<AdminUser> AdminUsers => Set<AdminUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasMaxLength(100).IsRequired();
                e.Property(x => x.ContactDetails).HasMaxLength(100).IsRequired();
                e.Property(x => x.Messager).HasMaxLength(50);
                e.Property(x => x.Comment).HasMaxLength(1000);
                e.Property(x => x.TargetFormat).HasMaxLength(50);
            });

            modelBuilder.Entity<Translation>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.EntityType).HasMaxLength(64).IsRequired();
                e.Property(x => x.Field).HasMaxLength(128).IsRequired();
                e.Property(x => x.Language).HasMaxLength(8).IsRequired();
                e.HasIndex(x => new { x.EntityType, x.EntityId, x.Field, x.Language }).IsUnique();
            });

            modelBuilder.Entity<UiTranslation>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Key).HasMaxLength(256).IsRequired();
                e.Property(x => x.Language).HasMaxLength(8).IsRequired();
                e.HasIndex(x => new { x.Key, x.Language }).IsUnique();
            });

            modelBuilder.Entity<SitePage>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
            });

            modelBuilder.Entity<CourseModule>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasOne(x => x.Course)
                    .WithMany(c => c.Modules)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CourseLesson>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasOne(x => x.Module)
                    .WithMany(m => m.Lessons)
                    .HasForeignKey(x => x.CourseModuleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Consultation>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
            });

            modelBuilder.Entity<Retreat>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
            });

            modelBuilder.Entity<RetreatSubcategory>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasOne(x => x.Retreat)
                    .WithMany(r => r.Subcategories)
                    .HasForeignKey(x => x.RetreatId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Yagya>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
            });

            modelBuilder.Entity<YagyaSubcategory>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasOne(x => x.Yagya)
                    .WithMany(y => y.Subcategories)
                    .HasForeignKey(x => x.YagyaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AdminUser>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Login).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Login).IsUnique();
                e.Property(x => x.PasswordHash).HasMaxLength(256).IsRequired();
            });

            var coursePranavidya = Guid.Parse("22222222-2222-2222-2222-222222222201");
            var courseMeditation = Guid.Parse("22222222-2222-2222-2222-222222222202");
            var courseYoga = Guid.Parse("22222222-2222-2222-2222-222222222203");

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = coursePranavidya, Slug = "pranavidya", SortOrder = 1, IsActive = true, IsOnline = true, IsOffline = true },
                new Course { Id = courseMeditation, Slug = "meditation", SortOrder = 2, IsActive = true, IsOnline = true, IsOffline = true },
                new Course { Id = courseYoga, Slug = "yoga", SortOrder = 3, IsActive = true, IsOnline = true, IsOffline = true });

            var consultSpiritual = Guid.Parse("33333333-3333-3333-3333-333333333301");
            var consultYouth = Guid.Parse("33333333-3333-3333-3333-333333333302");
            var consultPersonal = Guid.Parse("33333333-3333-3333-3333-333333333303");

            modelBuilder.Entity<Consultation>().HasData(
                new Consultation { Id = consultSpiritual, Slug = "spiritual-development", SortOrder = 1, IsActive = true, IsOnline = true, IsOffline = true },
                new Consultation { Id = consultYouth, Slug = "youth", SortOrder = 2, IsActive = true, IsOnline = true, IsOffline = true },
                new Consultation { Id = consultPersonal, Slug = "personal", SortOrder = 3, IsActive = true, IsOnline = true, IsOffline = true });

            var retreatMountain = Guid.Parse("55555555-5555-5555-5555-555555555501");
            var retreatSilence = Guid.Parse("55555555-5555-5555-5555-555555555502");

            modelBuilder.Entity<Retreat>().HasData(
                new Retreat { Id = retreatMountain, Slug = "mountain-practice", SortOrder = 1, IsActive = true },
                new Retreat { Id = retreatSilence, Slug = "silence-retreat", SortOrder = 2, IsActive = true });

            var yagyaFire = Guid.Parse("66666666-6666-6666-6666-666666666601");
            var yagyaNewYear = Guid.Parse("66666666-6666-6666-6666-666666666602");

            modelBuilder.Entity<Yagya>().HasData(
                new Yagya { Id = yagyaFire, Slug = "fire-ceremony", SortOrder = 1, IsActive = true },
                new Yagya { Id = yagyaNewYear, Slug = "new-year-intention", SortOrder = 2, IsActive = true });

            var pageAbout = Guid.Parse("44444444-4444-4444-4444-444444444401");
            var pageContacts = Guid.Parse("44444444-4444-4444-4444-444444444402");
            var pageHome = Guid.Parse("44444444-4444-4444-4444-444444444403");
            var pageCourses = Guid.Parse("44444444-4444-4444-4444-444444444404");
            var pageConsultations = Guid.Parse("44444444-4444-4444-4444-444444444405");
            var pageRetreats = Guid.Parse("44444444-4444-4444-4444-444444444406");
            var pageYagyas = Guid.Parse("44444444-4444-4444-4444-444444444407");
            var pageBlog = Guid.Parse("44444444-4444-4444-4444-444444444408");

            modelBuilder.Entity<SitePage>().HasData(
                new SitePage { Id = pageAbout, Slug = "about" },
                new SitePage { Id = pageContacts, Slug = "contacts" },
                new SitePage { Id = pageHome, Slug = "home" },
                new SitePage { Id = pageCourses, Slug = "courses" },
                new SitePage { Id = pageConsultations, Slug = "consultations" },
                new SitePage { Id = pageRetreats, Slug = "retreats" },
                new SitePage { Id = pageYagyas, Slug = "yagyas" },
                new SitePage { Id = pageBlog, Slug = "blog" });

            var translations = BuildSeedTranslations(
                coursePranavidya, courseMeditation, courseYoga,
                consultSpiritual, consultYouth, consultPersonal,
                retreatMountain, retreatSilence,
                yagyaFire, yagyaNewYear);

            var sectionTranslations = BuildSitePageSectionTranslations(pageRetreats, pageYagyas, pageBlog);
            modelBuilder.Entity<Translation>().HasData(translations.Concat(sectionTranslations).ToArray());
        }

        private static Translation[] BuildSeedTranslations(
            Guid c1, Guid c2, Guid c3,
            Guid s1, Guid s2, Guid s3,
            Guid r1, Guid r2,
            Guid y1, Guid y2)
        {
            var list = new List<Translation>();
            var seq = 0;

            void Tri(Guid entityId, string entityType, string field, string ru, string en, string uk)
            {
                foreach (var (lang, val) in new[] { ("ru", ru), ("en", en), ("uk", uk) })
                {
                    seq++;
                    list.Add(new Translation
                    {
                        Id = Guid.Parse($"bbbbbbbb-bbbb-4bbb-8bbb-{seq:D12}"),
                        EntityId = entityId,
                        EntityType = entityType,
                        Field = field,
                        Language = lang,
                        Value = val
                    });
                }
            }

            Tri(c1, "Course", "Title", "Пранавидья", "Pranavidya", "Пранавід'я");
            Tri(c1, "Course", "Subtitle", "Дыхание как опора практики", "Breath as the foundation of practice", "Дихання як опора практики");
            Tri(c1, "Course", "Eyebrow", "Курс", "Course", "Курс");
            Tri(c1, "Course", "Description", "Системная работа с пранаямой: от базовых техник до устойчивой самопрактики.", "Structured pranayama work: from foundational techniques to a steady self-practice.", "Системна робота з пранаямою: від базових технік до стійкої самопрактики.");
            Tri(c1, "Course", "Benefits", "Спокойнее нервная система|Больше энергии днём|Улучшенный сон", "A calmer nervous system|More daytime energy|Better sleep", "Спокійніша нервова система|Більше енергії вдень|Кращий сон");
            Tri(c1, "Course", "ImageUrl", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80");
            Tri(c1, "Course", "Duration", "8 недель", "8 weeks", "8 тижнів");
            Tri(c1, "Course", "Level", "От новичка до уверенной практики", "From beginner to confident practice", "Від новачка до впевненої практики");
            Tri(c1, "Course", "Format", "Онлайн и офлайн", "Online and in person", "Онлайн і офлайн");
            Tri(c1, "Course", "Schedule", "2 занятия в неделю + самостоятельная практика", "Two sessions per week + self-practice", "2 заняття на тиждень + самостійна практика");
            Tri(c1, "Course", "ForWhom", "Новичкам~Безопасный вход в практику|Практикующим~Углубление и стабилизация дыхания", "Beginners~A safe entry into practice|Experienced practitioners~Deepening and stabilising the breath", "Новачкам~Безпечний вхід у практику|Практикуючим~Поглиблення та стабілізація дихання");
            Tri(c1, "Course", "CtaHeading", "Начать с пранаямы", "Start with pranayama", "Почати з пранаями");
            Tri(c1, "Course", "CtaText", "Оставьте заявку — подберём формат и ответим на вопросы.", "Leave a request — we'll suggest a format and answer your questions.", "Залиште заявку — підберемо формат і відповімо на питання.");

            Tri(c2, "Course", "Title", "Медитация", "Meditation", "Медитація");
            Tri(c2, "Course", "Subtitle", "Тишина, устойчивость, ясность", "Stillness, stability, clarity", "Тиша, стійкість, ясність");
            Tri(c2, "Course", "Eyebrow", "Курс", "Course", "Курс");
            Tri(c2, "Course", "Description", "Пошаговое освоение медитативных техник для повседневной жизни.", "Step-by-step meditation skills for everyday life.", "Покрокове освоєння медитативних технік для повсякденного життя.");
            Tri(c2, "Course", "Benefits", "Меньше реактивности|Больше присутствия|Ясность решений", "Less reactivity|More presence|Clearer decisions", "Менше реактивності|Більше присутності|Ясність рішень");
            Tri(c2, "Course", "ImageUrl", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80");
            Tri(c2, "Course", "Duration", "6 недель", "6 weeks", "6 тижнів");
            Tri(c2, "Course", "Level", "Подходит любому уровню", "All levels welcome", "Підходить будь-якому рівню");
            Tri(c2, "Course", "Format", "Онлайн и офлайн", "Online and in person", "Онлайн і офлайн");
            Tri(c2, "Course", "Schedule", "Еженедельные встречи и короткие ежедневные практики", "Weekly meetings and short daily practices", "Щотижневі зустрічі та короткі щоденні практики");
            Tri(c2, "Course", "ForWhom", "Занятым людям~Короткие практики встроены в день|Искателям глубины~Разбор опыта с куратором", "Busy people~Short practices that fit the day|Seekers of depth~Guided reflection with a mentor", "Зайнятим людям~Короткі практики вбудовані в день|Шукачам глибини~Розбір досвіду з куратором");
            Tri(c2, "Course", "CtaHeading", "Попробовать медитацию", "Try meditation", "Спробувати медитацію");
            Tri(c2, "Course", "CtaText", "Расскажем, с чего начать именно вам.", "We'll suggest where to start for you.", "Розповімо, з чого почати саме вам.");

            Tri(c3, "Course", "Title", "Йога", "Yoga", "Йога");
            Tri(c3, "Course", "Subtitle", "Тело, дыхание, внимание", "Body, breath, attention", "Тіло, дихання, увага");
            Tri(c3, "Course", "Eyebrow", "Курс", "Course", "Курс");
            Tri(c3, "Course", "Description", "Комплексная практика: асаны, пранаяма и элементы медитации.", "A complete practice: asana, pranayama and elements of meditation.", "Комплексна практика: асани, пранаяма та елементи медитації.");
            Tri(c3, "Course", "Benefits", "Сила и гибкость|Ровное дыхание|Больше осознанности", "Strength and flexibility|Steady breath|More mindfulness", "Сила та гнучкість|Рівне дихання|Більше усвідомленості");
            Tri(c3, "Course", "ImageUrl", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80");
            Tri(c3, "Course", "Duration", "10 недель", "10 weeks", "10 тижнів");
            Tri(c3, "Course", "Level", "От основ к цельной практике", "From foundations to an integrated practice", "Від основ до цілісної практики");
            Tri(c3, "Course", "Format", "Онлайн и офлайн", "Online and in person", "Онлайн і офлайн");
            Tri(c3, "Course", "Schedule", "2 практики в неделю", "Two practices per week", "2 практики на тиждень");
            Tri(c3, "Course", "ForWhom", "Новичкам~Безопасный старт|Опытным~Тонкая настройка практики", "Beginners~A safe start|Experienced~Fine-tuning your practice", "Новачкам~Безпечний старт|Досвідченим~Тонке налаштування практики");
            Tri(c3, "Course", "CtaHeading", "Погрузиться в йогу", "Dive into yoga", "Зануритися в йогу");
            Tri(c3, "Course", "CtaText", "Подберём интенсивность и формат под ваш запрос.", "We'll match intensity and format to your goals.", "Підберемо інтенсивність і формат під ваш запит.");

            Tri(s1, "Consultation", "Title", "Духовное развитие", "Spiritual development", "Духовний розвиток");
            Tri(s1, "Consultation", "Subtitle", "Опора, ясность, личный ритм", "Support, clarity, your own pace", "Опора, ясність, особистий ритм");
            Tri(s1, "Consultation", "Eyebrow", "Консультация", "Consultation", "Консультація");
            Tri(s1, "Consultation", "Description", "Индивидуальная работа с вопросами смысла, ценностей и внутреннего роста.", "One-to-one work on meaning, values and inner growth.", "Індивідуальна робота з питаннями сенсу, цінностей та внутрішнього росту.");
            Tri(s1, "Consultation", "Quote", "«Место, где можно говорить честно — без оценки и спешки.»", "«A space to speak honestly — without judgement or rush.»", "«Місце, де можна говорити чесно — без оцінки та поспіху.»");
            Tri(s1, "Consultation", "Benefits", "Ясность направления|Опора в сложные периоды|Интеграция практики в жизнь", "Clarity of direction|Support in difficult periods|Integrating practice into life", "Ясність напрямку|Опора у складні періоди|Інтеграція практики в життя");
            Tri(s1, "Consultation", "ImageUrl", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80");
            Tri(s1, "Consultation", "Duration", "60–90 минут", "60–90 minutes", "60–90 хвилин");
            Tri(s1, "Consultation", "Format", "Онлайн / очно", "Online / in person", "Онлайн / очно");
            Tri(s1, "Consultation", "LanguageOffered", "RU / EN / UK", "RU / EN / UK", "RU / EN / UK");
            Tri(s1, "Consultation", "PriceLabel", "По запросу", "On request", "За запитом");
            Tri(s1, "Consultation", "ForWhom", "В переломные моменты~Нужен взгляд со стороны|Ищущим глубину~Связать практику и жизнь", "At turning points~An outside perspective|Seeking depth~Connecting practice and life", "У переломні моменти~Потрібен погляд збоку|Шукачам глибини~Зв'язати практику і життя");
            Tri(s1, "Consultation", "CtaHeading", "Записаться на сессию", "Book a session", "Записатися на сесію");
            Tri(s1, "Consultation", "CtaText", "Оставьте контакты — предложим время и формат.", "Leave your contacts — we'll suggest time and format.", "Залиште контакти — запропонуємо час і формат.");

            Tri(s2, "Consultation", "Title", "Для подростков", "For teenagers", "Для підлітків");
            Tri(s2, "Consultation", "Subtitle", "Опора, границы, уважение к росту", "Support, boundaries, respect for growth", "Опора, межі, повага до зростання");
            Tri(s2, "Consultation", "Eyebrow", "Консультация", "Consultation", "Консультація");
            Tri(s2, "Consultation", "Description", "Бережный формат разговора о телесных, эмоциональных и социальных темах.", "A careful conversation about body, emotions and social life.", "Обережний формат розмови про тілесні, емоційні та соціальні теми.");
            Tri(s2, "Consultation", "Quote", "«Подростку нужен взрослый, который слышит, а не оценивает.»", "«Teenagers need adults who listen, not judge.»", "«Підлітку потрібен дорослий, який чує, а не оцінює.»");
            Tri(s2, "Consultation", "Benefits", "Безопасное пространство|Язык, понятный подростку|Совместные шаги с семьёй при необходимости", "A safe space|Language that fits teens|Family steps when needed", "Безпечний простір|Мова, зрозуміла підлітку|Спільні кроки з родиною за потреби");
            Tri(s2, "Consultation", "ImageUrl", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80");
            Tri(s2, "Consultation", "Duration", "50–60 минут", "50–60 minutes", "50–60 хвилин");
            Tri(s2, "Consultation", "Format", "Онлайн / очно", "Online / in person", "Онлайн / очно");
            Tri(s2, "Consultation", "LanguageOffered", "RU / UK", "RU / UK", "RU / UK");
            Tri(s2, "Consultation", "PriceLabel", "По запросу", "On request", "За запитом");
            Tri(s2, "Consultation", "ForWhom", "Подросткам 12–17~И их родителям при согласии", "Teens 12–17~And their parents when agreed", "Підліткам 12–17~І їхнім батькам за згодою");
            Tri(s2, "Consultation", "CtaHeading", "Записаться", "Book", "Записатися");
            Tri(s2, "Consultation", "CtaText", "Коротко опишите запрос — подскажем следующий шаг.", "Briefly describe your request — we'll suggest the next step.", "Коротко опишіть запит — підкажемо наступний крок.");

            Tri(s3, "Consultation", "Title", "Личные вопросы", "Personal questions", "Особисті питання");
            Tri(s3, "Consultation", "Subtitle", "Конфиденциально и по делу", "Confidential and practical", "Конфіденційно і по суті");
            Tri(s3, "Consultation", "Eyebrow", "Консультация", "Consultation", "Консультація");
            Tri(s3, "Consultation", "Description", "Разбор личной ситуации: отношения, решения, нагрузка, поиск баланса.", "Working through a personal situation: relationships, decisions, load, balance.", "Розбір особистої ситуації: стосунки, рішення, навантаження, баланс.");
            Tri(s3, "Consultation", "Quote", "«Иногда нужен час, чтобы разложить всё по полочкам.»", "«Sometimes you need an hour to sort things out.»", "«Іноді потрібна година, щоб розкласти все по поличках.»");
            Tri(s3, "Consultation", "Benefits", "Структура вопроса|Варианты шагов|Поддержка после сессии", "A clearer question|Options for next steps|Follow-up support", "Структура питання|Варіанти кроків|Підтримка після сесії");
            Tri(s3, "Consultation", "ImageUrl", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80");
            Tri(s3, "Consultation", "Duration", "60 минут", "60 minutes", "60 хвилин");
            Tri(s3, "Consultation", "Format", "Онлайн / очно", "Online / in person", "Онлайн / очно");
            Tri(s3, "Consultation", "LanguageOffered", "RU / EN / UK", "RU / EN / UK", "RU / EN / UK");
            Tri(s3, "Consultation", "PriceLabel", "По запросу", "On request", "За запитом");
            Tri(s3, "Consultation", "ForWhom", "Сложный выбор~Разобрать варианты|Усталость и перегруз~Найти опору", "Hard choices~Sorting options|Fatigue and overload~Finding footing", "Складний вибір~Розібрати варіанти|Втома та перевантаження~Знайти опору");
            Tri(s3, "Consultation", "CtaHeading", "Записаться", "Book", "Записатися");
            Tri(s3, "Consultation", "CtaText", "Напишите, что хотите разобрать — ответим с вариантами времени.", "Tell us what you'd like to unpack — we'll reply with time options.", "Напишіть, що хочете розібрати — відповімо з варіантами часу.");

            // Retreats
            Tri(r1, "Retreat", "Title", "Горная практика", "Mountain practice", "Гірська практика");
            Tri(r1, "Retreat", "Subtitle", "Природа, тишина, глубина", "Nature, silence, depth", "Природа, тиша, глибина");
            Tri(r1, "Retreat", "Eyebrow", "Ретрит", "Retreat", "Ретрит");
            Tri(r1, "Retreat", "Description", "Выездной интенсив в горах: утренние практики, медитация, совместная работа.", "Mountain intensive: morning practices, meditation, group work.", "Виїзний інтенсив у горах: ранкові практики, медитація, спільна робота.");
            Tri(r1, "Retreat", "Benefits", "Перезагрузка|Глубокая практика|Общение в кругу единомышленников", "Reset|Deep practice|Community", "Перезавантаження|Глибока практика|Спілкування з однодумцями");
            Tri(r1, "Retreat", "ImageUrl", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1200&q=80");
            Tri(r1, "Retreat", "Duration", "5 дней", "5 days", "5 днів");
            Tri(r1, "Retreat", "Location", "Карпаты, Украина", "Carpathians, Ukraine", "Карпати, Україна");
            Tri(r1, "Retreat", "Format", "Офлайн", "In person", "Офлайн");
            Tri(r1, "Retreat", "PriceLabel", "По запросу", "On request", "За запитом");
            Tri(r1, "Retreat", "ForWhom", "Практикующим~Углубление опыта|Новичкам~Безопасное погружение", "Experienced~Deepen your experience|Beginners~A safe immersion", "Практикуючим~Поглиблення досвіду|Новачкам~Безпечне занурення");
            Tri(r1, "Retreat", "CtaHeading", "Забронировать место", "Reserve a spot", "Забронювати місце");
            Tri(r1, "Retreat", "CtaText", "Места ограничены — оставьте заявку заранее.", "Spots are limited — apply in advance.", "Місць обмаль — залиште заявку заздалегідь.");

            Tri(r2, "Retreat", "Title", "Ретрит тишины", "Silence retreat", "Ретрит тиші");
            Tri(r2, "Retreat", "Subtitle", "Слушать тишину внутри", "Listening to inner silence", "Слухати тишу всередині");
            Tri(r2, "Retreat", "Eyebrow", "Ретрит", "Retreat", "Ретрит");
            Tri(r2, "Retreat", "Description", "Три дня молчания: медитация, ходьба, дневник. Минимум слов — максимум внимания.", "Three days of silence: meditation, walking, journalling. Minimum words — maximum attention.", "Три дні мовчання: медитація, ходьба, щоденник. Мінімум слів — максимум уваги.");
            Tri(r2, "Retreat", "Benefits", "Ясность мысли|Снижение тревоги|Возврат энергии", "Mental clarity|Reduced anxiety|Energy restored", "Ясність думки|Зниження тривоги|Повернення енергії");
            Tri(r2, "Retreat", "ImageUrl", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=1200&q=80");
            Tri(r2, "Retreat", "Duration", "3 дня", "3 days", "3 дні");
            Tri(r2, "Retreat", "Location", "Вне города", "Outside the city", "За містом");
            Tri(r2, "Retreat", "Format", "Офлайн", "In person", "Офлайн");
            Tri(r2, "Retreat", "PriceLabel", "По запросу", "On request", "За запитом");
            Tri(r2, "Retreat", "ForWhom", "Опытным практикам~Углубление тишины|Всем, кто устал~Перезагрузка без лишнего", "Experienced practitioners~Deepening silence|Anyone tired~A reset without extras", "Досвідченим практикам~Поглиблення тиші|Усім, хто втомився~Перезавантаження без зайвого");
            Tri(r2, "Retreat", "CtaHeading", "Записаться на ретрит", "Sign up for the retreat", "Записатися на ретрит");
            Tri(r2, "Retreat", "CtaText", "Напишите — подскажем даты и условия.", "Write to us — we'll share dates and details.", "Напишіть — підкажемо дати й умови.");

            // Yagyas
            Tri(y1, "Yagya", "Title", "Огненная церемония", "Fire ceremony", "Вогняна церемонія");
            Tri(y1, "Yagya", "Subtitle", "Очищение через огонь", "Purification through fire", "Очищення через вогонь");
            Tri(y1, "Yagya", "Eyebrow", "Ягья", "Yagya", "Ягʼя");
            Tri(y1, "Yagya", "Description", "Групповой ведический ритуал с мантрами и подношениями огню.", "A group Vedic ritual with mantras and fire offerings.", "Груповий ведичний ритуал з мантрами та підношеннями вогню.");
            Tri(y1, "Yagya", "Benefits", "Очищение пространства|Совместная медитация|Символическое обновление", "Space cleansing|Group meditation|Symbolic renewal", "Очищення простору|Спільна медитація|Символічне оновлення");
            Tri(y1, "Yagya", "ImageUrl", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1200&q=80");
            Tri(y1, "Yagya", "Duration", "2–3 часа", "2–3 hours", "2–3 години");
            Tri(y1, "Yagya", "Format", "Очно", "In person", "Очно");
            Tri(y1, "Yagya", "PriceLabel", "Пожертвование", "Donation", "Пожертва");
            Tri(y1, "Yagya", "ForWhom", "Всем желающим~Опыт не обязателен|Практикующим~Дополнение к практике", "Everyone~No experience needed|Practitioners~A complement to practice", "Усім бажаючим~Досвід не обов'язковий|Практикуючим~Доповнення до практики");
            Tri(y1, "Yagya", "CtaHeading", "Участвовать", "Join", "Взяти участь");
            Tri(y1, "Yagya", "CtaText", "Оставьте заявку — пришлём детали ближайшей церемонии.", "Apply — we'll send details of the next ceremony.", "Залиште заявку — надішлемо деталі найближчої церемонії.");

            Tri(y2, "Yagya", "Title", "Новогоднее намерение", "New Year intention", "Новорічний намір");
            Tri(y2, "Yagya", "Subtitle", "Вход в новый цикл осознанно", "Entering a new cycle mindfully", "Вхід у новий цикл усвідомлено");
            Tri(y2, "Yagya", "Eyebrow", "Ягья", "Yagya", "Ягʼя");
            Tri(y2, "Yagya", "Description", "Церемония коллективного намерения в преддверии нового года.", "A ceremony of collective intention on the eve of the new year.", "Церемонія колективного наміру напередодні нового року.");
            Tri(y2, "Yagya", "Benefits", "Ясность целей|Энергия группы|Ритуал перехода", "Clarity of goals|Group energy|A rite of passage", "Ясність цілей|Енергія групи|Ритуал переходу");
            Tri(y2, "Yagya", "ImageUrl", "https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80", "https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80");
            Tri(y2, "Yagya", "Duration", "3 часа", "3 hours", "3 години");
            Tri(y2, "Yagya", "Format", "Очно", "In person", "Очно");
            Tri(y2, "Yagya", "PriceLabel", "Пожертвование", "Donation", "Пожертва");
            Tri(y2, "Yagya", "ForWhom", "Всем~Открытое мероприятие|Семьям~Можно с детьми от 7 лет", "Everyone~Open event|Families~Children 7+ welcome", "Усім~Відкритий захід|Родинам~Можна з дітьми від 7 років");
            Tri(y2, "Yagya", "CtaHeading", "Присоединиться", "Join", "Приєднатися");
            Tri(y2, "Yagya", "CtaText", "Узнайте дату и место — оставьте заявку.", "Find out the date and venue — apply now.", "Дізнайтеся дату й місце — залиште заявку.");

            return list.ToArray();
        }

        private static Translation[] BuildSitePageSectionTranslations(Guid retreatsId, Guid yagyasId, Guid blogId)
        {
            var list = new List<Translation>();
            var n = 0;

            void Tri(Guid entityId, string field, string ru, string en, string uk)
            {
                foreach (var (lang, val) in new[] { ("ru", ru), ("en", en), ("uk", uk) })
                {
                    n++;
                    list.Add(new Translation
                    {
                        Id = Guid.Parse($"cccccccc-cccc-4ccc-8ccc-{n:D12}"),
                        EntityId = entityId,
                        EntityType = "SitePage",
                        Field = field,
                        Language = lang,
                        Value = val
                    });
                }
            }

            Tri(retreatsId, "MetaTitle", "Ретриты | shakti.ashram", "Retreats | shakti.ashram", "Ретрити | shakti.ashram");
            Tri(retreatsId, "HeroTitle", "Ретриты", "Retreats", "Ретрити");
            Tri(retreatsId, "HeroSubtitle", "Погружение в практику вне суеты повседневности.", "Immersion in practice away from everyday rush.", "Занурення в практику поза метушнею буднів.");
            Tri(retreatsId, "HeroImageUrl", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1600&q=80");
            Tri(retreatsId, "Content", "<p>Здесь появятся анонсы ретритов и подробности программ. Чтобы узнать о ближайших датах, <a href=\"/contacts\">свяжитесь с нами</a>.</p>", "<p>Retreat announcements and programme details will appear here. To ask about upcoming dates, <a href=\"/contacts\">contact us</a>.</p>", "<p>Тут з’являться анонси ретритів і деталі програм. Щоб дізнатися про найближчі дати, <a href=\"/contacts\">напишіть нам</a>.</p>");

            Tri(yagyasId, "MetaTitle", "Ягьи | shakti.ashram", "Yagyas | shakti.ashram", "Ягʼї | shakti.ashram");
            Tri(yagyasId, "HeroTitle", "Ягьи", "Yagyas", "Ягʼї");
            Tri(yagyasId, "HeroSubtitle", "Совместные ритуалы и практики для общего намерения.", "Group rituals and practices for a shared intention.", "Спільні ритуали та практики для спільного наміру.");
            Tri(yagyasId, "HeroImageUrl", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1600&q=80");
            Tri(yagyasId, "Content", "<p>Расписание и описание ягьев будет публиковаться на этой странице. По вопросам участия напишите через <a href=\"/contacts\">контакты</a>.</p>", "<p>Schedules and descriptions of yagyas will be published here. For participation questions, use our <a href=\"/contacts\">contacts page</a>.</p>", "<p>Розклад і опис ягʼїв публікуватимуться тут. З питань участі звертайтеся через <a href=\"/contacts\">контакти</a>.</p>");

            Tri(blogId, "MetaTitle", "Блог | shakti.ashram", "Blog | shakti.ashram", "Блог | shakti.ashram");
            Tri(blogId, "HeroTitle", "Блог", "Blog", "Блог");
            Tri(blogId, "HeroSubtitle", "Статьи, заметки и материалы для практики.", "Articles, notes and materials for practice.", "Статті, нотатки та матеріали для практики.");
            Tri(blogId, "HeroImageUrl", "https://images.unsplash.com/photo-1499750310107-5fef28a66643?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1499750310107-5fef28a66643?auto=format&fit=crop&w=1600&q=80", "https://images.unsplash.com/photo-1499750310107-5fef28a66643?auto=format&fit=crop&w=1600&q=80");
            Tri(blogId, "Content", "<p>Публикации блога появятся здесь. Подпишитесь на наши каналы в <a href=\"/contacts\">соцсетях</a>, чтобы не пропустить выход материалов.</p>", "<p>Blog posts will appear here. Follow our channels via <a href=\"/contacts\">contacts</a> so you do not miss new materials.</p>", "<p>Публікації блогу з’являтимуться тут. Слідкуйте за нашими каналами у <a href=\"/contacts\">соцмережах</a>, щоб не пропустити матеріали.</p>");

            return list.ToArray();
        }
    }
}
