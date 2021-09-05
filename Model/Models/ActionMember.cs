using OpenOsp.Model.Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class ActionMember : IHasId<int, int> {

    [Display(Name = "Action's id"), Column("ActionId")]
    [Required]
    public int Id1 { get; set; }

    [Display(Name = "Member's id"),Column("MemberId")]
    [Required]
    public int Id2 { get; set; }

    [Required]
    public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;

    public virtual Action Action { get; set; }

    public virtual Member Member { get; set; }

  }

}