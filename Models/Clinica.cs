using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models
{
    public class Clinica
    {
        [Key]
        public Guid clinicaUUID{get; set;}

        [Required,MaxLength(30,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string nombre {get; set;}

        [Required,MaxLength(120,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string calle {get; set;}

        [Required,MaxLength(20,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string numero {get; set;}

        [Required,MaxLength(50,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string localidad {get; set;}

        //[Required,Range(9,9, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        [Required,MaxLength(9, ErrorMessage ="la longitud maxima de {0} es de {1}" )]
        public int codigoPostal {get; set;}

        //restriccion para direcciones web
        public string web {get; set;}

       [Required,Range(9,9, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public int telefono {get; set;}
         [JsonIgnore]
        public List <PacienteDeClinica> pacienteDeClinicas {get;set;}
    }
}