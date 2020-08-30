using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class dataBaseRemake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Check_Product");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Master",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Checks");

            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Checks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CheckUser",
                columns: table => new
                {
                    CheckId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckUser", x => new { x.CheckId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CheckUser_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CheckId",
                table: "Product",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckUser_UserId",
                table: "CheckUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Checks_CheckId",
                table: "Product",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Checks_CheckId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CheckUser");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Product_CheckId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Checks");

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Master",
                table: "Checks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Checks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Check_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check_Product", x => new { x.ProductId, x.CheckId, x.UserName });
                });
        }
    }
}
