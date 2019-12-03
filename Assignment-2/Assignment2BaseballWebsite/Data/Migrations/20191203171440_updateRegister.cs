using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class updateRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Register",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Register",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyPhoneNumber",
                table: "Register",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Register",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Register",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "EmergencyPhoneNumber",
                table: "Register",
                nullable: false,
                oldClrType: typeof(string));

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
    }
}
