using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Dtos;
using api.Interface.IServices;
using Microsoft.IdentityModel.Tokens;

namespace api.Implementation.Services
{
    public class JwtAuthentication : IJwtAuthentication
    {
        public string _key;

        public JwtAuthentication(string key)
        {
            _key = key;
        }

        public string GenerateToken(UserDto user)
        {
             var tokenHandler = new JwtSecurityTokenHandler();
             var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                }),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(token);

        }
    }
}