using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Models;
using OpenOsp.Model.Enums;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class ActionMemberCreateDto {

    [Display(Name = "Member's id")]
    [OspDA.Required]
    public int MemberId { get; set; }

    [OspDA.Required]
    public ActionMemberRole Role { get; set; } = ActionMemberRole.Member;

  }

}