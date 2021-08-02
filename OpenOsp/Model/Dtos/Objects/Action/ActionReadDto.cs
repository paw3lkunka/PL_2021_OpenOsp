using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Dtos {

  public class ActionReadDto {

    public int Id { get; set; }

    [Required]
    public ActionType Type { get; set; }

    [MaxLength(50)]
    public string Location { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public virtual List<ActionMemberReadDto> Members { get; set; }

    public virtual List<ActionEquipmentReadDto> Equipment { get; set; }

  }

}