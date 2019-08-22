using Microsoft.EntityFrameworkCore.Migrations;

namespace Makaleler.DataAccess.Migrations
{
    public partial class updateMakaleTableKategoriId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori",
                table: "Makale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kategori",
                table: "Makale",
                nullable: false,
                defaultValue: 0);
        }
    }
}
