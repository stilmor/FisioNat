using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Alergeno
    {
        [Key]
        [Column("id_alergeno", Order = 0)]
        public Guid UUID { get; set; }
        [Column("nombre", Order = 1)]
        public string nombreAlergeno { get; set; }
    }
}