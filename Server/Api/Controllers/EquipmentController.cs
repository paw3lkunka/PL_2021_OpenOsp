using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;

namespace OpenOsp.Server.Api.Controllers {
  [ApiController]
  public class EquipmentController
    : AuthorizedController<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto, int> {
    public EquipmentController(
      IHasIdService<Equipment, int> service,
      IDtoMapper<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto> mapper)
      : base(service, mapper) {
    }
  }
}