using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Imagen
    {
        [Key]
        public Guid UUID {get; set;}

        public string nombre {get; set;}

        public string url {get; set;}

        public Paciente paciente {get; set;}
    }
}