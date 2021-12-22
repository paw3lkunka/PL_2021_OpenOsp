using System;
using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class ActionReadDto {
  [OspDA.Required] public int Id { get; set; }

  [OspDA.Required] public ActionType Type { get; set; } = ActionType.Fire;

  [OspDA.Required] [OspDA.MaxLength(64)] public string Location { get; set; }

  [Display(Name = "Start time")]
  [OspDA.Required]
  public DateTime StartTime { get; set; }

  [Display(Name = "End time")]
  [OspDA.Required]
  [OspDA.DateGreaterEqual("StartTime")]
  public DateTime EndTime { get; set; }
}