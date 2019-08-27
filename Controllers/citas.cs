using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Raist.Controllers
{
    [Authorize]
    [Route("/citas")]
    [ApiController]
    public class citas :ControllerBase
    {
        [HttpGet("/citas/{cita_id}")]
        public ActionResult<string> Get(string cita_id)
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;



            return "value";
        }
    }
}