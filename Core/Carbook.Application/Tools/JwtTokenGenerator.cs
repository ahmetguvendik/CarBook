using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Carbook.Application.Features.CQRS.Results.AppUserResult;
using Carbook.Application.Services;
using Microsoft.IdentityModel.Tokens;

namespace Carbook.Application.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseService GenerateJwtTokenDefault(GetCheckAppUserQueryResult getCheckAppUserQueryResult)
    {
        var claims = new List<Claim>();
        if (!string.IsNullOrWhiteSpace(getCheckAppUserQueryResult.Role))
        {
            claims.Add(new Claim(ClaimTypes.Role , getCheckAppUserQueryResult.Role));
        }
       
           claims.Add(new Claim(ClaimTypes.NameIdentifier , getCheckAppUserQueryResult.Id.ToString()));

           if (!string.IsNullOrWhiteSpace(getCheckAppUserQueryResult.Username))
           {
               claims.Add(new Claim("Username", getCheckAppUserQueryResult.Username));
           }
           
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
           var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
           JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
               issuer: JwtTokenDefault.ValidIssuer,
               audience: JwtTokenDefault.ValidAudience,
               claims: claims,
               notBefore: DateTime.UtcNow,
               expires: expireDate,
               signingCredentials: creds
           );
           
           JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
           var jwtToken = handler.WriteToken(jwtSecurityToken);
           return new TokenResponseService(jwtToken, expireDate);
    }
}