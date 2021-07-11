using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenOsp.Model.Models;
using OpenOsp.WebApi.Services;

namespace OpenOsp.WebApi.Controllers {
  public abstract class CrudController<T> : ControllerBase where T : class {
    private readonly CrudService<T> _service;

    public CrudController(CrudService<T> service) {
      _service = service;
    }

    public ActionResult<IEnumerable<TReadDto>> GetAll<TReadDto>() {
      return null;
    }

    public ActionResult<TReadDto> Post<TCreateDto, TReadDto>(TCreateDto createDto) {
      return null;
    }

    public ActionResult<TReadDto> Put<TUpdateDto, TReadDto>() {
      return null;
    }

    public ActionResult<TReadDto> Patch<TUpdateDto, TReadDto>() {
      return null;
    }
    
    public ActionResult Delete(int id) {
      return null;
    }
  }
}