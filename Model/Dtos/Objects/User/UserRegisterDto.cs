using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class UserRegisterDto {

    [Display(Name = "Username")]
    [OspDA.Required, Username]
    public string UserName { get; set; }

    [Display(Name = "E-mail")]
    [OspDA.Required, OspDA.MaxLength(256), EmailAddress]
    public string Email { get; set; }

    [OspDA.Required, Password]
    public string Password { get; set; }

    [OspDA.Required, Display(Name = "Password confirmation")]
    [Compare("Password", ErrorMessage = "Password confirmation does not match")]
    public string PasswordConfirmation { get; set; }

  }

}