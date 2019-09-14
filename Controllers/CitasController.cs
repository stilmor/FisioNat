using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers
{
  //  [Authorize]
    [Route("/citas")]
    [ApiController]
    public class CitasController :ControllerBase
    {
        private readonly ClinicaContext _context;
        public CitasController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpGet("/citas")]
        public ActionResult<IEnumerable<Cita>> Get() {

            return _context.Citas.ToList();
        }

        [HttpGet("/citas/{cita_id}")]
        public ActionResult<Cita> Get(Guid cita_id)
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

            return new Cita
            {
                UUID = Guid.NewGuid(),
                fechaCita = new System.DateTime(2019,08,30,17,30,00),
               // especialidad = "Fisioterapia",
               // nombreEspecialista = "Isabel",
                descripcionConsulta = "Acude a consulta por dolor en hombro izquierdo",
              //  tratamiento = "manipulacion en la escapula del hombro izquierdo, tratamiento con frio y tens",
              //  inicioTratamiento = new DateTime(2019,08,30),
               // finTratamiento = new DateTime(2019,09,5),
                //pacienteUUID= Guid.NewGuid(),
                //especialistaUUID = Guid.NewGuid()
            };
        }
    }
}