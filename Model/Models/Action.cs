using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {
  public class Action : IHasId<int>, IOwnedBy<int> {
    [OspDA.RequiredAttribute] public ActionType Type { get; set; } = ActionType.Fire;

    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(64)]
    public string Location { get; set; }

    [Display(Name = "Start time")]
    [OspDA.RequiredAttribute]
    public DateTime StartTime { get; set; }

    [Display(Name = "End time")]
    [OspDA.RequiredAttribute]
    [OspDA.DateGreaterEqualAttribute("StartTime")]
    public DateTime EndTime { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionMember> Members { get; set; }

    public virtual IEnumerable<ActionEquipment> Equipment { get; set; }

    [Key] [OspDA.RequiredAttribute] public int Id { get; set; }

    [Display(Name = "Owner's id")]
    [Column("OwnerId")]
    [OspDA.RequiredAttribute]
    public int UserId { get; set; }
  }
}