using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class ActionEquipmentUpdateDto {

    [Display(Name = "Fuel used")]
    [OspDA.Required, NaturalNumber]
    public float FuelUsed { get; set; } = 0.0f;

    [Display(Name = "Counter state")]
    [OspDA.Required, NaturalNumber]
    public int CounterState { get; set; } = 0;

  }

}