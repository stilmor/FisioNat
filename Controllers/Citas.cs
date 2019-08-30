using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raist.Models;

namespace Raist.Controllers
{
  //  [Authorize]
    [Route("/citas")]
    [ApiController]
    public class citas :ControllerBase
    {
        [HttpGet("/citas")]
        public ActionResult<CabeceraCitas []> Get(){

          //  var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;

            int n = 0;
            int dia = 10;
            int hora = 18;
            int minutos = 15;

            CabeceraCitas [] listaCitas = new CabeceraCitas[3];            

            for (int i = 0; i < listaCitas.Length; i++)
            {
                CabeceraCitas nuevaCita = new CabeceraCitas
                {
                    UUID = Guid.NewGuid(),
                    fecha = new System.DateTime ( 2019,08,+ dia,hora,minutos,00),
                    especialidad = "Fisioterapia",
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
        public ActionResult<Cita> Get(Guid cita_id)
        {
            var user_uuid = User.Claims.Where(x => x.Type == ClaimTypes.Sid).First().Value;            
            
            return new Cita
            {
                UUID = Guid.NewGuid(),
                cuando = new System.DateTime(2019,08,30,17,30,00),
                especialidad = "Fisioterapia",
                nombreEspecialista = "Isabel",
                descripcionConsulta = "Acude a consulta por dolor en hombro izquierdo",
                tratamiento = "manipulacion en la escapula del hombro izquierdo, tratamiento con frio y tens",
                inicioTratamiento = new DateTime(2019,08,30),
                finTratamiento = new DateTime(2019,09,5),
            };
        }
    }
}