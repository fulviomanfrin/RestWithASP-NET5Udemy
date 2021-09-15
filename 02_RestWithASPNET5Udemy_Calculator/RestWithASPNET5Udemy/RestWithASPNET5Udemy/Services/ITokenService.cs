using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNET5Udemy.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefresToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);


    }
}
