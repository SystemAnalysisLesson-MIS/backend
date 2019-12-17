using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IkematgahDegisim.DataAccess.Migrations
{
    public partial class NewPropertiesToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "SozlesmeFotograf",
                table: "Talepler",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KalinanEvinAdresi",
                table: "Talepler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Onay",
                table: "Talepler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CepTelefonNumarasi",
                table: "Kullanicilar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KalinanEvinAdresi",
                table: "Talepler");

            migrationBuilder.DropColumn(
                name: "Onay",
                table: "Talepler");

            migrationBuilder.DropColumn(
                name: "CepTelefonNumarasi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.AlterColumn<byte[]>(
                name: "SozlesmeFotograf",
                table: "Talepler",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);
        }
    }
}
