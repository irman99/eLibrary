using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Medalja;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Medalja;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;

namespace eLibrary.Services
{
    public class MedaljaService : IMedaljaService
    {
        dbIB190096Context _db = new dbIB190096Context();

        public CommonResponse CreateMedalja(CreateMedaljaRequest request)
        {
            var medalja = new Medalja
            {
                NazivMedalje = request.NazivMedalje,
                SlikaMedalje = request.SlikaMedalje
            };

            _db.Medaljas.Add(medalja);
            _db.SaveChanges();

            return new CommonResponse { Message = "Medalja uspjesno kreirana." };
        }

        public List<GetMedaljaResponse> GetAllMedalje()
        {
            var medalje = _db.Medaljas
                            .Select(m => new GetMedaljaResponse
                            {
                                MedaljaID = m.MedaljaId,
                                NazivMedalje = m.NazivMedalje
                            })
                            .ToList();

            return medalje;
        }
        public CommonResponse UpdateMedalja(UpdateMedaljaRequest request)
        {

            var medalja = _db.Medaljas.FirstOrDefault(m => m.MedaljaId == request.MedaljaID);
            if (medalja == null)
            {
                return new CommonResponse { Message = "Medalja nije pronadjena." };
            }

            medalja.NazivMedalje = request.NazivMedalje;
            medalja.SlikaMedalje = request.SlikaMedalje;

            _db.SaveChanges();

            return new CommonResponse { Message = "Medalja uspjesno updateovana." };

        }

        public CommonResponse DeleteMedalja(CommonDeleteRequest request)
        {

            var medalja = _db.Medaljas.FirstOrDefault(m => m.MedaljaId == request.Id);
            if (medalja == null)
            {
                return new CommonResponse { Message = "Medalja nije pronadjena." };
            }

            _db.Medaljas.Remove(medalja);
            _db.SaveChanges();

            return new CommonResponse { Message = "Medalja uspjesno izbrisana." };

        }
        public CommonResponse AssignMedaljaToKorisnik(AssignMedaljaToKorisnikRequest request)
        {

            // Check if the Korisnik and Medalja exist
            var korisnik = _db.Korisniks.Find(request.KorisnikID);
            if (korisnik == null)
            {
                return new CommonResponse { Message = "Korisnik nije pronadjen." };
            }

            var medalja = _db.Medaljas.Find(request.MedaljaID);
            if (medalja == null)
            {
                return new CommonResponse { Message = "Medalja nije pronadjena." };
            }

            // Assign the medal to the Korisnik (create a new entry in KorisnikMedalja)
            var korisnikMedalja = new KorisnikMedalja
            {
                KorisnikId = request.KorisnikID,
                MedaljaId = request.MedaljaID
            };

            _db.KorisnikMedaljas.Add(korisnikMedalja);
            _db.SaveChanges();

            return new CommonResponse { Message = "Medalja uspjesno dodijeljena korisniku." };

        }
        public List<Medalja> GetMedaljeForKorisnik(GetMedaljeForKorisnikRequest request)
        {

            var korisnikMedaljaIds = _db.KorisnikMedaljas.Where(x => x.KorisnikId == request.KorisnikID).Select(x => x.MedaljaId).ToList();

            var medalje = _db.Medaljas.Where(x => korisnikMedaljaIds.Contains(x.MedaljaId)).ToList();

            return medalje;
        }
    }
}
