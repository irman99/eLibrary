using Azure;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Knjiga;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Knjiga;

namespace eLibrary.Commons.Interfaces
{
    public interface IKnjigaService
    {
        List<GetKnjigeResponse> GetKnjige(GetKnjigeRequest request);
        CommonResponse CreateKnjiga(CreateKnjigaRequest request);
        CommonResponse UpdateKnjiga(UpdateKnjigaRequest request);
        CommonResponse DeleteKnjiga(CommonDeleteRequest reques);

    }
}
