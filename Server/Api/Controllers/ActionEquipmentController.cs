using Microsoft.AspNetCore.Authorization;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;
using OpenOsp.Server.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace OpenOsp.Server.Api.Controllers {

  [NonController]
  public class ActionEquipmentController
    : AuthController<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto, int, int> {

    public ActionEquipmentController(
      IHasIdService<ActionEquipment, int, int> service,
      IDtoMapper<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto> mapper)
      : base(service, mapper) {
    }

  }

}