using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Annotations;

namespace OpenOsp.Model.Dtos.ViewModels {
  public class UserRegisterVM {
    [Required(ErrorMessage = "Username is required")]
    [RegularExpression(@"^[a-zA-Z0-9 ''-'\s]{1,20}$", ErrorMessage = "Name pattern error: use up to 20 alphanumeric signs")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [ValidateEmail]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [ValidatePassword]
    public string Password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required")]
    [Compare("Password", ErrorMessage = "Password confirmation does not match")]
    public string PasswordConfirmation { get; set; }
  }
}