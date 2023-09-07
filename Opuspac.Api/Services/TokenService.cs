using Microsoft.IdentityModel.Tokens;
using Opuspac.Core.Entities;
using Opuspac.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Opuspac.Api.Services;

public class TokenService : ITokenService
{
    public static string Secret = "qwertyuiopasdfghjklzxcvbnm123456";

    public Task<string> GenerateToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(Secret);

        var tokenConfig = new SecurityTokenDescriptor
        {
            Issuer = "opuspac-api",
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);
        return Task.FromResult(tokenString);
    }
}
