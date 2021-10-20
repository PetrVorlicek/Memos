using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class CreatorBasicControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedureOne =
                  @"CREATE PROCEDURE GetAllCreators
                  AS
                  BEGIN
                    SELECT * FROM Creators
                  END";

           string procedureTwo =
                  @"CREATE PROCEDURE GetCreatorByID
                  @CreatorID int
                  AS
                  BEGIN
                    SELECT * FROM Creators
                    WHERE CreatorID = @CreatorID
                  END";
            migrationBuilder.Sql(procedureOne);
            migrationBuilder.Sql(procedureTwo);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedureOne =
                @"DROP PROCEDURE GetAllCreators";
            string procedureTwo =
                @"DROP PROCEDURE GetCreatorByID";
            migrationBuilder.Sql(procedureOne);
            migrationBuilder.Sql(procedureTwo);
        }
    }
}
