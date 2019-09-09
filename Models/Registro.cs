using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Registro
    {
        [Key]
        public string usuario { get; set; }
        [Key]
        public string  password { get; set; }
        [Key]
        public string password_huella  { get; set; }
        public Paciente paciente_id { get; set; }

    }
}