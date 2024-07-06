namespace eLibrary.Commons.DTOs.Requests.Zanr
{
    public class CreateZanrRequest
    {
        public string NazivZanra { get; set; } = null!;
    }

    public class UpdateZanrRequest
    {
        public int ZanrID { get; set; }
        public string NazivZanra { get; set; } = null!;
    }

    public class GetZanrRequest
    {
        public int KnjigaID { get; set; }
    }
}
