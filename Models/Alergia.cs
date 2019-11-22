using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models
{
    public class Alergia
    {
        [Key]
        public Guid UUID { get; set; }
        [Required]

        [JsonIgnore]
        public Paciente paciente { get; set; }
        [Required]
        public Alergeno alergeno {get; set;}
    }
}
