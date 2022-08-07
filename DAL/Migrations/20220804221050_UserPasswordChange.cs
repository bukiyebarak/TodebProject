using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UserPasswordChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPasswords_Users_UserId",
                table: "UserPasswords");

            migrationBuilder.DropForeignKey(
                name: "FK_Users2_UserPasswords_PasswordId",
                table: "Users2");

            migrationBuilder.DropIndex(
                name: "IX_Users2_PasswordId",
                table: "Users2");

            migrationBuilder.DropIndex(
                name: "IX_UserPasswords_UserId",
                table: "UserPasswords");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                table: "Users2");

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswords_UserId",
                table: "UserPasswords",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPasswords_Users2_UserId",
                table: "UserPasswords",
                column: "UserId",
                principalTable: "Users2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPasswords_Users2_UserId",
                table: "UserPasswords");

            migrationBuilder.DropIndex(
                name: "IX_UserPasswords_UserId",
                table: "UserPasswords");

            migrationBuilder.AddColumn<int>(
                name: "PasswordId",
                table: "Users2",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users2_PasswordId",
                table: "Users2",
                column: "PasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPasswords_UserId",
                table: "UserPasswords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPasswords_Users_UserId",
                table: "UserPasswords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users2_UserPasswords_PasswordId",
                table: "Users2",
                column: "PasswordId",
                principalTable: "UserPasswords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
