using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class ActionEquipment : IHasKey<int, int> {

    [Column("action_id")]
    public int Key1 { get; set; }

    [Column("equipment_id")]
    public int Key2 { get; set; }

    public float FuelUsed { get; set; }

    public int CounterState { get; set; }

    public virtual Action Action { get; set; }

    public virtual Equipment Equipment { get; set; }

  }

}