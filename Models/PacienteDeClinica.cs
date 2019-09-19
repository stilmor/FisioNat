using System;

using System.Text.Json.Serialization;

namespace Raist.Models
{
    public class PacienteDeClinica
    {

        [JsonIgnore]
        public Guid pacienteUUID {get; set;}

        [JsonIgnore]
        public Paciente paciente{get; set;}

        public Guid clinicaUUID {get; set;}

        public Clinica clinica{get; set;}
    }
}