using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class fex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PlayerStats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PlayerStats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PlayerStats");
        }
    }
}
