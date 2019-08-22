using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Makaleler.DataAccess.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KategoriAdi = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Yazar",
                columns: table => new
                {
                    YazarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazar", x => x.YazarId);
                });

            migrationBuilder.CreateTable(
                name: "Makale",
                columns: table => new
                {
                    MakaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MakaleBaslik = table.Column<string>(maxLength: 300, nullable: false),
                    KisaIcerik = table.Column<string>(maxLength: 500, nullable: false),
                    Icerik = table.Column<string>(nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(nullable: true),
                    KategoriId = table.Column<int>(nullable: false),
                    Kategori = table.Column<int>(nullable: false),
                    YazarId = table.Column<int>(nullable: false),
                    Goruntulenme = table.Column<int>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makale", x => x.MakaleId);
                    table.ForeignKey(
                        name: "FK_Makale_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makale_Yazar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazar",
                        principalColumn: "YazarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makale_KategoriId",
                table: "Makale",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Makale_YazarId",
                table: "Makale",
                column: "YazarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Makale");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Yazar");
        }
    }
}
