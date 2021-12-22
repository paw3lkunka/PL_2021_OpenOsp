using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class ActionMemberUpdateDto {
  [OspDA.Required] public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;
}