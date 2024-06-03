using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleCrud.Services
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration _config);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredToken, IConfiguration _config);
    }
}
