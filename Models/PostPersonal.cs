using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models {
    public class PostPersonal {

        [Required]
        public string nombre { get; set; }

        [Required]
        public string password {get; set;}

        [Required]
        public string rol { get; set; }

        [Required]
        public string sexo { get; set; }

        [Required]
        public string apellido1 { get; set; }

        [Required]
        public string apellido2 { get; set; }
        public Guid especialidad { get; set; }
        public int numeroColegiado { get; set; }
    }
}