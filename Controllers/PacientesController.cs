using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers
{
        [Authorize]
        [Route("/[controller]")]
        [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaContext _context;
        private readonly IConfiguration _configuration;

         public PacientesController(IConfiguration configuration,ClinicaContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        [EnableCors]
        [HttpPost]
        public ActionResult<IDictionary<string, string>> altaPaciente([FromBody] PostPaciente paciente)
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

            Paciente nuevoPaciente = new Paciente
                {
                    UUID = Guid.NewGuid(),
                    codigoPin = 1234,
                    nombre = paciente.nombre,
                    apellido1 = paciente.apellido1,
                    apellido2 = paciente.apellido2,
                    telefonoFijo = paciente.telefonoFijo,
                    telefonoMovil = paciente.telefonoMovil,
                    fechaNacimiento = DateTime.Parse(paciente.fechaNacimiento.ToString()),
                    codigoPostal = paciente.codigoPostal,
                    correoElectronico = paciente.correoElectronico,
                };

                _context.Pacientes.Add(nuevoPaciente);

                _context.SaveChanges();

            return Ok(new Dictionary<string, string>() { { "ok", "usuario insertado" } });
        }

        [EnableCors]
        [HttpGet]
        public ActionResult <IEnumerable<Paciente>> Get()
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;


            return Ok(_context.Pacientes
            .Include(paciente => paciente.alergias).ToList());
        }


    }
}