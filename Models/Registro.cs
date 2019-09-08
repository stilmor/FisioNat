using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Registro
    {
        [Key]
        [Column("usuario", Order = 0) ]
        public string usuario { get; set; }

        [Key]
        [Column("password", Order = 1) ]
        public string  password { get; set; }

        [Key]
        [Column("password_huella", Order = 2) ]
        public string password_huella  { get; set; }

        [ForeignKey("Paciente")]
        [Column("id_paciente", Order = 3) ]
        public Guid paciente_id { get; set; }

    }
}