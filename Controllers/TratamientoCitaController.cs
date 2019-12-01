using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers {
    [Authorize]
    [Route ("/tratamientocita")]
    [ApiController]
    public class TratamientoCitaController : ControllerBase {

        private readonly ClinicaContext _context;
        public TratamientoCitaController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> postAlergia ([FromBody] PostTratamientoCita tratamientocita) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Cita cita = _context.Citas
                .Where (c => c.UUID == tratamientocita.citaId)
                .FirstOrDefault ();

            if (cita != null) {
                TratamientoCita nuevoTratamiento = new TratamientoCita {
                UUID = Guid.NewGuid (),
                fechaInicio = tratamientocita.fechaInicio,
                fechaFin = tratamientocita.fechaFin,
                descripcion = tratamientocita.descripcion,
                cita = cita
                };

                _context.tratamientoCitas.Add (nuevoTratamiento);
                _context.SaveChanges ();

                return Ok (new Dictionary<string, string> () { { "ok", "El tratamiento de esta cita se ha creado correctamente" } });
            }

            return BadRequest ("El tratamiento no se ha creado");
        }
    }
}