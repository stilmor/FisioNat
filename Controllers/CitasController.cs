using System;
using System.Collections.Generic;
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
    [Route ("/citas")]
    [ApiController]
    public class CitasController : ControllerBase {
        private readonly ClinicaContext _context;
        public CitasController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpGet ("/citas")]
        public ActionResult<IEnumerable<Cita>> Get () {
            Response.Headers.Add ("X-Total-Count", "2");
            Response.Headers.Add ("Access-Control-Expose-Headers", "X-Total-Count");
            return Ok (_context.Citas.ToList ());
        }

        [EnableCors]
        [HttpGet ("/citas/{cita_id}")]
        public ActionResult<Cita> Get (Guid cita_id) {

            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

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
        public ActionResult<IDictionary<string, string>> nuevaCita ([FromBody] Cita cita) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Cita nuevaCita = new Cita {
                UUID = Guid.NewGuid (),
                horaCita = cita.horaCita,
                especialista = cita.especialista,
                paciente = cita.paciente,
            };

            _context.Citas.Add (nuevaCita);

            _context.SaveChanges ();

            return Ok (new Dictionary<string, string> () { { "ok", "Cita creada correctamente" } });
        }
    }
}