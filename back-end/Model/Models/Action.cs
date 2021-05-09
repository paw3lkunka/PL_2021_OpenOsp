using System;

namespace OpenOsp.Model.Models {
  public class Action {
    public int Id { get; set; }
    public ActionType Type { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
  }
}