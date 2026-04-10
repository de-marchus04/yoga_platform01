using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoga.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEventDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EventEndDate",
                table: "Yagyas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventStartDate",
                table: "Yagyas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventEndDate",
                table: "Retreats",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventStartDate",
                table: "Retreats",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555501"),
                columns: new[] { "EventEndDate", "EventStartDate" },
                values: new object[] { new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555502"),
                columns: new[] { "EventEndDate", "EventStartDate" },
                values: new object[] { new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Yagyas",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666601"),
                columns: new[] { "EventEndDate", "EventStartDate" },
                values: new object[] { new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Yagyas",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666602"),
                columns: new[] { "EventEndDate", "EventStartDate" },
                values: new object[] { new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventEndDate",
                table: "Yagyas");

            migrationBuilder.DropColumn(
                name: "EventStartDate",
                table: "Yagyas");

            migrationBuilder.DropColumn(
                name: "EventEndDate",
                table: "Retreats");

            migrationBuilder.DropColumn(
                name: "EventStartDate",
                table: "Retreats");
        }
    }
}
