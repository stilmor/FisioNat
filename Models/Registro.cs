using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Registro
    {
        public string usuario { get; set; }
        public string  password { get; set; }
        public string passwordHuella  { get; set; }
        public Paciente pacienteId { get; set; }
    }
}