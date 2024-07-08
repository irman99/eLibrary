namespace eLibrary.Commons.DTOs.Requests.Ocjene
{
    public class CreateOcjenaRequest
    {
        public int? IdKorisnik { get; set; }
        public int? IdKnjiga { get; set; }
        public int IdKorisnikPosiljalac { get; set; }
        public decimal Rating { get; set; }
    }
}
