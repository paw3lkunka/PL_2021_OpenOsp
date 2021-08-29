using System.Linq;

using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {

  public class ActionDtoMapper : IDtoMapper<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto> {

    public Action MapCreate(ActionCreateDto dto) {
      return new Action {
        Type = dto.Type,
        Location = dto.Location,
        StartTime = dto.StartTime,
        EndTime = dto.EndTime,
        Members = dto.Members?.Select(e => new ActionMember {
          Id2 = e.MemberId,
          Role = e.Role
        }).ToList(),
        Equipment = dto.Equipment?.Select(e => new ActionEquipment {
          Id2 = e.EquipmentId,
          CounterState = e.CounterState,
          FuelUsed = e.FuelUsed
        }).ToList(),
      };
    }

    public ActionUpdateDto MapPatch(Action entity) {
      return new ActionUpdateDto {
        Type = entity.Type,
        Location = entity.Location,
        StartTime = entity.StartTime,
        EndTime = entity.EndTime,
      };
    }

    public ActionReadDto MapRead(Action entity) {
      return new ActionReadDto {
        Id = entity.Id,
        Type = entity.Type,
        Location = entity.Location,
        StartTime = entity.StartTime,
        EndTime = entity.EndTime,
        Members = entity.Members?.Select(e => new ActionMemberReadDto {
          MemberId = e.Id2,
          Role = e.Role,
        }).ToList(),
        Equipment = entity.Equipment?.Select(e => new ActionEquipmentReadDto {
          EquipmentId = e.Id2,
          CounterState = e.CounterState,
          FuelUsed = e.FuelUsed
        }).ToList(),
      };
    }

    public Action MapUpdate(ActionUpdateDto dto, Action entity) {
      entity.Type = dto.Type;
      entity.Location = dto.Location;
      entity.StartTime = dto.StartTime;
      entity.EndTime = dto.EndTime;
      return entity;
    }

  }

}