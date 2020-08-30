using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class nameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUser_Checks_CheckId",
                table: "CheckUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Checks_CheckId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checks",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Checks");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Product",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "Checks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checks",
                table: "Checks",
                column: "CheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUser_Checks_CheckId",
                table: "CheckUser",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "CheckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Checks_CheckId",
                table: "Product",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "CheckId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUser_Checks_CheckId",
                table: "CheckUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Checks_CheckId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checks",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "Checks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Checks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checks",
                table: "Checks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUser_Checks_CheckId",
                table: "CheckUser",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Checks_CheckId",
                table: "Product",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
