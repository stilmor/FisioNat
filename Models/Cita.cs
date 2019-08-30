using System;

namespace Raist.Models
{
    public class Cita
    {        
        public Guid UUID {get; set;}

        //public Guid usuarioUuid {get; set;}

        public DateTime cuando {get; set;}

        public string especialidad {get; set;}

        public string nombreEspecialista {get; set;}

        public string descripcionConsulta {get; set;}

        public string tratamiento {get; set;}

        public DateTime inicioTratamiento {get; set;}

        public DateTime finTratamiento {get; set;}

    }
}