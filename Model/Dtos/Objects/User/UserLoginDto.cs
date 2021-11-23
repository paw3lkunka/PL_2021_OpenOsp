using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class UserLoginDto {
    [Display(Name = "E-mail")]
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(256)]
    [EmailAddress]
    public string Email { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.PasswordAttribute]
    public string Password { get; set; }
  }
}