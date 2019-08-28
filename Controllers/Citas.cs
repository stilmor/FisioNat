using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raist.Models;

namespace Raist.Controllers
{
    [Authorize]
    [Route("/citas")]
    [ApiController]
    public class citas :ControllerBase
    {
        [HttpGet("/citas/historial")]
        public ActionResult<Cita []> Get(){

            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;
            int n = 0;
            int dia = 10;
            int hora = 18;
            int minutos = 15;
            Cita [] listaCitas = new Cita[3];

            for (int i = 0; i < listaCitas.Length; i++)
            {
                Cita nuevaCita = new Cita
                {
                    idCita = n,
                    cuando = new System.DateTime ( 2019,08,+ dia,hora,minutos,00),
                    especialista = "Fisioterapia"
                  //  usuarioUuid = Guid.Parse(user_uuid),                
                };
                
                n++;
                dia++;
                hora++;
                minutos = minutos + 10;
                listaCitas[i] = nuevaCita;    
            }

            return listaCitas;
        }

        [HttpGet("/citas/{cita_id}")]
        public ActionResult<string> Get(string cita_id)
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;
            return "value";
        }
    }
}