using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class UserLoginDto {

    [Display(Name = "E-mail")]
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Password]
    public string Password { get; set; }

  }

}