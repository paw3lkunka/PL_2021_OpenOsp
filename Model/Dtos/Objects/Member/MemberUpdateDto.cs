using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class MemberUpdateDto {
    [Display(Name = "First name")]
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string FirstName { get; set; }

    [Display(Name = "Last name")]
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string LastName { get; set; }

    [Display(Name = "PESEL")]
    [OspDA.RequiredAttribute]
    [OspDA.PeselAttribute]
    public string Pesel { get; set; }
  }
}