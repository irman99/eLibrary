using Azure;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Knjiga;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Knjiga;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Services
{
    public class KnjigaService : IKnjigaService
    {
        dbIB190096Context db = new dbIB190096Context();
        public List<GetKnjigeResponse> GetKnjige(GetKnjigeRequest request)
        {
            var query = db.Knjigas.AsQueryable();

            if (request.IdKnjiga.HasValue)
            {
                query = query.Where(k => k.IdKnjiga == request.IdKnjiga.Value);
            }
            if (!string.IsNullOrEmpty(request.Naslov))
            {
                query = query.Where(k => k.Naslov.Contains(request.Naslov));
            }
            if (request.AutorId.HasValue)
            {
                query = query.Where(k => k.AutorId == request.AutorId.Value);
            }
            if (request.DatumIzdavanja.HasValue)
            {
                query = query.Where(k => k.DatumIzdavanja.Year == request.DatumIzdavanja.Value.Year);
            }
            if (request.Dostupnost.HasValue)
            {
                query = query.Where(k => k.Dostupnost == request.Dostupnost.Value);
            }
            if (request.Cijena.HasValue)
            {
                query = query.Where(k => k.Cijena == request.Cijena.Value);
            }
            if (request.SelectedZanrIds != null && request.SelectedZanrIds.Count > 0)
            {
                var knjigaIds = db.ZanroviKnjigas
                    .Where(zk => request.SelectedZanrIds.Select(z => z).Contains(zk.ZanrId))
                    .Select(zk => zk.KnjigaId)
                    .Distinct()
                    .ToList();
                query = query.Where(k => knjigaIds.Contains(k.IdKnjiga));
            }

            var response = query.ToList();

            var dataList = new List<GetKnjigeResponse>();

            foreach (var item in response)
            {
                dataList.Add(new GetKnjigeResponse()
                {
                    AutorId = item.AutorId,
                    Cijena = item.Cijena,
                    DatumIzdavanja = item.DatumIzdavanja,
                    Dostupnost = item.Dostupnost,
                    IdKnjiga = item.IdKnjiga,
                    Naslov = item.Naslov,
                    NaslovnaSlika = item.NaslovnaSlika,
                    Opis = item.Opis
                });
            }

            return dataList;
        }




        public CommonResponse CreateKnjiga(CreateKnjigaRequest request)
        {
            var KnjigaExists = db.Knjigas.Where(x => x.Naslov.Equals(request.Naslov)).FirstOrDefault();
            if (KnjigaExists != null)
            {
                throw new InvalidOperationException("Naslov knjige je vec zauzet.");
            }
            var AutorExists=db.Autors.Where(x=>x.AutorId==request.AutorId).FirstOrDefault();
            if (AutorExists == null) {
                throw new NullReferenceException("Autor ne postoji.");
            }

            var newObject=new Knjiga() { 
            AutorId = request.AutorId,
            Cijena = request.Cijena,
            DatumIzdavanja = request.DatumIzdavanja,
            Dostupnost = true,
            Opis= request.Opis,
            Naslov= request.Naslov,
            NaslovnaSlika= request.NaslovnaSlika,
            };
            
            var response = db.Knjigas.Add(newObject);
            db.SaveChanges();

            foreach (var zanrId in request.SelectedZanrIds)
            {
                var zanrKnjiga = new ZanroviKnjiga
                {
                    KnjigaId = newObject.IdKnjiga, 
                    ZanrId = zanrId 
                };
                db.ZanroviKnjigas.Add(zanrKnjiga);
            }

            db.SaveChanges();

            var knjigaKorisnik = new KnjigaKorisnik
            {
                KorisnikId = request.AutorId, 
                KnjigaId = newObject.IdKnjiga
            };

            return new CommonResponse() { Id = response.Entity.IdKnjiga };
        }

        public CommonResponse UpdateKnjiga(UpdateKnjigaRequest request) {
            var knjiga = db.Knjigas.FirstOrDefault(k => k.IdKnjiga == request.IdKnjiga);

            if (knjiga == null)
            {
                return new CommonResponse { Message = $"Knjiga {request.IdKnjiga} nije pronadjena." };
            }
            if (request.Naslov != null)
            {
                knjiga.Naslov = request.Naslov;
            }
            if (request.Opis != null)
            {
                knjiga.Opis = request.Opis;
            }
            if (request.Dostupnost != null)
            {
                knjiga.Dostupnost = request.Dostupnost.Value;
            }
            if (request.Cijena != null)
            {
                knjiga.Cijena = request.Cijena.Value;
            }
            if (request.NaslovnaSlika != null)
            {
                knjiga.NaslovnaSlika = request.NaslovnaSlika;
            }

            db.SaveChanges();

            return new CommonResponse {Message = $"Knjiga {request.IdKnjiga} uspjesno updateovana." };


        }

        public CommonResponse DeleteKnjiga(CommonDeleteRequest request) {
            var knjiga = db.Knjigas.FirstOrDefault(k => k.IdKnjiga == request.Id);

            if (knjiga == null)
            {
                return new CommonResponse { Message = $"Knjiga {request.Id} nije pronadjena." };
            }
            db.Knjigas.Remove(knjiga);
            db.SaveChanges();

            return new CommonResponse { Message = $"Knjiga {request.Id} uspjesno izbrisana." };
        }
    }
}
