namespace eLibrary.Commons.DTOs.Requests.Knjiga
{
    public class GetKnjigeRequest
    {
        public int? IdKnjiga { get; set; }
        public string? Naslov { get; set; }
        public string? Zanr { get; set; }
        public int? AutorId { get; set; }
        public DateOnly? DatumIzdavanja { get; set; }
        public bool? Dostupnost { get; set; }
        public decimal? Cijena { get; set; }

    }
}
