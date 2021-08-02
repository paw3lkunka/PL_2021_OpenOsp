using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {

  public class EquipmentDtoReader : IDtoMapper<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto> {

    public Equipment MapCreate(EquipmentCreateDto dto) {
      return new Equipment {
        Brand = dto.Brand,
        Model = dto.Model,
        Name = dto.Name,
        RegistryNumber = dto.ReqistryNumber,
      };
    }

    public EquipmentUpdateDto MapPatch(Equipment entity) {
      return new EquipmentUpdateDto {
        Brand = entity.Brand,
        Model = entity.Model,
        Name = entity.Name,
        ReqistryNumber = entity.RegistryNumber,
      };
    }

    public EquipmentReadDto MapRead(Equipment entity) {
      return new EquipmentReadDto {
        Brand = entity.Brand,
        Id = entity.Id,
        Model = entity.Model,
        Name = entity.Name,
        ReqistryNumber = entity.RegistryNumber,
      };
    }

    public Equipment MapUpdate(EquipmentUpdateDto dto, Equipment entity) {
      entity.Brand = dto.Brand;
      entity.Model = dto.Model;
      entity.Name = dto.Name;
      entity.RegistryNumber = dto.ReqistryNumber;
      return entity;
    }

  }

}