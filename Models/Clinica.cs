using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Clinica
    {
        [Key]
        public Guid clinicaUUID{get; set;}

        [Required]
        [MaxLength(30)]
        public string nombre {get; set;}

        [Required]
        [MaxLength(120)]
        public string calle {get; set;}

        [Required]
        [MaxLength(20)]
        public string numero {get; set;}

        [Required]
        [MaxLength(50)]
        public string localidad {get; set;}

        [Required]
        [MaxLength(5)]
        [MinLength(5)]
        public int codigoPostal {get; set;}

        //restriccion para direcciones web
        public string web {get; set;}
        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public int telefono {get; set;}
        public List <PacienteDeClinica> pacienteDeClinicas {get;set;}
    }
}