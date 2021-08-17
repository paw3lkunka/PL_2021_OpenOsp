using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.Api.Services;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Api.Exceptions;
using System.Threading.Tasks;

namespace OpenOsp.Api.Controllers {

  public class HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId>
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class, IHasId<TId>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId : IEquatable<TId>, IComparable<TId> {

    public HasIdController(
      IHasIdService<T, TId> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) : base(service, mapper) {
      _service = service;
    }

    protected new readonly IHasIdService<T, TId> _service;

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
        return CreatedAtRoute(nameof(ReadById), new { id = entity.Id }, readDto);
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

  public class HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId1, TId2>
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class, IHasId<TId1, TId2>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2> {

    public HasIdController(
      IHasIdService<T, TId1, TId2> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) : base(service, mapper) {
      _service = service;
    }

    protected new readonly IHasIdService<T, TId1, TId2> _service;

    [HttpGet("{id1}/{id2}")]
    public virtual async Task<ActionResult<TReadDto>> ReadById(TId1 id1, TId2 id2) {
      try {
        var entity = await _service.ReadById(id1, id2);
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
        return CreatedAtRoute(nameof(ReadById),
          new { id1 = entity.Id1, id2 = entity.Id2 },
          readDto
        );
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

    [HttpPut("{id1}/{id2}")]
    public virtual async Task<ActionResult> Update(TId1 id1, TId2 id2, TUpdateDto updateDto) {
      try {
        var entity = await _service.ReadById(id1, id2);
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

    [HttpPatch("{id1}/{id2}")]
    public virtual async Task<ActionResult> Patch(TId1 id1, TId2 id2, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = await _service.ReadById(id1, id2);
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

    [HttpDelete("{id1}/{id2}")]
    public virtual async Task<ActionResult> Delete(TId1 id1, TId2 id2) {
      try {
        var entity = await _service.ReadById(id1, id2);
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

  public class HasIdController<T, TCreateDto, TReadDto, TUpdateDto, TId1, TId2, TId3>
    : Controller<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class, IHasId<TId1, TId2, TId3>
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {

    public HasIdController(
      IHasIdService<T, TId1, TId2, TId3> service,
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper
    ) : base(service, mapper) {
      _service = service;
    }

    protected new readonly IHasIdService<T, TId1, TId2, TId3> _service;

    [HttpGet("{id1}/{id2}/{id3}")]
    public virtual async Task<ActionResult<TReadDto>> ReadById(TId1 id1, TId2 id2, TId3 id3) {
      try {
        var entity = await _service.ReadById(id1, id2, id3);
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
        return CreatedAtRoute(
          nameof(ReadById),
          new { id1 = entity.Id1, id2 = entity.Id2, id3 = entity.Id3 },
          readDto
        );
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

    [HttpPut("{id1}/{id2}/{id3}")]
    public virtual async Task<ActionResult> Update(TId1 id1, TId2 id2, TId3 id3, TUpdateDto updateDto) {
      try {
        var entity = await _service.ReadById(id1, id2, id3);
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

    [HttpPatch("{id1}/{id2}/{id3}")]
    public virtual async Task<ActionResult> Patch(TId1 id1, TId2 id2, TId3 id3, JsonPatchDocument<TUpdateDto> patchDoc) {
      try {
        var entity = await _service.ReadById(id1, id2, id3);
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

    [HttpDelete("{id1}/{id2}/{id3}")]
    public virtual async Task<ActionResult> Delete(TId1 id1, TId2 id2, TId3 id3) {
      try {
        var entity = await _service.ReadById(id1, id2, id3);
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

}