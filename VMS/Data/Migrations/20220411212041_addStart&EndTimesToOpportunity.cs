using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class addStartEndTimesToOpportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Opportunity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Opportunity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Opportunity");
        }
    }
}
