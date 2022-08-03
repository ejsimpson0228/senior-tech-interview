using Microsoft.IdentityModel.Tokens;
using RxLightningAPI.Exceptions;
using RxLightningAPI.Models.DTOs;
using RxLightningAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RxLightningAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(UserLogin userLogin)
        {
            var result = _validUserLogins.FirstOrDefault(v => v.Email.ToUpper() == userLogin.Email.ToUpper() &&
            v.Password == userLogin.Password);

            if (result == null)
            {
                throw new HttpResponseException(401, "Invalid credentials");
            }

            var token = GenerateWebToken(userLogin);
            return token;
        }

        private string GenerateWebToken(UserLogin userLogin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Issuer"])
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], claims, null, DateTime.Now.AddMinutes(120), credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<UserLogin> _validUserLogins = new List<UserLogin>()
        {
            new UserLogin {Email = "User@email.com", Password = "P@ssword123"},
            new UserLogin {Email = "User2@email.com", Password = "P@ssword456"}
        };
    }
}
