using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Models {
  public class ActionMember {
    public int Id { get; set; }
    public int ActionId { get; set; }
    public int TeamMember { get; set; }
    public ActionMemberRole Role { get; set; }
  }
}