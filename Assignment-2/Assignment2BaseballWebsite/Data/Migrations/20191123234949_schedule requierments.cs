using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class schedulerequierments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
