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
        public DbSet<MediaFile> MediaFiles => Set<MediaFile>();

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
                e.Property(x => x.Status).HasConversion<int>();
                e.Property(x => x.OperatorNote).HasMaxLength(2000);
            });

            modelBuilder.Entity<MediaFile>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.FileName).HasMaxLength(256).IsRequired();
                e.Property(x => x.ContentType).HasMaxLength(128).IsRequired();
                e.Property(x => x.StoragePath).HasMaxLength(512).IsRequired();
                e.Property(x => x.AltText).HasMaxLength(512);
                e.HasIndex(x => x.StoragePath).IsUnique();
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
                e.Property(x => x.IsActive).HasDefaultValue(true);
                e.Property(x => x.IsDraft).HasDefaultValue(false);
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
                e.Property(x => x.IsDraft).HasDefaultValue(false);
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
                e.Property(x => x.IsDraft).HasDefaultValue(false);
            });

            modelBuilder.Entity<Retreat>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Slug).HasMaxLength(64).IsRequired();
                e.HasIndex(x => x.Slug).IsUnique();
                e.Property(x => x.IsDraft).HasDefaultValue(false);
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
                e.Property(x => x.IsDraft).HasDefaultValue(false);
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

            var pageAbout = Guid.Parse("44444444-4444-4444-4444-444444444401");
            var pageContacts = Guid.Parse("44444444-4444-4444-4444-444444444402");
            var pageHome = Guid.Parse("44444444-4444-4444-4444-444444444403");
            var pageCourses = Guid.Parse("44444444-4444-4444-4444-444444444404");
            var pageConsultations = Guid.Parse("44444444-4444-4444-4444-444444444405");
            var pageRetreats = Guid.Parse("44444444-4444-4444-4444-444444444406");
            var pageYagyas = Guid.Parse("44444444-4444-4444-4444-444444444407");
            var pageBlog = Guid.Parse("44444444-4444-4444-4444-444444444408");

            modelBuilder.Entity<SitePage>().HasData(
                new SitePage { Id = pageAbout, Slug = "about", IsActive = true },
                new SitePage { Id = pageContacts, Slug = "contacts", IsActive = true },
                new SitePage { Id = pageHome, Slug = "home", IsActive = true },
                new SitePage { Id = pageCourses, Slug = "courses", IsActive = true },
                new SitePage { Id = pageConsultations, Slug = "consultations", IsActive = true },
                new SitePage { Id = pageRetreats, Slug = "retreats", IsActive = true },
                new SitePage { Id = pageYagyas, Slug = "yagyas", IsActive = true },
                new SitePage { Id = pageBlog, Slug = "blog", IsActive = true });

            var sectionTranslations = BuildSitePageSectionTranslations(pageRetreats, pageYagyas, pageBlog);
            modelBuilder.Entity<Translation>().HasData(sectionTranslations);
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
