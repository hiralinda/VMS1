using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.Data.Migrations
{
    public partial class New_Post_Parameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createUserId",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "datePosted",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "totalLikes",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Post_createUserId",
                table: "Post",
                column: "createUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_createUserId",
                table: "Post",
                column: "createUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_createUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_createUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "createUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "datePosted",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "totalLikes",
                table: "Post");
        }
    }
}
