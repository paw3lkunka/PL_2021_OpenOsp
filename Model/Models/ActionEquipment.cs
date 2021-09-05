using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {

  public class ActionEquipment : IHasId<int, int> {

    [Display(Name = "Action's id"), Column("ActionId")]
    [Required]
    public int Id1 { get; set; }

    [Display(Name = "Equipment's id"), Column("EquipmentId")]
    [Required]
    public int Id2 { get; set; }

    [Display(Name = "Fuel used")]
    [Required, NaturalNumber]
    public float FuelUsed { get; set; } = 0.0f;

    [Display(Name = "Counter state")]
    [Required, NaturalNumber]
    public int CounterState { get; set; } = 0;

    public virtual Action Action { get; set; }

    public virtual Equipment Equipment { get; set; }

  }

}