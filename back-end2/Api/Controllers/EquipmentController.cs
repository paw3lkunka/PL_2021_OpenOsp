using Microsoft.AspNetCore.Authorization;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;
using OpenOsp.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace OpenOsp.Api.Controllers {

  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class EquipmentController
    : AuthController<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto, int> {

    public EquipmentController(
      IHasIdService<Equipment, int> service,
      IDtoMapper<Equipment, EquipmentCreateDto, EquipmentReadDto, EquipmentUpdateDto> mapper)
      : base(service, mapper) {
    }

  }

}