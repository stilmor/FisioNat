using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Registro
    {
        public string usuario { get; set; }

        [MaxLength(20,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        [MinLength(8, ErrorMessage = "La longitud minima de {0} es de {1} caracteres")]
        public string  password { get; set; }

        //revisar formato passwordHuella app
        public string passwordHuella  { get; set; }

        [Required]
        public Paciente pacienteId { get; set; }
    }
}