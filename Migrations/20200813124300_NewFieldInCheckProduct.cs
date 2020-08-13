using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class NewFieldInCheckProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductAndUsers_ProductsAndUserId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ProductAndUsers");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductsAndUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductsAndUserId",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Check_Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Check_Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductsAndUserId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductAndUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAndUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductsAndUserId",
                table: "Product",
                column: "ProductsAndUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductAndUsers_ProductsAndUserId",
                table: "Product",
                column: "ProductsAndUserId",
                principalTable: "ProductAndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
