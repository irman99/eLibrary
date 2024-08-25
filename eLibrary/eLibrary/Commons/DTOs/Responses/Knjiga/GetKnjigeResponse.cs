namespace eLibrary.Commons.DTOs.Responses.Knjiga
{
    public class GetKnjigeResponse
    {
        public int IdKnjiga { get; set; }
        public string Naslov { get; set; } = null!;
        public List<string> Zanrovi { get; set; } = new List<string>();
        public int AutorId { get; set; }
        public DateOnly DatumIzdavanja { get; set; }
        public string? Opis { get; set; }
        public bool? Dostupnost { get; set; }
        public decimal? Cijena { get; set; }
        public byte[]? NaslovnaSlika { get; set; }

    }
}
