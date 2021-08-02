using System;
using System.Collections.Generic;
using System.Linq;
using OpenOsp.Data.Contexts;
using OpenOsp.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace OpenOsp.Api.Services {

  public class Service<T> : IService<T>
    where T : class {

    public Service(AppDbContext context) {
      _context = context;
    }

    protected readonly AppDbContext _context;

    public void Create(T entity) => _context.Add<T>(entity);

    public void Delete(T entity) => _context.Remove<T>(entity);

    public virtual IEnumerable<T> ReadAll() {
      return _context.Set<T>()
        .IgnoreQueryFilters()
        .ToList();
    }

    public void SaveChanges() {
      if (_context.SaveChanges() < 0) {
        throw new DatabaseTransactionFailureException();
      }
    }

    public void Update(T entity) => _context.Update<T>(entity);

  }

}