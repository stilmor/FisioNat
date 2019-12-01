using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models {
    public class PostTratamientoCita {
        [Required, DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaInicio { get; set; }

        [Required, DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaFin { get; set; }

        [Required, MaxLength (2000, ErrorMessage = "La longitud maxima para {0} del tratamiento es de {1} caracteres")]
        public string descripcion { get; set; }
        [Required]
        public Guid citaId { get; set; }
    }
}