using System.ComponentModel.DataAnnotations;
namespace Raist.Controllers {
  public class LoginInformation {
    [Required]
    public string user { get; set; }

    [Required]
    public string password { get; set; }
  }
}