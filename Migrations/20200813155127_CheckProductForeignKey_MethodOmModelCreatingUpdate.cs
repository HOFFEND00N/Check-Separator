using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class CheckProductForeignKey_MethodOmModelCreatingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Check_Product",
                table: "Check_Product");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Check_Product",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Check_Product",
                table: "Check_Product",
                columns: new[] { "ProductId", "CheckId", "UserName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Check_Product",
                table: "Check_Product");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Check_Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Check_Product",
                table: "Check_Product",
                columns: new[] { "ProductId", "CheckId" });
        }
    }
}
