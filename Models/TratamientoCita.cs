using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class TratamientoCita
    {
        [Key]
        public Guid UUID {get; set;}

        public DateTime fechaInicio {get; set;}

        public DateTime fechaFin {get; set;}

        public string descripcion {get; set;}

        public Cita cita {get; set;}
    }
}