using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class UserRegisterDto {
    [Display(Name = "Username")]
    [OspDA.RequiredAttribute]
    [OspDA.UsernameAttribute]
    public string UserName { get; set; }

    [Display(Name = "E-mail")]
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(256)]
    [EmailAddress]
    public string Email { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.PasswordAttribute]
    public string Password { get; set; }

    [OspDA.RequiredAttribute]
    [Display(Name = "Password confirmation")]
    [Compare("Password", ErrorMessage = "Password confirmation does not match")]
    public string PasswordConfirmation { get; set; }
  }
}