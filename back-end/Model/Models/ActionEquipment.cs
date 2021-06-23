using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Models {
  public class ActionEquipment : DbModel {
    public int ActionId { get; set; }
    public int EquipmentId { get; set; }
    public float FuelUsed { get; set; }
    public int CounterState { get; set; }

    public virtual Action Action { get; set; }
    public virtual Equipment Equipment { get; set; }
  }
}