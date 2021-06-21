using System;
using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Enums;

namespace OpenOsp.Model.DTOs {
  public class ActionVM {
    [Required(ErrorMessage = "Action type is required")]
    public ActionType Type { get; set; }

    [MaxLength(50)]
    public string Location { get; set; }

    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }
  }
}