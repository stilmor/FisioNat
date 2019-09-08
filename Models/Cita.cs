using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
        public class Cita
    {
        [Key]
        [Column("id_cita")]
        public Guid UUID {get; set;}
        [Column("fecha")]
        public DateTime fechaCita {get; set;}
        [Column("hora")]
        public DateTime horaCita {get; set;}
        [Column("id_paciente")]
        public Guid pacienteUUID {get; set;}

        [Column("id_especialista")]
        [ForeignKey("Especialista")]
        public Guid especialistaUUID {get; set;}

        [Column("descripcion_consulta")]
        public string descripcionConsulta {get; set;}

        public Especialista especialista {get; set;}
    }
}