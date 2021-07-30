using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.WebApi.Services;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OpenOsp.WebApi.Exceptions;

namespace OpenOsp.WebApi.Controllers {

  [Route("[controller]")]
  public class AuthKeyController<TUserKey, T, TCreateDto, TReadDto, TUpdateDto, TKey>
    : AuthController<TUserKey, T, TCreateDto, TReadDto, TUpdateDto>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where T : class, IHasKey<TKey>, IOwnedBy<TUserKey>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TKey : IEquatable<TKey>, IComparable<TKey> {

    public AuthKeyController(
      IAuthKeyService<TUserKey, T, TKey> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
      _service = service;
    }

    protected readonly IAuthKeyService<TUserKey, T,TKey> _service;

    [HttpGet("{key}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult<TReadDto> ReadByKey(TKey key) {
      try {
        var entity = _service.ReadByKey(key);
        return base.ReadEntity(entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = base.CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(nameof(ReadByKey), new { key = entity.Key }, readDto);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{key}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Update(TKey key, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key);
        return base.UpdateEntity(updateDto, entity);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Patch(TKey key, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key);
        return base.PatchEntity(patchDoc, entity);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Delete(TKey key) {
      try {
        var entity = _service.ReadByKey(key);
        return base.DeleteEntity(entity);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

  }

  [Route("[controller]")]
  public class AuthKeyController<T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2, TUserKey>
    : AuthController<TUserKey, T, TCreateDto, TReadDto, TUpdateDto>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where T : class, IHasKey<TKey1, TKey2>, IOwnedBy<TUserKey>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {

    public AuthKeyController(
      IAuthKeyService<TUserKey, T, TKey1, TKey2> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
      _service = service;
    }

    protected readonly IAuthKeyService<TUserKey, T, TKey1, TKey2> _service;

    [HttpGet("{key1}/{key2}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult<TReadDto> ReadByKey(TKey1 key1, TKey2 key2) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.ReadEntity(entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = base.CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(nameof(ReadByKey), 
          new { key1 = entity.Key1, key2 = entity.Key2 }, 
          readDto
        );
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DatabaseTransactionFailureException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{key1}/{key2}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Update(TKey1 key1, TKey2 key2, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.UpdateEntity(updateDto, entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key1}/{key2}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Patch(TKey1 key1, TKey2 key2, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.PatchEntity(patchDoc, entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key1}/{key2}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Delete(TKey1 key1, TKey2 key2) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.DeleteEntity(entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

  }

  [Route("[controller]")]
  public class AuthKeyController<TUserKey, T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2, TKey3>
    : KeyController<T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2, TKey3>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible 
    where T : class, IHasKey<TKey1, TKey2, TKey3>, IOwnedBy<TUserKey>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {

    public AuthKeyController(
      IAuthKeyService<TUserKey, T, TKey1, TKey2, TKey3> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
      _service = service;
    }

    protected readonly IAuthKeyService<TUserKey, T, TKey1, TKey2, TKey3> _service;

    [HttpGet("{key1}/{key2}/{key3}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult<TReadDto> ReadByKey(TKey1 key1, TKey2 key2, TKey3 key3) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.ReadEntity(entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = base.CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(nameof(ReadByKey), 
          new { key1 = entity.Key1, key2 = entity.Key2, key3 = entity.Key3 }, 
          readDto);
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DatabaseTransactionFailureException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{key1}/{key2}/{key3}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Update(TKey1 key1, TKey2 key2, TKey3 key3, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.UpdateEntity(updateDto, entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key1}/{key2}/{key3}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Patch(TKey1 key1, TKey2 key2, TKey3 key3, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.PatchEntity(patchDoc, entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key1}/{key2}/{key3}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public virtual ActionResult Delete(TKey1 key1, TKey2 key2, TKey3 key3) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.DeleteEntity(entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

  }

}