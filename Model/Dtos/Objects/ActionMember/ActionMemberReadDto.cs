using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class ActionMemberReadDto {

    [Display(Name = "Member's id")]
    [Required]
    public int MemberId { get; set; }

    [Required]
    public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;

  }

}