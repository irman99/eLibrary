namespace eLibrary.Commons.DTOs.Requests.FajloviKnjige
{
    public class CreateFajloviKnjigeRequest
    {
        public IFormFile File { get; set; }
        public int IdKnjiga { get; set; }
    }

}
