using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eLibrary.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    LozinkaHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__58FE570E47FC08DE", x => x.IdKorisnik);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Autor__F58AE909C6B597BE", x => x.AutorID);
                    table.ForeignKey(
                        name: "FK__Autor__KorisnikI__2CF2ADDF",
                        column: x => x.KorisnikID,
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
                name: "Knjiga",
                columns: table => new
                {
                    IdKnjiga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    NazivFilea = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PathToFile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdKnjiga = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FajloviK__01E644E18C3C6F9A", x => x.IdFile);
                    table.ForeignKey(
                        name: "FK_FajloviKnjige_Knjiga",
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
                name: "Ocjene",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKorisnik = table.Column<int>(type: "int", nullable: true),
                    IdKnjiga = table.Column<int>(type: "int", nullable: true),
                    IdKorisnikPosiljalac = table.Column<int>(type: "int", nullable: false),
                    TipOcjene = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ocjene__E6FC7B494960E30A", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK__Ocjene__IdKnjiga__25518C17",
                        column: x => x.IdKnjiga,
                        principalTable: "Knjiga",
                        principalColumn: "IdKnjiga");
                    table.ForeignKey(
                        name: "FK__Ocjene__IdKorisn__245D67DE",
                        column: x => x.IdKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                    table.ForeignKey(
                        name: "FK__Ocjene__IdKorisn__2645B050",
                        column: x => x.IdKorisnikPosiljalac,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik");
                });

            migrationBuilder.CreateTable(
                name: "ZanroviKnjiga",
                columns: table => new
                {
                    ZanroviKnjigaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KnjigaID = table.Column<int>(type: "int", nullable: false),
                    ZanrID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ZanroviK__1B7D23DBE4800B7D", x => x.ZanroviKnjigaID);
                    table.ForeignKey(
                        name: "FK__ZanroviKn__Knjig__123EB7A3",
                        column: x => x.KnjigaID,
                        principalTable: "Knjiga",
                        principalColumn: "IdKnjiga");
                    table.ForeignKey(
                        name: "FK__ZanroviKn__ZanrI__1332DBDC",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Autor_KorisnikID",
                table: "Autor",
                column: "KorisnikID");

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
                name: "IX_Ocjene_IdKnjiga",
                table: "Ocjene",
                column: "IdKnjiga");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_IdKorisnik",
                table: "Ocjene",
                column: "IdKorisnik");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_IdKorisnikPosiljalac",
                table: "Ocjene",
                column: "IdKorisnikPosiljalac");

            migrationBuilder.CreateIndex(
                name: "IX_ZanroviKnjiga_KnjigaID",
                table: "ZanroviKnjiga",
                column: "KnjigaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZanroviKnjiga_ZanrID",
                table: "ZanroviKnjiga",
                column: "ZanrID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FajloviKnjige");

            migrationBuilder.DropTable(
                name: "Kartica");

            migrationBuilder.DropTable(
                name: "KnjigaKorisnik");

            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "KorisnikMedalja");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "ZanroviKnjiga");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
        }
    }
}
