using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class ActionEquipmentReadDto {

    [Display(Name = "Equipment's id")]
    [Required]
    public int EquipmentId { get; set; }

    [Display(Name = "Fuel used")]
    [Required, NaturalNumber]
    public float FuelUsed { get; set; } = 0.0f;

    [Display(Name = "Counter state")]
    [Required, NaturalNumber]
    public int CounterState { get; set; } = 0;

  }

}