using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Imagen
    {
        [Key]
        public Guid UUID {get; set;}

        [Required]
        [MaxLength(30)]
        public string nombre {get; set;}

        [Required]
        [MaxLength(1000)]
        public string url {get; set;}

        [Required]
        public Paciente paciente {get; set;}
    }
}