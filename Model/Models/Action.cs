using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OpenOsp.Model.Enums;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {

  public class Action : IHasId<int>, IOwnedBy<int> {

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public ActionType Type { get; set; } = ActionType.Fire;

    [Required, MaxLength(50)]
    public string Location { get; set; }

    [Display(Name = "Start time")]
    [Required]
    public DateTime StartTime { get; set; }

    [Display(Name = "End time")]
    [Required, DateGreaterEqual("StartTime")]
    public DateTime EndTime { get; set; }

    [Display(Name = "Owner's id"), Column("owner_id")]
    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionMember> Members { get; set; }

    public virtual IEnumerable<ActionEquipment> Equipment { get; set; }

  }

}