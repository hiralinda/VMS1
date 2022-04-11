using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class addStartEndTimesToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "oppTime",
                table: "Application",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oppTime",
                table: "Application");
        }
    }
}
