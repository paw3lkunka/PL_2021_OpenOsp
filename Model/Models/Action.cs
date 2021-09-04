using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Models {

  public class Action : IHasId<int>, IOwnedBy<int> {

    [Display(Name = "Action's id")]
    [Key]
    public int Id { get; set; }

    [Display(Name = "Action's type")]
    [Required]
    public ActionType Type { get; set; }

    [MaxLength(50)]
    public string Location { get; set; }

    [Display(Name = "Start time")]
    [Required]
    public DateTime StartTime { get; set; }

    [Display(Name = "End time")]
    [Required]
    public DateTime EndTime { get; set; }

    [Display(Name = "Action owner's id")]
    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual List<ActionMember> Members { get; set; }

    public virtual List<ActionEquipment> Equipment { get; set; }

  }

}