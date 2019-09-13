using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Imagen
    {
        [Key]
        public Guid UUID {get; set;}

        [Required,MaxLength(30,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string nombre {get; set;}

        [Required,MaxLength(1000,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string url {get; set;}

        [Required]
        public Paciente paciente {get; set;}
    }
}