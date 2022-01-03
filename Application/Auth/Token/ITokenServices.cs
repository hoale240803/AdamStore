using System.Collections.Generic;
using System.Security.Claims;

namespace Application.Auth.Token
{
    public interface ITokenServices
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}