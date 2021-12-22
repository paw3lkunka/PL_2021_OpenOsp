using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models; 

public class ActionEquipment : IHasId<int, int> {
  [Display(Name = "Fuel used")]
  [OspDA.Required]
  [OspDA.NaturalNumber]
  public float FuelUsed { get; set; } = 0.0f;

  [Display(Name = "Counter state")]
  [OspDA.Required]
  [OspDA.NaturalNumber]
  public int CounterState { get; set; } = 0;

  public virtual Action Action { get; set; }

  public virtual Equipment Equipment { get; set; }

  [Display(Name = "Action's id")]
  [Column("ActionId")]
  [OspDA.Required]
  public int Id { get; set; }

  [Display(Name = "Equipment's id")]
  [Column("EquipmentId")]
  [OspDA.Required]
  public int Id2 { get; set; }
}