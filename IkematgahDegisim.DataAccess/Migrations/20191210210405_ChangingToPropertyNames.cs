using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IkematgahDegisim.DataAccess.Migrations
{
    public partial class ChangingToPropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talepler_VatandasTalepler_VatandasTalepId",
                table: "Talepler");

            migrationBuilder.DropForeignKey(
                name: "FK_Teslimatlar_VatandasTeslimatlar_VatandasTeslimatId",
                table: "Teslimatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Vatandaslar_İkematgahlar_IkematgahId",
                table: "Vatandaslar");

            migrationBuilder.DropColumn(
                name: "DogumTamTarih",
                table: "Vatandaslar");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Teslimatlar");

            migrationBuilder.RenameColumn(
                name: "TeslimatId",
                table: "VatandasTeslimatlar",
                newName: "teslimatId");

            migrationBuilder.RenameColumn(
                name: "TalepId",
                table: "VatandasTalepler",
                newName: "talepId");

            migrationBuilder.RenameColumn(
                name: "TCKimlik",
                table: "Vatandaslar",
                newName: "tcKimlik");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Vatandaslar",
                newName: "soyad");

            migrationBuilder.RenameColumn(
                name: "IkematgahId",
                table: "Vatandaslar",
                newName: "ikematgahId");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Vatandaslar",
                newName: "ad");

            migrationBuilder.RenameIndex(
                name: "IX_Vatandaslar_IkematgahId",
                table: "Vatandaslar",
                newName: "IX_Vatandaslar_ikematgahId");

            migrationBuilder.RenameColumn(
                name: "VatandasTeslimatId",
                table: "Teslimatlar",
                newName: "vatandasTeslimatId");

            migrationBuilder.RenameIndex(
                name: "IX_Teslimatlar_VatandasTeslimatId",
                table: "Teslimatlar",
                newName: "IX_Teslimatlar_vatandasTeslimatId");

            migrationBuilder.RenameColumn(
                name: "VatandasTalepId",
                table: "Talepler",
                newName: "vatandasTalepId");

            migrationBuilder.RenameColumn(
                name: "TalepTarihi",
                table: "Talepler",
                newName: "talepTarihi");

            migrationBuilder.RenameColumn(
                name: "SozlesmeFotograf",
                table: "Talepler",
                newName: "sozlesmeFotograf");

            migrationBuilder.RenameColumn(
                name: "Onay",
                table: "Talepler",
                newName: "onay");

            migrationBuilder.RenameColumn(
                name: "Kiraci",
                table: "Talepler",
                newName: "kiraci");

            migrationBuilder.RenameColumn(
                name: "KalinanEvinAdresi",
                table: "Talepler",
                newName: "kalinanEvinAdresi");

            migrationBuilder.RenameIndex(
                name: "IX_Talepler_VatandasTalepId",
                table: "Talepler",
                newName: "IX_Talepler_vatandasTalepId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OperasyonelTalepler",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "KullaniciOperasyonelTalepler",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "OperationClaimId",
                table: "KullaniciOperasyonelTalepler",
                newName: "operationClaimId");

            migrationBuilder.RenameColumn(
                name: "Soyad",
                table: "Kullanicilar",
                newName: "soyad");

            migrationBuilder.RenameColumn(
                name: "SifreSalt",
                table: "Kullanicilar",
                newName: "sifreSalt");

            migrationBuilder.RenameColumn(
                name: "SifreHash",
                table: "Kullanicilar",
                newName: "sifreHash");

            migrationBuilder.RenameColumn(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                newName: "kullaniciAdi");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Kullanicilar",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Kullanicilar",
                newName: "durum");

            migrationBuilder.RenameColumn(
                name: "CepTelefonNumarasi",
                table: "Kullanicilar",
                newName: "ceptelefonNumarasi");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Kullanicilar",
                newName: "ad");

            migrationBuilder.RenameColumn(
                name: "EvAdres",
                table: "KisiselBilgiler",
                newName: "evAdres");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "KisiselBilgiler",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CepTelefonNumarasi",
                table: "KisiselBilgiler",
                newName: "ceptelefonNumarasi");

            migrationBuilder.RenameColumn(
                name: "IkematgahAdres",
                table: "İkematgahlar",
                newName: "ikematgahAdres");

            migrationBuilder.AlterColumn<int>(
                name: "ikematgahId",
                table: "Vatandaslar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "dogumTarih",
                table: "Vatandaslar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "teslimatToken",
                table: "Teslimatlar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "talepTarihi",
                table: "Talepler",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "refreshToken",
                table: "Kullanicilar",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "refreshTokenEndDate",
                table: "Kullanicilar",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Talepler_VatandasTalepler_vatandasTalepId",
                table: "Talepler",
                column: "vatandasTalepId",
                principalTable: "VatandasTalepler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teslimatlar_VatandasTeslimatlar_vatandasTeslimatId",
                table: "Teslimatlar",
                column: "vatandasTeslimatId",
                principalTable: "VatandasTeslimatlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vatandaslar_İkematgahlar_ikematgahId",
                table: "Vatandaslar",
                column: "ikematgahId",
                principalTable: "İkematgahlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talepler_VatandasTalepler_vatandasTalepId",
                table: "Talepler");

            migrationBuilder.DropForeignKey(
                name: "FK_Teslimatlar_VatandasTeslimatlar_vatandasTeslimatId",
                table: "Teslimatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Vatandaslar_İkematgahlar_ikematgahId",
                table: "Vatandaslar");

            migrationBuilder.DropColumn(
                name: "dogumTarih",
                table: "Vatandaslar");

            migrationBuilder.DropColumn(
                name: "teslimatToken",
                table: "Teslimatlar");

            migrationBuilder.DropColumn(
                name: "refreshToken",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "refreshTokenEndDate",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "teslimatId",
                table: "VatandasTeslimatlar",
                newName: "TeslimatId");

            migrationBuilder.RenameColumn(
                name: "talepId",
                table: "VatandasTalepler",
                newName: "TalepId");

            migrationBuilder.RenameColumn(
                name: "tcKimlik",
                table: "Vatandaslar",
                newName: "TCKimlik");

            migrationBuilder.RenameColumn(
                name: "soyad",
                table: "Vatandaslar",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "ikematgahId",
                table: "Vatandaslar",
                newName: "IkematgahId");

            migrationBuilder.RenameColumn(
                name: "ad",
                table: "Vatandaslar",
                newName: "Ad");

            migrationBuilder.RenameIndex(
                name: "IX_Vatandaslar_ikematgahId",
                table: "Vatandaslar",
                newName: "IX_Vatandaslar_IkematgahId");

            migrationBuilder.RenameColumn(
                name: "vatandasTeslimatId",
                table: "Teslimatlar",
                newName: "VatandasTeslimatId");

            migrationBuilder.RenameIndex(
                name: "IX_Teslimatlar_vatandasTeslimatId",
                table: "Teslimatlar",
                newName: "IX_Teslimatlar_VatandasTeslimatId");

            migrationBuilder.RenameColumn(
                name: "vatandasTalepId",
                table: "Talepler",
                newName: "VatandasTalepId");

            migrationBuilder.RenameColumn(
                name: "talepTarihi",
                table: "Talepler",
                newName: "TalepTarihi");

            migrationBuilder.RenameColumn(
                name: "sozlesmeFotograf",
                table: "Talepler",
                newName: "SozlesmeFotograf");

            migrationBuilder.RenameColumn(
                name: "onay",
                table: "Talepler",
                newName: "Onay");

            migrationBuilder.RenameColumn(
                name: "kiraci",
                table: "Talepler",
                newName: "Kiraci");

            migrationBuilder.RenameColumn(
                name: "kalinanEvinAdresi",
                table: "Talepler",
                newName: "KalinanEvinAdresi");

            migrationBuilder.RenameIndex(
                name: "IX_Talepler_vatandasTalepId",
                table: "Talepler",
                newName: "IX_Talepler_VatandasTalepId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "OperasyonelTalepler",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "KullaniciOperasyonelTalepler",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "operationClaimId",
                table: "KullaniciOperasyonelTalepler",
                newName: "OperationClaimId");

            migrationBuilder.RenameColumn(
                name: "soyad",
                table: "Kullanicilar",
                newName: "Soyad");

            migrationBuilder.RenameColumn(
                name: "sifreSalt",
                table: "Kullanicilar",
                newName: "SifreSalt");

            migrationBuilder.RenameColumn(
                name: "sifreHash",
                table: "Kullanicilar",
                newName: "SifreHash");

            migrationBuilder.RenameColumn(
                name: "kullaniciAdi",
                table: "Kullanicilar",
                newName: "KullaniciAdi");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Kullanicilar",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "durum",
                table: "Kullanicilar",
                newName: "Durum");

            migrationBuilder.RenameColumn(
                name: "ceptelefonNumarasi",
                table: "Kullanicilar",
                newName: "CepTelefonNumarasi");

            migrationBuilder.RenameColumn(
                name: "ad",
                table: "Kullanicilar",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "evAdres",
                table: "KisiselBilgiler",
                newName: "EvAdres");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "KisiselBilgiler",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ceptelefonNumarasi",
                table: "KisiselBilgiler",
                newName: "CepTelefonNumarasi");

            migrationBuilder.RenameColumn(
                name: "ikematgahAdres",
                table: "İkematgahlar",
                newName: "IkematgahAdres");

            migrationBuilder.AlterColumn<int>(
                name: "IkematgahId",
                table: "Vatandaslar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTamTarih",
                table: "Vatandaslar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Token",
                table: "Teslimatlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TalepTarihi",
                table: "Talepler",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Talepler_VatandasTalepler_VatandasTalepId",
                table: "Talepler",
                column: "VatandasTalepId",
                principalTable: "VatandasTalepler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teslimatlar_VatandasTeslimatlar_VatandasTeslimatId",
                table: "Teslimatlar",
                column: "VatandasTeslimatId",
                principalTable: "VatandasTeslimatlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vatandaslar_İkematgahlar_IkematgahId",
                table: "Vatandaslar",
                column: "IkematgahId",
                principalTable: "İkematgahlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
