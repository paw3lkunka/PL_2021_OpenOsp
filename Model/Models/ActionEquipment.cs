using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class ActionEquipment : IHasId<int, int> {

    [Column("action_id")]
    public int Id1 { get; set; }

    [Column("equipment_id")]
    public int Id2 { get; set; }

    [Display(Name = "Fuel used")]
    [Range(0.0, float.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
    public float FuelUsed { get; set; }

    [Display(Name = "Counter State")]
    [Range(0.0, float.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
    public int CounterState { get; set; }

    public virtual Action Action { get; set; }

    public virtual Equipment Equipment { get; set; }

  }

}