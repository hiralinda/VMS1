using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class attemptAddingExtraVolunteerInfoToApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutYou",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherWebsite",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "Application",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutYou",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "OtherWebsite",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "Application");
        }
    }
}
