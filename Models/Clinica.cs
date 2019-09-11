using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Clinica
    {
        [Key]
        public Guid clinicaUUID{get; set;}
        public string nombre {get; set;}
        public string calle {get; set;}
        public string numero {get; set;}
        public string localidad {get; set;}
        public int codigoPostal {get; set;}
        public string web {get; set;}
        public int telefono {get; set;}
        public List <PacienteDeClinica> pacienteDeClinicas {get;set;}

    }
}