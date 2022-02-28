using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class application_update_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "oppDate",
                table: "Application",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "oppLocation",
                table: "Application",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oppDate",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "oppLocation",
                table: "Application");
        }
    }
}
