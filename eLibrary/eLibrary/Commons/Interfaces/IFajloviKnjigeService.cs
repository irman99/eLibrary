using eLibrary.Commons.DTOs.Requests.FajloviKnjige;
using eLibrary.Commons.DTOs.Responses.FajloviKnjige;
using eLibrary.Commons.DTOs.Responses;

namespace eLibrary.Commons.Interfaces
{
    public interface IFajloviKnjigeService
    {
        Task<CommonResponse> CreateFajloviKnjige(CreateFajloviKnjigeRequest request);
        Task<string> GetFilePathForKnjigaAsync(GetKnjigaFileRequest request);
    }
}
