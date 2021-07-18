using OpenOsp.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {
  public class ActionMember : IHasKey<int, int> {
    [Column("action_id")]
    public int Key1 { get; set; }

    [Column("member_id")]
    public int Key2 { get; set; }

    public ActionMemberRole Role { get; set; }

    public virtual Action Action { get; set; }

    public virtual Member Member { get; set; }
  }
}