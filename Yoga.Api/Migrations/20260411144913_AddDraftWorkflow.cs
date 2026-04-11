using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoga.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDraftWorkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Yagyas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SitePages",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "SitePages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Retreats",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444401"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444402"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444403"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444404"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444405"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444406"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444407"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "SitePages",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444408"),
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Yagyas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SitePages");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "SitePages");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Retreats");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Consultations");
        }
    }
}
