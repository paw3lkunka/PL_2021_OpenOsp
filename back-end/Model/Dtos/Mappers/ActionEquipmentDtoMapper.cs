using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {

  public class ActionEquipmentDtoMapper : IDtoMapper<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto> {

    public ActionEquipment MapCreate(ActionEquipmentCreateDto dto) {
      return new ActionEquipment {
        CounterState = dto.CounterState,
        Key2 = dto.EquipmentId,
        FuelUsed = dto.FuelUsed,
      };
    }

    public ActionEquipmentUpdateDto MapPatch(ActionEquipment entity) {
      return new ActionEquipmentUpdateDto {
        CounterState = entity.CounterState,
        FuelUsed = entity.FuelUsed,
      };
    }

    public ActionEquipmentReadDto MapRead(ActionEquipment entity) {
      return new ActionEquipmentReadDto {
        CounterState = entity.CounterState,
        EquipmentId = entity.Key2,
        FuelUsed = entity.FuelUsed,
      };
    }

    public ActionEquipment MapUpdate(ActionEquipmentUpdateDto dto, ActionEquipment entity) {
      entity.CounterState = dto.CounterState;
      entity.FuelUsed = dto.FuelUsed;
      return entity;
    }

  }

}