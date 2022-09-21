using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMS.Data.Migrations
{
    public partial class AddOppCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolunteerId",
                table: "Opportunity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_VolunteerId",
                table: "Opportunity",
                column: "VolunteerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Volunteer_VolunteerId",
                table: "Opportunity",
                column: "VolunteerId",
                principalTable: "Volunteer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Volunteer_VolunteerId",
                table: "Opportunity");

            migrationBuilder.DropIndex(
                name: "IX_Opportunity_VolunteerId",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "VolunteerId",
                table: "Opportunity");
        }
    }
}
