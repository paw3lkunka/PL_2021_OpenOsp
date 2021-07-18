using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {
  public class MemberDtoMapper : IDtoMapper<Member, MemberCreateDto, MemberReadDto, MemberUpdateDto> {
    public Member MapCreate(MemberCreateDto dto) {
      return new Member {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Pesel = dto.Pesel,
      };
    }

    public MemberUpdateDto MapPatch(Member entity) {
      return new MemberUpdateDto {
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Pesel = entity.Pesel,
      };
    }

    public MemberReadDto MapRead(Member entity) {
      return new MemberReadDto {
        FirstName = entity.FirstName,
        Id = entity.Key,
        LastName = entity.LastName,
        Pesel = entity.Pesel
      };
    }

    public Member MapUpdate(MemberUpdateDto dto, Member entity) {
      entity.FirstName = dto.FirstName;
      entity.LastName = dto.LastName;
      entity.Pesel = dto.Pesel;
      return entity;
    }
  }
}