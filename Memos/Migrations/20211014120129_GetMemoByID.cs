using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class GetMemoByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = 
                @"CREATE PROCEDURE GetMemoByID
                  @MemoID int
                  AS
                  BEGIN
                    SELECT * FROM Memos
                    WHERE MemoID = @MemoID
                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure =
                @"DROP PROCEDURE GetMemoByID";
            migrationBuilder.Sql(procedure);
        }
    }
}
