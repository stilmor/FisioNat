using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models
{
    public class Especialidad
    {
        [Key]
        public Guid UUID {get; set;}

        [Required,MaxLength(30,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string nombre {get;set;}

        [JsonIgnore]
        public ICollection <Especialista> especialistas { get; set; }
    }
}