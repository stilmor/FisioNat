using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Raist.Data;
using Raist.Models;
using Raist.Services.Helpers;

namespace Raist.Controllers.Helpers {
    [Authorize]
    [Route ("/imagen")]
    public class s3Controller : ControllerBase {
        private readonly ClinicaContext _context;
        private readonly IConfiguration _configuration;

        public s3Controller (IConfiguration configuration, ClinicaContext context) {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePhoto (PostImagen imagenPaciente) {
            var user_uuid = User.Claims.Where (x => x.Type == ClaimTypes.Sid).First ().Value;

            // I'm getting file inside Request object

            Paciente pacienteEncontrado = _context.Pacientes
                .Where (p => p.UUID == imagenPaciente.uuidPaciente)
                .FirstOrDefault ();

            if (pacienteEncontrado == null) {
                return BadRequest (new Dictionary<string, string> () { { "Error", "El paciente no existe" } });
            }

            var file = this.Request.Form.Files[0];

            // File type validation
            if (!file.ContentType.Contains ("image")) {
                return BadRequest (new Dictionary<string, string> () { { "Error", "La imagen no es valida" } });
            }

            var imageResponse = await ImagenService.UploadObject (file);

            var awsregion = _configuration.GetSection ("AppSettings").GetValue<string> ("AWSRegion");
            string amazonAWS = "amazonaws.com";
            string urlImage = "https://" + imageResponse.BucketName + ".s3-" + awsregion + "." + amazonAWS + "/" + imageResponse.FileName;

            Imagen nuevaImagen = new Imagen {
                uuid = Guid.NewGuid (),
                paciente = pacienteEncontrado,
                url = urlImage,
                descripcion = imagenPaciente.descripcion
            };

            _context.Imagenes.Add (nuevaImagen);

            _context.SaveChanges ();

            JsonResult response = new JsonResult (new Object ());
            return Ok ("imagen subida al servidor");
        }

    }

}