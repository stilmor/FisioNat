using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raist.Models
{
    public class PacienteDeClinica
    {

        public Guid pacienteUUID {get; set;}
        public Paciente paciente{get; set;}


        public Guid clinicaUUID {get; set;}
        public Clinica clinica{get; set;}
    }
}