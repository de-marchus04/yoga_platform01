using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLockoutColumnsToCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Idempotent deletes (won't fail if already absent)
            migrationBuilder.Sql("DELETE FROM \"Consultations\" WHERE \"Id\" = '33333333-3333-3333-3333-333333333301';");
            migrationBuilder.Sql("DELETE FROM \"Consultations\" WHERE \"Id\" = '33333333-3333-3333-3333-333333333302';");
            migrationBuilder.Sql("DELETE FROM \"Consultations\" WHERE \"Id\" = '33333333-3333-3333-3333-333333333303';");

            // Idempotent: columns may already exist if added manually via SQL scripts
            migrationBuilder.Sql(@"ALTER TABLE ""Customers"" ADD COLUMN IF NOT EXISTS ""FailedLoginAttempts"" integer NOT NULL DEFAULT 0;");
            migrationBuilder.Sql(@"ALTER TABLE ""Customers"" ADD COLUMN IF NOT EXISTS ""LockoutEndUtc"" timestamp with time zone;");
            migrationBuilder.Sql(@"ALTER TABLE ""CustomerAccessGrants"" ADD COLUMN IF NOT EXISTS ""YagyaId"" uuid;");
            migrationBuilder.Sql(@"ALTER TABLE ""BlogPosts"" ADD COLUMN IF NOT EXISTS ""RelatedYagyaId"" uuid;");

            // Idempotent inserts
            migrationBuilder.Sql(@"
                INSERT INTO ""Consultations"" (""Id"", ""IsActive"", ""IsOffline"", ""IsOnline"", ""LiveEventId"", ""Slug"", ""SortOrder"")
                VALUES
                    ('33333333-3333-3333-3333-333333333304', true, false, false, null, 'spiritual-development', 1),
                    ('33333333-3333-3333-3333-333333333305', true, false, false, null, 'youth', 2),
                    ('33333333-3333-3333-3333-333333333306', true, false, false, null, 'personal', 3)
                ON CONFLICT (""Id"") DO NOTHING;");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000019"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.spiritual_development", "Духовное развитие" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000020"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.spiritual_development", "Spiritual Development" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000021"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.spiritual_development", "Духовний розвиток" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.youth", "Молодежь" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.youth", "Youth" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.youth", "Молодь" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000025"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.personal", "Личные вопросы" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000026"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.personal", "Personal Questions" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000027"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.personal", "Особисті питання" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Consultations\" WHERE \"Id\" = '33333333-3333-3333-3333-333333333304';");
            migrationBuilder.Sql("DELETE FROM \"Consultations\" WHERE \"Id\" = '33333333-3333-3333-3333-333333333305';");
            migrationBuilder.Sql("DELETE FROM \"Consultations\" WHERE \"Id\" = '33333333-3333-3333-3333-333333333306';");

            migrationBuilder.Sql(@"ALTER TABLE ""Customers"" DROP COLUMN IF EXISTS ""FailedLoginAttempts"";");
            migrationBuilder.Sql(@"ALTER TABLE ""Customers"" DROP COLUMN IF EXISTS ""LockoutEndUtc"";");
            migrationBuilder.Sql(@"ALTER TABLE ""CustomerAccessGrants"" DROP COLUMN IF EXISTS ""YagyaId"";");
            migrationBuilder.Sql(@"ALTER TABLE ""BlogPosts"" DROP COLUMN IF EXISTS ""RelatedYagyaId"";");

            migrationBuilder.Sql(@"
                INSERT INTO ""Consultations"" (""Id"", ""IsActive"", ""IsOffline"", ""IsOnline"", ""LiveEventId"", ""Slug"", ""SortOrder"")
                VALUES
                    ('33333333-3333-3333-3333-333333333301', true, false, false, null, 'energy', 1),
                    ('33333333-3333-3333-3333-333333333302', true, false, false, null, 'ayurveda', 2),
                    ('33333333-3333-3333-3333-333333333303', true, false, false, null, 'spirituality', 3)
                ON CONFLICT (""Id"") DO NOTHING;");

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000019"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.energy", "Энергетика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000020"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.energy", "Energetics" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000021"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.energy", "Енергетика" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000022"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.ayurveda", "Для подростков" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000023"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.ayurveda", "For Teenagers" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000024"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.ayurveda", "Для підлітків" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000025"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.spirituality", "Духовность" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000026"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.spirituality", "Spirituality" });

            migrationBuilder.UpdateData(
                table: "UiTranslations",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000027"),
                columns: new[] { "Key", "Value" },
                values: new object[] { "nav.consultations.spirituality", "Духовність" });
        }
    }
}
