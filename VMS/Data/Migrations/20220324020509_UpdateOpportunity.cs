using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class UpdateOpportunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeBracket",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CompanyLogo",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeLevel",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterestAreas",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolunteersNeeded",
                table: "Opportunity",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeBracket",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "CompanyLogo",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "InterestAreas",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "VolunteersNeeded",
                table: "Opportunity");
        }
    }
}
