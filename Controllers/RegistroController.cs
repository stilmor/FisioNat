using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers {
    [Authorize]
    [Route ("/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase {
        private readonly ClinicaContext _context;

        public RegistroController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpPut ("{id}")]
        public async Task<IActionResult> putRegistro ([FromBody] Huella huella) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == huella.usuarioId)
                .FirstOrDefault ();

            Registro registro = _context.registros
                .Where (r => r.pacienteId.UUID == paciente.UUID)
                .FirstOrDefault ();

            registro.passwordHuella = huella.huellaId;

            await _context.SaveChangesAsync ();

            return Ok ("Huella registrada");
        }

    }
}