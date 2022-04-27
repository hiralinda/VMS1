using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class removeUnusedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOrgName",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "CreateOrgPic",
                table: "Opportunity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateOrgName",
                table: "Opportunity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CreateOrgPic",
                table: "Opportunity",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
