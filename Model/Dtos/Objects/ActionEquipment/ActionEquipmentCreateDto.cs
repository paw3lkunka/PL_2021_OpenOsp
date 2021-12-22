using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class ActionEquipmentCreateDto {
  [Display(Name = "Equipment's id")]
  [OspDA.Required]
  public int EquipmentId { get; set; }

  [Display(Name = "Fuel used")]
  [OspDA.Required]
  [OspDA.NaturalNumber]
  public float FuelUsed { get; set; } = 0.0f;

  [Display(Name = "Counter state")]
  [OspDA.Required]
  [OspDA.NaturalNumber]
  public int CounterState { get; set; } = 0;
}