using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.WebApi.Exceptions;
using OpenOsp.WebApi.Services;

namespace OpenOsp.WebApi.Controllers {

  [Route("[controller]")]
  public class AuthController<TUserKey, T, TCreateDto, TReadDto, TUpdateDto> 
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where T : class, IOwnedBy<TUserKey>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class {

    public AuthController(
      IService<T> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public override ActionResult<IEnumerable<TReadDto>> ReadAll() {
      try {
        return base.ReadAll();
      }
      catch(UnauthorizedException ex) {
        return Unauthorized(ex.Message);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public override ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(null, readDto);
      }
      catch(UnauthorizedException ex) {
        return Unauthorized(ex.Message);
      }
      catch(ValidationProblemException ex) {
        return ValidationProblem();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    // protected TUserKey GetTokenUid() {
    //   if(ClaimsIdentity == default(ClaimsIdentity)) {
    //       throw new UnauthorizedException("No identity provided for a request.");
    //   }
    //   var uid = ClaimsIdentity.FindFirst("Uid");
    //   if(uid == default(Claim)) {
    //     throw new UnauthorizedException("Provided identity is missing Uid claim.");
    //   }
    //   try {
    //     return (TUserKey)Convert.ChangeType(uid.Value, typeof(TUserKey));
    //   }
    //   catch (InvalidCastException) {
    //     throw new UnauthorizedException("Invalid Uid claim format");
    //   }
    // }

    protected override ActionResult ReadEntity(T entity) {
      try {
        if(entity == default(T)) {
          throw new UnauthorizedException();
        }
        return base.ReadEntity(entity);
      }
      catch(UnauthorizedException) {
        return Unauthorized();
      }
    }

    protected override ActionResult UpdateEntity(TUpdateDto updateDto, T entity) {
      try {
        if(entity == default(T)) {
          throw new UnauthorizedException();
        }
        return base.UpdateEntity(updateDto, entity);
      }
      catch(UnauthorizedException) {
        return Unauthorized();
      }
    }

    protected override ActionResult PatchEntity(JsonPatchDocument<TUpdateDto> patchDoc, T entity) {
      try {
        if(entity == default(T)) {
          throw new UnauthorizedException();
        }
        return base.PatchEntity(patchDoc, entity);
      }
      catch(UnauthorizedException) {
        return Unauthorized();
      }
    }

    protected override ActionResult DeleteEntity(T entity) {
      try {
        if(entity == default(T)) {
          throw new UnauthorizedException();
        }
        return base.DeleteEntity(entity);
      }
      catch(UnauthorizedException) {
        return Unauthorized();
      }
    }

  }

}