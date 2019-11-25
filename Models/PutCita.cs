using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models {
    public class PutCita {
        [Required]
        public Guid uuidCita { get; set; }

        [Required]
        public DateTime horaCita { get; set; }
        public string descripcionConsulta { get; set; }

        [Required]

        public Guid idPaciente { get; set; }

        [Required]

        public Guid idEspecialista { get; set; }

    }
}