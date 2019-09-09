using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Empleado
    {
        [Key]
        public Guid UUID{get; set;}

        public string nombre {get; set;}

        public string apellido1 {get; set;}

        public string apellido2 {get; set;}


    }
}