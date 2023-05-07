using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChurchManagementApi.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly SecurityKey _securityKey;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        }
        public string GenerateAuthenticationToken(ChurchUser churchUser)
        {
            List<Claim> claims = new()
            {
                new(ClaimTypes.NameIdentifier, churchUser.Id.ToString()),
                new(ClaimTypes.Name, churchUser.Username),
            };

            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = new(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new(_securityKey, SecurityAlgorithms.HmacSha512Signature)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}
