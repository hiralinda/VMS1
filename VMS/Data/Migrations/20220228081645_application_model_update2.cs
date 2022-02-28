using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class application_model_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "oppName",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "volunteerName",
                table: "Application",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oppName",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "volunteerName",
                table: "Application");
        }
    }
}
