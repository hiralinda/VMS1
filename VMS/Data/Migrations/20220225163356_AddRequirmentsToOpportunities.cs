using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class AddRequirmentsToOpportunities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Opportunity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Opportunity");
        }
    }
}
