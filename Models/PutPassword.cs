using System;
using System.ComponentModel.DataAnnotations;

namespace Raist.Models {
    public class PutPassword {
        [Required]
        public Guid idpaciente { get; set; }

        [Required]
        public string oldPassword { get; set; }

        [Required]
        public String newpassword { get; set; }

    }
}