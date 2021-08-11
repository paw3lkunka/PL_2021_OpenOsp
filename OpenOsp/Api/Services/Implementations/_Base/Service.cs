using System;
using System.Collections.Generic;
using System.Linq;
using OpenOsp.Data.Contexts;
using OpenOsp.Api.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OpenOsp.Api.Services {

  public class Service<T> : IService<T>
    where T : class {

    public Service(AppDbContext context) {
      _context = context;
    }

    protected readonly AppDbContext _context;

    public void Create(T entity) => _context.Add<T>(entity);

    public void Delete(T entity) => _context.Remove<T>(entity);

    public virtual async Task<IEnumerable<T>> ReadAll() {
      return await _context.Set<T>()
        .IgnoreQueryFilters()
        .ToListAsync();
    }

    public async Task SaveChanges() {
      if (await _context.SaveChangesAsync() < 0) {
        throw new DatabaseTransactionFailureException();
      }
    }

    public void Update(T entity) => _context.Update<T>(entity);

  }

}