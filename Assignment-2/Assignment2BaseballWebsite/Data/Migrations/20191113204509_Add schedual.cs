using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class Addschedual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeam",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "HomeTeam",
                table: "Schedule");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamScore",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamScore",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamInfoId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamInfoId",
                table: "Register",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TeamInfoId",
                table: "Schedule",
                column: "TeamInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_TeamInfoId",
                table: "Register",
                column: "TeamInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_TeamInfo_TeamInfoId",
                table: "Register",
                column: "TeamInfoId",
                principalTable: "TeamInfo",
                principalColumn: "TeamInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_TeamInfo_TeamInfoId",
                table: "Schedule",
                column: "TeamInfoId",
                principalTable: "TeamInfo",
                principalColumn: "TeamInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_TeamInfo_TeamInfoId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_TeamInfo_TeamInfoId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TeamInfoId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Register_TeamInfoId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "AwayTeamScore",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "HomeTeamScore",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TeamInfoId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TeamInfoId",
                table: "Register");

            migrationBuilder.AddColumn<string>(
                name: "AwayTeam",
                table: "Schedule",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTeam",
                table: "Schedule",
                nullable: false,
                defaultValue: "");
        }
    }
}
