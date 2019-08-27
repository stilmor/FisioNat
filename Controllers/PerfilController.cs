using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raist.Models;

namespace Raist.Controllers
{
    [Authorize]
    [Route("/perfil")]
    [ApiController]
    public class UsuariosController :ControllerBase
    {
        [HttpGet("/perfil")]
        public ActionResult<Usuario> Get()
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

            Usuario cara = new Usuario {
                UUID = Guid.NewGuid(),
                nombre = "Caramon",
                apellido1 = "Majere",
                apellido2 = "Rosaemun",
                telefono = "+94918836498",
                email = "hermano.raistlin@mylance.com"               
            };
            return cara;
        }
    }
}