using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class updatePlayerStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    StatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hits = table.Column<int>(nullable: false),
                    Doubles = table.Column<int>(nullable: false),
                    Triples = table.Column<int>(nullable: false),
                    HomeRuns = table.Column<int>(nullable: false),
                    RunsBattedIn = table.Column<int>(nullable: false),
                    RegisterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.StatId);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Register_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "Register",
                        principalColumn: "RegisterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_RegisterId",
                table: "PlayerStats",
                column: "RegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStats");
        }
    }
}
