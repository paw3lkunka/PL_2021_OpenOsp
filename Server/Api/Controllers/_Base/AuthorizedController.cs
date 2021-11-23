using System;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;

namespace OpenOsp.Server.Api.Controllers {
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AuthorizedController<T, TCreateDto, TReadDto, TUpdateDto, TId>
    : HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId>
    where T : class, IHasId<TId>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId : IEquatable<TId>, IComparable<TId> {
    public AuthorizedController(
      IHasIdService<T, TId> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
    }
  }

  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AuthorizedController<T, TCreateDto, TReadDto, TUpdateDto, TId, TId2>
    : HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId, TId2>
    where T : class, IHasId<TId, TId2>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId : IEquatable<TId>, IComparable<TId>
    where TId2 : IEquatable<TId2>, IComparable<TId2> {
    public AuthorizedController(
      IHasIdService<T, TId, TId2> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
    }
  }

  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class AuthorizedController<T, TCreateDto, TReadDto, TUpdateDto, TId, TId2, TId3>
    : HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId, TId2, TId3>
    where T : class, IHasId<TId, TId2, TId3>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId : IEquatable<TId>, IComparable<TId>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {
    public AuthorizedController(
      IHasIdService<T, TId, TId2, TId3> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
    }
  }
}