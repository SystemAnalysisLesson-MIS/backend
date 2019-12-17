using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IkematgahDegisim.DataAccess.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "İkematgahlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IkematgahAdres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İkematgahlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SifreSalt = table.Column<byte[]>(nullable: true),
                    SifreHash = table.Column<byte[]>(nullable: true),
                    Durum = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciOperasyonelTalepler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    OperationClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciOperasyonelTalepler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperasyonelTalepler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperasyonelTalepler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vatandaslar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    TCKimlik = table.Column<int>(nullable: false),
                    DogumTamTarih = table.Column<DateTime>(nullable: false),
                    IkematgahId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vatandaslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vatandaslar_İkematgahlar_IkematgahId",
                        column: x => x.IkematgahId,
                        principalTable: "İkematgahlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisiselBilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EvAdres = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CepTelefonNumarasi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiselBilgiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KisiselBilgiler_Vatandaslar_Id",
                        column: x => x.Id,
                        principalTable: "Vatandaslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VatandasTalepler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TalepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatandasTalepler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VatandasTalepler_Vatandaslar_Id",
                        column: x => x.Id,
                        principalTable: "Vatandaslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VatandasTeslimatlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TeslimatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatandasTeslimatlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VatandasTeslimatlar_Vatandaslar_Id",
                        column: x => x.Id,
                        principalTable: "Vatandaslar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talepler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kiraci = table.Column<bool>(nullable: false),
                    SozlesmeFotograf = table.Column<byte[]>(nullable: true),
                    TalepTarihi = table.Column<DateTime>(nullable: false),
                    VatandasTalepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talepler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talepler_VatandasTalepler_VatandasTalepId",
                        column: x => x.VatandasTalepId,
                        principalTable: "VatandasTalepler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teslimatlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<int>(nullable: false),
                    VatandasTeslimatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teslimatlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teslimatlar_VatandasTeslimatlar_VatandasTeslimatId",
                        column: x => x.VatandasTeslimatId,
                        principalTable: "VatandasTeslimatlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talepler_VatandasTalepId",
                table: "Talepler",
                column: "VatandasTalepId");

            migrationBuilder.CreateIndex(
                name: "IX_Teslimatlar_VatandasTeslimatId",
                table: "Teslimatlar",
                column: "VatandasTeslimatId");

            migrationBuilder.CreateIndex(
                name: "IX_Vatandaslar_IkematgahId",
                table: "Vatandaslar",
                column: "IkematgahId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisiselBilgiler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "KullaniciOperasyonelTalepler");

            migrationBuilder.DropTable(
                name: "OperasyonelTalepler");

            migrationBuilder.DropTable(
                name: "Talepler");

            migrationBuilder.DropTable(
                name: "Teslimatlar");

            migrationBuilder.DropTable(
                name: "VatandasTalepler");

            migrationBuilder.DropTable(
                name: "VatandasTeslimatlar");

            migrationBuilder.DropTable(
                name: "Vatandaslar");

            migrationBuilder.DropTable(
                name: "İkematgahlar");
        }
    }
}
