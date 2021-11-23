using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {
  public class EquipmentDtoMapper : IDtoMapper<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto> {
    public Equipment MapCreate(EquipmentCreateDto dto) {
      return new Equipment {Brand = dto.Brand, Model = dto.Model, RegistryNumber = dto.RegistryNumber};
    }

    public EquipmentUpdateDto MapPatch(Equipment entity) {
      return new EquipmentUpdateDto {
        Brand = entity.Brand, Model = entity.Model, RegistryNumber = entity.RegistryNumber
      };
    }

    public EquipmentReadDto MapRead(Equipment entity) {
      return new EquipmentReadDto {
        Brand = entity.Brand, Id = entity.Id, Model = entity.Model, RegistryNumber = entity.RegistryNumber
      };
    }

    public Equipment MapUpdate(EquipmentUpdateDto dto, Equipment entity) {
      entity.Brand = dto.Brand;
      entity.Model = dto.Model;
      entity.RegistryNumber = dto.RegistryNumber;
      return entity;
    }
  }
}