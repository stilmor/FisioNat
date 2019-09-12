using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Empleado
    {
        [Key]
        public Guid UUID{get; set;}

        [Required]
        [MaxLength(30)]
        public string nombre {get; set;}

        [Required]
        [MaxLength(30)]
        public string apellido1 {get; set;}

        [Required]
        [MaxLength(30)]
        public string apellido2 {get; set;}
    }
}