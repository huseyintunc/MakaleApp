using Microsoft.EntityFrameworkCore.Migrations;

namespace Makaleler.DataAccess.Migrations
{
    public partial class addColumnTableYazarNameandSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Yazar",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Yazar",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Yazar");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Yazar");
        }
    }
}
