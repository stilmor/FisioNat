using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers
{
    [EnableCors]
    [Route("/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ClinicaContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration, ClinicaContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [EnableCors]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<IDictionary<string, string>> usuario([FromBody] LoginInformation login)
        {
           // Tu código para validar que el usuario ingresado es válido
           Registro registro = _context.registros.Where(r => r.usuario == login.user.ToUpper()).FirstOrDefault();

           if (registro == null || registro.password != login.password)
           {
               return NotFound("Usuario o contraseña incorrecta");
           }

           var claims = new[]
            {
                new Claim(ClaimTypes.Sid, "2df84ab3-42e8-4f1e-8157-7f5b27f54474"),
                new Claim(ClaimTypes.Uri, "urn:type:usuario")
            };
            // Leemos el secret_key desde nuestro appseting
            var token = tokenize(claims);

            return Ok(new Dictionary<string, string>() { { "token", token } });
        }

        [EnableCors]
        [HttpPost]
        [Route("/login/empleado")]
        public ActionResult<IDictionary<string, string>> empleado([FromBody] LoginInformation login)
        {
           // Tu código para validar que el usuario ingresado es válido
           Empleado empleado = _context.Empleados.Where(e => e.user == login.user.ToUpper()).FirstOrDefault();

           Console.WriteLine("**************************");
           Console.WriteLine(login.user.ToUpper());
           Console.WriteLine("**************************");

           if (empleado == null || empleado.password != login.password)
           {
               return NotFound("Usuario o contraseña incorrecta");
           }

           var claims = new[]
            {
                new Claim(ClaimTypes.Sid, "2df84ab3-42e8-4f1e-8157-7f5b27f54474"),
                new Claim(ClaimTypes.Uri, "urn:type:usuario")
            };
            // Leemos el secret_key desde nuestro appseting
            var token = tokenize(claims);

            return Ok(new Dictionary<string, string>() { { "token", token } });
        }

        [EnableCors]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<IDictionary<string, string>> huella([FromBody] LoginInformation login)
        {
           // Tu código para validar que el usuario ingresado es válido
           Registro registro = _context.registros.Where(r => r.usuario == login.user).FirstOrDefault();

           if (registro == null || registro.passwordHuella != login.password)
           {
               return NotFound("Usuario o contraseña incorrecta");
           }

           var claims = new[]
            {
                new Claim(ClaimTypes.Sid, "2df84ab3-42e8-4f1e-8157-7f5b27f54474"),
                new Claim(ClaimTypes.Uri, "urn:type:usuario")
            };

            var token = tokenize(claims);

            return Ok(new Dictionary<string, string>() { { "token", token } });
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
                Expires = DateTime.UtcNow.AddMinutes(5),
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
