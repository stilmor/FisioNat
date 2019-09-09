using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Especialista
    {
        [Key]
        public Guid UUID {get; set;}

        [ForeignKey("Especialista")]
        public Especialidad especialidadId {get; set;}

        [ForeignKey("Empleado")]
        public Empleado empleadoId {get; set;}

        public int numeroColegiado {get; set;}
    }
}