using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication21_1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayersCount = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    LevelFear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quests");
        }
    }
}
