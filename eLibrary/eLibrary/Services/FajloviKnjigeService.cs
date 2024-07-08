using eLibrary.Commons.DTOs.Requests.FajloviKnjige;
using eLibrary.Commons.DTOs.Responses.FajloviKnjige;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Services
{
    public class FajloviKnjigeService : IFajloviKnjigeService
    {
        dbIB190096Context _db = new dbIB190096Context();

        private readonly string _fileUploadPath;

        public FajloviKnjigeService(dbIB190096Context dbContext, string fileUploadPath)
        {
            _fileUploadPath = fileUploadPath ?? throw new ArgumentNullException(nameof(fileUploadPath));
        }

        public async Task<CommonResponse> CreateFajloviKnjige(CreateFajloviKnjigeRequest request)
        {
            if (request.File == null || request.File.Length == 0)
            {
                return new CommonResponse { Message = "Fajl je prazan ili ništa nije odabrano." };
            }

            if (!Directory.Exists(_fileUploadPath))
            {
                Directory.CreateDirectory(_fileUploadPath);
            }

            var filePath = Path.Combine(_fileUploadPath, request.File.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            var fajloviKnjige = new FajloviKnjige
            {
                NazivFilea = request.File.FileName,
                PathToFile = filePath,
                IdKnjiga = request.IdKnjiga
            };

            _db.FajloviKnjiges.Add(fajloviKnjige);
            await _db.SaveChangesAsync();

            return new CommonResponse { Message = "Fajl uspješno uploadovan." };
        }

        public async Task<string> GetFilePathForKnjigaAsync(GetKnjigaFileRequest request)
        {
            bool ownsBook = await _db.KnjigaKorisniks
                .AnyAsync(kk => kk.KorisnikId == request.IdKorisnik && kk.KnjigaId == request.IdKnjiga);

            if (!ownsBook)
            {
                return null;
            }

            var filePath = await _db.FajloviKnjiges
                .Where(f => f.IdKnjiga == request.IdKnjiga)
                .Select(f => f.PathToFile)
                .FirstOrDefaultAsync();

            return filePath;
        }
    }
}
