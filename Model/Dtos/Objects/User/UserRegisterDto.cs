using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class UserRegisterDto {
  [Display(Name = "Username")]
  [OspDA.Required]
  [OspDA.Username]
  public string UserName { get; set; }

  [Display(Name = "E-mail")]
  [OspDA.Required]
  [OspDA.MaxLength(256)]
  [EmailAddress]
  public string Email { get; set; }

  [OspDA.Required] [OspDA.Password] public string Password { get; set; }

  [OspDA.Required]
  [Display(Name = "Password confirmation")]
  [Compare("Password", ErrorMessage = "Password confirmation does not match")]
  public string PasswordConfirmation { get; set; }
}