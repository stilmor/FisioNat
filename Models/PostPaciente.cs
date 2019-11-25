using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Raist.Models
{
    public class PostPaciente
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string sexo { get; set; }
        [Required]
        public string apellido1 { get; set; }
        [Required]
        public string apellido2 { get; set; }
        [Required]
        public int telefonoFijo { get; set; }
        [Required]
        public int telefonoMovil { get; set; }
        [Required]
        public DateTime fechaNacimiento { get; set; }

        public string calle { get; set; }

        public string portal { get; set;}

        public string escalera { get; set; }

        public string piso { get; set; }

        public string letra { get; set; }

        public string poblacion { get; set; }
        [Required]
        public string provincia { get; set; }
        [Required]
        public int codigoPostal { get; set; }
        public string correoElectronico { get; set; }
    }
}