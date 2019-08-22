using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
//using System.Security.Claims;
using System.Threading.Tasks;
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
        // POST /login

        /*
             public ActionResult<IDictionary<string, double>> Get() // Action web que devuelve un diccionario con string y double
        {
             // Lo que devuelvas aqui se convierte en JSON o HTML depende de las cabeceras enviadas a tu API
             // Pero no te tienes que preocupar de eso, tu crea un objecto y devuelvelo
             // En este caso es un diccionario, normalmente sera una clase tuya o un IEnumerable<Clase>
             return new Dictionary<string, double>() { { "version", 3.1 } };
        }
        */
    private readonly IConfiguration _configuration;

    public Login(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    [HttpPost]
    [Route("[action]")]
    public ActionResult<IDictionary<string, string>> Logina([FromBody] LoginInformation login)
    {
        // Tu código para validar que el usuario ingresado es válido

  
        // Leemos el secret_key desde nuestro appseting
        var secretKey = _configuration.GetValue<string>("SecretKey");
        var key = System.Text.Encoding.ASCII.GetBytes(secretKey);


        // Creamos los claims (pertenencias, características) del usuario
        var claims = new[]
        {
            new Claim(ClaimTypes.Sid, "uuid de este usuario"),
        };


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
        return new Dictionary<string, string>() { { "token", token } };
    }
        
        // [HttpPost]
        // //devolvemos los datos del usuario/paciente
        // public Usuario Post([FromBody] LoginInformation login)
        // {  
        //   /* //BadRequestObjectResult loginNull = BadRequest("El usuario o contraseña estan vacios");
        //     if (login == null)
        //     {
        //         return loginNull;
        //     }
        //     buscar para implementar IHttpActionResult
        //     */
        //     Usuario cara = new Usuario {
        //         UUID = Guid.NewGuid(),
        //         nombre = "Caramon",
        //         apellido1 = "Majere",
        //         apellido2 = "Rosaemun",
        //         telefono = "+94918836498",
        //         email = "hermano.raistlin@mylance.com",                
        //     };

        //     return cara;
        // }

        [HttpGet]
        public ActionResult <String> get()
        {
            return "Login hecho!!";
        }

        
    }
}
