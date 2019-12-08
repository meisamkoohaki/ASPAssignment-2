using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class z : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "TeamInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamInfo_ScheduleId",
                table: "TeamInfo",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamInfo_Schedule_ScheduleId",
                table: "TeamInfo",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamInfo_Schedule_ScheduleId",
                table: "TeamInfo");

            migrationBuilder.DropIndex(
                name: "IX_TeamInfo_ScheduleId",
                table: "TeamInfo");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "TeamInfo");
        }
    }
}
