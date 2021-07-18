using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.WebApi.Services;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.WebApi.Exceptions;

namespace OpenOsp.WebApi.Controllers {
  [Route("[controller]")]
  public class ControllerWithKey<T, TCreateDto, TReadDto, TUpdateDto, TKey> : Controller<T, TCreateDto, TReadDto, TUpdateDto> 
    where T : class, IHasKey<TKey>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class 
    where TKey : IEquatable<TKey>, IComparable<TKey> {
    protected new readonly IServiceWithKey<T, TKey> _service;
    
    public ControllerWithKey(IServiceWithKey<T, TKey> service, IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper) 
      : base(service, mapper) {
      _service = service;
    }

    [HttpGet("{key}")]
    public ActionResult<TReadDto> ReadByKey(TKey key) {
      try {
        var entity = _service.ReadByKey(key);
        return base.Read(entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{key}")]
    public ActionResult Update(TKey key, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key);
        return base.Update(updateDto, entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key}")]
    public ActionResult Patch(TKey key, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key);
        return base.Patch(patchDoc, entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key}")]
    public ActionResult Delete(TKey key) {
      try {
        var entity = _service.ReadByKey(key);
        return base.Delete(entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }

  [Route("[controller]")]
  public class ControllerWithKey<T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2> : Controller<T, TCreateDto, TReadDto, TUpdateDto> 
    where T : class, IHasKey<TKey1, TKey2>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class 
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {
    protected new readonly IServiceWithKey<T, TKey1, TKey2> _service;
    
    public ControllerWithKey(IServiceWithKey<T, TKey1, TKey2> service, IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper) 
      : base(service, mapper) {
      _service = service;
    }

    [HttpGet("{key1}/{key2}")]
    public ActionResult<TReadDto> ReadByKey(TKey1 key1, TKey2 key2) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.Read(entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{key1}/{key2}")]
    public ActionResult Update(TKey1 key1, TKey2 key2, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.Update(updateDto, entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key1}/{key2}")]
    public ActionResult Patch(TKey1 key1, TKey2 key2, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.Patch(patchDoc, entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key1}/{key2}")]
    public ActionResult Delete(TKey1 key1, TKey2 key2) {
      try {
        var entity = _service.ReadByKey(key1, key2);
        return base.Delete(entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }

  [Route("[controller]")]
  public class ControllerWithKey<T, TCreateDto, TReadDto, TUpdateDto, TKey1, TKey2, TKey3> : Controller<T, TCreateDto, TReadDto, TUpdateDto> 
    where T : class, IHasKey<TKey1, TKey2, TKey3>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class 
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {
    protected new readonly IServiceWithKey<T, TKey1, TKey2, TKey3> _service;
    
    public ControllerWithKey(IServiceWithKey<T, TKey1, TKey2, TKey3> service, IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper) 
      : base(service, mapper) {
      _service = service;
    }

    [HttpGet("{key1}/{key2}/{key3}")]
    public ActionResult<TReadDto> ReadByKey(TKey1 key1, TKey2 key2, TKey3 key3) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.Read(entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPut("{key1}/{key2}/{key3}")]
    public ActionResult Update(TKey1 key1, TKey2 key2, TKey3 key3, TUpdateDto updateDto) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.Update(updateDto, entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPatch("{key1}/{key2}/{key3}")]
    public ActionResult Patch(TKey1 key1, TKey2 key2, TKey3 key3, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.Patch(patchDoc, entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpDelete("{key1}/{key2}/{key3}")]
    public ActionResult Delete(TKey1 key1, TKey2 key2, TKey3 key3) {
      try {
        var entity = _service.ReadByKey(key1, key2, key3);
        return base.Delete(entity);
      }
      catch(NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}