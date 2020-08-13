using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class addIdFieldToProductsAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsAndUserId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "productAndUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAndUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductsAndUserId",
                table: "Product",
                column: "ProductsAndUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_productAndUsers_ProductsAndUserId",
                table: "Product",
                column: "ProductsAndUserId",
                principalTable: "productAndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_productAndUsers_ProductsAndUserId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "productAndUsers");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductsAndUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductsAndUserId",
                table: "Product");
        }
    }
}
