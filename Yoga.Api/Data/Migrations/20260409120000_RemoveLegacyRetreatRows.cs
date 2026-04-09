using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Yoga.Api.Data;

#nullable disable

namespace Yoga.Api.Data.Migrations
{
    /// <summary>
    /// Production: back up DB first, then from repo root:
    /// <c>dotnet ef database update 20260409120000_RemoveLegacyRetreatRows --project Yoga.Api/Yoga.Api.csproj</c>
    /// with <c>ConnectionStrings__Default</c> (or env) pointing at production PostgreSQL.
    /// Or run the SQL in <c>Up()</c> manually on the server.
    /// </summary>
    [DbContext(typeof(AppDbContext))]
    [Migration("20260409120000_RemoveLegacyRetreatRows")]
    public partial class RemoveLegacyRetreatRows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DO $$
DECLARE legacy_ids uuid[] := ARRAY[
  'bb000002-0000-0000-0000-000000000001'::uuid,
  'bb000002-0000-0000-0000-000000000002'::uuid
];
BEGIN
  UPDATE ""Leads"" SET ""RetreatId"" = NULL WHERE ""RetreatId"" = ANY(legacy_ids);
  UPDATE ""CustomerAccessGrants"" SET ""RetreatId"" = NULL WHERE ""RetreatId"" = ANY(legacy_ids);
  UPDATE ""BlogPosts"" SET ""RelatedRetreatId"" = NULL WHERE ""RelatedRetreatId"" = ANY(legacy_ids);
  DELETE FROM ""Translations"" WHERE ""EntityType"" = 'Retreat' AND ""EntityId"" = ANY(legacy_ids);
  DELETE FROM ""Retreats"" WHERE ""Id"" = ANY(legacy_ids);
END $$;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
