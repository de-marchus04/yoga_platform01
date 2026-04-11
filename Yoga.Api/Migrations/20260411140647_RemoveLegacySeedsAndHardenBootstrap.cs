using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Yoga.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLegacySeedsAndHardenBootstrap : Migration
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

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222203"));

            migrationBuilder.DeleteData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555501"));

            migrationBuilder.DeleteData(
                table: "Retreats",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555502"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000001"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000002"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000003"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000004"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000005"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000006"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000007"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000008"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000009"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000010"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000011"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000012"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000013"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000014"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000015"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000016"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000017"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000018"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000019"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000020"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000021"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000022"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000023"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000024"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000025"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000026"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000027"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000028"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000029"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000030"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000031"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000032"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000033"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000034"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000035"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000036"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000037"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000038"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000039"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000040"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000041"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000042"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000043"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000044"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000045"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000046"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000047"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000048"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000049"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000050"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000051"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000052"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000053"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000054"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000055"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000056"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000057"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000058"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000059"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000060"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000061"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000062"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000063"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000064"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000065"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000066"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000067"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000068"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000069"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000070"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000071"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000072"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000073"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000074"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000075"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000076"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000077"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000078"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000079"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000080"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000081"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000082"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000083"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000084"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000085"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000086"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000087"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000088"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000089"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000090"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000091"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000092"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000093"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000094"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000095"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000096"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000097"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000098"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000099"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000100"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000101"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000102"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000103"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000104"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000105"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000106"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000107"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000108"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000109"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000110"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000111"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000112"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000113"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000114"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000115"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000116"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000117"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000118"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000119"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000120"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000121"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000122"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000123"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000124"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000125"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000126"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000127"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000128"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000129"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000130"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000131"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000132"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000133"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000134"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000135"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000136"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000137"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000138"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000139"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000140"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000141"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000142"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000143"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000144"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000145"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000146"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000147"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000148"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000149"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000150"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000151"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000152"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000153"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000154"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000155"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000156"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000157"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000158"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000159"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000160"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000161"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000162"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000163"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000164"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000165"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000166"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000167"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000168"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000169"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000170"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000171"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000172"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000173"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000174"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000175"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000176"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000177"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000178"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000179"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000180"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000181"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000182"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000183"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000184"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000185"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000186"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000187"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000188"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000189"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000190"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000191"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000192"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000193"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000194"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000195"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000196"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000197"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000198"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000199"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000200"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000201"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000202"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000203"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000204"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000205"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000206"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000207"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000208"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000209"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000210"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000211"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000212"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000213"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000214"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000215"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000216"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000217"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000218"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000219"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000220"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000221"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000222"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000223"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000224"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000225"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000226"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000227"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000228"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000229"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000230"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000231"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000232"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000233"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000234"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000235"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000236"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000237"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000238"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000239"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000240"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000241"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000242"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000243"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000244"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000245"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000246"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000247"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000248"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000249"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000250"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000251"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000252"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000253"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000254"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000255"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000256"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000257"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000258"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000259"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000260"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000261"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000262"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000263"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000264"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000265"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000266"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000267"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000268"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000269"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000270"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000271"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000272"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000273"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000274"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000275"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000276"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000277"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000278"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000279"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000280"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000281"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000282"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000283"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000284"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000285"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000286"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000287"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000288"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000289"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000290"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000291"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000292"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000293"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000294"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000295"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000296"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000297"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000298"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000299"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000300"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000301"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000302"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000303"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000304"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000305"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000306"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000307"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000308"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000309"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000310"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000311"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000312"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000313"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000314"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000315"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000316"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000317"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000318"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000319"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000320"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000321"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000322"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000323"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000324"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000325"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000326"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000327"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000328"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000329"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000330"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000331"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000332"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000333"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000334"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000335"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000336"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000337"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000338"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000339"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000340"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000341"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000342"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000343"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000344"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000345"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000346"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000347"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000348"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000349"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000350"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000351"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000352"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000353"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000354"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000355"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000356"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000357"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000358"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000359"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000360"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000361"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000362"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000363"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000364"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000365"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000366"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000367"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000368"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000369"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000370"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000371"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000372"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000373"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000374"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000375"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000376"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000377"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000378"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000379"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000380"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000381"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000382"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000383"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000384"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000385"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000386"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000387"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000388"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000389"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000390"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000391"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000392"));

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000393"));

            migrationBuilder.DeleteData(
                table: "Yagyas",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666601"));

            migrationBuilder.DeleteData(
                table: "Yagyas",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666602"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "IsActive", "IsOffline", "IsOnline", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333301"), true, true, true, "spiritual-development", 1 },
                    { new Guid("33333333-3333-3333-3333-333333333302"), true, true, true, "youth", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333303"), true, true, true, "personal", 3 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsActive", "IsOffline", "IsOnline", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), true, true, true, "pranavidya", 1 },
                    { new Guid("22222222-2222-2222-2222-222222222202"), true, true, true, "meditation", 2 },
                    { new Guid("22222222-2222-2222-2222-222222222203"), true, true, true, "yoga", 3 }
                });

            migrationBuilder.InsertData(
                table: "Retreats",
                columns: new[] { "Id", "EventEndDate", "EventStartDate", "IsActive", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555501"), new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "mountain-practice", 1 },
                    { new Guid("55555555-5555-5555-5555-555555555502"), new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "silence-retreat", 2 }
                });

            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "EntityId", "EntityType", "Field", "Language", "Value" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000001"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Title", "ru", "Пранавидья" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000002"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Title", "en", "Pranavidya" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000003"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Title", "uk", "Пранавід'я" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000004"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Subtitle", "ru", "Дыхание как опора практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000005"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Subtitle", "en", "Breath as the foundation of practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000006"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Subtitle", "uk", "Дихання як опора практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000007"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Eyebrow", "ru", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000008"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Eyebrow", "en", "Course" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000009"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Eyebrow", "uk", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000010"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Description", "ru", "Системная работа с пранаямой: от базовых техник до устойчивой самопрактики." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000011"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Description", "en", "Structured pranayama work: from foundational techniques to a steady self-practice." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000012"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Description", "uk", "Системна робота з пранаямою: від базових технік до стійкої самопрактики." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000013"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Benefits", "ru", "Спокойнее нервная система|Больше энергии днём|Улучшенный сон" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000014"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Benefits", "en", "A calmer nervous system|More daytime energy|Better sleep" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000015"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Benefits", "uk", "Спокійніша нервова система|Більше енергії вдень|Кращий сон" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000016"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ImageUrl", "ru", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000017"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ImageUrl", "en", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000018"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ImageUrl", "uk", "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000019"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Duration", "ru", "8 недель" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000020"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Duration", "en", "8 weeks" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000021"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Duration", "uk", "8 тижнів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000022"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Level", "ru", "От новичка до уверенной практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000023"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Level", "en", "From beginner to confident practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000024"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Level", "uk", "Від новачка до впевненої практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000025"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Format", "ru", "Онлайн и офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000026"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Format", "en", "Online and in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000027"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Format", "uk", "Онлайн і офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000028"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Schedule", "ru", "2 занятия в неделю + самостоятельная практика" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000029"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Schedule", "en", "Two sessions per week + self-practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000030"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "Schedule", "uk", "2 заняття на тиждень + самостійна практика" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000031"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ForWhom", "ru", "Новичкам~Безопасный вход в практику|Практикующим~Углубление и стабилизация дыхания" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000032"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ForWhom", "en", "Beginners~A safe entry into practice|Experienced practitioners~Deepening and stabilising the breath" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000033"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "ForWhom", "uk", "Новачкам~Безпечний вхід у практику|Практикуючим~Поглиблення та стабілізація дихання" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000034"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaHeading", "ru", "Начать с пранаямы" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000035"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaHeading", "en", "Start with pranayama" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000036"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaHeading", "uk", "Почати з пранаями" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000037"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaText", "ru", "Оставьте заявку — подберём формат и ответим на вопросы." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000038"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaText", "en", "Leave a request — we'll suggest a format and answer your questions." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000039"), new Guid("22222222-2222-2222-2222-222222222201"), "Course", "CtaText", "uk", "Залиште заявку — підберемо формат і відповімо на питання." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000040"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Title", "ru", "Медитация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000041"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Title", "en", "Meditation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000042"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Title", "uk", "Медитація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000043"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Subtitle", "ru", "Тишина, устойчивость, ясность" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000044"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Subtitle", "en", "Stillness, stability, clarity" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000045"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Subtitle", "uk", "Тиша, стійкість, ясність" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000046"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Eyebrow", "ru", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000047"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Eyebrow", "en", "Course" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000048"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Eyebrow", "uk", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000049"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Description", "ru", "Пошаговое освоение медитативных техник для повседневной жизни." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000050"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Description", "en", "Step-by-step meditation skills for everyday life." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000051"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Description", "uk", "Покрокове освоєння медитативних технік для повсякденного життя." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000052"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Benefits", "ru", "Меньше реактивности|Больше присутствия|Ясность решений" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000053"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Benefits", "en", "Less reactivity|More presence|Clearer decisions" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000054"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Benefits", "uk", "Менше реактивності|Більше присутності|Ясність рішень" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000055"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ImageUrl", "ru", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000056"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ImageUrl", "en", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000057"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ImageUrl", "uk", "https://images.unsplash.com/photo-1506126279646-a697353d3166?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000058"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Duration", "ru", "6 недель" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000059"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Duration", "en", "6 weeks" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000060"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Duration", "uk", "6 тижнів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000061"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Level", "ru", "Подходит любому уровню" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000062"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Level", "en", "All levels welcome" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000063"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Level", "uk", "Підходить будь-якому рівню" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000064"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Format", "ru", "Онлайн и офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000065"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Format", "en", "Online and in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000066"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Format", "uk", "Онлайн і офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000067"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Schedule", "ru", "Еженедельные встречи и короткие ежедневные практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000068"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Schedule", "en", "Weekly meetings and short daily practices" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000069"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "Schedule", "uk", "Щотижневі зустрічі та короткі щоденні практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000070"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ForWhom", "ru", "Занятым людям~Короткие практики встроены в день|Искателям глубины~Разбор опыта с куратором" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000071"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ForWhom", "en", "Busy people~Short practices that fit the day|Seekers of depth~Guided reflection with a mentor" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000072"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "ForWhom", "uk", "Зайнятим людям~Короткі практики вбудовані в день|Шукачам глибини~Розбір досвіду з куратором" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000073"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaHeading", "ru", "Попробовать медитацию" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000074"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaHeading", "en", "Try meditation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000075"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaHeading", "uk", "Спробувати медитацію" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000076"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaText", "ru", "Расскажем, с чего начать именно вам." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000077"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaText", "en", "We'll suggest where to start for you." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000078"), new Guid("22222222-2222-2222-2222-222222222202"), "Course", "CtaText", "uk", "Розповімо, з чого почати саме вам." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000079"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Title", "ru", "Йога" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000080"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Title", "en", "Yoga" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000081"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Title", "uk", "Йога" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000082"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Subtitle", "ru", "Тело, дыхание, внимание" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000083"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Subtitle", "en", "Body, breath, attention" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000084"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Subtitle", "uk", "Тіло, дихання, увага" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000085"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Eyebrow", "ru", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000086"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Eyebrow", "en", "Course" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000087"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Eyebrow", "uk", "Курс" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000088"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Description", "ru", "Комплексная практика: асаны, пранаяма и элементы медитации." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000089"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Description", "en", "A complete practice: asana, pranayama and elements of meditation." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000090"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Description", "uk", "Комплексна практика: асани, пранаяма та елементи медитації." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000091"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Benefits", "ru", "Сила и гибкость|Ровное дыхание|Больше осознанности" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000092"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Benefits", "en", "Strength and flexibility|Steady breath|More mindfulness" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000093"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Benefits", "uk", "Сила та гнучкість|Рівне дихання|Більше усвідомленості" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000094"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ImageUrl", "ru", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000095"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ImageUrl", "en", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000096"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ImageUrl", "uk", "https://images.unsplash.com/photo-1599901860907-2e5f1c9d5e9b?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000097"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Duration", "ru", "10 недель" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000098"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Duration", "en", "10 weeks" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000099"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Duration", "uk", "10 тижнів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000100"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Level", "ru", "От основ к цельной практике" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000101"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Level", "en", "From foundations to an integrated practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000102"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Level", "uk", "Від основ до цілісної практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000103"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Format", "ru", "Онлайн и офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000104"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Format", "en", "Online and in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000105"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Format", "uk", "Онлайн і офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000106"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Schedule", "ru", "2 практики в неделю" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000107"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Schedule", "en", "Two practices per week" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000108"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "Schedule", "uk", "2 практики на тиждень" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000109"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ForWhom", "ru", "Новичкам~Безопасный старт|Опытным~Тонкая настройка практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000110"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ForWhom", "en", "Beginners~A safe start|Experienced~Fine-tuning your practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000111"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "ForWhom", "uk", "Новачкам~Безпечний старт|Досвідченим~Тонке налаштування практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000112"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaHeading", "ru", "Погрузиться в йогу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000113"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaHeading", "en", "Dive into yoga" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000114"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaHeading", "uk", "Зануритися в йогу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000115"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaText", "ru", "Подберём интенсивность и формат под ваш запрос." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000116"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaText", "en", "We'll match intensity and format to your goals." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000117"), new Guid("22222222-2222-2222-2222-222222222203"), "Course", "CtaText", "uk", "Підберемо інтенсивність і формат під ваш запит." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000118"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Title", "ru", "Духовное развитие" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000119"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Title", "en", "Spiritual development" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000120"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Title", "uk", "Духовний розвиток" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000121"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Subtitle", "ru", "Опора, ясность, личный ритм" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000122"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Subtitle", "en", "Support, clarity, your own pace" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000123"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Subtitle", "uk", "Опора, ясність, особистий ритм" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000124"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Eyebrow", "ru", "Консультация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000125"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Eyebrow", "en", "Consultation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000126"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Eyebrow", "uk", "Консультація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000127"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Description", "ru", "Индивидуальная работа с вопросами смысла, ценностей и внутреннего роста." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000128"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Description", "en", "One-to-one work on meaning, values and inner growth." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000129"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Description", "uk", "Індивідуальна робота з питаннями сенсу, цінностей та внутрішнього росту." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000130"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Quote", "ru", "«Место, где можно говорить честно — без оценки и спешки.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000131"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Quote", "en", "«A space to speak honestly — without judgement or rush.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000132"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Quote", "uk", "«Місце, де можна говорити чесно — без оцінки та поспіху.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000133"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Benefits", "ru", "Ясность направления|Опора в сложные периоды|Интеграция практики в жизнь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000134"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Benefits", "en", "Clarity of direction|Support in difficult periods|Integrating practice into life" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000135"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Benefits", "uk", "Ясність напрямку|Опора у складні періоди|Інтеграція практики в життя" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000136"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ImageUrl", "ru", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000137"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ImageUrl", "en", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000138"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ImageUrl", "uk", "https://images.unsplash.com/photo-1518611012118-696072aa579a?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000139"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Duration", "ru", "60–90 минут" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000140"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Duration", "en", "60–90 minutes" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000141"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Duration", "uk", "60–90 хвилин" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000142"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Format", "ru", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000143"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Format", "en", "Online / in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000144"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "Format", "uk", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000145"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "LanguageOffered", "ru", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000146"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "LanguageOffered", "en", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000147"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "LanguageOffered", "uk", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000148"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000149"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000150"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000151"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ForWhom", "ru", "В переломные моменты~Нужен взгляд со стороны|Ищущим глубину~Связать практику и жизнь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000152"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ForWhom", "en", "At turning points~An outside perspective|Seeking depth~Connecting practice and life" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000153"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "ForWhom", "uk", "У переломні моменти~Потрібен погляд збоку|Шукачам глибини~Зв'язати практику і життя" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000154"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaHeading", "ru", "Записаться на сессию" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000155"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaHeading", "en", "Book a session" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000156"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaHeading", "uk", "Записатися на сесію" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000157"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaText", "ru", "Оставьте контакты — предложим время и формат." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000158"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaText", "en", "Leave your contacts — we'll suggest time and format." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000159"), new Guid("33333333-3333-3333-3333-333333333301"), "Consultation", "CtaText", "uk", "Залиште контакти — запропонуємо час і формат." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000160"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Title", "ru", "Для подростков" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000161"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Title", "en", "For teenagers" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000162"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Title", "uk", "Для підлітків" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000163"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Subtitle", "ru", "Опора, границы, уважение к росту" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000164"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Subtitle", "en", "Support, boundaries, respect for growth" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000165"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Subtitle", "uk", "Опора, межі, повага до зростання" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000166"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Eyebrow", "ru", "Консультация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000167"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Eyebrow", "en", "Consultation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000168"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Eyebrow", "uk", "Консультація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000169"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Description", "ru", "Бережный формат разговора о телесных, эмоциональных и социальных темах." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000170"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Description", "en", "A careful conversation about body, emotions and social life." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000171"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Description", "uk", "Обережний формат розмови про тілесні, емоційні та соціальні теми." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000172"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Quote", "ru", "«Подростку нужен взрослый, который слышит, а не оценивает.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000173"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Quote", "en", "«Teenagers need adults who listen, not judge.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000174"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Quote", "uk", "«Підлітку потрібен дорослий, який чує, а не оцінює.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000175"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Benefits", "ru", "Безопасное пространство|Язык, понятный подростку|Совместные шаги с семьёй при необходимости" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000176"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Benefits", "en", "A safe space|Language that fits teens|Family steps when needed" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000177"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Benefits", "uk", "Безпечний простір|Мова, зрозуміла підлітку|Спільні кроки з родиною за потреби" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000178"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ImageUrl", "ru", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000179"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ImageUrl", "en", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000180"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ImageUrl", "uk", "https://images.unsplash.com/photo-1529156069898-49953e39b3ac?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000181"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Duration", "ru", "50–60 минут" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000182"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Duration", "en", "50–60 minutes" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000183"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Duration", "uk", "50–60 хвилин" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000184"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Format", "ru", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000185"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Format", "en", "Online / in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000186"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "Format", "uk", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000187"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "LanguageOffered", "ru", "RU / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000188"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "LanguageOffered", "en", "RU / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000189"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "LanguageOffered", "uk", "RU / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000190"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000191"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000192"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000193"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ForWhom", "ru", "Подросткам 12–17~И их родителям при согласии" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000194"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ForWhom", "en", "Teens 12–17~And their parents when agreed" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000195"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "ForWhom", "uk", "Підліткам 12–17~І їхнім батькам за згодою" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000196"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaHeading", "ru", "Записаться" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000197"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaHeading", "en", "Book" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000198"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaHeading", "uk", "Записатися" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000199"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaText", "ru", "Коротко опишите запрос — подскажем следующий шаг." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000200"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaText", "en", "Briefly describe your request — we'll suggest the next step." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000201"), new Guid("33333333-3333-3333-3333-333333333302"), "Consultation", "CtaText", "uk", "Коротко опишіть запит — підкажемо наступний крок." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000202"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Title", "ru", "Личные вопросы" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000203"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Title", "en", "Personal questions" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000204"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Title", "uk", "Особисті питання" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000205"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Subtitle", "ru", "Конфиденциально и по делу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000206"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Subtitle", "en", "Confidential and practical" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000207"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Subtitle", "uk", "Конфіденційно і по суті" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000208"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Eyebrow", "ru", "Консультация" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000209"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Eyebrow", "en", "Consultation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000210"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Eyebrow", "uk", "Консультація" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000211"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Description", "ru", "Разбор личной ситуации: отношения, решения, нагрузка, поиск баланса." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000212"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Description", "en", "Working through a personal situation: relationships, decisions, load, balance." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000213"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Description", "uk", "Розбір особистої ситуації: стосунки, рішення, навантаження, баланс." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000214"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Quote", "ru", "«Иногда нужен час, чтобы разложить всё по полочкам.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000215"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Quote", "en", "«Sometimes you need an hour to sort things out.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000216"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Quote", "uk", "«Іноді потрібна година, щоб розкласти все по поличках.»" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000217"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Benefits", "ru", "Структура вопроса|Варианты шагов|Поддержка после сессии" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000218"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Benefits", "en", "A clearer question|Options for next steps|Follow-up support" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000219"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Benefits", "uk", "Структура питання|Варіанти кроків|Підтримка після сесії" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000220"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ImageUrl", "ru", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000221"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ImageUrl", "en", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000222"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ImageUrl", "uk", "https://images.unsplash.com/photo-1573496359142-b8d87734a5a2?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000223"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Duration", "ru", "60 минут" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000224"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Duration", "en", "60 minutes" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000225"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Duration", "uk", "60 хвилин" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000226"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Format", "ru", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000227"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Format", "en", "Online / in person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000228"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "Format", "uk", "Онлайн / очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000229"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "LanguageOffered", "ru", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000230"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "LanguageOffered", "en", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000231"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "LanguageOffered", "uk", "RU / EN / UK" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000232"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000233"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000234"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000235"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ForWhom", "ru", "Сложный выбор~Разобрать варианты|Усталость и перегруз~Найти опору" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000236"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ForWhom", "en", "Hard choices~Sorting options|Fatigue and overload~Finding footing" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000237"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "ForWhom", "uk", "Складний вибір~Розібрати варіанти|Втома та перевантаження~Знайти опору" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000238"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaHeading", "ru", "Записаться" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000239"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaHeading", "en", "Book" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000240"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaHeading", "uk", "Записатися" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000241"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaText", "ru", "Напишите, что хотите разобрать — ответим с вариантами времени." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000242"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaText", "en", "Tell us what you'd like to unpack — we'll reply with time options." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000243"), new Guid("33333333-3333-3333-3333-333333333303"), "Consultation", "CtaText", "uk", "Напишіть, що хочете розібрати — відповімо з варіантами часу." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000244"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Title", "ru", "Горная практика" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000245"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Title", "en", "Mountain practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000246"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Title", "uk", "Гірська практика" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000247"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Subtitle", "ru", "Природа, тишина, глубина" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000248"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Subtitle", "en", "Nature, silence, depth" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000249"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Subtitle", "uk", "Природа, тиша, глибина" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000250"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Eyebrow", "ru", "Ретрит" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000251"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Eyebrow", "en", "Retreat" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000252"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Eyebrow", "uk", "Ретрит" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000253"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Description", "ru", "Выездной интенсив в горах: утренние практики, медитация, совместная работа." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000254"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Description", "en", "Mountain intensive: morning practices, meditation, group work." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000255"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Description", "uk", "Виїзний інтенсив у горах: ранкові практики, медитація, спільна робота." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000256"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Benefits", "ru", "Перезагрузка|Глубокая практика|Общение в кругу единомышленников" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000257"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Benefits", "en", "Reset|Deep practice|Community" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000258"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Benefits", "uk", "Перезавантаження|Глибока практика|Спілкування з однодумцями" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000259"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "ImageUrl", "ru", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000260"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "ImageUrl", "en", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000261"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "ImageUrl", "uk", "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000262"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Duration", "ru", "5 дней" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000263"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Duration", "en", "5 days" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000264"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Duration", "uk", "5 днів" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000265"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Location", "ru", "Карпаты, Украина" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000266"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Location", "en", "Carpathians, Ukraine" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000267"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Location", "uk", "Карпати, Україна" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000268"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Format", "ru", "Офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000269"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Format", "en", "In person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000270"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "Format", "uk", "Офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000271"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000272"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000273"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000274"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "ForWhom", "ru", "Практикующим~Углубление опыта|Новичкам~Безопасное погружение" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000275"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "ForWhom", "en", "Experienced~Deepen your experience|Beginners~A safe immersion" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000276"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "ForWhom", "uk", "Практикуючим~Поглиблення досвіду|Новачкам~Безпечне занурення" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000277"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "CtaHeading", "ru", "Забронировать место" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000278"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "CtaHeading", "en", "Reserve a spot" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000279"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "CtaHeading", "uk", "Забронювати місце" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000280"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "CtaText", "ru", "Места ограничены — оставьте заявку заранее." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000281"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "CtaText", "en", "Spots are limited — apply in advance." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000282"), new Guid("55555555-5555-5555-5555-555555555501"), "Retreat", "CtaText", "uk", "Місць обмаль — залиште заявку заздалегідь." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000283"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Title", "ru", "Ретрит тишины" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000284"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Title", "en", "Silence retreat" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000285"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Title", "uk", "Ретрит тиші" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000286"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Subtitle", "ru", "Слушать тишину внутри" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000287"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Subtitle", "en", "Listening to inner silence" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000288"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Subtitle", "uk", "Слухати тишу всередині" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000289"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Eyebrow", "ru", "Ретрит" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000290"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Eyebrow", "en", "Retreat" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000291"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Eyebrow", "uk", "Ретрит" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000292"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Description", "ru", "Три дня молчания: медитация, ходьба, дневник. Минимум слов — максимум внимания." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000293"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Description", "en", "Three days of silence: meditation, walking, journalling. Minimum words — maximum attention." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000294"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Description", "uk", "Три дні мовчання: медитація, ходьба, щоденник. Мінімум слів — максимум уваги." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000295"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Benefits", "ru", "Ясность мысли|Снижение тревоги|Возврат энергии" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000296"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Benefits", "en", "Mental clarity|Reduced anxiety|Energy restored" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000297"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Benefits", "uk", "Ясність думки|Зниження тривоги|Повернення енергії" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000298"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "ImageUrl", "ru", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000299"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "ImageUrl", "en", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000300"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "ImageUrl", "uk", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000301"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Duration", "ru", "3 дня" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000302"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Duration", "en", "3 days" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000303"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Duration", "uk", "3 дні" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000304"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Location", "ru", "Вне города" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000305"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Location", "en", "Outside the city" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000306"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Location", "uk", "За містом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000307"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Format", "ru", "Офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000308"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Format", "en", "In person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000309"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "Format", "uk", "Офлайн" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000310"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "PriceLabel", "ru", "По запросу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000311"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "PriceLabel", "en", "On request" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000312"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "PriceLabel", "uk", "За запитом" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000313"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "ForWhom", "ru", "Опытным практикам~Углубление тишины|Всем, кто устал~Перезагрузка без лишнего" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000314"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "ForWhom", "en", "Experienced practitioners~Deepening silence|Anyone tired~A reset without extras" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000315"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "ForWhom", "uk", "Досвідченим практикам~Поглиблення тиші|Усім, хто втомився~Перезавантаження без зайвого" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000316"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "CtaHeading", "ru", "Записаться на ретрит" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000317"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "CtaHeading", "en", "Sign up for the retreat" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000318"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "CtaHeading", "uk", "Записатися на ретрит" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000319"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "CtaText", "ru", "Напишите — подскажем даты и условия." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000320"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "CtaText", "en", "Write to us — we'll share dates and details." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000321"), new Guid("55555555-5555-5555-5555-555555555502"), "Retreat", "CtaText", "uk", "Напишіть — підкажемо дати й умови." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000322"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Title", "ru", "Огненная церемония" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000323"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Title", "en", "Fire ceremony" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000324"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Title", "uk", "Вогняна церемонія" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000325"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Subtitle", "ru", "Очищение через огонь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000326"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Subtitle", "en", "Purification through fire" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000327"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Subtitle", "uk", "Очищення через вогонь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000328"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Eyebrow", "ru", "Ягья" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000329"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Eyebrow", "en", "Yagya" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000330"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Eyebrow", "uk", "Ягʼя" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000331"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Description", "ru", "Групповой ведический ритуал с мантрами и подношениями огню." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000332"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Description", "en", "A group Vedic ritual with mantras and fire offerings." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000333"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Description", "uk", "Груповий ведичний ритуал з мантрами та підношеннями вогню." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000334"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Benefits", "ru", "Очищение пространства|Совместная медитация|Символическое обновление" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000335"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Benefits", "en", "Space cleansing|Group meditation|Symbolic renewal" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000336"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Benefits", "uk", "Очищення простору|Спільна медитація|Символічне оновлення" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000337"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "ImageUrl", "ru", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000338"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "ImageUrl", "en", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000339"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "ImageUrl", "uk", "https://images.unsplash.com/photo-1518241353330-0f7941c2d9b5?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000340"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Duration", "ru", "2–3 часа" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000341"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Duration", "en", "2–3 hours" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000342"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Duration", "uk", "2–3 години" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000343"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Format", "ru", "Очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000344"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Format", "en", "In person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000345"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "Format", "uk", "Очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000346"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "PriceLabel", "ru", "Пожертвование" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000347"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "PriceLabel", "en", "Donation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000348"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "PriceLabel", "uk", "Пожертва" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000349"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "ForWhom", "ru", "Всем желающим~Опыт не обязателен|Практикующим~Дополнение к практике" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000350"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "ForWhom", "en", "Everyone~No experience needed|Practitioners~A complement to practice" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000351"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "ForWhom", "uk", "Усім бажаючим~Досвід не обов'язковий|Практикуючим~Доповнення до практики" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000352"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "CtaHeading", "ru", "Участвовать" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000353"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "CtaHeading", "en", "Join" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000354"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "CtaHeading", "uk", "Взяти участь" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000355"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "CtaText", "ru", "Оставьте заявку — пришлём детали ближайшей церемонии." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000356"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "CtaText", "en", "Apply — we'll send details of the next ceremony." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000357"), new Guid("66666666-6666-6666-6666-666666666601"), "Yagya", "CtaText", "uk", "Залиште заявку — надішлемо деталі найближчої церемонії." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000358"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Title", "ru", "Новогоднее намерение" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000359"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Title", "en", "New Year intention" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000360"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Title", "uk", "Новорічний намір" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000361"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Subtitle", "ru", "Вход в новый цикл осознанно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000362"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Subtitle", "en", "Entering a new cycle mindfully" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000363"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Subtitle", "uk", "Вхід у новий цикл усвідомлено" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000364"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Eyebrow", "ru", "Ягья" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000365"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Eyebrow", "en", "Yagya" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000366"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Eyebrow", "uk", "Ягʼя" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000367"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Description", "ru", "Церемония коллективного намерения в преддверии нового года." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000368"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Description", "en", "A ceremony of collective intention on the eve of the new year." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000369"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Description", "uk", "Церемонія колективного наміру напередодні нового року." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000370"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Benefits", "ru", "Ясность целей|Энергия группы|Ритуал перехода" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000371"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Benefits", "en", "Clarity of goals|Group energy|A rite of passage" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000372"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Benefits", "uk", "Ясність цілей|Енергія групи|Ритуал переходу" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000373"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "ImageUrl", "ru", "https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000374"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "ImageUrl", "en", "https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000375"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "ImageUrl", "uk", "https://images.unsplash.com/photo-1507608616759-54f48f0af0ee?auto=format&fit=crop&w=1200&q=80" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000376"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Duration", "ru", "3 часа" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000377"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Duration", "en", "3 hours" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000378"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Duration", "uk", "3 години" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000379"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Format", "ru", "Очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000380"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Format", "en", "In person" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000381"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "Format", "uk", "Очно" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000382"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "PriceLabel", "ru", "Пожертвование" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000383"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "PriceLabel", "en", "Donation" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000384"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "PriceLabel", "uk", "Пожертва" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000385"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "ForWhom", "ru", "Всем~Открытое мероприятие|Семьям~Можно с детьми от 7 лет" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000386"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "ForWhom", "en", "Everyone~Open event|Families~Children 7+ welcome" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000387"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "ForWhom", "uk", "Усім~Відкритий захід|Родинам~Можна з дітьми від 7 років" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000388"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "CtaHeading", "ru", "Присоединиться" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000389"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "CtaHeading", "en", "Join" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000390"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "CtaHeading", "uk", "Приєднатися" },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000391"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "CtaText", "ru", "Узнайте дату и место — оставьте заявку." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000392"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "CtaText", "en", "Find out the date and venue — apply now." },
                    { new Guid("bbbbbbbb-bbbb-4bbb-8bbb-000000000393"), new Guid("66666666-6666-6666-6666-666666666602"), "Yagya", "CtaText", "uk", "Дізнайтеся дату й місце — залиште заявку." }
                });

            migrationBuilder.InsertData(
                table: "Yagyas",
                columns: new[] { "Id", "EventEndDate", "EventStartDate", "IsActive", "Slug", "SortOrder" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666601"), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "fire-ceremony", 1 },
                    { new Guid("66666666-6666-6666-6666-666666666602"), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "new-year-intention", 2 }
                });
        }
    }
}
