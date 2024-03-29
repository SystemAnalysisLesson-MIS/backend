﻿// <auto-generated />
using System;
using IkematgahDegisim.DataAccess.Concerete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IkematgahDegisim.DataAccess.Migrations
{
    [DbContext(typeof(IkematgahDegisimContext))]
    [Migration("20191126213935_CreateTable")]
    partial class CreateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IkematgahDegisim.Core.Entities.Concerete.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SifreHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SifreSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("IkematgahDegisim.Core.Entities.Concerete.KullaniciOperasyonelTalep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KullaniciOperasyonelTalepler");
                });

            modelBuilder.Entity("IkematgahDegisim.Core.Entities.Concerete.OperasyonelTalep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperasyonelTalepler");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Ikematgah", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IkematgahAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("İkematgahlar");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Talep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Kiraci")
                        .HasColumnType("bit");

                    b.Property<byte[]>("SozlesmeFotograf")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VatandasTalepId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VatandasTalepId");

                    b.ToTable("Talepler");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Teslimat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Token")
                        .HasColumnType("int");

                    b.Property<int?>("VatandasTeslimatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VatandasTeslimatId");

                    b.ToTable("Teslimatlar");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Vatandas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTamTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("IkematgahId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TCKimlik")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IkematgahId");

                    b.ToTable("Vatandaslar");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.VatandasKisisel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CepTelefonNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvAdres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KisiselBilgiler");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.VatandasTalep", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("TalepId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VatandasTalepler");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.VatandasTeslimat", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("TeslimatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VatandasTeslimatlar");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Talep", b =>
                {
                    b.HasOne("IkematgahDegisim.Entity.Concerete.VatandasTalep", "VatandasTalep")
                        .WithMany("Talepler")
                        .HasForeignKey("VatandasTalepId");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Teslimat", b =>
                {
                    b.HasOne("IkematgahDegisim.Entity.Concerete.VatandasTeslimat", "VatandasTeslimat")
                        .WithMany("Teslimatlar")
                        .HasForeignKey("VatandasTeslimatId");
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.Vatandas", b =>
                {
                    b.HasOne("IkematgahDegisim.Entity.Concerete.Ikematgah", "Ikematgah")
                        .WithMany("Vatandaslar")
                        .HasForeignKey("IkematgahId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.VatandasKisisel", b =>
                {
                    b.HasOne("IkematgahDegisim.Entity.Concerete.Vatandas", "Vatandas")
                        .WithOne("VatandasKisisel")
                        .HasForeignKey("IkematgahDegisim.Entity.Concerete.VatandasKisisel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.VatandasTalep", b =>
                {
                    b.HasOne("IkematgahDegisim.Entity.Concerete.Vatandas", "Vatandas")
                        .WithOne("VatandasTalep")
                        .HasForeignKey("IkematgahDegisim.Entity.Concerete.VatandasTalep", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IkematgahDegisim.Entity.Concerete.VatandasTeslimat", b =>
                {
                    b.HasOne("IkematgahDegisim.Entity.Concerete.Vatandas", "Vatandas")
                        .WithOne("VatandasTeslimat")
                        .HasForeignKey("IkematgahDegisim.Entity.Concerete.VatandasTeslimat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
