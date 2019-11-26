using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models {
    public class Especialista {
        [Key]
        public Guid UUID { get; set; }

        [JsonIgnore]
        public ICollection<Cita> citas { get; set; }

        [Required]
        public Especialidad especialidad { get; set; }

        [Required]
        [JsonIgnore]
        public Empleado empleado { get; set; }

        [Required]
        public int numeroColegiado { get; set; }

    }
}