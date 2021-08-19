using Microsoft.AspNetCore.Authorization;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;
using OpenOsp.Server.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace OpenOsp.Server.Api.Controllers {

  [ApiController]
  public class MembersController
    : AuthController<Member, MemberCreateDto, MemberReadDto, MemberUpdateDto, int> {

    public MembersController(
      IHasIdService<Member, int> service,
      IDtoMapper<Member, MemberCreateDto, MemberReadDto, MemberUpdateDto> mapper
    ) : base(service, mapper) {
    }

  }

}