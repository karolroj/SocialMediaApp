using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Core.Interfaces;
using SocialMediaApp.Core.Models.AppSettings;

namespace SocialMediaApp.Core.Services;
public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    public TokenService(IOptions<AppSettings> appSettings)
    {
        _jwtSettings = appSettings.Value.Jwt; 
    }

    public string GenerateToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}