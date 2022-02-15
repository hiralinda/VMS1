using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class UpdateOpportunityLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Opportunity");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Opportunity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Opportunity");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Opportunity",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
