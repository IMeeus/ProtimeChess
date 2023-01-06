using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Event.Migrations
{
    public partial class FK_Game_GameEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GameEvents_GameId",
                table: "GameEvents",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameEvents_Games_GameId",
                table: "GameEvents",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEvents_Games_GameId",
                table: "GameEvents");

            migrationBuilder.DropIndex(
                name: "IX_GameEvents_GameId",
                table: "GameEvents");
        }
    }
}
