using System;
using System.Collections.Generic;
using System.Linq;
using OpenOsp.Server.Data.Contexts;
using OpenOsp.Server.Enums;
using OpenOsp.Server.Exceptions;
using OpenOsp.Model.Filters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OpenOsp.Server.Api.Services {

  public class Service<T> : IService<T>
    where T : class {

    public Service(AppDbContext context) {
      _context = context;
    }

    protected readonly AppDbContext _context;

    public void Create(T entity) => _context.Add<T>(entity);

    public async Task CreateAsync(T entity) {
      Create(entity);
      await CommitDbTransaction(DbTransactionType.Create);
    }

    public void Update(T entity) => _context.Update<T>(entity);

    public async Task UpdateAsync(T entity) {
      Update(entity);
      await CommitDbTransaction(DbTransactionType.Update);
    }

    public void Delete(T entity) => _context.Remove<T>(entity);

    public async Task DeleteAsync(T entity) {
      Delete(entity);
      await CommitDbTransaction(DbTransactionType.Delete);
    }

    public virtual async Task<IEnumerable<T>> ReadAll() {
      return await _context.Set<T>()
        .IgnoreQueryFilters()
        .ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) {
      return await _context.Set<T>()
        .IgnoreQueryFilters()
        .Skip((pagination.PageIndex - 1) * pagination.PageSize)
        .Take(pagination.PageSize)
        .ToListAsync();
    }
    
    public virtual async Task<int> ReadCount() => await _context.Set<T>().IgnoreQueryFilters().CountAsync();

    public async Task CommitDbTransaction(int rows, DbTransactionType type) {
      if (await _context.SaveChangesAsync() < 0) {
        throw new DbTransactionException<T>(type, rows);
      }
    }

    public async Task CommitDbTransaction(DbTransactionType type) => await CommitDbTransaction(1, type);

    public async Task CommitDbTransaction() => await CommitDbTransaction(DbTransactionType.None);

  }

}