using System;

namespace Raist.Models {
    public class PostPersonal {
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public Guid especialidad { get; set; }
        public int numeroColegiado {get; set;}
    }
}