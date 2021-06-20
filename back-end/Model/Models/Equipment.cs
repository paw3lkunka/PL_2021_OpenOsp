using System.Collections.Generic;

namespace OpenOsp.Model.Models {
  public class Equipment {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string RegistryNumber { get; set; }
    public int UserId { get; set; }

    public virtual User User { get; set; }
    public virtual List<ActionEquipment> Actions { get; set; }
  }
}