using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{        public class Cita
    {
        [Key]
        public Guid UUID {get; set;}

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCita {get; set;}

        [Required]
        //falta configuracion de horas
        public DateTime horaCita {get; set;}

        [Required]
        [ForeignKey("Paciente")]
        public Paciente paciente {get; set;}

        [Required]
        [MaxLength(2000)]
        public string descripcionConsulta {get; set;}

        [Required]
        [ForeignKey("Especialista")]
        public Especialista especialista {get; set;}
    }
}