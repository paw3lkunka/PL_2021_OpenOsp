using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class MemberCreateDto {
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string FirstName { get; set; }

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