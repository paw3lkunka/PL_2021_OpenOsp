using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class MemberReadDto {

    [OspDA.Required]
    public int Id { get; set; }

    [OspDA.Required, OspDA.MaxLength(24), Name]
    public string FirstName { get; set; }

    [OspDA.Required, OspDA.MaxLength(24), Name]
    public string LastName { get; set; }

    [Display(Name = "PESEL")]
    [OspDA.Required, Pesel]
    public string Pesel { get; set; }

  }

}