using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class MemberUpdateDto {

    [Required, MaxLength(25), Name]
    public string FirstName { get; set; }

    [Required, MaxLength(25), Name]
    public string LastName { get; set; }

    [Display(Name = "PESEL")]
    [Required, Pesel]
    public string Pesel { get; set; }

  }
}