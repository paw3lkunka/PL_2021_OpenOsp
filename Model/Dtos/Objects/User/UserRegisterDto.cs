using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Annotations;

namespace OpenOsp.Model.Dtos {

  public class UserRegisterDto {

    [Required, Display(Name = "Username")]
    [RegularExpression(@"^[a-zA-Z0-9 ''-'\s]{1,20}$", ErrorMessage = "Username can consist of up to 20 alphanumeric signs")]
    public string UserName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, ValidatePassword]
    public string Password { get; set; }

    [Required, Display(Name = "Password confirmation")]
    [Compare("Password", ErrorMessage = "Password confirmation does not match")]
    public string PasswordConfirmation { get; set; }

  }

}