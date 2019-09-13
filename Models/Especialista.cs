using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Especialista
    {
        [Key]
        public Guid UUID {get; set;}

        [Required,ForeignKey("Especialidad")]
        public Especialidad especialidadId {get; set;}

        [Required,ForeignKey("Empleado")]
        public Empleado empleadoId {get; set;}

        [Required,Range(9,9, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public int numeroColegiado {get; set;}
    }
}