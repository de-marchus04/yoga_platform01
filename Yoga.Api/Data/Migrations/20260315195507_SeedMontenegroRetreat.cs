using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedMontenegroRetreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$fUcO6uH0vWdcWDHlIWcbNefVk.AgrmB3xDWs6EjPZM1ZFVnNYSppy");

            migrationBuilder.InsertData(
                table: "Retreats",
                columns: new[] { "Id", "Description", "EndDate", "IsActive", "Location", "StartDate", "Title" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Погружение в себя на берегу Адриатического моря. Практики тишины, йога 2 раза в день, авторское меню и детокс.", new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), true, "Будва, Черногория", new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Ретрит в Черногории: Возврат к себе" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$zGHF/.NcKnt6gPKaDArZkub4CaAsC/D2ikWjndwjr91iJwJ6xXdzS");
        }
    }
}
