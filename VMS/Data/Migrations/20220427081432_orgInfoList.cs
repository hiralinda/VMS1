using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class orgInfoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateOrgName",
                table: "Opportunity",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CreateOrgPic",
                table: "Opportunity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOrgName",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "CreateOrgPic",
                table: "Opportunity");
        }
    }
}
