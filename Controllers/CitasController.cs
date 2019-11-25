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
    [Route ("/citas")]
    [ApiController]
    public class CitasController : ControllerBase {
        private readonly ClinicaContext _context;
        public CitasController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpGet ("/citas")]
        public ActionResult<IEnumerable<Cita>> GetListacitas (Guid id) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Response.Headers.Add ("X-Total-Count", "2");
            Response.Headers.Add ("Access-Control-Expose-Headers", "X-Total-Count");

            return Ok (_context.Citas.ToList ());
        }

        //sacar las citas de un paciente concreto
        [EnableCors]
        [HttpGet ("/citas/lista/{id}")]
        public ActionResult<IEnumerable<Cita>> GetListacitasUsuario (Guid id) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Response.Headers.Add ("X-Total-Count", "2");
            Response.Headers.Add ("Access-Control-Expose-Headers", "X-Total-Count");

            return Ok (_context.Citas.Where (c => c.paciente.UUID == id).ToList ());
        }

        //para sacar una cita concreta
        [EnableCors]
        [HttpGet ("/citas/{cita_id}")]
        public ActionResult<Cita> Get (Guid cita_id) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Cita cita = _context.Citas
                .Include (cita => cita.paciente.alergias)
                .ThenInclude (alergia => alergia.alergeno)
                .Include (cita => cita.paciente.tratamientosFarmacologicos)
                .Include (cita => cita.especialista.especialidad)
                .Include (cita => cita.especialista.empleado)
                .Include (cita => cita.tratamientoscitas)
                .Where (c => c.UUID == cita_id)
                .FirstOrDefault ();

            if (cita == null) {
                return NotFound ("Cita no encontrada");
            }
            return cita;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> nuevaCita ([FromBody] PostCita cita) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == cita.pacienteId)
                .FirstOrDefault ();

            Especialista especialista = _context.Especialistas
                .Where (e => e.UUID == cita.especialistaId)
                .FirstOrDefault ();

            if (paciente != null && especialista != null) {
                Cita nuevaCita = new Cita {
                UUID = Guid.NewGuid (),
                horaCita = cita.horaCita,
                especialista = especialista,
                paciente = paciente,
                descripcionConsulta = cita.descripcionConsulta
                };
                _context.Citas.Add (nuevaCita);
                _context.SaveChanges ();
                return Ok (new Dictionary<string, string> () { { "ok", "Cita creada correctamente" } });
            }

            return BadRequest ("la cita no se a creado");

        }

        [EnableCors]
        [HttpDelete ("{id}")]
        public ActionResult<IDictionary<string, string>> deleteCita (Guid id) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Cita cita = _context.Citas
                .Where (c => c.UUID == id)
                .FirstOrDefault ();

            _context.Citas.Remove (cita);
            _context.SaveChanges ();

            if (cita == null) {
                return NotFound ();
            }

            return Ok (new Dictionary<string, string> () { { "ok", "cita borrada" } });
        }

        [EnableCors]
        [HttpPut]
        public async Task<IActionResult> updateCita ([FromBody] PutCita citaModificada) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
            .Where(p => p.UUID == citaModificada.idPaciente)
            .FirstOrDefault();

            Especialista especialista = _context.Especialistas
            .Where(e => e.UUID == citaModificada.idEspecialista)
            .FirstOrDefault();

            Cita nuevaCita = new Cita {
                horaCita = citaModificada.horaCita,
                paciente = paciente,
                especialista = especialista,
                descripcionConsulta = citaModificada.descripcionConsulta
            };

            Cita cita = _context.Citas
                .Where (c => c.UUID == citaModificada.uuidCita)
                .FirstOrDefault ();

            _context.Entry (cita).State = EntityState.Detached;
            _context.Entry (nuevaCita).State = EntityState.Modified;


                await _context.SaveChangesAsync ();

                if (citaModificada == null || nuevaCita == null) {
                    return NotFound ();
                }


            return Ok ("cita Modificada");
        }
    }
}