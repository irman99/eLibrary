using eLibrary.Database.Models;

namespace eLibrary.Commons.DTOs.Requests.Korisnik
{
    public class UpdateKorisnikRequest
    {
        public int IdKorisnik { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Email { get; set; }
        public string? KorisnickoIme { get; set; }
        public byte[]? Fotografija { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public int? TipKorisnika { get; set; }
    }
}
