using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eLibrary.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTipKorisnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO TipKorisnika (IdTipKorisnika, TipKorisnika) VALUES (1, 'admin'), (2, 'superadmin'), (3, 'korisnik');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TipKorisnika WHERE IdTipKorisnika IN (1, 2, 3);");
        }
    }
}
