using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class UserLoginDto {

    [Display(Name = "E-mail")]
    [OspDA.Required, OspDA.MaxLength(256), EmailAddress]
    public string Email { get; set; }

    [OspDA.Required, Password]
    public string Password { get; set; }

  }

}