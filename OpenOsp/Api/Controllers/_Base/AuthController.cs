using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.Api.Services;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OpenOsp.Api.Controllers {

  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AuthController<T, TCreateDto, TReadDto, TUpdateDto, TId>
    : HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId>
    where T : class, IHasId<TId>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId : IEquatable<TId>, IComparable<TId> {

    public AuthController(
      IHasIdService<T, TId> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) : base(service, mapper) {
    }

  }

  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AuthController<T, TCreateDto, TReadDto, TUpdateDto, TId1, TId2>
    : HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId1, TId2>
    where T : class, IHasId<TId1, TId2>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2> {

    public AuthController(
      IHasIdService<T, TId1, TId2> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) : base(service, mapper) {
    }

  }

  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AuthController<T, TCreateDto, TReadDto, TUpdateDto, TId1, TId2, TId3>
    : HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId1, TId2, TId3>
    where T : class, IHasId<TId1, TId2, TId3>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {

    public AuthController(
      IHasIdService<T, TId1, TId2, TId3> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) : base(service, mapper) {
    }

  }

}