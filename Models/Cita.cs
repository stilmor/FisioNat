using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{        public class Cita
    {
        [Key]
        public Guid UUID {get; set;}
        public DateTime fechaCita {get; set;}
        public DateTime horaCita {get; set;}
        [ForeignKey("Paciente")]
        public Paciente paciente {get; set;}
        public string descripcionConsulta {get; set;}

        [ForeignKey("Especialista")]
        public Especialista especialista {get; set;}
    }
}