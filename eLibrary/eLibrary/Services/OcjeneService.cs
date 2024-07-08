using eLibrary.Commons.DTOs.Requests.Ocjene;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;

namespace eLibrary.Services
{
    public class OcjeneService : IOcjeneService
    {
        dbIB190096Context _db= new dbIB190096Context();

        public CommonResponse CreateOcjenaKorisnik(CreateOcjenaRequest request)
        {
            var ocjena = new Ocjene
            {
                IdKorisnik = request.IdKorisnik,
                IdKorisnikPosiljalac = request.IdKorisnikPosiljalac,
                TipOcjene = false,
                Rating = request.Rating
            };

            _db.Ocjenes.Add(ocjena);
            _db.SaveChanges();

            return new CommonResponse { Message = "Korisnik uspjesno ocjenjen." };
        }

        public CommonResponse CreateOcjenaKnjiga(CreateOcjenaRequest request)
        {
            var ocjena = new Ocjene
            {
                IdKnjiga = request.IdKnjiga,
                IdKorisnikPosiljalac = request.IdKorisnikPosiljalac,
                TipOcjene = true,
                Rating = request.Rating
            };

            _db.Ocjenes.Add(ocjena);
            _db.SaveChanges();

            return new CommonResponse { Message = "Knjiga uspjesno ocjenjena." };
        }

        public CommonResponse UpdateOcjena(UpdateOcjenaRequest request)
        {
            var korisnikKojiOcjenjuje=_db.Ocjenes.Where(x=>x.IdKorisnikPosiljalac==request.IdKorisnikPosiljalac).ToList();

            var ocjenaZaUpdate = korisnikKojiOcjenjuje.Where(x => x.IdKorisnik == request.IdKorisnik || x.IdKnjiga == request.IdKnjiga).FirstOrDefault();

            if (ocjenaZaUpdate == null)
            {
                return new CommonResponse {Message = "Ocjena nije pronadjena ili niste autorizovani za promjenu ocjene." };
            }

            ocjenaZaUpdate.Rating = request.Rating;
            
            _db.SaveChanges();

            return new CommonResponse {Message = "Ocjena uspjesno updateovana." };
        }

        public GetOcjenaResponse GetOcjenaKorisnika(GetOcjenaRequest request)
        {
            IQueryable<Ocjene> query = _db.Ocjenes;

            if (request.IdKorisnik.HasValue)
            {
                query = query.Where(o => o.IdKorisnik == request.IdKorisnik);
            }

            decimal averageRating = query.Average(o => o.Rating);

            return new GetOcjenaResponse
            {
                AverageRating = averageRating,
                Description = $"Ocjena korisnika {request.IdKorisnik} iznosi: {averageRating}"
            };
        }
        public GetOcjenaResponse GetOcjenaKnjige(GetOcjenaRequest request)
        {
            IQueryable<Ocjene> query = _db.Ocjenes;

            if (request.IdKnjiga.HasValue)
            {
                query = query.Where(o => o.IdKnjiga == request.IdKnjiga);
            }

            decimal averageRating = query.Average(o => o.Rating);

            return new GetOcjenaResponse
            {
                AverageRating = averageRating,
                Description = $"Ocjena knjige {request.IdKnjiga} iznosi: {averageRating}"
            };
        }
    }
}
