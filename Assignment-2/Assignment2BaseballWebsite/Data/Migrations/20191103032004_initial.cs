using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2BaseballWebsite.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    RegisterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    BirthMonth = table.Column<byte>(nullable: false),
                    BirthDay = table.Column<byte>(nullable: false),
                    BirthYear = table.Column<int>(nullable: false),
                    StreetNumber = table.Column<int>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    EmergencyFirstName = table.Column<string>(nullable: false),
                    EmergencyLastName = table.Column<string>(nullable: false),
                    EmergencyRelationship = table.Column<string>(nullable: false),
                    EmergencyPhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeTeam = table.Column<string>(nullable: false),
                    AwayTeam = table.Column<string>(nullable: false),
                    GameDate = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "TeamInfo",
                columns: table => new
                {
                    TeamInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: false),
                    TeamLogoURL = table.Column<string>(nullable: true),
                    TeamDivision = table.Column<string>(nullable: false),
                    HomeField = table.Column<string>(nullable: false),
                    TeamManager = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInfo", x => x.TeamInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "TeamInfo");
        }
    }
}
