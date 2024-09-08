using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Korisnik;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eLibrary.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly dbIB190096Context _db;
        private readonly IConfiguration _configuration;

        public KorisnikService(dbIB190096Context db, IConfiguration configuration)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _configuration = configuration;
        }

        public Korisnik GetUserById(string userId)
        {
            return _db.Korisniks.Find(userId);
        }

        public async Task<CommonResponse> RegisterKorisnikAsync(RegisterKorisnikRequest request)
        {
            if (_db.Korisniks.Any(k => k.Email == request.Email || k.KorisnickoIme == request.KorisnickoIme))
            {
                throw new InvalidOperationException("Korisnicko ime ili email koje ste unijeli vec postoji.");
            }

            var salt = GenerateSalt();
            var hash = ComputeHash(request.Lozinka, salt);

            var korisnik = new Korisnik
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                Email = request.Email,
                KorisnickoIme = request.KorisnickoIme,
                LozinkaHash = hash,
                LozinkaSalt = salt,
                DatumRodjenja = request.DatumRodjenja,
                TipKorisnikaId = request.TipKorisnika ?? 3, // Default to user if not specified
            };

            _db.Korisniks.Add(korisnik);
            await _db.SaveChangesAsync();

            return new CommonResponse { Message = "User registered successfully." };
        }

        public List<GetKorisnikResponse> GetAllKorisniks()
        {
            var korisnici = _db.Korisniks.ToList();

            return korisnici.Select(korisnik => new GetKorisnikResponse
            {
                IdKorisnik = korisnik.IdKorisnik,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                KorisnickoIme = korisnik.KorisnickoIme,
                Fotografija = korisnik.Fotografija,
                DatumRodjenja = korisnik.DatumRodjenja,
                TipKorisnika=korisnik.TipKorisnika    
            }).ToList();
        }

        public async Task<Korisnik> ValidateUserAsync(LoginKorisnikRequest request)
        {
            var korisnik = _db.Korisniks
                .FirstOrDefault(k => k.KorisnickoIme == request.KorisnickoIme);

            if (korisnik == null || !VerifyPassword(request.Lozinka, korisnik.LozinkaHash, korisnik.LozinkaSalt))
            {
                return null;
            }

            return korisnik;
        }

        public GetKorisnikResponse GetKorisnik(GetKorisnikRequest request)
        {
            var korisnik = _db.Korisniks.FirstOrDefault(k => k.IdKorisnik == request.IdKorisnik);

            if (korisnik == null)
            {
                throw new Exception($"User with ID {request.IdKorisnik} not found.");
            }

            return new GetKorisnikResponse
            {
                IdKorisnik = korisnik.IdKorisnik,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                KorisnickoIme = korisnik.KorisnickoIme,
                Fotografija = korisnik.Fotografija,
                DatumRodjenja = korisnik.DatumRodjenja,
                TipKorisnika = korisnik.TipKorisnika
            };
        }

        public CommonResponse UpdateKorisnik(UpdateKorisnikRequest request)
        {
            var korisnik = _db.Korisniks.FirstOrDefault(k => k.IdKorisnik == request.IdKorisnik);

            if (korisnik == null)
            {
                throw new InvalidOperationException($"Korisnik sa ID {request.IdKorisnik} ne postoji.");
            }

            if (!string.IsNullOrEmpty(request.Ime))
            {
                korisnik.Ime = request.Ime;
            }
            if (!string.IsNullOrEmpty(request.Prezime))
            {
                korisnik.Prezime = request.Prezime;
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                korisnik.Email = request.Email;
            }
            if (!string.IsNullOrEmpty(request.KorisnickoIme))
            {
                korisnik.KorisnickoIme = request.KorisnickoIme;
            }
            if (request.Fotografija != null)
            {
                korisnik.Fotografija = request.Fotografija;
            }
            if (request.DatumRodjenja.HasValue)
            {
                korisnik.DatumRodjenja = request.DatumRodjenja.Value;
            }
            if (request.TipKorisnika != null)
            {
                korisnik.TipKorisnikaId = request.TipKorisnika.Value;
            }

            _db.SaveChanges();

            return new CommonResponse { Message = "Korisnik uspješno updateovan." };
        }

        public CommonResponse DeleteKorisnik(CommonDeleteRequest request)
        {
            var korisnik = _db.Korisniks.FirstOrDefault(k => k.IdKorisnik == request.Id);

            if (korisnik == null)
            {
                throw new InvalidOperationException($"Korisnik sa ID {request.Id} ne postoji.");
            }
            _db.Korisniks.Remove(korisnik);
            _db.SaveChanges();
            return new CommonResponse { Message = "Korisnik uspješno izbrisan." };
        }

        private static string GenerateSalt()
        {
            using var rng = new RNGCryptoServiceProvider();
            var salt = new byte[16];
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        private static string ComputeHash(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = Encoding.UTF8.GetBytes(password + salt);
            var hash = sha256.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hash);
        }

        private static bool VerifyPassword(string password, string hash, string salt)
        {
            var computedHash = ComputeHash(password, salt);
            return hash == computedHash;
        }

        
    }
}
