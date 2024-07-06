namespace eLibrary.Commons.DTOs.Requests.Komentar
{
    public class CreateKomentarRequest
    {
        public int KnjigaID { get; set; }
        public int KorisnikID { get; set; }
        public string Sadrzaj { get; set; }
    }

    public class GetKomentariRequest
    {
        public int KnjigaID { get; set; }
    }

    public class UpdateKomentarRequest
    {
        public int KomentarID { get; set; }
        public string Sadrzaj { get; set; }
    }
}
