using System;
using System.Collections.Generic;
using System.Linq;
using OpenOsp.Server.Data.Contexts;
using OpenOsp.Server.Enums;
using OpenOsp.Server.Exceptions;
using OpenOsp.Model.Filters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using OpenOsp.Server.Api.Repositories.Implementations;

namespace OpenOsp.Server.Api.Services {

  public class Service<T> : IService<T>
    where T : class {

    public Service(Repository<T> repo) {
      _repo = repo;
    }

    protected readonly Repository<T> _repo;

    public async Task Create(T entity) {
      _repo.Create(entity);
      await CommitDbTransaction(DbTransactionType.Create);
    }

    public async Task Update(T entity) {
      _repo.Update(entity);
      await CommitDbTransaction(DbTransactionType.Update);
    }

    public async Task Delete(T entity) {
      _repo.Delete(entity);
      await CommitDbTransaction(DbTransactionType.Delete);
    }

    public virtual async Task<IEnumerable<T>> ReadAll() => await _repo.ReadAll().ToListAsync();

    public virtual async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) => await _repo.ReadAll(pagination).ToListAsync();
    
    public virtual async Task<int> ReadCount() => await ReadAll().CountAsync();

    public async Task CommitDbTransaction(int rows, DbTransactionType type) {
      if (await _context.SaveChangesAsync() < 0) {
        throw new DbTransactionException<T>(type, rows);
      }
    }

    public async Task CommitDbTransaction(DbTransactionType type) => await CommitDbTransaction(1, type);

    public async Task CommitDbTransaction() => await CommitDbTransaction(DbTransactionType.None);

  }

}