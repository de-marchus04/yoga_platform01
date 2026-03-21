using Microsoft.EntityFrameworkCore;
using Yoga.Shared.Models;

namespace Yoga.Api.Data
{
    public class AppDbContext : DbContext
    {
        private const string SeedAdminPasswordHash = "$2a$11$5GzmO4VSpubKXylzDjfXpuaxwNy.1b3yEaWf8Qdps3a2.cKQBwz7O";

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Retreat> Retreats { get; set; }
        public DbSet<Yagya> Yagyas { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<SitePage> SitePages { get; set; }
        public DbSet<UiTranslation> UiTranslations { get; set; }
        
        // Customer domain
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
        public DbSet<CustomerAccessGrant> CustomerAccessGrants { get; set; }
        public DbSet<PremiumResource> PremiumResources { get; set; }
        public DbSet<LiveEvent> LiveEvents { get; set; }
        public DbSet<AdminAuditLog> AdminAuditLogs { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Any specific configurations, e.g.
            modelBuilder.Entity<Lead>().HasKey(l => l.Id);
            modelBuilder.Entity<Retreat>().HasKey(r => r.Id);
            modelBuilder.Entity<Yagya>().HasKey(y => y.Id);
            modelBuilder.Entity<AdminUser>().HasKey(a => a.Id);

            // Translations unique index
            modelBuilder.Entity<Translation>()
                .HasIndex(t => new { t.EntityType, t.EntityId, t.Field, t.Language })
                .IsUnique();

            // UiTranslations unique index
            modelBuilder.Entity<UiTranslation>()
                .HasIndex(u => new { u.Key, u.Language })
                .IsUnique();

            // MediaFiles index
            modelBuilder.Entity<MediaFile>()
                .HasIndex(m => new { m.EntityType, m.EntityId, m.SortOrder });

            // CourseModule FK
            modelBuilder.Entity<CourseModule>()
                .HasOne(cm => cm.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(cm => cm.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // CourseLesson FK
            modelBuilder.Entity<CourseLesson>()
                .HasOne(cl => cl.Module)
                .WithMany(m => m.Lessons)
                .HasForeignKey(cl => cl.CourseModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            // ── Customer domain ──
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<CustomerSubscription>()
                .HasOne(s => s.Customer)
                .WithOne(c => c.Subscription)
                .HasForeignKey<CustomerSubscription>(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerAccessGrant>()
                .HasOne(g => g.Customer)
                .WithMany(c => c.AccessGrants)
                .HasForeignKey(g => g.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CustomerAccessGrant>()
                .HasIndex(g => new { g.CustomerId, g.AccessType });

            modelBuilder.Entity<PremiumResource>().HasKey(r => r.Id);
            modelBuilder.Entity<LiveEvent>().HasKey(e => e.Id);
            modelBuilder.Entity<LiveEvent>()
                .HasIndex(e => e.Status);
            modelBuilder.Entity<AdminAuditLog>().HasKey(a => a.Id);
            modelBuilder.Entity<AdminAuditLog>()
                .HasIndex(a => a.CreatedAt);
            modelBuilder.Entity<AdminAuditLog>()
                .HasIndex(a => new { a.EntityType, a.EntityId, a.CreatedAt });

            modelBuilder.Entity<PasswordResetToken>().HasKey(t => t.Id);
            modelBuilder.Entity<PasswordResetToken>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.Token)
                .IsUnique();

            // Seed SuperAdmin Default
            modelBuilder.Entity<AdminUser>().HasData(new AdminUser
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "admin",
                PasswordHash = SeedAdminPasswordHash,
                DisplayName = "Администратор",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            // Seed example Retreat
            var retreatId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            modelBuilder.Entity<Retreat>().HasData(new Retreat
            {
                Id = retreatId,
                Title = "Ретрит в Черногории: Возврат к себе",
                Description = "Погружение в себя на берегу Адриатического моря. Практики тишины, йога 2 раза в день, авторское меню и детокс.",
                Location = "Будва, Черногория",
                StartDate = new DateTime(2026, 5, 10, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2026, 5, 17, 0, 0, 0, DateTimeKind.Utc),
                IsActive = true
            });

            // Seed retreat translations (ru, en, uk)
            modelBuilder.Entity<Translation>().HasData(
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000001"), EntityType = "Retreat", EntityId = retreatId, Field = "Title", Language = "ru", Value = "Ретрит в Черногории: Возврат к себе" },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000002"), EntityType = "Retreat", EntityId = retreatId, Field = "Description", Language = "ru", Value = "Погружение в себя на берегу Адриатического моря. Практики тишины, йога 2 раза в день, авторское меню и детокс." },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000003"), EntityType = "Retreat", EntityId = retreatId, Field = "Location", Language = "ru", Value = "Будва, Черногория" },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000004"), EntityType = "Retreat", EntityId = retreatId, Field = "Title", Language = "en", Value = "Retreat in Montenegro: Return to Yourself" },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000005"), EntityType = "Retreat", EntityId = retreatId, Field = "Description", Language = "en", Value = "A deep dive into yourself on the shores of the Adriatic Sea. Silence practices, yoga twice a day, a curated menu and detox." },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000006"), EntityType = "Retreat", EntityId = retreatId, Field = "Location", Language = "en", Value = "Budva, Montenegro" },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000007"), EntityType = "Retreat", EntityId = retreatId, Field = "Title", Language = "uk", Value = "Ретрит у Чорногорії: Повернення до себе" },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000008"), EntityType = "Retreat", EntityId = retreatId, Field = "Description", Language = "uk", Value = "Занурення в себе на березі Адріатичного моря. Практики тиші, йога 2 рази на день, авторське меню та детокс." },
                new Translation { Id = Guid.Parse("a0000001-0001-0001-0001-000000000009"), EntityType = "Retreat", EntityId = retreatId, Field = "Location", Language = "uk", Value = "Будва, Чорногорія" }
            );

            // Seed Courses
            var coursePranayama = Guid.Parse("22222222-2222-2222-2222-222222222201");
            var courseMeditation = Guid.Parse("22222222-2222-2222-2222-222222222202");
            var courseYoga = Guid.Parse("22222222-2222-2222-2222-222222222203");
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = coursePranayama, Slug = "pranayama", SortOrder = 1, IsActive = true },
                new Course { Id = courseMeditation, Slug = "meditation", SortOrder = 2, IsActive = true },
                new Course { Id = courseYoga, Slug = "yoga", SortOrder = 3, IsActive = true }
            );

            // Seed Consultations
            var consultEnergy = Guid.Parse("33333333-3333-3333-3333-333333333301");
            var consultAyurveda = Guid.Parse("33333333-3333-3333-3333-333333333302");
            var consultSpirit = Guid.Parse("33333333-3333-3333-3333-333333333303");
            modelBuilder.Entity<Consultation>().HasData(
                new Consultation { Id = consultEnergy, Slug = "energy", SortOrder = 1, IsActive = true },
                new Consultation { Id = consultAyurveda, Slug = "ayurveda", SortOrder = 2, IsActive = true },
                new Consultation { Id = consultSpirit, Slug = "spirituality", SortOrder = 3, IsActive = true }
            );

            // Seed SitePages
            var pageAbout = Guid.Parse("44444444-4444-4444-4444-444444444401");
            var pageContacts = Guid.Parse("44444444-4444-4444-4444-444444444402");
            var pageHome = Guid.Parse("44444444-4444-4444-4444-444444444403");
            var pageCourses = Guid.Parse("44444444-4444-4444-4444-444444444404");
            var pageConsultations = Guid.Parse("44444444-4444-4444-4444-444444444405");
            var pageBlog = Guid.Parse("44444444-4444-4444-4444-444444444406");
            var pageRetreats = Guid.Parse("44444444-4444-4444-4444-444444444407");
            var pageYagyas = Guid.Parse("44444444-4444-4444-4444-444444444408");
            modelBuilder.Entity<SitePage>().HasData(
                new SitePage { Id = pageAbout, Slug = "about" },
                new SitePage { Id = pageContacts, Slug = "contacts" },
                new SitePage { Id = pageHome, Slug = "home" },
                new SitePage { Id = pageCourses, Slug = "courses" },
                new SitePage { Id = pageConsultations, Slug = "consultations" },
                new SitePage { Id = pageBlog, Slug = "blog" },
                new SitePage { Id = pageRetreats, Slug = "retreats" },
                new SitePage { Id = pageYagyas, Slug = "yagyas" }
            );

            // ==== Seed UiTranslations ====
            SeedUiTranslations(modelBuilder);
        }

        private static void SeedUiTranslations(ModelBuilder modelBuilder)
        {
            var items = new List<UiTranslation>();
            int seq = 0;

            void Add(string key, string ru, string en, string uk)
            {
                seq++;
                var baseId = "b0000000-0000-0000-0000-";
                items.Add(new UiTranslation { Id = Guid.Parse(baseId + seq.ToString("D12")), Key = key, Language = "ru", Value = ru });
                seq++;
                items.Add(new UiTranslation { Id = Guid.Parse(baseId + seq.ToString("D12")), Key = key, Language = "en", Value = en });
                seq++;
                items.Add(new UiTranslation { Id = Guid.Parse(baseId + seq.ToString("D12")), Key = key, Language = "uk", Value = uk });
            }

            // Navigation
            Add("nav.home", "Главная", "Home", "Головна");
            Add("nav.courses", "Курсы", "Courses", "Курси");
            Add("nav.courses.pranayama", "Пранавидья", "Pranavidya", "Пранавід'я");
            Add("nav.courses.meditation", "Медитация", "Meditation", "Медитація");
            Add("nav.courses.yoga", "Йога", "Yoga", "Йога");
            Add("nav.consultations", "Консультации", "Consultations", "Консультації");
            Add("nav.consultations.energy", "Энергетика", "Energetics", "Енергетика");
            Add("nav.consultations.ayurveda", "Для подростков", "For Teenagers", "Для підлітків");
            Add("nav.consultations.spirituality", "Духовность", "Spirituality", "Духовність");
            Add("nav.retreats", "Ретриты", "Retreats", "Ретрити");
            Add("nav.retreats.actual", "Актуальные", "Current", "Актуальні");
            Add("nav.retreats.upcoming", "Предстоящие", "Upcoming", "Майбутні");
            Add("nav.retreats.past", "Прошедшие", "Past", "Минулі");
            Add("nav.yagyas", "Ягьи", "Yagyas", "Яг'ї");
            Add("nav.yagyas.upcoming", "Предстоящие", "Upcoming", "Майбутні");
            Add("nav.yagyas.past", "Прошедшие", "Past", "Минулі");
            Add("nav.blog", "Блог", "Blog", "Блог");
            Add("nav.blog.articles", "Статьи", "Articles", "Статті");
            Add("nav.blog.videos", "Видео", "Videos", "Відео");
            Add("nav.blog.photos", "Фото", "Photos", "Фото");
            Add("nav.about", "О нас", "About", "Про нас");
            Add("nav.contacts", "Контакты", "Contact", "Контакти");

            // Footer
            Add("footer.copy", "© 2026 Yoga.Life Enterprise. Возврат к истокам.", "© 2026 Yoga.Life Enterprise. A return to origins.", "© 2026 Yoga.Life Enterprise. Повернення до витоків.");

            // Home — Hero
            Add("page.home.title", "Yoga.Life | Авторские Ретриты", "Yoga.Life | Author-Led Retreats", "Yoga.Life | Авторські Ретрити");
            Add("page.home.hero.eyebrow", "Yoga · Life · Enterprise", "Yoga · Life · Enterprise", "Yoga · Life · Enterprise");
            Add("page.home.hero.h1.line1", "Возврат", "Return", "Повернення");
            Add("page.home.hero.h1.em", "к себе", "to yourself", "до себе");
            Add("page.home.hero.text", "Авторские ретриты и программы обучения. Погружение в тишину, практики осознанности и полное обновление.", "Author-led retreats and training programmes. A plunge into stillness, mindfulness practices and complete renewal.", "Авторські ретрити та навчальні програми. Занурення в тишу, практики усвідомленості та повне оновлення.");
            Add("page.home.hero.cta", "Записаться", "Sign up", "Записатися");

            // Home — Stats
            Add("page.home.stats.retreats", "Ретритов", "Retreats", "Ретритів");
            Add("page.home.stats.members", "Участников", "Participants", "Учасників");
            Add("page.home.stats.countries", "Стран", "Countries", "Країн");
            Add("page.home.stats.years", "Лет практики", "Years of practice", "Років практики");

            // Home — Retreats section
            Add("page.home.retreats.eyebrow", "Программы", "Programmes", "Програми");
            Add("page.home.retreats.h2", "Ближайшие ретриты", "Upcoming Retreats", "Найближчі ретрити");
            Add("page.home.retreats.loading", "Загрузка расписания...", "Loading schedule...", "Завантаження розкладу...");
            Add("page.home.retreats.empty", "Нет доступных ретритов в данный момент.", "No retreats currently available.", "Немає доступних ретритів на даний момент.");
            Add("page.home.retreats.cta", "Хочу сюда", "I want to go", "Хочу сюди");

            // Home — Directions
            Add("page.home.directions.eyebrow", "Что мы предлагаем", "What we offer", "Що ми пропонуємо");
            Add("page.home.directions.h2", "Направления", "Directions", "Напрямки");
            Add("page.home.directions.01", "01", "01", "01");
            Add("page.home.directions.01.h3", "Курсы", "Courses", "Курси");
            Add("page.home.directions.01.text", "Пранаяма, медитация, йога — системные программы для углублённой практики в любом темпе.", "Pranayama, meditation, yoga — structured programmes for deepening your practice at your own pace.", "Пранаяма, медитація, йога — системні програми для поглибленої практики в будь-якому темпі.");
            Add("page.home.directions.01.link", "Смотреть курсы →", "View courses →", "Дивитися курси →");
            Add("page.home.directions.02", "02", "02", "02");
            Add("page.home.directions.02.h3", "Консультации", "Consultations", "Консультації");
            Add("page.home.directions.02.text", "Индивидуальный разбор по энергетике, аюрведе и духовным практикам с личным куратором.", "Individual session on energetics, Ayurveda and spiritual practices with a personal mentor.", "Індивідуальний розбір з енергетики, аюрведи та духовних практик з особистим куратором.");
            Add("page.home.directions.02.link", "Записаться →", "Book a session →", "Записатися →");
            Add("page.home.directions.03", "03", "03", "03");
            Add("page.home.directions.03.h3", "Ретриты", "Retreats", "Ретрити");
            Add("page.home.directions.03.text", "Выездные программы в Черногории, Индии и других локациях. От 7 до 21 дня полного погружения.", "Immersive programmes in Montenegro, India and beyond. From 7 to 21 days of full immersion.", "Виїзні програми в Чорногорії, Індії та інших локаціях. Від 7 до 21 дня повного занурення.");
            Add("page.home.directions.03.link", "Все ретриты →", "All retreats →", "Всі ретрити →");

            // Home — Quote
            Add("page.home.quote.line1", "«Йога — это не то, что вы делаете на коврике.", "«Yoga is not what you do on the mat.", "«Йога — це не те, що ви робите на килимку.");
            Add("page.home.quote.line2", "Это то, кем вы становитесь — за его пределами.»", "It is who you become — beyond it.»", "Це те, ким ви стаєте — за його межами.»");
            Add("page.home.quote.by", "— Yoga.Life", "— Yoga.Life", "— Yoga.Life");

            // Home — Formats
            Add("page.home.formats.eyebrow1", "Формат I", "Format I", "Формат I");
            Add("page.home.formats.h2.1", "Онлайн", "Online", "Онлайн");
            Add("page.home.formats.text1", "Практикуйте из любой точки мира. Живые сессии, записи, индивидуальная обратная связь от куратора в вашем ритме.", "Practice from anywhere in the world. Live sessions, recordings, personal feedback from your mentor at your own pace.", "Практикуйте з будь-якої точки світу. Живі сесії, записи, індивідуальний зворотній зв'язок від куратора у вашому ритмі.");
            Add("page.home.formats.cta1", "Онлайн-курсы", "Online courses", "Онлайн-курси");
            Add("page.home.formats.eyebrow2", "Формат II", "Format II", "Формат II");
            Add("page.home.formats.h2.2", "Офлайн", "In-person", "Офлайн");
            Add("page.home.formats.text2", "Живое присутствие и глубокое взаимодействие. Ретриты и интенсивы в сакральных местах силы.", "Real presence and deep connection. Retreats and intensives in sacred places of power.", "Жива присутність і глибока взаємодія. Ретрити та інтенсиви в сакральних місцях сили.");
            Add("page.home.formats.cta2", "Ретриты и выезды", "Retreats & travel", "Ретрити і виїзди");

            // Home — Reviews
            Add("page.home.reviews.eyebrow", "Отзывы", "Reviews", "Відгуки");
            Add("page.home.reviews.h2", "Говорят участники", "What participants say", "Говорять учасники");
            Add("page.home.reviews.1.quote", "«После ретрита в Черногории я впервые за несколько лет почувствовала, что тело и голова — в одном месте. Это был настоящий перезапуск.»", "«After the Montenegro retreat I felt, for the first time in years, that my body and mind were in the same place. It was a true reset.»", "«Після ретриту в Чорногорії я вперше за кілька років відчула, що тіло і голова — в одному місці. Це був справжній перезапуск.»");
            Add("page.home.reviews.1.name", "Анна К.", "Anna K.", "Анна К.");
            Add("page.home.reviews.1.program", "Ретрит «Черногория, сентябрь»", "Retreat 'Montenegro, September'", "Ретрит «Чорногорія, вересень»");
            Add("page.home.reviews.2.quote", "«Курс по пранаяме изменил моё отношение к дыханию и к жизни в целом. Простые техники, которые работают каждый день.»", "«The pranayama course changed my relationship with breathing — and with life itself. Simple techniques that work every single day.»", "«Курс з пранаями змінив моє ставлення до дихання і до життя загалом. Прості техніки, які працюють щодня.»");
            Add("page.home.reviews.2.name", "Михаил Р.", "Mikhail R.", "Михайло Р.");
            Add("page.home.reviews.2.program", "Курс «Пранаяма: базовый»", "Course 'Pranayama: Foundations'", "Курс «Пранаяма: базовий»");
            Add("page.home.reviews.3.quote", "«Индивидуальная консультация по аюрведе дала мне план на год вперёд — питание, режим, практики. Всё чётко и без лишней эзотерики.»", "«The Ayurveda consultation gave me a year-long plan — nutrition, daily routine, practices. Clear and without unnecessary mysticism.»", "«Індивідуальна консультація з аюрведи дала мені план на рік вперед — харчування, режим, практики. Все чітко і без зайвої езотерики.»");
            Add("page.home.reviews.3.name", "Светлана В.", "Svetlana V.", "Світлана В.");
            Add("page.home.reviews.3.program", "Консультация «Аюрведа»", "Consultation 'Ayurveda'", "Консультація «Аюрведа»");

            // Home — Blog
            Add("page.home.blog.eyebrow", "Из блога", "From the blog", "З блогу");
            Add("page.home.blog.h2", "Статьи и размышления", "Articles & reflections", "Статті та роздуми");
            Add("page.home.blog.1.tag", "Практика", "Practice", "Практика");
            Add("page.home.blog.1.h3", "Пранаяма для начинающих: 5 техник, которые изменят качество сна", "Pranayama for beginners: 5 techniques that will transform your sleep", "Пранаяма для початківців: 5 технік, які змінять якість сну");
            Add("page.home.blog.1.text", "Простые дыхательные упражнения, которые можно выполнять лёжа в постели — без коврика и специального оборудования.", "Simple breathing exercises you can do lying in bed — no mat or special equipment required.", "Прості дихальні вправи, які можна виконувати лежачи в ліжку — без килимка і спеціального обладнання.");
            Add("page.home.blog.2.tag", "Философия", "Philosophy", "Філософія");
            Add("page.home.blog.2.h3", "Ахимса в повседневности: как принцип ненасилия работает вне коврика", "Ahimsa in daily life: how the non-violence principle works off the mat", "Ахімса у повсякденності: як принцип ненасилля працює поза килимком");
            Add("page.home.blog.2.text", "О том, как одно из базовых правил йоги можно применять в разговорах, питании и отношении к себе.", "How one of yoga's foundational rules can be applied in conversations, diet and your relationship with yourself.", "Про те, як одне з базових правил йоги можна застосовувати в розмовах, харчуванні та ставленні до себе.");
            Add("page.home.blog.3.tag", "Ретриты", "Retreats", "Ретрити");
            Add("page.home.blog.3.h3", "Почему 7 дней тишины меняют больше, чем год терапии", "Why 7 days of silence changes more than a year of therapy", "Чому 7 днів тиші змінюють більше, ніж рік терапії");
            Add("page.home.blog.3.text", "Личный опыт и разбор механизмов: что происходит с нервной системой в условиях глубокой тишины и отрыва от привычной среды.", "Personal experience and analysis: what happens to the nervous system in conditions of deep silence and disconnection from everyday life.", "Особистий досвід і розбір механізмів: що відбувається з нервовою системою в умовах глибокої тиші та відриву від звичного середовища.");
            Add("page.home.blog.readmore", "Читать →", "Read →", "Читати →");
            Add("page.home.blog.all", "Все статьи", "All articles", "Всі статті");

            // Home — CTA
            Add("page.home.cta.eyebrow", "Следующий шаг", "Next step", "Наступний крок");
            Add("page.home.cta.h2", "Готовы к изменениям?", "Ready for change?", "Готові до змін?");
            Add("page.home.cta.text", "Оставьте заявку — мы подберём программу, которая подойдёт именно вам.", "Leave a request — we'll find the programme that's right for you.", "Залиште заявку — ми підберемо програму, яка підійде саме вам.");
            Add("page.home.cta.btn", "Хочу попасть на программу", "I want to join a programme", "Хочу потрапити на програму");

            // Courses
            Add("page.courses.title", "Курсы | Yoga.Life", "Courses | Yoga.Life", "Курси | Yoga.Life");
            Add("page.courses.h1", "Курсы", "Courses", "Курси");
            Add("page.courses.sub", "Выберите направление.", "Choose a direction.", "Оберіть напрямок.");
            Add("page.courses.pranayama.title", "Пранавидья | Yoga.Life", "Pranavidya | Yoga.Life", "Пранавід'я | Yoga.Life");
            Add("page.courses.pranayama.h1", "Пранавидья", "Pranavidya", "Пранавід'я");
            Add("page.courses.meditation.title", "Медитация | Yoga.Life", "Meditation | Yoga.Life", "Медитація | Yoga.Life");
            Add("page.courses.meditation.h1", "Медитация", "Meditation", "Медитація");
            Add("page.courses.yoga.title", "Йога | Yoga.Life", "Yoga | Yoga.Life", "Йога | Yoga.Life");
            Add("page.courses.yoga.h1", "Йога", "Yoga", "Йога");

            // Consultations
            Add("page.consultations.title", "Консультации | Yoga.Life", "Consultations | Yoga.Life", "Консультації | Yoga.Life");
            Add("page.consultations.h1", "Консультации", "Consultations", "Консультації");
            Add("page.consultations.energy.title", "Энергетика | Yoga.Life", "Energetics | Yoga.Life", "Енергетика | Yoga.Life");
            Add("page.consultations.energy.h1", "Энергетика", "Energetics", "Енергетика");
            Add("page.consultations.ayurveda.title", "Для подростков | Yoga.Life", "For Teenagers | Yoga.Life", "Для підлітків | Yoga.Life");
            Add("page.consultations.ayurveda.h1", "Для подростков", "For Teenagers", "Для підлітків");
            Add("page.consultations.spirituality.title", "Духовность | Yoga.Life", "Spirituality | Yoga.Life", "Духовність | Yoga.Life");
            Add("page.consultations.spirituality.h1", "Духовность", "Spirituality", "Духовність");

            // Retreats
            Add("page.retreats.actual.title", "Актуальные ретриты | Yoga.Life", "Current Retreats | Yoga.Life", "Актуальні ретрити | Yoga.Life");
            Add("page.retreats.actual.h1", "Актуальные ретриты", "Current Retreats", "Актуальні ретрити");
            Add("page.retreats.upcoming.title", "Предстоящие ретриты | Yoga.Life", "Upcoming Retreats | Yoga.Life", "Майбутні ретрити | Yoga.Life");
            Add("page.retreats.upcoming.h1", "Предстоящие ретриты", "Upcoming Retreats", "Майбутні ретрити");
            Add("page.retreats.past.title", "Прошедшие ретриты | Yoga.Life", "Past Retreats | Yoga.Life", "Минулі ретрити | Yoga.Life");
            Add("page.retreats.past.h1", "Прошедшие ретриты", "Past Retreats", "Минулі ретрити");
            Add("page.yagyas.title", "Ягьи | Yoga.Life", "Yagyas | Yoga.Life", "Яг'ї | Yoga.Life");
            Add("page.yagyas.h1", "Ягьи", "Yagyas", "Яг'ї");
            Add("page.yagyas.eyebrow", "Огненные практики", "Fire ceremonies", "Вогняні практики");
            Add("page.yagyas.intro", "Предстоящие и прошедшие ягьи с описанием намерения, формата участия и ключевых дат.", "Upcoming and past yagyas with the intention, format and key dates.", "Майбутні та минулі яг'ї з описом наміру, формату участі та ключових дат.");
            Add("page.yagyas.upcoming.title", "Предстоящие ягьи | Yoga.Life", "Upcoming Yagyas | Yoga.Life", "Майбутні яг'ї | Yoga.Life");
            Add("page.yagyas.upcoming.h1", "Предстоящие ягьи", "Upcoming Yagyas", "Майбутні яг'ї");
            Add("page.yagyas.upcoming.intro", "Ближайшие церемонии, к которым можно присоединиться сейчас.", "The next ceremonies you can join now.", "Найближчі церемонії, до яких можна долучитися зараз.");
            Add("page.yagyas.past.title", "Прошедшие ягьи | Yoga.Life", "Past Yagyas | Yoga.Life", "Минулі яг'ї | Yoga.Life");
            Add("page.yagyas.past.h1", "Прошедшие ягьи", "Past Yagyas", "Минулі яг'ї");
            Add("page.yagyas.past.intro", "Архив проведённых ягий с программой, местом и основным фокусом церемонии.", "Archive of completed yagyas with program, location and ceremony focus.", "Архів проведених яг'ї з програмою, локацією та головним фокусом церемонії.");
            Add("page.yagyas.empty", "Ягьи пока не опубликованы.", "No yagyas have been published yet.", "Яг'ї ще не опубліковані.");
            Add("page.yagyas.card.cta", "Оставить заявку", "Send request", "Залишити заявку");
            Add("page.yagya.detail.loading", "Загрузка...", "Loading...", "Завантаження...");
            Add("page.yagya.detail.back", "Все ягьи", "All yagyas", "Усі яг'ї");
            Add("page.yagya.detail.about_eyebrow", "О церемонии", "About the ceremony", "Про церемонію");
            Add("page.yagya.detail.about_h2", "Описание и намерение", "Description and intention", "Опис і намір");
            Add("page.yagya.detail.program_eyebrow", "Программа", "Program", "Програма");
            Add("page.yagya.detail.program_h2", "Как проходит ягья", "How the yagya unfolds", "Як проходить яг'я");
            Add("page.yagya.detail.booking_h3", "Присоединиться к ягье", "Join the yagya", "Долучитися до яг'ї");
            Add("page.yagya.detail.other_eyebrow", "Другие ягьи", "Other yagyas", "Інші яг'ї");
            Add("page.yagya.detail.other_h2", "Смотрите также", "See also", "Дивіться також");
            Add("page.yagya.detail.other_cta", "Подробнее →", "Learn more →", "Детальніше →");

            // Blog
            Add("page.blog.title", "Блог | Yoga.Life", "Blog | Yoga.Life", "Блог | Yoga.Life");
            Add("page.blog.h1", "Блог", "Blog", "Блог");
            Add("page.blog.articles.title", "Статьи | Yoga.Life", "Articles | Yoga.Life", "Статті | Yoga.Life");
            Add("page.blog.articles.h1", "Статьи", "Articles", "Статті");
            Add("page.blog.videos.title", "Видео | Yoga.Life", "Videos | Yoga.Life", "Відео | Yoga.Life");
            Add("page.blog.videos.h1", "Видео", "Videos", "Відео");
            Add("page.blog.photos.title", "Фото | Yoga.Life", "Photos | Yoga.Life", "Фото | Yoga.Life");
            Add("page.blog.photos.h1", "Фото", "Photos", "Фото");

            // About & Contacts
            Add("page.about.title", "О нас | Yoga.Life", "About | Yoga.Life", "Про нас | Yoga.Life");
            Add("page.about.h1", "О нас", "About Us", "Про нас");
            Add("page.contacts.title", "Контакты | Yoga.Life", "Contact | Yoga.Life", "Контакти | Yoga.Life");
            Add("page.contacts.h1", "Контакты", "Contact", "Контакти");

            // Form (LeadModal)
            Add("form.heading", "Записаться", "Sign Up", "Записатися");
            Add("form.subtext", "Оставьте свои контакты, и мы свяжемся с вами для уточнения деталей.", "Leave your details and we'll be in touch to confirm.", "Залиште контакти — ми зв'яжемось для уточнення деталей.");
            Add("form.context_prefix", "Запись на", "Sign up for", "Запис на");
            Add("form.name", "Ваше имя", "Your name", "Ваше ім'я");
            Add("form.messenger", "В каком мессенджере связаться?", "Preferred messenger", "Месенджер для зв'язку");
            Add("form.phone_call", "Звонок", "Phone call", "Дзвінок");
            Add("form.contact", "Номер телефона или Никнейм", "Phone number or username", "Номер телефону або нікнейм");
            Add("form.comment", "Комментарий (пожелания, вопросы)", "Comment (wishes, questions)", "Коментар (побажання, питання)");
            Add("form.submit", "Оставить заявку", "Submit request", "Залишити заявку");
            Add("form.submitting", "Отправляем...", "Sending...", "Надсилаємо...");
            Add("form.success", "Спасибо! Ваша заявка успешно отправлена. Мы скоро свяжемся с вами.", "Thank you! Your request has been sent. We'll be in touch soon.", "Дякуємо! Вашу заявку надіслано. Ми скоро зв'яжемось.");

            // Shared section labels (inner pages)
            Add("section.overview.eyebrow", "О программе", "About the programme", "Про програму");
            Add("section.overview.h2", "Что вас ждёт", "What awaits you", "Що на вас чекає");
            Add("section.benefits.h4", "Что вы получите", "What you'll gain", "Що ви отримаєте");
            Add("section.program.eyebrow", "Программа", "Programme", "Програма");
            Add("section.program.h2", "Структура курса", "Course structure", "Структура курсу");
            Add("section.forwhom.eyebrow", "Для кого", "For whom", "Для кого");
            Add("section.forwhom.h2", "Кому подойдёт", "Who is it for", "Кому підійде");
            Add("section.cta.eyebrow", "Следующий шаг", "Next step", "Наступний крок");
            Add("section.cta.h2", "Готовы начать путь?", "Ready to begin?", "Готові розпочати шлях?");
            Add("section.cta.text", "Оставьте заявку — мы ответим в течение дня и расскажем о ближайшем потоке.", "Submit a request — we'll reply within the day with details on the next intake.", "Залиште заявку — ми відповімо протягом дня.");
            Add("section.cta.btn", "Хочу записаться", "I want to sign up", "Хочу записатися");
            Add("section.back_to_list", "← Назад к списку", "← Back to list", "← Назад до списку");

            // Courses index
            Add("page.courses.eyebrow", "Направления обучения", "Learning directions", "Напрями навчання");
            Add("page.courses.h2", "Выберите свой путь", "Choose your path", "Оберіть свій шлях");
            Add("page.courses.intro", "Три авторские программы — от дыхания до глубинной трансформации.", "Three proprietary programmes — from breathwork to deep transformation.", "Три авторські програми — від дихання до глибинної трансформації.");
            Add("page.courses.card.pranayama.eyebrow", "Дыхательные практики", "Breathing practices", "Дихальні практики");
            Add("page.courses.card.pranayama.tagline", "Сила вдоха — сила жизни", "The power of breath — the power of life", "Сила вдиху — сила життя");
            Add("page.courses.card.pranayama.text", "Научитесь управлять дыханием и откройте новые горизонты сознания.", "Learn to harness your breath and unlock new horizons of consciousness.", "Навчіться управляти диханням та відкрийте нові горизонти свідомості.");
            Add("page.courses.card.meditation.eyebrow", "Медитативные практики", "Meditative practices", "Медитативні практики");
            Add("page.courses.card.meditation.tagline", "Тишина как инструмент", "Silence as a tool", "Тиша як інструмент");
            Add("page.courses.card.meditation.text", "Освойте техники медитации и найдите покой в любой ситуации.", "Master meditation techniques and find stillness in any situation.", "Опануйте техніки медитації та знайдіть спокій у будь-якій ситуації.");
            Add("page.courses.card.yoga.eyebrow", "Йога-практика", "Yoga practice", "Йога-практика");
            Add("page.courses.card.yoga.tagline", "Тело как отражение духа", "Body as a reflection of spirit", "Тіло як відображення духу");
            Add("page.courses.card.yoga.text", "Комплексная практика асан, пранаямы и медитации для целостной трансформации.", "A complete practice of asanas, pranayama and meditation for holistic transformation.", "Комплексна практика асан, пранаями та медитації для цілісної трансформації.");
            Add("page.courses.card.cta", "Подробнее →", "Learn more →", "Детальніше →");

            // Consultations index
            Add("page.consultations.eyebrow", "Индивидуальная работа", "Individual work", "Індивідуальна робота");
            Add("page.consultations.h2", "Личное сопровождение", "Personal guidance", "Особистий супровід");
            Add("page.consultations.intro", "Три направления персональных консультаций с нашими специалистами.", "Three areas of personal consultations with our specialists.", "Три напрями персональних консультацій з нашими фахівцями.");
            Add("page.consultations.card.energy.eyebrow", "Работа с энергией", "Energy work", "Робота з енергією");
            Add("page.consultations.card.energy.tagline", "Восстановить баланс сил", "Restore the balance of energies", "Відновити баланс сил");
            Add("page.consultations.card.energy.text", "Диагностика и балансировка энергетических центров через пранаяму и медитацию.", "Diagnosis and balancing of energy centres through pranayama and meditation.", "Діагностика та балансування енергетичних центрів через пранаяму та медитацію.");
            Add("page.consultations.card.ayurveda.eyebrow", "Аюрведическая диагностика", "Ayurvedic diagnosis", "Аюрведична діагностика");
            Add("page.consultations.card.ayurveda.tagline", "Природная мудрость здоровья", "Natural wisdom of health", "Природна мудрість здоров'я");
            Add("page.consultations.card.ayurveda.text", "Определение вашего доши-типа и составление персональных рекомендаций.", "Determine your dosha type and receive personalised recommendations.", "Визначення вашого типу доші та складання персональних рекомендацій.");
            Add("page.consultations.card.spirituality.eyebrow", "Духовное развитие", "Spiritual development", "Духовний розвиток");
            Add("page.consultations.card.spirituality.tagline", "Путь к истинному себе", "Path to the true self", "Шлях до справжнього себе");
            Add("page.consultations.card.spirituality.text", "Индивидуальная работа с убеждениями, страхами и духовными вопросами.", "Individual work with beliefs, fears and spiritual questions.", "Індивідуальна робота з переконаннями, страхами та духовними питаннями.");
            Add("page.consultations.card.cta", "Записаться →", "Book →", "Записатися →");

            // About page
            Add("page.about.founders.eyebrow", "Мы — Yoga.Life", "We are Yoga.Life", "Ми — Yoga.Life");
            Add("page.about.founders.h2", "Три пути — одна миссия", "Three paths — one mission", "Три шляхи — одна місія");
            Add("page.about.philosophy.eyebrow", "Принципы", "Principles", "Принципи");
            Add("page.about.philosophy.h2", "Философия проекта", "Project philosophy", "Філософія проекту");

            // Contacts page
            Add("page.contacts.eyebrow", "Всегда на связи", "Always in touch", "Завжди на зв'язку");
            Add("page.contacts.info.h2", "Давайте познакомимся", "Let's connect", "Давайте познайомимось");
            Add("page.contacts.social.eyebrow", "Социальные сети", "Social media", "Соціальні мережі");
            Add("page.contacts.social.h2", "Присоединяйтесь к нам", "Join us online", "Приєднуйтесь до нас");

            // Retreats pages
            Add("page.retreats.eyebrow", "Ближайшие программы", "Upcoming programmes", "Найближчі програми");
            Add("page.retreats.actual.intro", "Открытые ретриты, на которые сейчас можно записаться.", "Open retreats you can register for right now.", "Відкриті ретрити, на які зараз можна записатись.");
            Add("page.retreats.upcoming.intro", "Предстоящие ретриты — запишитесь заранее и получите лучшие условия.", "Upcoming retreats — register early for the best terms.", "Майбутні ретрити — запишіться заздалегідь для найкращих умов.");
            Add("page.retreats.past.intro", "История наших программ. Каждый ретрит — это особенная история.", "A record of our past programmes. Each retreat is a unique story.", "Історія наших програм. Кожен ретрит — це особлива історія.");
            Add("page.retreats.card.location", "Местоположение", "Location", "Місцезнаходження");
            Add("page.retreats.card.dates", "Даты", "Dates", "Дати");
            Add("page.retreats.card.cta", "Записаться", "Sign up", "Записатися");
            Add("page.retreats.empty", "Ретриты не найдены.", "No retreats found.", "Ретрити не знайдено.");

            // Blog pages
            Add("page.blog.eyebrow", "Знания и вдохновение", "Knowledge and inspiration", "Знання та натхнення");
            Add("page.blog.h2", "Исследуйте темы", "Explore topics", "Досліджуйте теми");
            Add("page.blog.articles.eyebrow", "Авторские статьи", "Articles", "Авторські статті");
            Add("page.blog.articles.intro", "Глубокие материалы о практике, философии и образе жизни.", "In-depth material on practice, philosophy and lifestyle.", "Глибокі матеріали про практику, філософію та спосіб життя.");
            Add("page.blog.videos.eyebrow", "Видеоматериалы", "Video content", "Відеоматеріали");
            Add("page.blog.videos.intro", "Практические уроки и вдохновляющие записи с наших ретритов.", "Practical lessons and inspiring recordings from our retreats.", "Практичні уроки та надихаючі записи з наших ретритів.");
            Add("page.blog.photos.eyebrow", "Галерея", "Gallery", "Галерея");
            Add("page.blog.photos.intro", "Моменты из жизни нашего сообщества.", "Moments from the life of our community.", "Моменти з життя нашої спільноти.");
            Add("page.blog.readmore", "Читать →", "Read →", "Читати →");
            Add("page.blog.empty", "Публикации пока не добавлены.", "No posts have been added yet.", "Публікації ще не додані.");

            modelBuilder.Entity<UiTranslation>().HasData(items);
        }
    }
}
