using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Responses;
using eLibrary.Commons.DTOs.Responses.Korisnik;
using eLibrary.Commons.Interfaces;
using eLibrary.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;


        public KorisnikService(dbIB190096Context db, IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityUser> roleManager)
        {            
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
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

            var user = new IdentityUser { UserName = request.KorisnickoIme, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Lozinka);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Error creating user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
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

        public async Task<LogInResponse> LoginKorisnikAsync(LoginKorisnikRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.KorisnickoIme);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Lozinka))
            {
                throw new InvalidOperationException("Password or username incorrect.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Generate JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256));

            return new LogInResponse
            {
                Message = "Login successful.",
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
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

        private string CreateToken(Korisnik user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.IdKorisnik.ToString()),
        new Claim(ClaimTypes.Name, user.KorisnickoIme),
        new Claim(ClaimTypes.Role, GetRoleForUser(user.TipKorisnikaId.Value)) // Assuming a method to get role string
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), // Set token expiration
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private string GetRoleForUser(int tipKorisnikaId)
        {
            return tipKorisnikaId switch
            {
                1 => "Admin",
                2 => "SuperAdmin",
                3 => "User",
                _ => "User"
            };
        }


    }
}
