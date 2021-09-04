using OpenOsp.Model.Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class ActionMember : IHasId<int, int> {

    [Column("action_id")]
    public int Id1 { get; set; }

    [Column("member_id")]
    public int Id2 { get; set; }

    [Required]
    public ActionMemberRole Role { get; set; }

    public virtual Action Action { get; set; }

    public virtual Member Member { get; set; }

  }

}