using eLibrary.Database.Models;

namespace eLibrary.Commons.DTOs.Requests.Korisnik
{
    public class RegisterKorisnikRequest
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public string Lozinka { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }
        public int? TipKorisnika { get; set; }
    }
}
