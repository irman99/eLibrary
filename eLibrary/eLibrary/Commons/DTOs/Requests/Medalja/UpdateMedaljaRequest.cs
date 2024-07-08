namespace eLibrary.Commons.DTOs.Requests.Medalja
{
    public class UpdateMedaljaRequest
    {
        public int MedaljaID { get; set; }
        public string? NazivMedalje { get; set; }
        public byte[]? SlikaMedalje { get; set; }
    }
}
