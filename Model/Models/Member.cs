using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models; 

public class Member : IHasId<int>, IOwnedBy<int> {
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
  [Column(TypeName = "char(11)")]
  [OspDA.Required]
  [OspDA.MaxLength(11)]
  [OspDA.Pesel]
  public string Pesel { get; set; }

  public virtual User User { get; set; }

  public virtual IEnumerable<ActionMember> Actions { get; set; }

  [Key] [OspDA.Required] public int Id { get; set; }

  [Display(Name = "Member owner's id")]
  [Column("OwnerId")]
  [OspDA.Required]
  public int UserId { get; set; }
}