using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers {

    [Authorize]
    [Route ("/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase {
        private readonly ClinicaContext _context;
        private readonly IConfiguration _configuration;

        public PacientesController (IConfiguration configuration, ClinicaContext context) {
            _context = context;
            _configuration = configuration;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> altaPaciente ([FromBody] PostPaciente paciente) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente pacienteBuscado = _context.Pacientes
                .Where (p => p.nombre == paciente.nombre && p.apellido1 == paciente.apellido1 && p.apellido2 == paciente.apellido2 && p.telefonoMovil == paciente.telefonoMovil)
                .FirstOrDefault ();

            if (pacienteBuscado != null) {

                return BadRequest ("El paciente ya existe en el registro");
            }

            string correoElectronicoChequeado;

            if (paciente.correoElectronico != null) {
                correoElectronicoChequeado = paciente.correoElectronico.ToUpper ();
            } else {
                correoElectronicoChequeado = null;
            }

            Paciente nuevoPaciente = new Paciente {
                UUID = Guid.NewGuid (),
                codigoPin = new Random ().Next (10000),
                nombre = paciente.nombre,
                sexo = paciente.sexo,
                apellido1 = paciente.apellido1,
                apellido2 = paciente.apellido2,
                telefonoFijo = paciente.telefonoFijo,
                telefonoMovil = paciente.telefonoMovil,
                fechaNacimiento = DateTime.Parse (paciente.fechaNacimiento.ToString ()),
                codigoPostal = paciente.codigoPostal,
                calle = paciente.calle,
                portal = paciente.portal,
                escalera = paciente.escalera,
                piso = paciente.piso,
                letra = paciente.letra,
                poblacion = paciente.poblacion,
                provincia = paciente.provincia,
                correoElectronico = correoElectronicoChequeado
            };

            _context.Pacientes.Add (nuevoPaciente);

            _context.SaveChanges ();

            if (nuevoPaciente.correoElectronico != null) {

                nuevoRegistro (nuevoPaciente);
            }

            return Ok (new Dictionary<string, string> () { { "ok", "usuario insertado" } });
        }

        private void nuevoRegistro (Paciente pacienteRegistrado) {

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == pacienteRegistrado.UUID)
                .FirstOrDefault ();

            Registro nuevoRegistro = new Registro {
                pacienteId = pacienteRegistrado,
                password = pacienteRegistrado.codigoPin.ToString (),
                usuario = pacienteRegistrado.correoElectronico,
            };

            try {
                _context.registros.Add (nuevoRegistro);
                _context.SaveChanges ();
            } catch (DbUpdateException e) {
                if (e.HResult == 2601!) {
                    BadRequest ("el Paciente ya existe en la base de datos");
                }
            }
        }

        [EnableCors]
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get () {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            return Ok (_context.Pacientes
                .Include (paciente => paciente.alergias)
                .Include (Paciente => Paciente.imagenes)
                .ToList ());
        }

        [EnableCors]
        [HttpPut ("{id}")]
        public async Task<IActionResult> putPaciente ([FromBody] Paciente pacientemodificado) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == pacientemodificado.UUID)
                .FirstOrDefault ();

            if (pacientemodificado != null) {
                nuevoRegistro (pacientemodificado);
            }

            _context.Entry (paciente).State = EntityState.Detached;
            _context.Entry (pacientemodificado).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateConcurrencyException) {
                if (pacientemodificado == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }

            return Ok ("Usuario Modificado");
        }

        [EnableCors]
        [HttpPut ("/cambiopass")]
        public async Task<IActionResult> putCambioPassword ([FromBody] PutPassword solicitudCambioPassword) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;
            Registro registroPaciente = _context.registros
                .Where (r => r.pacienteId.UUID == solicitudCambioPassword.idpaciente)
                .FirstOrDefault ();
            if (solicitudCambioPassword.oldPassword == registroPaciente.password) {
                try {
                    registroPaciente.password = solicitudCambioPassword.newpassword;

                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    throw;
                }
                return Ok ("Password actualizada");
            } else {
                return BadRequest ("la contraseña no es correcta");
            }
        }

        [EnableCors]
        [HttpDelete ("{id}")]
        public ActionResult<IDictionary<string, string>> deletePaciente (Guid id) {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            Paciente paciente = _context.Pacientes
                .Where (p => p.UUID == id)
                .FirstOrDefault ();

            _context.Pacientes.Remove (paciente);
            _context.SaveChanges ();

            if (paciente == null) {
                return NotFound ();
            }

            return Ok (new Dictionary<string, string> () { { "ok", "Paciente borrado" } });
        }
    }
}