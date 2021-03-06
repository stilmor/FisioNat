using System.ComponentModel.DataAnnotations;


namespace Raist.Models
{
    public class Registro
    {
         [Key]
        public string usuario { get; set; }

        //[Range(4,20, ErrorMessage = "La longitud minima de {0} es de {1} caracteres y la maxima de {2}")]
        [Required]
        public string  password { get; set; }

        //revisar formato passwordHuella app
        public string passwordHuella  { get; set; }

        [Required]
        public Paciente pacienteId { get; set; }
    }
}