using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Alergia
    {
        [Key]
        public Guid UUID { get; set; }
        public Paciente pacienteId { get; set; }
        public Alergeno alergenoId {get; set;}
    }
}