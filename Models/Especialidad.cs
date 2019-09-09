using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Especialidad
    {
        [Key]
        public Guid UUID {get; set;}

        public string nombre {get;set;}
    }
}