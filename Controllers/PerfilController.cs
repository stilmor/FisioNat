using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers
{
    [Authorize]
    [Route("/perfil")]
    [ApiController]

    public class PerfilController :ControllerBase
    {
    private readonly ClinicaContext _context;

        public PerfilController(ClinicaContext context)
        {
            _context = context;
        }
        [HttpGet("/perfil")]
        //<IEnumerable<Cita>
        public ActionResult<Paciente> Get()
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

             Paciente paciente = _context.Pacientes.Where(s => s.nombre == "victor").FirstOrDefault();

            // if (paciente == null){
            //     return NotFound();
            //     }


            // Usuario cara = new Usuario {
            //     UUID = Guid.NewGuid(),
            //     nombre = "Caramon",
            //     apellido1 = "Majere",
            //     apellido2 = "Rosaemun",
            //     telefono = "+94918836498",
            //     email = "hermano.raistlin@mylance.com"
            // };
            return paciente;
        }
    }
}