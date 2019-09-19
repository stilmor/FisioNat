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

        [EnableCors]
        [HttpGet("/citas")]
        public ActionResult<IEnumerable<Cita>> Get() {
            Response.Headers.Add("X-Total-Count", "2");
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            return Ok(_context.Citas.ToList());
        }

        [EnableCors]
        [HttpGet("/citas/{cita_id}")]
        public ActionResult<Cita> Get(Guid cita_id)
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

            Cita cita  = _context.Citas.Where(c => c.UUID == cita_id)
            .Include
                (cita => cita.paciente)
            .Include
                (cita => cita.especialista)
            .Include
                (cita => cita.tratamientoscitas)
            .FirstOrDefault();

            return cita;
        }
    }
}
