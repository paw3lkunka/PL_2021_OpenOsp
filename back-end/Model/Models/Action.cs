using System;
using System.Collections.Generic;
using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Models {
  public class Action {
    public int Id { get; set; }
    public ActionType Type { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public virtual User User { get; set; }
    public virtual List<ActionMember> Members { get; set; }
    public virtual List<ActionEquipment> Equipment { get; set; }
  }
}