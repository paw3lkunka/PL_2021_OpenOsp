using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;

namespace OpenOsp.Server.Api.Controllers; 

[NonController]
public class ActionEquipmentController
  : AuthorizedController<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto,
    int,
    int> {
  public ActionEquipmentController(
    IHasIdService<ActionEquipment, int, int> service,
    IDtoMapper<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto> mapper)
    : base(service, mapper) {
  }
}