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
    [Route ("/clinicas")]
    [ApiController]
    public class ClinicasController : ControllerBase {
        private readonly ClinicaContext _context;
        public ClinicasController (ClinicaContext context) {
            _context = context;
        }

        [EnableCors]
        [HttpGet]
        public ActionResult<IEnumerable<Clinica>> Get () {

            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            return Ok (_context.Clinicas.ToList ());
        }
    }

}