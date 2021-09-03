using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Annotations;

namespace OpenOsp.Model.Dtos {

  public class UserLoginDto {

    [Required, EmailAddress, MinLength(3)]
    public string Email { get; set; }

    [Required, ValidatePassword, MinLength(3)]
    public string Password { get; set; }

  }

}