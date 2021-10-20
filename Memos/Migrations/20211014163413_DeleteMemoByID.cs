using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class DeleteMemoByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure =
                  @"CREATE PROCEDURE DeleteMemoByID
                  @MemoID int
                  AS
                  BEGIN
                    DELETE FROM Memos
                    WHERE MemoID = @MemoID
                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure =
                @"DROP PROCEDURE DeleteMemoByID";
            migrationBuilder.Sql(procedure);
        }
    }
}
