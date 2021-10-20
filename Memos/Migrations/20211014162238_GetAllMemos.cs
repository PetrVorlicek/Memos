using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class GetAllMemos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure =
                  @"CREATE PROCEDURE GetAllMemos
                  AS
                  BEGIN
                    SELECT * FROM Memos
                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure =
                 @"DROP PROCEDURE GetAllMemos";
            migrationBuilder.Sql(procedure);
        }
    }
}
