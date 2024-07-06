using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Komentar;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Komentar;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;

namespace eLibrary.Services
{
    public class KomentarService : IKomentarService
    {
        dbIB190096Context _db= new dbIB190096Context();

        public CommonResponse CreateKomentar(CreateKomentarRequest request)
        {
            var komentar = new Komentari
            {
                KnjigaId = request.KnjigaID,
                KorisnikId = request.KorisnikID,
                Sadrzaj = request.Sadrzaj,
                VrijemeKomentara = DateTime.Now
            };

            _db.Komentaris.Add(komentar);
            _db.SaveChanges();

            return new CommonResponse { Message = "Komentar uspjesno kreiran." };
        }
        public CommonResponse DeleteKomentar(CommonDeleteRequest request)
        {
            var komentar = _db.Komentaris.Find(request.Id);

            if (komentar == null)
            {
                return new CommonResponse { Message = "Komentar nije pronadjen." };
            }

            _db.Komentaris.Remove(komentar);
            _db.SaveChanges();

            return new CommonResponse { Message = "Komentar uspjesno izbrisan." };
        }

        public List<GetKomentariResponse> GetKomentariByKnjigaId(GetKomentariRequest request)
        {
            var komentari = _db.Komentaris.Where(k => k.KnjigaId == request.KnjigaID).ToList();

            var datalist=new List<GetKomentariResponse>();

            foreach (var item in komentari)
            {
                datalist.Add(new GetKomentariResponse()
                {
                    KomentarID=item.KomentarId,
                    KnjigaID=item.KnjigaId.Value,
                    Sadrzaj=item.Sadrzaj,
                    KorisnikID=item.KorisnikId.Value,
                    VrijemeKomentara=item.VrijemeKomentara.Value
                });
            }
            return datalist;
        }

        public CommonResponse UpdateKomentar(UpdateKomentarRequest request)
        {
            var komentar = _db.Komentaris.Find(request.KomentarID);

            if (komentar == null)
            {
                return new CommonResponse {Message = "Komentar nije pronadjen." };
            }

            komentar.Sadrzaj = request.Sadrzaj;
            _db.SaveChanges();

            return new CommonResponse { Message = "Komentar uspjesno updateovan." };
        }
    }
}
