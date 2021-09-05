using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class UserRegisterDto {

    [Display(Name = "Username")]
    [Required, Username]
    public string UserName { get; set; }

    [Display(Name = "E-mail")]
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Password]
    public string Password { get; set; }

    [Required, Display(Name = "Password confirmation")]
    [Compare("Password", ErrorMessage = "Password confirmation does not match")]
    public string PasswordConfirmation { get; set; }

  }

}