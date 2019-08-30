using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Raist.Controllers
{
    public class LoginInformation
    {
         [Required]
       public string user {get; set;}
         [Required]
        public string password {get; set;}        

        public LoginInformation(){
        }
    }   
}