using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {
  public class
    ActionMemberDtoMapper : IDtoMapper<ActionMember, ActionMemberCreateDto, ActionMemberReadDto,
      ActionMemberUpdateDto> {
    public ActionMember MapCreate(ActionMemberCreateDto dto) {
      return new ActionMember {Id2 = dto.MemberId, Role = dto.Role};
    }

    public ActionMemberUpdateDto MapPatch(ActionMember entity) {
      return new ActionMemberUpdateDto {Role = entity.Role};
    }

    public ActionMemberReadDto MapRead(ActionMember entity) {
      return new ActionMemberReadDto {MemberId = entity.Id2, Role = entity.Role};
    }

    public ActionMember MapUpdate(ActionMemberUpdateDto dto, ActionMember entity) {
      entity.Role = dto.Role;
      return entity;
    }
  }
}