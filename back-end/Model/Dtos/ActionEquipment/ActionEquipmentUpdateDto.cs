namespace OpenOsp.Model.Dtos {
  public class ActionEquipmentUpdateDto {
    public int ActionId { get; set; }
    public int EquipmentId { get; set; }
    public float FuelUsed { get; set; }
    public int CounterState { get; set; }
  }
}