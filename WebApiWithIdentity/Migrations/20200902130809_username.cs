using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiWithIdentity.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FistName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FistName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
