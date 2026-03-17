using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCrossLinksAndFormats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leads",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Messager",
                table: "Leads",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDetails",
                table: "Leads",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Leads",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminNotes",
                table: "Leads",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultationId",
                table: "Leads",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Leads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TargetFormat",
                table: "Leads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsOffline",
                table: "Courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOffline",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedConsultationId",
                table: "BlogPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedCourseId",
                table: "BlogPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedRetreatId",
                table: "BlogPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$R0hTi8YuWpfrUqM4EPCvHOSZV8G/GxvVm9qXNwCqOnbbtXGzsUSKm");

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333301"),
                columns: new[] { "IsOffline", "IsOnline" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333302"),
                columns: new[] { "IsOffline", "IsOnline" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333303"),
                columns: new[] { "IsOffline", "IsOnline" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"),
                columns: new[] { "IsOffline", "IsOnline" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"),
                columns: new[] { "IsOffline", "IsOnline" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222203"),
                columns: new[] { "IsOffline", "IsOnline" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminNotes",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "TargetFormat",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "IsOffline",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsOffline",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "RelatedConsultationId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "RelatedCourseId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "RelatedRetreatId",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leads",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Messager",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDetails",
                table: "Leads",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$WYfVNHALKATmgNSgBkBzvOeubWRjeyc0P/m4miaB4MyMbLAF7t/pK");
        }
    }
}
