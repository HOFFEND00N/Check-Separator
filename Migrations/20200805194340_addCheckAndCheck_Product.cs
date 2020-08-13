using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class addCheckAndCheck_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_productAndUsers_ProductsAndUserId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productAndUsers",
                table: "productAndUsers");

            migrationBuilder.RenameTable(
                name: "productAndUsers",
                newName: "ProductAndUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAndUsers",
                table: "ProductAndUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Check_Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CheckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check_Product", x => new { x.ProductId, x.CheckId });
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Master = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductAndUsers_ProductsAndUserId",
                table: "Product",
                column: "ProductsAndUserId",
                principalTable: "ProductAndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductAndUsers_ProductsAndUserId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Check_Product");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAndUsers",
                table: "ProductAndUsers");

            migrationBuilder.RenameTable(
                name: "ProductAndUsers",
                newName: "productAndUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productAndUsers",
                table: "productAndUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_productAndUsers_ProductsAndUserId",
                table: "Product",
                column: "ProductsAndUserId",
                principalTable: "productAndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
