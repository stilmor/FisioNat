using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Especialista
    {
        [Key]
        public Guid UUID {get; set;}

        [Required]
        [ForeignKey("Especialista")]
        public Especialidad especialidadId {get; set;}

        [Required]
        [ForeignKey("Empleado")]
        public Empleado empleadoId {get; set;}

        [Required]
        [MaxLength(99999)]
        public int numeroColegiado {get; set;}
    }
}