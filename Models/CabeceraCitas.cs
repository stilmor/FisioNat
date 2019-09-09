using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models
{
    public class CabeceraCitas
    {
           [Key]
           public Guid UUID {get; set;}
           public string especialidad {get; set;}
           public DateTime fecha {get; set;}
    }
}