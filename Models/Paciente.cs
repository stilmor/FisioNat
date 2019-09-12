using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Paciente
    {
        [Key]
        public Guid pacienteUUID { get; set; }

        [Required]
        //el codigo se generara de forma automatica al crear el usuario, hay que ver la longitud del codigo generado
        public int codigoPin { get; set; }

        [Required]
        [MaxLength(30)]
        public string nombre { get; set; }

        [Required]
        [MaxLength(30)]
        public string apellido1 { get; set; }

        [Required]
        [MaxLength(30)]
        public string apellido2 { get; set; }

        //consultar mas adelante la obligatoriedad del telefono fijo
        [MaxLength(9)]
        [MinLength(9)]
        public int telefonoFijo { get; set; }

        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public int telefonoMovil { get; set; }

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [MaxLength(500)]
        public string ocupacion { get; set; }

        [MaxLength(500)]
        public string actividadFisica { get; set; }

        [Required]
        [MaxLength(2000)]
        public string valoracionInicial { get; set; }

        [Required]
        [MaxLength(500)]
        public string cirugia { get; set; }
        [MaxLength(500)]
        public string calle { get; set; }
        [MaxLength(500)]
        public string portal { get; set;}

        [MaxLength(100)]
        public string escalera { get; set; }
        [MaxLength(20)]
        public string piso { get; set; }

        [MaxLength(10)]
        public string letra { get; set; }

        [MaxLength(50)]
        public string poblacion { get; set; }

        [MaxLength(20)]
        public string provincia { get; set; }

        [MaxLength(5)]
        [MinLength(5)]
        public int codigoPostal { get; set; }

        //el correo deberia ser obligatorio dado que este sera el usuario para la app
        public string correoElectronico { get; set; }
        public List <PacienteDeClinica> pacienteDeClinicas {get;set;}
    }
}