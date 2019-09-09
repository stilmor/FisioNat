using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class TratamientoFarmacologico
    {
        [Key]
        public Guid UUID {get; set;}
        public DateTime fechaInicio {get; set;}
        public DateTime fechaFin {get; set;}
        public string descripcionTratamiento {get; set;}
        public Paciente paciente {get; set;}
    }
}