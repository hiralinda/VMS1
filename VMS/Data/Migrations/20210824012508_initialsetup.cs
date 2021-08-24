using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opportunityName = table.Column<string>(nullable: true),
                    center = table.Column<string>(nullable: true),
                    datePosted = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    preferences = table.Column<string>(nullable: true),
                    skills = table.Column<string>(nullable: true),
                    availability = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    education = table.Column<string>(nullable: true),
                    licenses = table.Column<string>(nullable: true),
                    emergName = table.Column<string>(nullable: true),
                    emergPhone = table.Column<string>(nullable: true),
                    emergEmail = table.Column<string>(nullable: true),
                    emergAdd = table.Column<string>(nullable: true),
                    approvalStatus = table.Column<string>(nullable: true),
                    activeStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
