using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;
using OpenOsp.Server.Exceptions;

namespace OpenOsp.Server.Api.Controllers; 

public class HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId>
  : Controller<T, TCreateDto, TReadDto, TUpdateDto>
  where T : class, IHasId<TId>
  where TCreateDto : class
  where TReadDto : class
  where TUpdateDto : class
  where TId : IEquatable<TId>, IComparable<TId> {
  protected new readonly IHasIdService<T, TId> _service;

  public HasIdController(
    IHasIdService<T, TId> service,
    IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
    : base(service, mapper) {
    _service = service;
  }

  [HttpGet("{id}")]
  public virtual async Task<ActionResult<TReadDto>> ReadById(TId id) {
    try {
      var entity = await _service.ReadById(id);
      return base.ReadEntity(entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost]
  public override async Task<ActionResult<TReadDto>> Create(TCreateDto createDto) {
    try {
      var entity = await base.CreateEntity(createDto);
      var readDto = _mapper.MapRead(entity);
      return CreatedAtAction(nameof(ReadById), new {id = entity.Id}, readDto);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (ValidationProblemException) {
      return ValidationProblem();
    }
    catch (DbTransactionException) {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut("{id}")]
  public virtual async Task<ActionResult> Update(TId id, TUpdateDto updateDto) {
    try {
      var entity = await _service.ReadById(id);
      return await base.UpdateEntity(updateDto, entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPatch("{id}")]
  public virtual async Task<ActionResult> Patch(TId id, JsonPatchDocument<TUpdateDto> patchDoc) {
    try {
      var entity = await _service.ReadById(id);
      return await base.PatchEntity(patchDoc, entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete("{id}")]
  public virtual async Task<ActionResult> Delete(TId id) {
    try {
      var entity = await _service.ReadById(id);
      return await base.DeleteEntity(entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}

public class HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId, TId2>
  : Controller<T, TCreateDto, TReadDto, TUpdateDto>
  where T : class, IHasId<TId, TId2>
  where TCreateDto : class
  where TReadDto : class
  where TUpdateDto : class
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2> {
  protected new readonly IHasIdService<T, TId, TId2> _service;

  public HasIdController(
    IHasIdService<T, TId, TId2> service,
    IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
    : base(service, mapper) {
    _service = service;
  }

  [HttpGet("{id}")]
  public virtual async Task<ActionResult<IEnumerable<TReadDto>>> ReadById(TId id) {
    try {
      var entities = await _service.ReadById(id);
      return base.ReadEntities(entities);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet("{id}/count")]
  public virtual async Task<ActionResult<int>> ReadCount(TId id) {
    try {
      return await _service.ReadCount(id);
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet("{id}/{id2}")]
  public virtual async Task<ActionResult<TReadDto>> ReadById(TId id, TId2 id2) {
    try {
      var entity = await _service.ReadById(id, id2);
      return base.ReadEntity(entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost("{id}")]
  public virtual async Task<ActionResult<TReadDto>> Create(TId id, TCreateDto createDto) {
    try {
      if (TryValidateModel(createDto) == false) {
        throw new ValidationProblemException();
      }

      var entity = _mapper.MapCreate(createDto);
      entity.Id = id;
      entity = await CreateEntity(entity);
      var readDto = _mapper.MapRead(entity);
      return CreatedAtAction(nameof(ReadById),
        new {id = entity.Id, id2 = entity.Id2},
        readDto);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (ValidationProblemException) {
      return ValidationProblem();
    }
    catch (DbTransactionException) {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut("{id}/{id2}")]
  public virtual async Task<ActionResult> Update(TId id, TId2 id2, TUpdateDto updateDto) {
    try {
      var entity = await _service.ReadById(id, id2);
      return await base.UpdateEntity(updateDto, entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPatch("{id}/{id2}")]
  public virtual async Task<ActionResult> Patch(TId id, TId2 id2, JsonPatchDocument<TUpdateDto> patchDoc) {
    try {
      var entity = await _service.ReadById(id, id2);
      return await base.PatchEntity(patchDoc, entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete("{id}/{id2}")]
  public virtual async Task<ActionResult> Delete(TId id, TId2 id2) {
    try {
      var entity = await _service.ReadById(id, id2);
      return await base.DeleteEntity(entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}

public class HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId, TId2, TId3>
  : Controller<T, TCreateDto, TReadDto, TUpdateDto>
  where T : class, IHasId<TId, TId2, TId3>
  where TCreateDto : class
  where TReadDto : class
  where TUpdateDto : class
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2>
  where TId3 : IEquatable<TId3>, IComparable<TId3> {
  protected new readonly IHasIdService<T, TId, TId2, TId3> _service;

  public HasIdController(
    IHasIdService<T, TId, TId2, TId3> service,
    IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper)
    : base(service, mapper) {
    _service = service;
  }

  [HttpGet("{id}")]
  public virtual async Task<ActionResult<IEnumerable<TReadDto>>> ReadById(TId id) {
    try {
      var entities = await _service.ReadById(id);
      return base.ReadEntities(entities);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet("{id}/{id2}")]
  public virtual async Task<ActionResult<IEnumerable<TReadDto>>> ReadById(TId id, TId2 id2) {
    try {
      var entities = await _service.ReadById(id, id2);
      return base.ReadEntities(entities);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet("{id}/{id2}/count")]
  public virtual async Task<ActionResult<int>> ReadCount(TId id, TId2 id2) {
    try {
      return await _service.ReadCount(id, id2);
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet("{id}/{id2}/{id3}")]
  public virtual async Task<ActionResult<TReadDto>> ReadById(TId id, TId2 id2, TId3 id3) {
    try {
      var entity = await _service.ReadById(id, id2, id3);
      return base.ReadEntity(entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost("{id}/{id2}")]
  public virtual async Task<ActionResult<TReadDto>> Create(TId id, TId2 id2, TCreateDto createDto) {
    try {
      if (TryValidateModel(createDto) == false) {
        throw new ValidationProblemException();
      }

      var entity = _mapper.MapCreate(createDto);
      entity.Id = id;
      entity.Id2 = id2;
      entity = await CreateEntity(entity);
      var readDto = _mapper.MapRead(entity);
      return CreatedAtAction(
        nameof(ReadById),
        new {id = entity.Id, id2 = entity.Id2, id3 = entity.Id3},
        readDto);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (ValidationProblemException) {
      return ValidationProblem();
    }
    catch (DbTransactionException) {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut("{id}/{id2}/{id3}")]
  public virtual async Task<ActionResult> Update(TId id, TId2 id2, TId3 id3, TUpdateDto updateDto) {
    try {
      var entity = await _service.ReadById(id, id2, id3);
      return await base.UpdateEntity(updateDto, entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPatch("{id}/{id2}/{id3}")]
  public virtual async Task<ActionResult>
    Patch(TId id, TId2 id2, TId3 id3, JsonPatchDocument<TUpdateDto> patchDoc) {
    try {
      var entity = await _service.ReadById(id, id2, id3);
      return await base.PatchEntity(patchDoc, entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete("{id}/{id2}/{id3}")]
  public virtual async Task<ActionResult> Delete(TId id, TId2 id2, TId3 id3) {
    try {
      var entity = await _service.ReadById(id, id2, id3);
      return await base.DeleteEntity(entity);
    }
    catch (UnauthorizedException) {
      return Unauthorized();
    }
    catch (NotFoundException) {
      return NotFound();
    }
    catch {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}