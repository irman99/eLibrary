﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eLibrary.Database.Models;

#nullable disable

namespace eLibrary.Migrations
{
    [DbContext(typeof(dbIB190096Context))]
    [Migration("20240705000722_PopulateTipkorisnika")]
    partial class PopulateTipkorisnika
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_CI_AS")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KnjigaZanr", b =>
                {
                    b.Property<int>("KnjigaId")
                        .HasColumnType("int");

                    b.Property<int>("ZanrId")
                        .HasColumnType("int");

                    b.HasKey("KnjigaId", "ZanrId");

                    b.ToTable("KnjigaZanr");
                });

            modelBuilder.Entity("ZanroviKnjiga", b =>
                {
                    b.Property<int>("KnjigaId")
                        .HasColumnType("int")
                        .HasColumnName("KnjigaID");

                    b.Property<int>("ZanrId")
                        .HasColumnType("int")
                        .HasColumnName("ZanrID");

                    b.HasKey("KnjigaId", "ZanrId")
                        .HasName("PK__ZanroviK__6341075C47E0A703");

                    b.HasIndex("ZanrId");

                    b.ToTable("ZanroviKnjiga", (string)null);
                });

            modelBuilder.Entity("eLibrary.Database.Models.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AutorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutorId"));

                    b.Property<int?>("IdKorisnik")
                        .HasColumnType("int");

                    b.HasKey("AutorId")
                        .HasName("PK__Autor__F58AE909FF3A2D32");

                    b.HasIndex(new[] { "IdKorisnik" }, "UQ__Autor__58FE570FC3ABC52F")
                        .IsUnique()
                        .HasFilter("[IdKorisnik] IS NOT NULL");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("eLibrary.Database.Models.FajloviKnjige", b =>
                {
                    b.Property<int>("IdFile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFile"));

                    b.Property<int?>("IdKnjiga")
                        .HasColumnType("int");

                    b.Property<string>("NazivFilea")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("SadrzajFilea")
                        .HasMaxLength(1)
                        .HasColumnType("binary(1)")
                        .IsFixedLength();

                    b.HasKey("IdFile")
                        .HasName("PK__FajloviK__01E644E1C53A6723");

                    b.HasIndex("IdKnjiga");

                    b.ToTable("FajloviKnjige");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Kartica", b =>
                {
                    b.Property<int>("KarticaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KarticaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KarticaId"));

                    b.Property<string>("BrojKartice")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("char(16)")
                        .IsFixedLength();

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.HasKey("KarticaId")
                        .HasName("PK__Kartica__8B34B3E9772AE18C");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Kartica");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Knjiga", b =>
                {
                    b.Property<int>("IdKnjiga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKnjiga"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int")
                        .HasColumnName("AutorID");

                    b.Property<decimal?>("Cijena")
                        .HasColumnType("money");

                    b.Property<DateOnly>("DatumIzdavanja")
                        .HasColumnType("date");

                    b.Property<bool?>("Dostupnost")
                        .HasColumnType("bit");

                    b.Property<string>("Naslov")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("NaslovnaSlika")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Opis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Zanr")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdKnjiga");

                    b.HasIndex("AutorId");

                    b.ToTable("Knjiga");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KnjigaKorisnik", b =>
                {
                    b.Property<int>("KnjigaKorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KnjigaKorisnikID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KnjigaKorisnikId"));

                    b.Property<int?>("KnjigaId")
                        .HasColumnType("int")
                        .HasColumnName("KnjigaID");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.HasKey("KnjigaKorisnikId")
                        .HasName("PK__KnjigaKo__20694ADD00A98B7C");

                    b.HasIndex("KnjigaId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("KnjigaKorisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Komentari", b =>
                {
                    b.Property<int>("KomentarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KomentarID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KomentarId"));

                    b.Property<int?>("KnjigaId")
                        .HasColumnType("int")
                        .HasColumnName("KnjigaID");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("VrijemeKomentara")
                        .HasColumnType("datetime");

                    b.HasKey("KomentarId")
                        .HasName("PK__Komentar__C0C304BCDCCCF195");

                    b.HasIndex("KnjigaId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Komentari");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Korisnik", b =>
                {
                    b.Property<int>("IdKorisnik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKorisnik"));

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Fotografija")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaHash")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TipKorisnikaId")
                        .HasColumnType("int")
                        .HasColumnName("TipKorisnikaID");

                    b.HasKey("IdKorisnik")
                        .HasName("PK__Korisnik__58FE570E47FC08DE");

                    b.HasIndex("TipKorisnikaId");

                    b.HasIndex(new[] { "KorisnickoIme" }, "UQ__Korisnik__992E6F92044E7587")
                        .IsUnique();

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KorisnikMedalja", b =>
                {
                    b.Property<int>("KorisnikMedaljaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikMedaljaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikMedaljaId"));

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<int?>("MedaljaId")
                        .HasColumnType("int")
                        .HasColumnName("MedaljaID");

                    b.HasKey("KorisnikMedaljaId")
                        .HasName("PK__Korisnik__14DBBC3D0204EBF6");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MedaljaId");

                    b.ToTable("KorisnikMedalja");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Medalja", b =>
                {
                    b.Property<int>("MedaljaId")
                        .HasColumnType("int")
                        .HasColumnName("MedaljaID");

                    b.Property<string>("NazivMedalje")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("SlikaMedalje")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("MedaljaId");

                    b.ToTable("Medalja");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Notifikacije", b =>
                {
                    b.Property<int>("NotifikacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NotifikacijaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotifikacijaId"));

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Procitana")
                        .HasColumnType("bit");

                    b.Property<int>("TipNotifikacijeId")
                        .HasColumnType("int")
                        .HasColumnName("TipNotifikacijeID");

                    b.Property<DateTime>("VrijemeNotifikacije")
                        .HasColumnType("datetime");

                    b.HasKey("NotifikacijaId")
                        .HasName("PK__Notifika__595D01C3706BE0DF");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TipNotifikacijeId");

                    b.ToTable("Notifikacije");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Ocjena", b =>
                {
                    b.Property<int>("OcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OcjenaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OcjenaId"));

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<int?>("Ocjena1")
                        .HasColumnType("int")
                        .HasColumnName("Ocjena");

                    b.Property<bool?>("TipOcjene")
                        .HasColumnType("bit");

                    b.HasKey("OcjenaId")
                        .HasName("PK__Ocjena__E6FC7B49718B4227");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("eLibrary.Database.Models.TipKorisnika", b =>
                {
                    b.Property<int>("IdTipKorisnika")
                        .HasColumnType("int");

                    b.Property<string>("TipKorisnika1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TipKorisnika");

                    b.HasKey("IdTipKorisnika")
                        .HasName("PK__TipKoris__8AAF1E40BE47B039");

                    b.HasIndex(new[] { "TipKorisnika1" }, "UQ__TipKoris__DB142111DAF9DD2B")
                        .IsUnique()
                        .HasFilter("[TipKorisnika] IS NOT NULL");

                    b.ToTable("TipKorisnika");
                });

            modelBuilder.Entity("eLibrary.Database.Models.TipNotifikacije", b =>
                {
                    b.Property<int>("TipNotifikacijeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipNotifikacijeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipNotifikacijeId"));

                    b.Property<string>("NazivNotifikacije")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TipNotifikacijeId")
                        .HasName("PK__TipNotif__A8350ACAF3315E83");

                    b.ToTable("TipNotifikacije");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Zanr", b =>
                {
                    b.Property<int>("ZanrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ZanrID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZanrId"));

                    b.Property<string>("NazivZanra")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ZanrId")
                        .HasName("PK__Zanr__953868F360589D60");

                    b.ToTable("Zanr");
                });

            modelBuilder.Entity("ZanroviKnjiga", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", null)
                        .WithMany()
                        .HasForeignKey("KnjigaId")
                        .IsRequired()
                        .HasConstraintName("FK_ZK_Knjiga");

                    b.HasOne("eLibrary.Database.Models.Zanr", null)
                        .WithMany()
                        .HasForeignKey("ZanrId")
                        .IsRequired()
                        .HasConstraintName("FK_ZK_Zanr");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Autor", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Korisnik", "IdKorisnikNavigation")
                        .WithOne("Autor")
                        .HasForeignKey("eLibrary.Database.Models.Autor", "IdKorisnik")
                        .HasConstraintName("FK_Autor_Korisnik");

                    b.Navigation("IdKorisnikNavigation");
                });

            modelBuilder.Entity("eLibrary.Database.Models.FajloviKnjige", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "IdKnjigaNavigation")
                        .WithMany("FajloviKnjiges")
                        .HasForeignKey("IdKnjiga")
                        .HasConstraintName("FK_Fajlovi_Knjige");

                    b.Navigation("IdKnjigaNavigation");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Kartica", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany("Karticas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Kartica_Korisnik");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Knjiga", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Autor", "Autor")
                        .WithMany("Knjigas")
                        .HasForeignKey("AutorId")
                        .IsRequired()
                        .HasConstraintName("FK_Knjiga_Autor");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KnjigaKorisnik", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany("KnjigaKorisniks")
                        .HasForeignKey("KnjigaId")
                        .HasConstraintName("FK_KK_Knjiga");

                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany("KnjigaKorisniks")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KK_Korisnik");

                    b.Navigation("Knjiga");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Komentari", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Knjiga", "Knjiga")
                        .WithMany("Komentaris")
                        .HasForeignKey("KnjigaId")
                        .HasConstraintName("FK_Komentar_Knjiga");

                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany("Komentaris")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Komentar_Korisnik");

                    b.Navigation("Knjiga");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Korisnik", b =>
                {
                    b.HasOne("eLibrary.Database.Models.TipKorisnika", "TipKorisnika")
                        .WithMany("Korisniks")
                        .HasForeignKey("TipKorisnikaId")
                        .HasConstraintName("FK_Korisnik_TipKorisnika");

                    b.Navigation("TipKorisnika");
                });

            modelBuilder.Entity("eLibrary.Database.Models.KorisnikMedalja", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany("KorisnikMedaljas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisnikMedalja_Korisnik");

                    b.HasOne("eLibrary.Database.Models.Medalja", "Medalja")
                        .WithMany("KorisnikMedaljas")
                        .HasForeignKey("MedaljaId")
                        .HasConstraintName("FK_KorisnikMedalja_Medalja");

                    b.Navigation("Korisnik");

                    b.Navigation("Medalja");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Notifikacije", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany("Notifikacijes")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Notifikacije_Korisnik");

                    b.HasOne("eLibrary.Database.Models.TipNotifikacije", "TipNotifikacije")
                        .WithMany("Notifikacijes")
                        .HasForeignKey("TipNotifikacijeId")
                        .IsRequired()
                        .HasConstraintName("FK_Notifikacije_TipNotifikacije");

                    b.Navigation("Korisnik");

                    b.Navigation("TipNotifikacije");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Ocjena", b =>
                {
                    b.HasOne("eLibrary.Database.Models.Korisnik", "Korisnik")
                        .WithMany("Ocjenas")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Ocjena_Korisnik");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Autor", b =>
                {
                    b.Navigation("Knjigas");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Knjiga", b =>
                {
                    b.Navigation("FajloviKnjiges");

                    b.Navigation("KnjigaKorisniks");

                    b.Navigation("Komentaris");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Korisnik", b =>
                {
                    b.Navigation("Autor");

                    b.Navigation("Karticas");

                    b.Navigation("KnjigaKorisniks");

                    b.Navigation("Komentaris");

                    b.Navigation("KorisnikMedaljas");

                    b.Navigation("Notifikacijes");

                    b.Navigation("Ocjenas");
                });

            modelBuilder.Entity("eLibrary.Database.Models.Medalja", b =>
                {
                    b.Navigation("KorisnikMedaljas");
                });

            modelBuilder.Entity("eLibrary.Database.Models.TipKorisnika", b =>
                {
                    b.Navigation("Korisniks");
                });

            modelBuilder.Entity("eLibrary.Database.Models.TipNotifikacije", b =>
                {
                    b.Navigation("Notifikacijes");
                });
#pragma warning restore 612, 618
        }
    }
}
