using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class application_model_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_nonprofitId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_nonprofitId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "nonprofitId",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "opportunityId",
                table: "Application",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_opportunityId",
                table: "Application",
                column: "opportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Opportunity_opportunityId",
                table: "Application",
                column: "opportunityId",
                principalTable: "Opportunity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Opportunity_opportunityId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_opportunityId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "opportunityId",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "nonprofitId",
                table: "Application",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_nonprofitId",
                table: "Application",
                column: "nonprofitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_nonprofitId",
                table: "Application",
                column: "nonprofitId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
