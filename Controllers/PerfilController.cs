using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers {
    [Authorize]
    [Route ("/perfil")]
    [ApiController]

    public class PerfilController : ControllerBase {
        private readonly ClinicaContext _context;

        public PerfilController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
         [HttpGet ("/perfil/{idPaciente}")]

        public ActionResult<Paciente> Get (Guid idPaciente) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Include (paciente => paciente.alergias)
                .ThenInclude (alergia => alergia.alergeno)
                .Include (paciente => paciente.tratamientosFarmacologicos)
                .Include (paciente => paciente.pacienteDeClinicas)
                .ThenInclude (clinica => clinica.clinica)
                .Include(paciente => paciente.imagenes)
                .Where (s => s.UUID == idPaciente).FirstOrDefault ();

            if (paciente == null) {
                return NotFound ();
            }

            return paciente;
        }
    }
}