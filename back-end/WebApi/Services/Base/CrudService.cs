using System;
using System.Collections.Generic;
using System.Linq;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {
  public abstract class CrudService<T> : ICrudService<T> where T : class{
    private readonly AppDbContext _context;

    public CrudService(AppDbContext context) {
      _context = context;
    }

    public void Create(T entity) {
      if (entity == default(T)) {
        throw new ArgumentException();
      }
      _context.Add<T>(entity);
    }

    public void Delete(T entity) {
      if (entity == default(T)) {
        throw new ArgumentException();
      }
      _context.Remove<T>(entity);
    }

    public IEnumerable<T> ReadAll() {
      return _context.Set<T>().ToList();
    }

    public bool SaveChanges() {
      return _context.SaveChanges() >= 0;
    }

    public void Update(T entity) {
      if (entity == default(T)) {
        throw new ArgumentException();
      }
      _context.Update<T>(entity);
    }
  }
}