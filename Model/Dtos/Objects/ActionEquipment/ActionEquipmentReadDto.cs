using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class ActionEquipmentReadDto {
    [Display(Name = "Equipment's id")]
    [OspDA.RequiredAttribute]
    public int EquipmentId { get; set; }

    [Display(Name = "Fuel used")]
    [OspDA.RequiredAttribute]
    [OspDA.NaturalNumberAttribute]
    public float FuelUsed { get; set; } = 0.0f;

    [Display(Name = "Counter state")]
    [OspDA.RequiredAttribute]
    [OspDA.NaturalNumberAttribute]
    public int CounterState { get; set; } = 0;
  }
}