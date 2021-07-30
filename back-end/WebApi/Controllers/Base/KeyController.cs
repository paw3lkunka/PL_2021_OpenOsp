using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.WebApi.Services;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.WebApi.Exceptions;

namespace OpenOsp.WebApi.Controllers {

  [Route("[controller]")]
  public class KeyController<T, TCreateDto, TReadDto, TUpdateDto, TKey> 
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class, IHasKey<TKey>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TKey : IEquatable<TKey>, IComparable<TKey> {

    public KeyController(
      IKeyService<T, TKey> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
      _service = service;
    }

    protected new readonly IKeyService<T, TKey> _service;

    [HttpGet("{key}")]
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
    public virtual ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = base.CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(nameof(ReadByKey), new { key = entity.Key }, readDto);
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

    [HttpPut("{key}")]
    public virtual ActionResult Update(TKey key, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key);
        return base.UpdateEntity(updateDto, entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key}")]
    public virtual ActionResult Patch(TKey key, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key);
        return base.PatchEntity(patchDoc, entity);
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key}")]
    public virtual ActionResult Delete(TKey key) {
      try {
        var entity = _service.ReadByKey(key);
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
  public class KeyController<T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2> 
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class, IHasKey<TKey1, TKey2>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {

    public KeyController(
      IKeyService<T, TKey1, TKey2> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
      _service = service;
    }

    protected new readonly IKeyService<T, TKey1, TKey2> _service;

    [HttpGet("{key1}/{key2}")]
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
  public class KeyController<T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2, TKey3> 
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class, IHasKey<TKey1, TKey2, TKey3>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {

    public KeyController(
      IKeyService<T, TKey1, TKey2, TKey3> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
      : base(service, mapper) {
      _service = service;
    }

    protected new readonly IKeyService<T, TKey1, TKey2, TKey3> _service;

    [HttpGet("{key1}/{key2}/{key3}")]
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
    public virtual ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = base.CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(
          nameof(ReadByKey), 
          new { key1 = entity.Key1, key2 = entity.Key2, key3 = entity.Key3 }, 
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

    [HttpPut("{key1}/{key2}/{key3}")]
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