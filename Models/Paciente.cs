using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Paciente
    {
        [Key]
        public Guid UUID { get; set; }

        //public ICollection<Cita> citas { get; set; }

        [Required]
        //el codigo se generara de forma automatica al crear el usuario, hay que ver la longitud del codigo generado
        public int codigoPin { get; set; }

        [Required,MaxLength(30, ErrorMessage = "La longitud maxima2 de {0} es de {1} caracteres")]
        public string nombre { get; set; }

        [Required,MaxLength(30, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string apellido1 { get; set; }

        [Required,MaxLength(30,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string apellido2 { get; set; }

        //consultar mas adelante la obligatoriedad del telefono fijo
        [Range(9,9, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public int telefonoFijo { get; set; }

        [Required,Range(9,9, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public int telefonoMovil { get; set; }

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [MaxLength(500,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string ocupacion { get; set; }

        [MaxLength(500,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string actividadFisica { get; set; }

        [Required,MaxLength(2000,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string valoracionInicial { get; set; }

        [Required,MaxLength(500,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string cirugia { get; set; }

        [MaxLength(500,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string calle { get; set; }

        [MaxLength(500,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string portal { get; set;}

        [MaxLength(100,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string escalera { get; set; }

        [MaxLength(20,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string piso { get; set; }

        [MaxLength(10,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string letra { get; set; }

        [MaxLength(50,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string poblacion { get; set; }

        [MaxLength(20,ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public string provincia { get; set; }

        [Range(5,5, ErrorMessage = "La longitud maxima de {0} es de {1} caracteres")]
        public int codigoPostal { get; set; }

        //el correo deberia ser obligatorio dado que este sera el usuario para la app
        public string correoElectronico { get; set; }
        public List <PacienteDeClinica> pacienteDeClinicas {get;set;}
        public ICollection<Alergia> alergias { get; set; }
        public ICollection <TratamientoFarmacologico> tratamientosFarmacologicos { get; set; }
        public ICollection <Imagen> imagenes { get; set; }
    }
}
