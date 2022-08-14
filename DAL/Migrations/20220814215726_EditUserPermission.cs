using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditUserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_Users_UserId",
                table: "UserPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPermission",
                table: "UserPermission");

            migrationBuilder.RenameTable(
                name: "UserPermission",
                newName: "UserPermissions");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermission_UserId",
                table: "UserPermissions",
                newName: "IX_UserPermissions_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPermissions",
                table: "UserPermissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_UserId",
                table: "UserPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Users_UserId",
                table: "UserPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPermissions",
                table: "UserPermissions");

            migrationBuilder.RenameTable(
                name: "UserPermissions",
                newName: "UserPermission");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermission",
                newName: "IX_UserPermission_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPermission",
                table: "UserPermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_Users_UserId",
                table: "UserPermission",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
