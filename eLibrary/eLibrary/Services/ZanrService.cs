using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Zanr;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Zanr;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;

namespace eLibrary.Services
{
    public class ZanrService : IZanrService
    {
        dbIB190096Context _db = new dbIB190096Context();

        public List<GetZanrResponse> GetZanrovi()
        {
            var zanrovi = _db.Zanrs
                            .Select(z => new GetZanrResponse
                            {
                                ZanrID = z.ZanrId,
                                NazivZanra = z.NazivZanra
                            })
                            .ToList();
            return zanrovi;
        }
        public List<GetZanrResponse> GetZanrKnjige(GetZanrRequest request)
        {
            var zanrKnjiga = _db.ZanroviKnjigas.Where(x => x.KnjigaId == request.KnjigaID).Select(x=>x.ZanrId).ToList();

            var zanrovi = _db.Zanrs.Where(x => zanrKnjiga.Contains(x.ZanrId)).ToList();

            var dataList=new List<GetZanrResponse>();

            foreach (var item in zanrovi)
            {
                dataList.Add(new GetZanrResponse()
                {
                    ZanrID= item.ZanrId,
                    NazivZanra=item.NazivZanra
                });
            }

            return dataList;
        }
        public CommonResponse CreateZanr(CreateZanrRequest request)
        {
            var zanr = new Zanr
            {
                NazivZanra = request.NazivZanra
            };

            _db.Zanrs.Add(zanr);
            _db.SaveChanges();

            return new CommonResponse { Message = "Zanr uspjesno napravljen." };
        }

        public CommonResponse UpdateZanr(UpdateZanrRequest request)
        {
            var zanr = _db.Zanrs.Find(request.ZanrID);

            if (zanr == null)
            {
                throw new Exception($"Zanr sa ID {request.ZanrID} nije pronadjen.");
            }

            zanr.NazivZanra = request.NazivZanra;
            _db.SaveChanges();

            return new CommonResponse { Message = "Zanr uspjesno updateovan." };
        }
        public CommonResponse DeleteZanr(CommonDeleteRequest request)
        {
            var zanr = _db.Zanrs.Find(request.Id);

            if (zanr == null)
            {
                throw new Exception($"Zanr sa ID {request.Id} nije pronadjen.");
            }

            _db.Zanrs.Remove(zanr);
            _db.SaveChanges();

            return new CommonResponse { Message = "Zanr uspjesno izbrisan." };
        }
    }
}
