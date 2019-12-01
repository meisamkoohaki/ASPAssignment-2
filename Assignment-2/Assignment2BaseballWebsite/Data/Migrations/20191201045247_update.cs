using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerStatsStatId",
                table: "Register",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Register_PlayerStatsStatId",
                table: "Register",
                column: "PlayerStatsStatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_PlayerStats_PlayerStatsStatId",
                table: "Register",
                column: "PlayerStatsStatId",
                principalTable: "PlayerStats",
                principalColumn: "StatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_PlayerStats_PlayerStatsStatId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_PlayerStatsStatId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "PlayerStatsStatId",
                table: "Register");
        }
    }
}
