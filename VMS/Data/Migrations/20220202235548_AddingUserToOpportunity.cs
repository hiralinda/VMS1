using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class AddingUserToOpportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "opportunityName",
                table: "Opportunity",
                newName: "OpportunityName");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Opportunity",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Opportunity",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Opportunity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CreateUserId",
                table: "Opportunity",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_AspNetUsers_CreateUserId",
                table: "Opportunity",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_AspNetUsers_CreateUserId",
                table: "Opportunity");

            migrationBuilder.DropIndex(
                name: "IX_Opportunity_CreateUserId",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Opportunity");

            migrationBuilder.RenameColumn(
                name: "OpportunityName",
                table: "Opportunity",
                newName: "opportunityName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Opportunity",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Opportunity",
                newName: "description");
        }
    }
}
