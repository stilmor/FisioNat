using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models
{
    public class Especialista
    {
        [Key]
        public Guid UUID {get; set;}

        [JsonIgnore]
        public ICollection<Cita> citas {get; set;}

        [Required]
        public Especialidad especialidad {get; set;}

        [Required]
        public Empleado empleado {get; set;}

        [Required,Range(9,9, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public int numeroColegiado {get; set;}
    }
}
