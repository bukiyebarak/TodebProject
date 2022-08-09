using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_UserId",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserId",
                table: "Bills",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_UserId",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserId",
                table: "Bills",
                column: "UserId",
                unique: true);
        }
    }
}
