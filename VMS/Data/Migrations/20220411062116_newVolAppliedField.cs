using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class newVolAppliedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolunteersApplied",
                table: "Opportunity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolunteersApplied",
                table: "Opportunity");
        }
    }
}
