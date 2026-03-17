using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yoga.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRetreatProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "Retreats",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$b8WnQXCNAWYOxW6NebSO7ulLexFbxBSzVto7kZBkVejx90kcA1q3C");

            migrationBuilder.UpdateData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Program",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Program",
                table: "Retreats");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "PasswordHash",
                value: "$2a$11$CdbcoRNcyyUQ7a4w66mmV.RASPBRAqKooB4CP3p/aT6wqEngUf.Y.");
        }
    }
}
