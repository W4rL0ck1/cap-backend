using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Application.Interfaces;


namespace Products.Application.Services
{
    public class JwtService: IJwtService
    {

        private IConfiguration _configuration;

        private string _secretKey; 

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            _secretKey = _configuration.GetSection("SecretKey:HashKey").Value.ToString().Trim();
        }

        public string GenerateToken(object payload, int expirationMinutes)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            string jsonString = JsonSerializer.Serialize(payload);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, jsonString)
                }),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Issuer="Renato",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}