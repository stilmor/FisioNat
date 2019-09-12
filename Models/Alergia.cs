using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Alergia
    {
        [Key]
        public Guid UUID { get; set; }
        [Required]
        public Paciente pacienteId { get; set; }
        [Required]
        public Alergeno alergenoId {get; set;}
    }
}