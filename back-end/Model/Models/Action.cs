using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Models {
  public class Action : IHasKey<int> {
    [Key]
    [Column("id")]
    public int Key { get; set; }

    [Required(ErrorMessage = "Action type is required")]
    public ActionType Type { get; set; }

    [MaxLength(50)]
    public string Location { get; set; }
    
    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }
    
    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }

    [Required(ErrorMessage = "Action's owner id is required")]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual List<ActionMember> Members { get; set; }

    public virtual List<ActionEquipment> Equipment { get; set; }
  }
}