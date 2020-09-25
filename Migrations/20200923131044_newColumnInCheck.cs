using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckSeparatorMVC.Migrations
{
    public partial class newColumnInCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Checks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Checks");
        }
    }
}
