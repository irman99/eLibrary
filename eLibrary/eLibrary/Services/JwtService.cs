using eLibrary.Database.Models;
using eLibrary.Commons.DTOs; // Make sure this namespace is included
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IConfiguration configuration)
    {
        _jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>()
            ?? throw new ArgumentNullException(nameof(configuration), "JWT settings are not configured.");
    }

    public string GenerateToken(Korisnik user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.IdKorisnik.ToString()),
            new Claim(ClaimTypes.Name, user.KorisnickoIme),
            new Claim(ClaimTypes.Role, GetRoleForUser(user.TipKorisnikaId.Value))
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.Now.AddMinutes(_jwtSettings.TokenExpiryInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GetRoleForUser(int tipKorisnikaId)
    {
        return tipKorisnikaId switch
        {
            1 => "Admin",
            2 => "SuperUser",
            3 => "User",
            _ => "User"
        };
    }
}
