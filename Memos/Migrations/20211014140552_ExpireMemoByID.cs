using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class ExpireMemoByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure =
                  @"CREATE PROCEDURE ExpireMemoByID
                  @MemoID int
                  AS
                  BEGIN
                    UPDATE Memos
                    SET ExpiredDate = GETDATE()
                    WHERE MemoID = @MemoID
                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE ExpireMemoByID";
            migrationBuilder.Sql(procedure);
        }
    }
}
