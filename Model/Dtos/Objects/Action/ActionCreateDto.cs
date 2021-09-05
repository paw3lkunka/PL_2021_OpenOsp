using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Enums;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class ActionCreateDto {

    [Required]
    public ActionType Type { get; set; }

    [Required, MaxLength(50)]
    public string Location { get; set; }

    [Display(Name = "Start time")]
    [Required]
    public DateTime StartTime { get; set; }

    [Display(Name = "End time")]
    [Required, DateGreaterEqual("StartTime")]
    public DateTime EndTime { get; set; }

    public virtual IEnumerable<ActionMemberCreateDto> Members { get; set; }

    public virtual IEnumerable<ActionEquipmentCreateDto> Equipment { get; set; }

  }

}