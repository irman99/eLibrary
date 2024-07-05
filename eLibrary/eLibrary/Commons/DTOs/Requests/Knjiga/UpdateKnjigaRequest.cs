namespace eLibrary.Commons.DTOs.Requests.Knjiga
{
    public class UpdateKnjigaRequest
    {
        public int IdKnjiga { get; set; }
        public string? Naslov { get; set; }
        public string? Zanr { get; set; }
        public string? Opis { get; set; }
        public bool? Dostupnost { get; set; }
        public decimal? Cijena { get; set; }
        public byte[]? NaslovnaSlika { get; set; }
    }
}
