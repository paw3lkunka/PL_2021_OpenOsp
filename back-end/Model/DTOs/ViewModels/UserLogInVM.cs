using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Attributes;

namespace OpenOsp.Model.DTOs {
  public class UserLoginVM {
    [Required(ErrorMessage = "Email is required")]
    [ValidateEmail]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [ValidatePassword]
    public string Password { get; set; }
  }
}