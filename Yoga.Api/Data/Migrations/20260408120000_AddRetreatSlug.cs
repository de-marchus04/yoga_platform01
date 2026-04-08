using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Yoga.Api.Data;

#nullable disable

namespace Yoga.Api.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260408120000_AddRetreatSlug")]
    public class AddRetreatSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ""Retreats"" ADD COLUMN IF NOT EXISTS ""Slug"" text;");

            migrationBuilder.Sql(@"
                UPDATE ""Retreats"" SET ""Slug"" = 'me01', ""Location"" = 'Бар, Черногория'
                WHERE ""Id"" = '11111111-1111-1111-1111-111111111111';

                UPDATE ""Translations"" SET ""Value"" = 'Бар, Черногория'
                WHERE ""EntityId"" = '11111111-1111-1111-1111-111111111111' AND ""EntityType"" = 'Retreat' AND ""Field"" = 'Location' AND ""Language"" = 'ru';

                UPDATE ""Translations"" SET ""Value"" = 'Bar, Montenegro'
                WHERE ""EntityId"" = '11111111-1111-1111-1111-111111111111' AND ""EntityType"" = 'Retreat' AND ""Field"" = 'Location' AND ""Language"" = 'en';

                UPDATE ""Translations"" SET ""Value"" = 'Бар, Чорногорія'
                WHERE ""EntityId"" = '11111111-1111-1111-1111-111111111111' AND ""EntityType"" = 'Retreat' AND ""Field"" = 'Location' AND ""Language"" = 'uk';
            ");

            migrationBuilder.Sql(@"DROP INDEX IF EXISTS ""IX_Retreats_Slug"";");
            migrationBuilder.Sql(
                @"CREATE UNIQUE INDEX ""IX_Retreats_Slug"" ON ""Retreats"" (""Slug"") WHERE ""Slug"" IS NOT NULL;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS ""IX_Retreats_Slug"";");
            migrationBuilder.Sql(@"ALTER TABLE ""Retreats"" DROP COLUMN IF EXISTS ""Slug"";");
        }
    }
}
