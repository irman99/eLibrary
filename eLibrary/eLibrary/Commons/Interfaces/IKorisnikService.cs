using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Korisnik;
using eLibrary.Database.Models;

namespace eLibrary.Commons.Interfaces
{
    public interface IKorisnikService
    {
        Korisnik GetUserById(string userId);
        Task<CommonResponse> RegisterKorisnikAsync(RegisterKorisnikRequest request);
        Task<LogInResponse> LoginKorisnikAsync(LoginKorisnikRequest request);
        List<GetKorisnikResponse> GetAllKorisniks();
        GetKorisnikResponse GetKorisnik(GetKorisnikRequest request);
        CommonResponse UpdateKorisnik(UpdateKorisnikRequest request);
        CommonResponse DeleteKorisnik(CommonDeleteRequest request);
    }
}