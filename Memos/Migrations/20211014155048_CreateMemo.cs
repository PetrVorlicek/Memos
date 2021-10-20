using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class CreateMemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure =
                  @"CREATE PROCEDURE CreateMemo
                  @CreatorID int,
                  @MemoHeader varchar(80),
                  @MemoBody varchar(280)
                  AS
                  BEGIN
                    INSERT INTO Memos (CreatorID, MemoHeader, MemoBody)
                    VALUES 
                    (@CreatorID, @MemoHeader, @MemoBody)
                  END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE CreateMemo";
            migrationBuilder.Sql(procedure);
        }
    }
}
