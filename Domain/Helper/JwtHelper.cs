using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace Domain.Helper
{
    public class JwtHelper
    {
        private readonly JwtSettings _JwtSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtHelper(
        IConfiguration configuration
        ,IHttpContextAccessor httpContextAccessor
        )
        {         
           _JwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
           _httpContextAccessor = httpContextAccessor;
        }
        public string GenerateJwtToken(ApplicationUser user)
        {
            try
            {
                var claims = new[]
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim("UserName",user.UserName.ToString()),
                    new Claim("RoleId",user.RoleId.ToString()),
                    new Claim("RoleName",user.RoleName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                };

                return GenerateClaims(claims.ToList());
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public string GenerateClaims(List<Claim> claims)
        {
            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSettings.SecretKey));
            var Credentials = new SigningCredentials(SecretKey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _JwtSettings.Issuer,
                audience: _JwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(365),
                signingCredentials: Credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string ReadTokenClaim(TokenClaimType   tokenClaimType)
        {   
            var value = _httpContextAccessor?.HttpContext?.User?.FindFirst(Enum.GetName(tokenClaimType))?.Value ?? "-";
            return value;
            //return "-";
        }
    }


    public enum TokenClaimType
    {
        Id,
        UserName,
        RoleId,
    }
}
