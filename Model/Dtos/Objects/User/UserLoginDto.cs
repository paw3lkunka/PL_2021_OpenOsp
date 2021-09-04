using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Annotations;

namespace OpenOsp.Model.Dtos {

  public class UserLoginDto {

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, ValidatePassword]
    public string Password { get; set; }

  }

}