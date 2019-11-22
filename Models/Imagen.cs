using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Raist.Models {
    public class Imagen {
        [Key]
        public Guid uuid { get; set; }

        [Required]
        public string url { get; set; }

        [Required]
        public string descripcion { get; set; }

        [Required]

        [JsonIgnore]
        public Paciente paciente { get; set; }
    }
}