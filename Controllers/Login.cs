using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Raist.Models;



namespace Raist.Controllers
{

    [Route("/login")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Login(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult<IDictionary<string, string>> usuario([FromBody] LoginInformation login)
        {
           // Tu código para validar que el usuario ingresado es válido

           var claims = new[]
            {
                new Claim(ClaimTypes.Sid, "uuid de este usuario"),
                new Claim(ClaimTypes.Uri, "urn:type:usuario")
            };
            // Leemos el secret_key desde nuestro appseting
            var token = tokenize(claims);

            return new Dictionary<string, string>() { { "token", token } };
        }


        private string tokenize(Claim[] claims)
        {
            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = System.Text.Encoding.ASCII.GetBytes(secretKey); 

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createdToken);
            return token;
        }
    }
}
