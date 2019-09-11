using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Clinica
    {
        public Clinica()
        {
            this.Pacientes = new HashSet<Paciente>();
        }
        
        [Key]
        public Guid UUID{get; set;}
        public string nombre {get; set;}
        public string calle {get; set;}
        public string numero {get; set;}
        public string localidad {get; set;}
        public int codigoPostal {get; set;}
        public string web {get; set;}
        public int telefono {get; set;}
        public virtual ICollection <Paciente> Pacientes {get;set;}

    }
}