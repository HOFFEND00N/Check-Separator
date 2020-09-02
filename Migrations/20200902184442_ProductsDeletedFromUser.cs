using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class ProductsDeletedFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUser_Checks_CheckId",
                table: "CheckUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUser_Users_UserId",
                table: "CheckUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Product_ProductId",
                table: "ProductUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUser_Users_UserId",
                table: "ProductUser");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUser",
                table: "ProductUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckUser",
                table: "CheckUser");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductUser",
                newName: "productUsers");

            migrationBuilder.RenameTable(
                name: "CheckUser",
                newName: "checkUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUser_UserId",
                table: "productUsers",
                newName: "IX_productUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckUser_UserId",
                table: "checkUsers",
                newName: "IX_checkUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productUsers",
                table: "productUsers",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_checkUsers",
                table: "checkUsers",
                columns: new[] { "CheckId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_checkUsers_Checks_CheckId",
                table: "checkUsers",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "CheckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_checkUsers_Users_UserId",
                table: "checkUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productUsers_Product_ProductId",
                table: "productUsers",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productUsers_Users_UserId",
                table: "productUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_checkUsers_Checks_CheckId",
                table: "checkUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_checkUsers_Users_UserId",
                table: "checkUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_productUsers_Product_ProductId",
                table: "productUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_productUsers_Users_UserId",
                table: "productUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productUsers",
                table: "productUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_checkUsers",
                table: "checkUsers");

            migrationBuilder.RenameTable(
                name: "productUsers",
                newName: "ProductUser");

            migrationBuilder.RenameTable(
                name: "checkUsers",
                newName: "CheckUser");

            migrationBuilder.RenameIndex(
                name: "IX_productUsers_UserId",
                table: "ProductUser",
                newName: "IX_ProductUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_checkUsers_UserId",
                table: "CheckUser",
                newName: "IX_CheckUser_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUser",
                table: "ProductUser",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckUser",
                table: "CheckUser",
                columns: new[] { "CheckId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUser_Checks_CheckId",
                table: "CheckUser",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "CheckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUser_Users_UserId",
                table: "CheckUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Product_ProductId",
                table: "ProductUser",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUser_Users_UserId",
                table: "ProductUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
