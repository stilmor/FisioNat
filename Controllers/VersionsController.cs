using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// Estos son los ficheros que reciben las peticiones a tu servidor.
// En este sentido aqui empieza todo, lo que devuelvas aqui, va a salir de tu servidor
namespace Raist.Controllers
{
    [Authorize]
    [Route("/version")] // Este es el path de este controlador.Cuando hay una peticion aqui, este codigo se activa
    [ApiController]  // Esto es mierdas C#
    public class VersionsController : ControllerBase // mas mierdas C#
    {
        [HttpGet] // Esto es para indicar que solo funciona cuando nos pidan info en esta API pero no recibimos info de fuera
        public ActionResult<IDictionary<string, double>> Get() // Action web que devuelve un diccionario con string y double
        {
             // Lo que devuelvas aqui se convierte en JSON o HTML depende de las cabeceras enviadas a tu API
             // Pero no te tienes que preocupar de eso, tu crea un objecto y devuelvelo
             // En este caso es un diccionario, normalmente sera una clase tuya o un IEnumerable<Clase>
             return new Dictionary<string, double>() { { "version", 3.1 } };
        }

    }
}
