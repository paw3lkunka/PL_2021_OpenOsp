using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class ActionMemberReadDto {
  [Display(Name = "Member's id")]
  [OspDA.Required]
  public int MemberId { get; set; }

  [OspDA.Required] public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;
}