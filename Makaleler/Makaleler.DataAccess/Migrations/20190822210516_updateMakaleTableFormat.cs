using Microsoft.EntityFrameworkCore.Migrations;

namespace Makaleler.DataAccess.Migrations
{
    public partial class updateMakaleTableFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MakaleBaslik",
                table: "Makale",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "KisaIcerik",
                table: "Makale",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MakaleBaslik",
                table: "Makale",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "KisaIcerik",
                table: "Makale",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
