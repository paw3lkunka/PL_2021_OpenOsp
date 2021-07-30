using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

using OpenOsp.WebApi.Services;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.WebApi.Exceptions;

namespace OpenOsp.WebApi.Controllers {

  [Route("[controller]")]
  public abstract class Controller<T, TCreateDto, TReadDto, TUpdateDto> : ControllerBase
    where T : class
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class {

    public Controller(
      IService<T> service, 
      IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> mapper) {
      _service = service;
      _mapper = mapper;
    }

    protected readonly IService<T> _service;

    protected readonly IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> _mapper;

    [HttpGet]
    public virtual ActionResult<IEnumerable<TReadDto>> ReadAll() {
      try {
        var entities = _service.ReadAll();
        var dtos = entities.Select(e => _mapper.MapRead(e)).ToList();
        return Ok(dtos);
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost]
    public virtual ActionResult<TReadDto> Create(TCreateDto createDto) {
      try {
        var entity = CreateEntity(createDto);
        var readDto = _mapper.MapRead(entity);
        return CreatedAtRoute(null, readDto);
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

    protected T CreateEntity(T entity) {
      _service.Create(entity);
      _service.SaveChanges();
      return entity;
    }

    protected virtual T CreateEntity(TCreateDto createDto) {
      if (!TryValidateModel(createDto)) {
        throw new ValidationProblemException();
      }
      var entity = _mapper.MapCreate(createDto);
      return CreateEntity(entity);
    }

    protected virtual ActionResult<T> ReadEntity(T entity) {
      var readDto = _mapper.MapRead(entity);
      return Ok(readDto);
    }

    protected virtual ActionResult UpdateEntity(TUpdateDto updateDto, T entity) {
      try {
        if (!TryValidateModel(updateDto)) {
          throw new ValidationProblemException();
        }
        _mapper.MapUpdate(updateDto, entity);
        _service.Update(entity);
        _service.SaveChanges();
        return NoContent();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DatabaseTransactionFailureException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
    }

    protected virtual ActionResult PatchEntity(JsonPatchDocument<TUpdateDto> patchDoc, T entity) {
      try {
        var entityToPatch = _mapper.MapPatch(entity);
        patchDoc.ApplyTo(entityToPatch);
        if (!TryValidateModel(entityToPatch)) {
          throw new ValidationProblemException();
        }
        _mapper.MapUpdate(entityToPatch, entity);
        _service.Update(entity);
        _service.SaveChanges();
        return NoContent();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DatabaseTransactionFailureException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
    }

    protected virtual ActionResult DeleteEntity(T entity) {
      try {
        _service.Delete(entity);
        _service.SaveChanges();
        return NoContent();
      }
      catch (DatabaseTransactionFailureException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
    }

  }

}