using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models; 

public class ActionMember : IHasId<int, int> {
  [OspDA.Required] public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;

  public virtual Action Action { get; set; }

  public virtual Member Member { get; set; }

  [Display(Name = "Action's id")]
  [Column("ActionId")]
  [OspDA.Required]
  public int Id { get; set; }

  [Display(Name = "Member's id")]
  [Column("MemberId")]
  [OspDA.Required]
  public int Id2 { get; set; }
}