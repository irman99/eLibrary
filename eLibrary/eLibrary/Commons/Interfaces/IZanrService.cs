using eLibrary.Commons.DTOs.Requests.Zanr;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Responses.Zanr;
using eLibrary.Commons.DTOs.Responses;

namespace eLibrary.Commons.Interfaces
{
    public interface IZanrService
    {
        List<GetZanrResponse> GetZanrovi();
        GetZanrResponse GetZanr(GetZanrRequest request);
        CommonResponse CreateZanr(CreateZanrRequest request);
        CommonResponse UpdateZanr(UpdateZanrRequest request);
        CommonResponse DeleteZanr(CommonDeleteRequest request);
    }
}
