using eLibrary.Commons.DTOs.Requests.Medalja;
using eLibrary.Commons.DTOs.Responses.Medalja;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Database.Models;

namespace eLibrary.Commons.Interfaces
{
    public interface IMedaljaService
    {
        CommonResponse CreateMedalja(CreateMedaljaRequest request);
        List<GetMedaljaResponse> GetAllMedalje();
        CommonResponse UpdateMedalja(UpdateMedaljaRequest request);
        CommonResponse DeleteMedalja(CommonDeleteRequest request);
        CommonResponse AssignMedaljaToKorisnik(AssignMedaljaToKorisnikRequest request);
        List<Medalja> GetMedaljeForKorisnik(GetMedaljeForKorisnikRequest request);
    }
}
