using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class ActionCreateDto {
  [OspDA.Required] public ActionType Type { get; set; }

  [OspDA.Required] [OspDA.MaxLength(64)] public string Location { get; set; }

  [Display(Name = "Start time")]
  [OspDA.Required]
  public DateTime StartTime { get; set; }

  [Display(Name = "End time")]
  [OspDA.Required]
  [OspDA.DateGreaterEqual("StartTime")]
  public DateTime EndTime { get; set; }

  public virtual IList<ActionMemberCreateDto> Members { get; set; }

  public virtual IList<ActionEquipmentCreateDto> Equipment { get; set; }
}