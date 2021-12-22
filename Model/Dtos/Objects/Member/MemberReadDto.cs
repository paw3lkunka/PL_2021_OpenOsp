using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class MemberReadDto {
  [OspDA.Required] public int Id { get; set; }

  [Display(Name = "First name")]
  [OspDA.Required]
  [OspDA.MaxLength(24)]
  [OspDA.Name]
  public string FirstName { get; set; }

  [Display(Name = "Last name")]
  [OspDA.Required]
  [OspDA.MaxLength(24)]
  [OspDA.Name]
  public string LastName { get; set; }

  [Display(Name = "PESEL")]
  [OspDA.Required]
  [OspDA.Pesel]
  public string Pesel { get; set; }
}