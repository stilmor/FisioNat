using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        [EnableCors]
        [HttpGet("/perfil")]
        //<IEnumerable<Cita>
        public ActionResult<Paciente> Get()
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

            //  Paciente paciente = _context.Pacientes.Where(s => s.nombre == "victor").FirstOrDefault();
             Paciente paciente = _context.Pacientes
             .Include(paciente => paciente.alergias)
             .ThenInclude(alergia => alergia.alergeno)
             .Include(paciente => paciente.tratamientosFarmacologicos)
             .Include(paciente => paciente.pacienteDeClinicas)
             .ThenInclude(clinica => clinica.clinica)
             .Where(s => s.nombre == "victor").FirstOrDefault();

            // Clinica UUID =
            // Paciente pacienten = _context.Pacientes
            // .Include(pacienten => paciente.pacienteDeClinicas.clinicaUUID

            //  Paciente pacient = _context.Pacientes
            //  .Include(_context.Clinicas.Where(c => c.clinicaUUID = paciente.))
            //  .Where(s => s.nombre == "Victor").FirstOrDefault();





            //  Cita cita  = _context.Citas
            // .Include(cita => cita.paciente)
            // .Include(cita => cita.especialista)
            // .Include(cita => cita.tratamientoscitas)
            // .Where(c => c.UUID == cita_id)
            // .FirstOrDefault();

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