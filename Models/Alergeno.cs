using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class Alergeno
    {
        [Key]
        public Guid UUID { get; set; }
        public string nombreAlergeno { get; set; }

    }
}