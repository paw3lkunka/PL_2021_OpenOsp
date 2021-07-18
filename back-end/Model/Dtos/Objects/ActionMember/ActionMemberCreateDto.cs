using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Dtos {
  public class ActionMemberCreateDto {
    public int MemberId { get; set; }

    public ActionMemberRole Role { get; set; }
  }
}