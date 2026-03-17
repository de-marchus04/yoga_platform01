using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AdminUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AdminUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AdminUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginAt",
                table: "AdminUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "DisplayName", "Email", "LastLoginAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Администратор", null, null, "$2a$11$cwhrNNkkEkaLhzv6nF5vTOV.wD7HlyR1k5xJGRSN7x68layFe.fWa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginAt",
                table: "AdminUsers");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$serSi4fSLPqdoGgptXSo7O0epC8g.q6SGI/MUsJTiNZPcAYd1ZZl6");
        }
    }
}
