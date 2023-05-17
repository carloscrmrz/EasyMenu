using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EasyMenu.Portal.Models;

public class EasyMenuToken
{
    private JwtSecurityToken SecurityToken { get; set; }
    private readonly JwtSecurityTokenHandler _securityTokenHandler = new();
    public DateTime Expiration { get; private set; }

    private string Token => _securityTokenHandler.WriteToken(SecurityToken);

    public IEnumerable<Claim> Claims { get; private set; }

    public EasyMenuToken(string key, string issuer, string audience, IEnumerable<Claim> claims, int expirationTime = 8)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        Claims = claims;
        Expiration = DateTime.Now.AddHours(expirationTime);

        SecurityToken = new JwtSecurityToken(issuer, audience, Claims, expires: Expiration,
            signingCredentials: credentials);
    }

    public ClaimsPrincipal GetClaimsPrincipal()
    {
        var claims = Claims;
        return new ClaimsPrincipal(new ClaimsIdentity(claims));
    }

    public override string ToString()
    {
        return Token;
    }
}