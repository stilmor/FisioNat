using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Especialidad
    {
        [Key]
        public Guid UUID {get; set;}

        [Required]
        [MaxLength(30)]
        public string nombre {get;set;}
    }
}