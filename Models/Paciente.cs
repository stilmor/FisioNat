using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class Paciente
    {
        public Paciente()
        {
            this.Clinicas = new HashSet<Clinica>();
        }
        [Key]
        public Guid UUID { get; set; }
        public int codigoPin { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int telefonoFijo { get; set; }
        public int telefonoMovil { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ocupacion { get; set; }
        public string actividadFisica { get; set; }
        public string valoracionInicial { get; set; }
        public string cirugia { get; set; }
        public string calle { get; set; }
        public string portal { get; set;}
        public string escalera { get; set; }
        public string piso { get; set; }
        public string letra { get; set; }
        public string poblacion { get; set; }
        public string provincia { get; set; }
        public int codigoPostal { get; set; }
        public string correoElectronico { get; set; }
        public virtual ICollection <Clinica> Clinicas { get; set; }
    }
}