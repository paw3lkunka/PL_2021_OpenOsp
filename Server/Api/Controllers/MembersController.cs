using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;

namespace OpenOsp.Server.Api.Controllers; 

[ApiController]
public class MembersController
  : AuthorizedController<Member, MemberCreateDto, MemberReadDto, MemberUpdateDto, int> {
  public MembersController(
    IHasIdService<Member, int> service,
    IDtoMapper<Member, MemberCreateDto, MemberReadDto, MemberUpdateDto> mapper)
    : base(service, mapper) {
  }
}