namespace eLibrary.Commons.DTOs.Requests.Ocjene
{
    public class UpdateOcjenaRequest
    {
        public int IdKorisnikPosiljalac { get; set; }
        public int? IdKorisnik { get; set; }
        public int? IdKnjiga { get; set; }
        public decimal Rating { get; set; }
    }
}
