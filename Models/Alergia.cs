using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Alergia
    {
        [Key]
        [Column("id_alergia")]
        public Guid UUID { get; set; }

        [Column("id_paciente")]
        [ForeignKey("Usuario")]
        public Guid pacienteId { get; set; }

        [Column("id_alergeno")]
        [ForeignKey("Alergeno")]
        public Guid alergenoId {get; set;}
        public Alergeno alergeno {get; set;}
    }
}