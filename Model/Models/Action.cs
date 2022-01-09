using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models; 

public class Action : IHasId<int>, IOwnedBy<int> {
  [OspDA.Required] public ActionType Type { get; set; } = ActionType.Fire;

  [OspDA.Required] [OspDA.MaxLength(64)] public string Location { get; set; }

  [Display(Name = "Start time")]
  [Column(TypeName = "timestamp")]
  [OspDA.Required]
  public DateTime StartTime { get; set; }

  [Display(Name = "End time")]
  [Column(TypeName = "timestamp")]
  [OspDA.Required]
  [OspDA.DateGreaterEqual("StartTime")]
  public DateTime EndTime { get; set; }

  public virtual User User { get; set; }

  public virtual IEnumerable<ActionMember> Members { get; set; }

  public virtual IEnumerable<ActionEquipment> Equipment { get; set; }

  [Key] [OspDA.Required] public int Id { get; set; }

  [Display(Name = "Owner's id")]
  [Column("OwnerId")]
  [OspDA.Required]
  public int UserId { get; set; }
}