using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Korisnik;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eLibrary.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly byte[] _secretKey;
        private readonly dbIB190096Context _db;

        public KorisnikService(string secretKey, dbIB190096Context db)
        {
            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32) // Check if the key is at least 32 bytes (256 bits)
                throw new ArgumentException("Secret key must be at least 256 bits long.", nameof(secretKey));

            _secretKey = Convert.FromBase64String(secretKey);
            if (_secretKey.Length != 32)
                throw new ArgumentException("Secret key must be 256 bits (32 bytes) long.", nameof(secretKey));

            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public CommonResponse RegisterKorisnik(RegisterKorisnikRequest request)
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
                TipKorisnikaId = request.TipKorisnika ?? 3,
            };

            _db.Korisniks.Add(korisnik);
            _db.SaveChanges();

            var autor = new Autor
            {
                AutorId = korisnik.IdKorisnik,
                KorisnikId = korisnik.IdKorisnik
            };

            _db.Autors.Add(autor);
            _db.SaveChanges();

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
                TipKorisnika = korisnik.TipKorisnika
            }).ToList();
        }

        public LogInResponse LoginKorisnik(LoginKorisnikRequest request)
        {
            var korisnik = _db.Korisniks.FirstOrDefault(k => k.KorisnickoIme == request.KorisnickoIme);
            if (korisnik == null || !VerifyPassword(request.Lozinka, korisnik.LozinkaHash, korisnik.LozinkaSalt))
            {
                throw new InvalidOperationException("Password or username incorrect.");
            }

            var token = GenerateJwtToken(korisnik);

            return new LogInResponse { Message = "Login successful.", Token = token };
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

        private string GenerateJwtToken(Korisnik korisnik)
        {
            if (_secretKey == null || _secretKey.Length != 32) // Ensure the key is valid
                throw new InvalidOperationException("Secret key is not properly set.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(_secretKey);

            // Map TipKorisnikaId to role names
            string role;
            switch (korisnik.TipKorisnikaId)
            {
                case 1:
                    role = "Admin";
                    break;
                case 2:
                    role = "SuperAdmin";
                    break;
                case 3:
                    role = "User";
                    break;
                default:
                    role = "User"; // Default role if ID is not recognized
                    break;
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, korisnik.KorisnickoIme ?? throw new ArgumentNullException(nameof(korisnik.KorisnickoIme))),
                    new Claim(ClaimTypes.Role, role) // Include the role in the token
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
