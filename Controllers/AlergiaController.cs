using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers {
    [Authorize]
    [Route ("/alergia")]
    [ApiController]
    public class AlergiaController : ControllerBase {

        private readonly ClinicaContext _context;
        public AlergiaController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> postAlergia ([FromBody] PostAlergia alergia) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == alergia.pacienteId)
                .FirstOrDefault ();
            if (paciente != null) {
                Alergeno nuevoAlergeno = new Alergeno {
                UUID = Guid.NewGuid (),
                nombre = alergia.nombreAlergeno,
                };
                if (nuevoAlergeno == null) {
                    return BadRequest ("alergeno no existe");
                }

                _context.Alergenos.Add (nuevoAlergeno);
                _context.SaveChanges ();

                Alergia nuevaAlgeria = new Alergia {
                    UUID = Guid.NewGuid (),
                    alergeno = nuevoAlergeno,
                    paciente = paciente
                };

                if (nuevaAlgeria == null) {
                    return BadRequest ("la alergia no existe");
                }
                _context.Alergias.Add (nuevaAlgeria);
                _context.SaveChanges ();
                return Ok (new Dictionary<string, string> () { { "ok", "Alergia creada correctamente" } });
            }

            return BadRequest ("la alergia no se ha creado");
        }

        [EnableCors]
        [HttpPut]
        public async Task<IActionResult> modificarAlergia (putAlergia alergia) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Alergia alergiaGuardada = _context.Alergias
                .Where (a => a.UUID == alergia.UUID)
                .FirstOrDefault ();

            if (alergiaGuardada != null) {
                Alergeno nuevoAlergeno = new Alergeno {
                UUID = Guid.NewGuid (),
                nombre = alergia.nombreAlergeno
                };
                _context.Alergenos.Add (nuevoAlergeno);
                _context.SaveChanges ();

                Alergia alergiaModificada = new Alergia {
                    UUID = alergiaGuardada.UUID,
                    alergeno = nuevoAlergeno
                };

                _context.Entry (alergiaGuardada).State = EntityState.Detached;
                _context.Entry (alergiaModificada).State = EntityState.Modified;

                await _context.SaveChangesAsync ();
                return Ok ("alergia actualizada");
            };
            return BadRequest ("la alergia no existe");
        }

         [EnableCors]
        [HttpDelete ("{id}")]
        public ActionResult<IDictionary<string, string>> deleteAlergia (Guid id) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Alergia alergia = _context.Alergias
                .Where (a => a.UUID == id)
                .FirstOrDefault ();

            _context.Alergias.Remove (alergia);
            _context.SaveChanges ();

            if (alergia == null) {
                return NotFound ();
            }

            return Ok (new Dictionary<string, string> () { { "ok", "alergia borrada" } });
        }

    }
}