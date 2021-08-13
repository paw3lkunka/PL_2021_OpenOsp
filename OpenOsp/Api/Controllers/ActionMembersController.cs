using Microsoft.AspNetCore.Authorization;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;
using OpenOsp.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace OpenOsp.Api.Controllers {

  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ActionMembersController
    : AuthController<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto, int, int> {

    public ActionMembersController(
      IHasIdService<ActionMember, int, int> service,
      IDtoMapper<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto> mapper
    ) : base(service, mapper) {
    }

  }

}