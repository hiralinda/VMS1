using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class Updateopportunty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GroupActivity",
                table: "Opportunity",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfOpportunity",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Virtual",
                table: "Opportunity",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupActivity",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "TypeOfOpportunity",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "Virtual",
                table: "Opportunity");
        }
    }
}
