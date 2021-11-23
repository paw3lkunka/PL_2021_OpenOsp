using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class ActionMemberCreateDto {
    [Display(Name = "Member's id")]
    [OspDA.RequiredAttribute]
    public int MemberId { get; set; }

    [OspDA.RequiredAttribute] public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;
  }
}