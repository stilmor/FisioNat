using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Alergeno
    {
        [Key]
        public Guid UUID { get; set; }

        [Required,MaxLength(50,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string nombreAlergeno { get; set; }
    }
}