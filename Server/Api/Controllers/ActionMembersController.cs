using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;

namespace OpenOsp.Server.Api.Controllers {
  [NonController]
  public class ActionMembersController
    : AuthorizedController<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto, int, int> {
    public ActionMembersController(
      IHasIdService<ActionMember, int, int> service,
      IDtoMapper<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto> mapper)
      : base(service, mapper) {
    }
  }
}