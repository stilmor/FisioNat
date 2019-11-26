using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models {
    public class PostCita {
        
        [Required]
        public DateTime horaCita { get; set; }

        [Required]
        public Guid pacienteId { get; set; }

        [Required]
        public Guid especialistaId { get; set; }

        public String descripcionConsulta {get; set;}
    }
}