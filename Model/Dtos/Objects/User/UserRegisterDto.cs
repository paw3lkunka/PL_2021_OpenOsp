using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Annotations;

namespace OpenOsp.Model.Dtos {

  public class UserRegisterDto {

    [Required(ErrorMessage = "User name is required")]
    [RegularExpression(@"^[a-zA-Z0-9 ''-'\s]{1,20}$", ErrorMessage = "Name pattern error: use up to 20 alphanumeric signs")]
    public string UserName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    [ValidatePassword]
    public string Password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("Password", ErrorMessage = "Password confirmation does not match")]
    public string PasswordConfirmation { get; set; }

  }

}