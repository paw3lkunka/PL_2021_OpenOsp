using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenOsp.Model.Enums;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {

  public class Action : IHasId<int>, IOwnedBy<int> {

    [Key]
    [OspDA.Required]
    public int Id { get; set; }

    [OspDA.Required]
    public ActionType Type { get; set; } = ActionType.Fire;

    [OspDA.Required, OspDA.MaxLength(64)]
    public string Location { get; set; }

    [Display(Name = "Start time")]
    [OspDA.Required]
    public DateTime StartTime { get; set; }

    [Display(Name = "End time")]
    [OspDA.Required, DateGreaterEqual("StartTime")]
    public DateTime EndTime { get; set; }

    [Display(Name = "Owner's id"), Column("OwnerId")]
    [OspDA.Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionMember> Members { get; set; }

    public virtual IEnumerable<ActionEquipment> Equipment { get; set; }

  }

}