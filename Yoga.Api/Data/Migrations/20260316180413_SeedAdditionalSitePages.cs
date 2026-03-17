using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditionalSitePages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$M2b6UCe.Mm2qyySAOlnl/OEosQ3t/0fKiSRPqGjTf5vwCQqpbdt/y");

            migrationBuilder.InsertData(
                table: "SitePages",
                columns: new[] { "Id", "Slug" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444403"), "home" },
                    { new Guid("44444444-4444-4444-4444-444444444404"), "courses" },
                    { new Guid("44444444-4444-4444-4444-444444444405"), "consultations" },
                    { new Guid("44444444-4444-4444-4444-444444444406"), "blog" },
                    { new Guid("44444444-4444-4444-4444-444444444407"), "retreats" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444403"));

            migrationBuilder.DeleteData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444404"));

            migrationBuilder.DeleteData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444405"));

            migrationBuilder.DeleteData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444406"));

            migrationBuilder.DeleteData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444407"));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$cwhrNNkkEkaLhzv6nF5vTOV.wD7HlyR1k5xJGRSN7x68layFe.fWa");
        }
    }
}
