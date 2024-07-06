namespace eLibrary.Commons.DTOs.Responses.Komentar
{
    public class GetKomentariResponse
    {
        public int KomentarID { get; set; }
        public int KnjigaID { get; set; }
        public int KorisnikID { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemeKomentara { get; set; }
    }
}
