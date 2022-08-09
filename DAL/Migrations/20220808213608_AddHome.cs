using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Apartments_ApartmentId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Images",
                newName: "HomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ApartmentId",
                table: "Images",
                newName: "IX_Images_HomeId");

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    ApartmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_UserId",
                table: "Homes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Homes_HomeId",
                table: "Images",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Homes_HomeId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.RenameColumn(
                name: "HomeId",
                table: "Images",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_HomeId",
                table: "Images",
                newName: "IX_Images_ApartmentId");

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentStatus = table.Column<int>(type: "int", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Apartments_ApartmentId",
                table: "Images",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
