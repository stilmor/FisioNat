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
    [Route ("/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase {
        private readonly ClinicaContext _context;

        public PersonalController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> PostPersonal ([FromBody] PostPersonal empleado) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Empleado nuevoEmpleado = new Empleado {
                UUID = Guid.NewGuid (),
                nombre = empleado.nombre,
                apellido1 = empleado.apellido1,
                apellido2 = empleado.apellido2,
            };

            _context.Empleados.Add (nuevoEmpleado);

            _context.SaveChanges ();
            Console.WriteLine ("*****************");
            Console.WriteLine (empleado.especialidad);
            Console.WriteLine ("*****************");

            if (empleado.especialidad != null && empleado.especialidad != new Guid ("00000000-0000-0000-0000-000000000000")) {

                nuevoEspecialista (nuevoEmpleado, empleado.numeroColegiado, empleado.especialidad);
            }

            return Ok (new Dictionary<string, string> () { { "ok", "trabajador creado" } });
        }

        private void nuevoEspecialista (Empleado nuevoEmpleado, int numeroColegiado, Guid especialidadId) {

            Especialidad especialidadElegida = _context.Especialidades
                .Where (esp => esp.UUID == especialidadId)
                .FirstOrDefault ();

            Especialista nuevoEspecialista = new Especialista {
                UUID = Guid.NewGuid (),
                especialidad = especialidadElegida,
                numeroColegiado = numeroColegiado,
                empleado = nuevoEmpleado
            };

            _context.Especialistas.Add (nuevoEspecialista);

            _context.SaveChanges ();
        }

        [EnableCors]
        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> Get () {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            return Ok (_context.Empleados
                .Include (empleado => empleado.especialistas)
                .ThenInclude (especialista => especialista.especialidad)
                .ToList ());
        }

        [EnableCors]
        [HttpPut]
        public async Task<IActionResult> PutEmpleado ([FromBody] Empleado empleadoModificado) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Empleado empleado = _context.Empleados
                .Where (p => p.UUID == empleadoModificado.UUID)
                .FirstOrDefault ();

            _context.Entry (empleado).State = EntityState.Detached;
            _context.Entry (empleadoModificado).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateConcurrencyException) {
                if (empleadoModificado == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }

            return Ok ("empleado Modificado");
        }

        [EnableCors]
        [HttpDelete]
        public ActionResult<IDictionary<string, string>> deletePaciente (Guid id) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Empleado empleado = _context.Empleados
                .Where (e => e.UUID == id)
                .FirstOrDefault ();

            _context.Empleados.Remove (empleado);
            _context.SaveChanges ();

            if (empleado == null) {
                return NotFound ();
            }

            return Ok (new Dictionary<string, string> () { { "ok", "empleado borrado" } });
        }
    }
}