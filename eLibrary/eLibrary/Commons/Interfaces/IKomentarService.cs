using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Komentar;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Komentar;

namespace eLibrary.Commons.Interfaces
{    
        public interface IKomentarService
        {
            List<GetKomentariResponse> GetKomentariByKnjigaId(GetKomentariRequest request);
            CommonResponse CreateKomentar(CreateKomentarRequest request);
            CommonResponse DeleteKomentar(CommonDeleteRequest request);
            CommonResponse UpdateKomentar(UpdateKomentarRequest request);
        }    
}
