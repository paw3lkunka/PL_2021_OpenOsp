using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {
  public class Member : IHasId<int>, IOwnedBy<int> {
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string FirstName { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string LastName { get; set; }

    [Display(Name = "PESEL")]
    [Column(TypeName = "char(11)")]
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(11)]
    [OspDA.PeselAttribute]
    public string Pesel { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionMember> Actions { get; set; }

    [Key] [OspDA.RequiredAttribute] public int Id { get; set; }

    [Display(Name = "Member owner's id")]
    [Column("OwnerId")]
    [OspDA.RequiredAttribute]
    public int UserId { get; set; }
  }
}