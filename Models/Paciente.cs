using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Paciente
    {
        [Key]
        [Column("id_paciente")]
        public Guid UUID { get; set; }

        [Column("codigo_pin")]
         public int codigoPin { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("apellido1")]
        public string apellido1 { get; set; }

        [Column("apellido2")]
        public string apellido2 { get; set; }

        [Column("telefono_fijo")]
        public int telefonoFijo { get; set; }

        [Column("telefono_movil")]
        public int telefonoMovil { get; set; }

        [Column("fechaNacimiento")]
        public DateTime fechaNacimiento { get; set; }

        [Column("ocupacion")]
        public string ocupacion { get; set; }

        [Column("actividad_fisica")]
        public string actividadFisica { get; set; }

        [Column("valoracion_inicial")]
        public string valoracionInicial { get; set; }

        [Column("cirugia")]
        public string cirugia { get; set; }

        [Column("calle")]
        public string calle { get; set; }

        [Column("portal")]
        public string portal { get; set; }

        [Column("escalera")]
        public string escalera { get; set; }

        [Column("piso")]
        public string piso { get; set; }

        [Column("letra")]
        public string letra { get; set; }

        [Column("poblacion")]
        public string poblacion { get; set; }

        [Column("provincia")]
        public string provincia { get; set; }

        [Column("codigo_postal")]
        public int codigoPostal { get; set; }

        [Column("correoElectronico")]
        public string correoElectronico { get; set; }
    }
}