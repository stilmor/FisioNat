using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{        public class Cita
    {
        [Key]
        public Guid UUID {get; set;}

        [Required]
        //falta configuracion de horas
        public DateTime horaCita {get; set;}

        [Required,MaxLength(2000,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string descripcionConsulta {get; set;}

        public Paciente paciente {get; set;}

        public Especialista especialista {get; set;}

        public ICollection <TratamientoCita> tratamientoscitas  { get; set; }

    }
}
