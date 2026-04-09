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
        public DbSet<SitePage> SitePages => Set<SitePage>();
        public DbSet<UiTranslation> UiTranslations => Set<UiTranslation>();

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

            var pageAbout = Guid.Parse("44444444-4444-4444-4444-444444444401");
            var pageContacts = Guid.Parse("44444444-4444-4444-4444-444444444402");
            var pageHome = Guid.Parse("44444444-4444-4444-4444-444444444403");
            var pageCourses = Guid.Parse("44444444-4444-4444-4444-444444444404");
            var pageConsultations = Guid.Parse("44444444-4444-4444-4444-444444444405");

            modelBuilder.Entity<SitePage>().HasData(
                new SitePage { Id = pageAbout, Slug = "about" },
                new SitePage { Id = pageContacts, Slug = "contacts" },
                new SitePage { Id = pageHome, Slug = "home" },
                new SitePage { Id = pageCourses, Slug = "courses" },
                new SitePage { Id = pageConsultations, Slug = "consultations" });

            var translations = BuildSeedTranslations(
                coursePranavidya, courseMeditation, courseYoga,
                consultSpiritual, consultYouth, consultPersonal);

            modelBuilder.Entity<Translation>().HasData(translations);
        }

        private static Translation[] BuildSeedTranslations(
            Guid c1, Guid c2, Guid c3,
            Guid s1, Guid s2, Guid s3)
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

            return list.ToArray();
        }
    }
}
