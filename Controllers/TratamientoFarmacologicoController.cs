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
    [Route ("/tratamiento")]
    [ApiController]
    public class TratamientoFarmacologicoController : ControllerBase {
        private readonly ClinicaContext _context;

        public TratamientoFarmacologicoController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> postTratamiento ([FromBody] PostTratamientoFarmacologico tratamiento) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == tratamiento.pacienteId)
                .FirstOrDefault ();

            if (paciente != null) {
                TratamientoFarmacologico nuevoTratamiento = new TratamientoFarmacologico {
                UUID = Guid.NewGuid (),
                fechaInicio = tratamiento.fechaInicio,
                fechaFin = tratamiento.fechaFin,
                descripcionTratamiento = tratamiento.descripcionTratamiento,
                paciente = paciente
                };
                _context.tratamientosFarmacologicos.Add(nuevoTratamiento);
                _context.SaveChanges ();

                return Ok (new Dictionary<string, string> () { { "ok", "Tratamiento agregado correctamente" } });
            }

            return BadRequest ("El tratamiento no se ha creado");
        }
    }
}