using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class GetMemoByCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure =
                  @"CREATE PROCEDURE GetMemoByCreator
                  @CreatorID int
                  AS
                  BEGIN
                    SELECT * FROM Memos
                    WHERE CreatorID = @CreatorID
                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure =
                @"DROP PROCEDURE GetMemoByCreator";
            migrationBuilder.Sql(procedure);
        }
    }
}
