using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models {
    public class putAlergia {
        [Required]
        public Guid UUID { get; set; }

        [Required]

        public Guid pacienteId { get; set; }

        [Required]
        public string nombreAlergeno { get; set; }
    }
}