namespace eLibrary.Commons.DTOs.Requests.Knjiga
{
    public class CreateKnjigaRequest
    {
        public string Naslov { get; set; } = null!;
        public string Zanr { get; set; } = null!;
        public List<int> SelectedZanrIds { get; set; }
        public int AutorId { get; set; }
        public DateOnly DatumIzdavanja { get; set; }
        public string? Opis { get; set; }
        public bool? Dostupnost { get; set; }
        public decimal? Cijena { get; set; }
        public byte[]? NaslovnaSlika { get; set; }

    }
}
