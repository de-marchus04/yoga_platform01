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
            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333301"));

            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333302"));

            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333303"));

            migrationBuilder.AddColumn<int>(
                name: "FailedLoginAttempts",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockoutEndUtc",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "YagyaId",
                table: "CustomerAccessGrants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedYagyaId",
                table: "BlogPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "IsActive", "IsOffline", "IsOnline", "LiveEventId", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333304"), true, false, false, null, "spiritual-development", 1 },
                    { new Guid("33333333-3333-3333-3333-333333333305"), true, false, false, null, "youth", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333306"), true, false, false, null, "personal", 3 }
                });

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
            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333304"));

            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333305"));

            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333306"));

            migrationBuilder.DropColumn(
                name: "FailedLoginAttempts",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LockoutEndUtc",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "YagyaId",
                table: "CustomerAccessGrants");

            migrationBuilder.DropColumn(
                name: "RelatedYagyaId",
                table: "BlogPosts");

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "IsActive", "IsOffline", "IsOnline", "LiveEventId", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333301"), true, false, false, null, "energy", 1 },
                    { new Guid("33333333-3333-3333-3333-333333333302"), true, false, false, null, "ayurveda", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333303"), true, false, false, null, "spirituality", 3 }
                });

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
