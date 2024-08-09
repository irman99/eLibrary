using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Korisnik;

namespace eLibrary.Commons.Interfaces
{
    public interface IKorisnikService
    {
        CommonResponse RegisterKorisnik(RegisterKorisnikRequest request);
        CommonResponse LoginKorisnik(LoginKorisnikRequest request);
        List<GetKorisnikResponse> GetAllKorisniks();
        GetKorisnikResponse GetKorisnik(GetKorisnikRequest request);
        CommonResponse UpdateKorisnik(UpdateKorisnikRequest request);
        CommonResponse DeleteKorisnik(CommonDeleteRequest request);
    }
}