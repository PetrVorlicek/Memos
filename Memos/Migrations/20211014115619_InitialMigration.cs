using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memos.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    CreatorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.CreatorID);
                });

            migrationBuilder.CreateTable(
                name: "Memos",
                columns: table => new
                {
                    MemoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    MemoHeader = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    MemoBody = table.Column<string>(type: "varchar(280)", unicode: false, maxLength: 280, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ExpiredDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memos", x => x.MemoID);
                    table.ForeignKey(
                        name: "FK__Memos__CreatorID__398D8EEE",
                        column: x => x.CreatorID,
                        principalTable: "Creators",
                        principalColumn: "CreatorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memos_CreatorID",
                table: "Memos",
                column: "CreatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memos");

            migrationBuilder.DropTable(
                name: "Creators");
        }
    }
}
