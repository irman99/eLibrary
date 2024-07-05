using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eLibrary.Migrations
{
    /// <inheritdoc />
    public partial class PopulateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KnjigaZanr",
                columns: table => new
                {
                    KnjigaId = table.Column<int>(type: "int", nullable: false),
                    ZanrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjigaZanr", x => new { x.KnjigaId, x.ZanrId });
                });

            migrationBuilder.CreateTable(
                name: "Medalja",
                columns: table => new
                {
                    MedaljaID = table.Column<int>(type: "int", nullable: false),
                    NazivMedalje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SlikaMedalje = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medalja", x => x.MedaljaID);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnika",
                columns: table => new
                {
                    IdTipKorisnika = table.Column<int>(type: "int", nullable: false),
                    TipKorisnika = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipKoris__8AAF1E40BE47B039", x => x.IdTipKorisnika);
                });

            migrationBuilder.CreateTable(
                name: "TipNotifikacije",
                columns: table => new
                {
                    TipNotifikacijeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivNotifikacije = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipNotif__A8350ACAF3315E83", x => x.TipNotifikacijeID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ZanrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivZanra = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Zanr__953868F360589D60", x => x.ZanrID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    IdKorisnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fotografija = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipKorisnikaID = table.Column<int>(type: "int", nullable: true),
                    LozinkaHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__58FE570E47FC08DE", x => x.IdKorisnik);
                    table.ForeignKey(
                        name: "FK_Korisnik_TipKorisnika",
                        column: x => x.TipKorisnikaID,
                        principalTable: "TipKorisnika",
                        principalColumn: "IdTipKorisnika");
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKorisnik = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Autor__F58AE909FF3A2D32", x => x.AutorID);
                    table.ForeignKey(
                        name: "FK_Autor_Korisnik",
                        column: x => x.IdKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                });

            migrationBuilder.CreateTable(
                name: "Kartica",
                columns: table => new
                {
                    KarticaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKartice = table.Column<string>(type: "char(16)", unicode: false, fixedLength: true, maxLength: 16, nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kartica__8B34B3E9772AE18C", x => x.KarticaID);
                    table.ForeignKey(
                        name: "FK_Kartica_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikMedalja",
                columns: table => new
                {
                    KorisnikMedaljaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: true),
                    MedaljaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__14DBBC3D0204EBF6", x => x.KorisnikMedaljaID);
                    table.ForeignKey(
                        name: "FK_KorisnikMedalja_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                    table.ForeignKey(
                        name: "FK_KorisnikMedalja_Medalja",
                        column: x => x.MedaljaID,
                        principalTable: "Medalja",
                        principalColumn: "MedaljaID");
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    NotifikacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: true),
                    Poruka = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VrijemeNotifikacije = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipNotifikacijeID = table.Column<int>(type: "int", nullable: false),
                    Procitana = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifika__595D01C3706BE0DF", x => x.NotifikacijaID);
                    table.ForeignKey(
                        name: "FK_Notifikacije_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                    table.ForeignKey(
                        name: "FK_Notifikacije_TipNotifikacije",
                        column: x => x.TipNotifikacijeID,
                        principalTable: "TipNotifikacije",
                        principalColumn: "TipNotifikacijeID");
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<int>(type: "int", nullable: true),
                    TipOcjene = table.Column<bool>(type: "bit", nullable: true),
                    KorisnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ocjena__E6FC7B49718B4227", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK_Ocjena_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    IdKnjiga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Zanr = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    DatumIzdavanja = table.Column<DateOnly>(type: "date", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Dostupnost = table.Column<bool>(type: "bit", nullable: true),
                    Cijena = table.Column<decimal>(type: "money", nullable: true),
                    NaslovnaSlika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.IdKnjiga);
                    table.ForeignKey(
                        name: "FK_Knjiga_Autor",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "AutorID");
                });

            migrationBuilder.CreateTable(
                name: "FajloviKnjige",
                columns: table => new
                {
                    IdFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivFilea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SadrzajFilea = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: true),
                    IdKnjiga = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FajloviK__01E644E1C53A6723", x => x.IdFile);
                    table.ForeignKey(
                        name: "FK_Fajlovi_Knjige",
                        column: x => x.IdKnjiga,
                        principalTable: "Knjiga",
                        principalColumn: "IdKnjiga");
                });

            migrationBuilder.CreateTable(
                name: "KnjigaKorisnik",
                columns: table => new
                {
                    KnjigaKorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: true),
                    KnjigaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KnjigaKo__20694ADD00A98B7C", x => x.KnjigaKorisnikID);
                    table.ForeignKey(
                        name: "FK_KK_Knjiga",
                        column: x => x.KnjigaID,
                        principalTable: "Knjiga",
                        principalColumn: "IdKnjiga");
                    table.ForeignKey(
                        name: "FK_KK_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                });

            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    KomentarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnjigaID = table.Column<int>(type: "int", nullable: true),
                    KorisnikID = table.Column<int>(type: "int", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VrijemeKomentara = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Komentar__C0C304BCDCCCF195", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_Komentar_Knjiga",
                        column: x => x.KnjigaID,
                        principalTable: "Knjiga",
                        principalColumn: "IdKnjiga");
                    table.ForeignKey(
                        name: "FK_Komentar_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                });

            migrationBuilder.CreateTable(
                name: "ZanroviKnjiga",
                columns: table => new
                {
                    KnjigaID = table.Column<int>(type: "int", nullable: false),
                    ZanrID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ZanroviK__6341075C47E0A703", x => new { x.KnjigaID, x.ZanrID });
                    table.ForeignKey(
                        name: "FK_ZK_Knjiga",
                        column: x => x.KnjigaID,
                        principalTable: "Knjiga",
                        principalColumn: "IdKnjiga");
                    table.ForeignKey(
                        name: "FK_ZK_Zanr",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Autor__58FE570FC3ABC52F",
                table: "Autor",
                column: "IdKorisnik",
                unique: true,
                filter: "[IdKorisnik] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FajloviKnjige_IdKnjiga",
                table: "FajloviKnjige",
                column: "IdKnjiga");

            migrationBuilder.CreateIndex(
                name: "IX_Kartica_KorisnikID",
                table: "Kartica",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_AutorID",
                table: "Knjiga",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_KnjigaKorisnik_KnjigaID",
                table: "KnjigaKorisnik",
                column: "KnjigaID");

            migrationBuilder.CreateIndex(
                name: "IX_KnjigaKorisnik_KorisnikID",
                table: "KnjigaKorisnik",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_KnjigaID",
                table: "Komentari",
                column: "KnjigaID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_KorisnikID",
                table: "Komentari",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_TipKorisnikaID",
                table: "Korisnik",
                column: "TipKorisnikaID");

            migrationBuilder.CreateIndex(
                name: "UQ__Korisnik__992E6F92044E7587",
                table: "Korisnik",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikMedalja_KorisnikID",
                table: "KorisnikMedalja",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikMedalja_MedaljaID",
                table: "KorisnikMedalja",
                column: "MedaljaID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_KorisnikID",
                table: "Notifikacije",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacije_TipNotifikacijeID",
                table: "Notifikacije",
                column: "TipNotifikacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_KorisnikID",
                table: "Ocjena",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "UQ__TipKoris__DB142111DAF9DD2B",
                table: "TipKorisnika",
                column: "TipKorisnika",
                unique: true,
                filter: "[TipKorisnika] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ZanroviKnjiga_ZanrID",
                table: "ZanroviKnjiga",
                column: "ZanrID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FajloviKnjige");

            migrationBuilder.DropTable(
                name: "Kartica");

            migrationBuilder.DropTable(
                name: "KnjigaKorisnik");

            migrationBuilder.DropTable(
                name: "KnjigaZanr");

            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "KorisnikMedalja");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "ZanroviKnjiga");

            migrationBuilder.DropTable(
                name: "Medalja");

            migrationBuilder.DropTable(
                name: "TipNotifikacije");

            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "TipKorisnika");
        }
    }
}
