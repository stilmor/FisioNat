using Microsoft.AspNetCore.Mvc;

namespace Raist.Controllers
{
    [Route("/citas")]
    [ApiController]
    public class citas :ControllerBase
    {
        [HttpGet("{user_id}/citas/{cita_id}")]
        public ActionResult<string> Get(string user_id, string cita_id)
        {
            var user_claim_id = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;
            if user_claim_id != user_id {
                return Unauthorized;
            }


            

            return "value";
        }

    }
}