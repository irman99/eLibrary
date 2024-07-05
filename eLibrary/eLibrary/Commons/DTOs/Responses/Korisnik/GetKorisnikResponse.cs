using eLibrary.Database.Models;

namespace eLibrary.Commons.DTOs.Responses.Korisnik
{
    public class GetKorisnikResponse
    {
        public int IdKorisnik { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string KorisnickoIme { get; set; } = null!;
        public byte[]? Fotografija { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
    }
}
