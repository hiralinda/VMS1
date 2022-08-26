using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMS.Data.Migrations
{
    public partial class AddCollectionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_volunteerId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Opportunity_opportunityId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_createUserId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Volunteer",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "skills",
                table: "Volunteer",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "preferences",
                table: "Volunteer",
                newName: "Preferences");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Volunteer",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Volunteer",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "licenses",
                table: "Volunteer",
                newName: "Licenses");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Volunteer",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Volunteer",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "emergPhone",
                table: "Volunteer",
                newName: "EmergPhone");

            migrationBuilder.RenameColumn(
                name: "emergName",
                table: "Volunteer",
                newName: "EmergName");

            migrationBuilder.RenameColumn(
                name: "emergEmail",
                table: "Volunteer",
                newName: "EmergEmail");

            migrationBuilder.RenameColumn(
                name: "emergAdd",
                table: "Volunteer",
                newName: "EmergAdd");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Volunteer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "education",
                table: "Volunteer",
                newName: "Education");

            migrationBuilder.RenameColumn(
                name: "availability",
                table: "Volunteer",
                newName: "Availability");

            migrationBuilder.RenameColumn(
                name: "approvalStatus",
                table: "Volunteer",
                newName: "ApprovalStatus");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Volunteer",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "activeStatus",
                table: "Volunteer",
                newName: "ActiveStatus");

            migrationBuilder.RenameColumn(
                name: "totalLikes",
                table: "Post",
                newName: "TotalLikes");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Post",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Post",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "datePosted",
                table: "Post",
                newName: "DatePosted");

            migrationBuilder.RenameColumn(
                name: "createUserName",
                table: "Post",
                newName: "CreateUserName");

            migrationBuilder.RenameColumn(
                name: "createUserId",
                table: "Post",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "Post",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Post",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_createUserId",
                table: "Post",
                newName: "IX_Post_CreateUserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Organization",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "zip",
                table: "AspNetUsers",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "school",
                table: "AspNetUsers",
                newName: "School");

            migrationBuilder.RenameColumn(
                name: "isStudent",
                table: "AspNetUsers",
                newName: "IsStudent");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "AspNetUsers",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "volunteerName",
                table: "Application",
                newName: "VolunteerName");

            migrationBuilder.RenameColumn(
                name: "volunteerId",
                table: "Application",
                newName: "VolunteerId");

            migrationBuilder.RenameColumn(
                name: "volsNeeded",
                table: "Application",
                newName: "VolsNeeded");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Application",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "opportunityId",
                table: "Application",
                newName: "OpportunityId");

            migrationBuilder.RenameColumn(
                name: "oppTime",
                table: "Application",
                newName: "OppTime");

            migrationBuilder.RenameColumn(
                name: "oppName",
                table: "Application",
                newName: "OppName");

            migrationBuilder.RenameColumn(
                name: "oppLocation",
                table: "Application",
                newName: "OppLocation");

            migrationBuilder.RenameColumn(
                name: "oppID",
                table: "Application",
                newName: "OppId");

            migrationBuilder.RenameColumn(
                name: "oppDate",
                table: "Application",
                newName: "OppDate");

            migrationBuilder.RenameColumn(
                name: "isVirtual",
                table: "Application",
                newName: "IsVirtual");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Application",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Application_volunteerId",
                table: "Application",
                newName: "IX_Application_VolunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_opportunityId",
                table: "Application",
                newName: "IX_Application_OpportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_VolunteerId",
                table: "Application",
                column: "VolunteerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Opportunity_OpportunityId",
                table: "Application",
                column: "OpportunityId",
                principalTable: "Opportunity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_CreateUserId",
                table: "Post",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_VolunteerId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Opportunity_OpportunityId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_CreateUserId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Volunteer",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Volunteer",
                newName: "skills");

            migrationBuilder.RenameColumn(
                name: "Preferences",
                table: "Volunteer",
                newName: "preferences");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Volunteer",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Volunteer",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Licenses",
                table: "Volunteer",
                newName: "licenses");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Volunteer",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Volunteer",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "EmergPhone",
                table: "Volunteer",
                newName: "emergPhone");

            migrationBuilder.RenameColumn(
                name: "EmergName",
                table: "Volunteer",
                newName: "emergName");

            migrationBuilder.RenameColumn(
                name: "EmergEmail",
                table: "Volunteer",
                newName: "emergEmail");

            migrationBuilder.RenameColumn(
                name: "EmergAdd",
                table: "Volunteer",
                newName: "emergAdd");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Volunteer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Education",
                table: "Volunteer",
                newName: "education");

            migrationBuilder.RenameColumn(
                name: "Availability",
                table: "Volunteer",
                newName: "availability");

            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                table: "Volunteer",
                newName: "approvalStatus");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Volunteer",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "ActiveStatus",
                table: "Volunteer",
                newName: "activeStatus");

            migrationBuilder.RenameColumn(
                name: "TotalLikes",
                table: "Post",
                newName: "totalLikes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Post",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Post",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Post",
                newName: "datePosted");

            migrationBuilder.RenameColumn(
                name: "CreateUserName",
                table: "Post",
                newName: "createUserName");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Post",
                newName: "createUserId");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Post",
                newName: "body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CreateUserId",
                table: "Post",
                newName: "IX_Post_createUserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organization",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "AspNetUsers",
                newName: "zip");

            migrationBuilder.RenameColumn(
                name: "School",
                table: "AspNetUsers",
                newName: "school");

            migrationBuilder.RenameColumn(
                name: "IsStudent",
                table: "AspNetUsers",
                newName: "isStudent");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "AspNetUsers",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "VolunteerName",
                table: "Application",
                newName: "volunteerName");

            migrationBuilder.RenameColumn(
                name: "VolunteerId",
                table: "Application",
                newName: "volunteerId");

            migrationBuilder.RenameColumn(
                name: "VolsNeeded",
                table: "Application",
                newName: "volsNeeded");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Application",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "OpportunityId",
                table: "Application",
                newName: "opportunityId");

            migrationBuilder.RenameColumn(
                name: "OppTime",
                table: "Application",
                newName: "oppTime");

            migrationBuilder.RenameColumn(
                name: "OppName",
                table: "Application",
                newName: "oppName");

            migrationBuilder.RenameColumn(
                name: "OppLocation",
                table: "Application",
                newName: "oppLocation");

            migrationBuilder.RenameColumn(
                name: "OppId",
                table: "Application",
                newName: "oppID");

            migrationBuilder.RenameColumn(
                name: "OppDate",
                table: "Application",
                newName: "oppDate");

            migrationBuilder.RenameColumn(
                name: "IsVirtual",
                table: "Application",
                newName: "isVirtual");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Application",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Application_VolunteerId",
                table: "Application",
                newName: "IX_Application_volunteerId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_OpportunityId",
                table: "Application",
                newName: "IX_Application_opportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_volunteerId",
                table: "Application",
                column: "volunteerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Opportunity_opportunityId",
                table: "Application",
                column: "opportunityId",
                principalTable: "Opportunity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_createUserId",
                table: "Post",
                column: "createUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
