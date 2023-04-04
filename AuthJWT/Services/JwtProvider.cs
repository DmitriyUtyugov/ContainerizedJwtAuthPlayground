using AuthJWT.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthJWT.Services;

public class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _configuration;

    public JwtProvider(IConfiguration configuration) => _configuration = configuration;

    public string CreateJwtToken(User user)
    {
        List<Claim> claims = new()
        {   new Claim(JwtRegisteredClaimNames.Iss, "localhost"), // should be a domain name
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString("G")),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Vault"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(10),
            signingCredentials: credentials
         );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}
