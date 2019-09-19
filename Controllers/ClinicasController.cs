using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raist.Data;
using Raist.Models;

namespace Raist.Controllers
{
    [Authorize]
    [Route("/Clinicas")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private readonly ClinicaContext _context;
        public ClinicasController(ClinicaContext context)
        {
            _context = context;
        }

       // [HttpGet("/clinicas")]

        //  public ActionResult<IEnumerable<Clinica>> Get() {

        //     return _context.Citas.ToList();
        // }
    }
}