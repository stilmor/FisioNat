using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models {
    public class PostAlergia {

        [Required]
        public Guid UUID { get; set; }

        [Required]
        public Guid pacienteId { get; set; }

        [Required]
        public string nombreAlergeno { get; set; }
    }
}