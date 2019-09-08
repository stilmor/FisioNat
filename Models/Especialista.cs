using System;

namespace Raist.Models
{
    public class Especialista
    {
        public Guid EspecialistaId{get; set;}

        public Guid especialidadId {get; set;}

        public Guid trabajadorId {get; set;}

        public int numeroColegiado {get; set;}

    }
}