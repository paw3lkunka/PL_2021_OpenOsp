using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Filters;
using OpenOsp.Server.Api.Repositories;
using OpenOsp.Server.Enums;
using OpenOsp.Server.Exceptions;

namespace OpenOsp.Server.Api.Services; 

public class Service<T> : IService<T>
  where T : class {
  private readonly IRepository<T> _repo;

  public Service(IRepository<T> repo) {
    _repo = repo;
  }

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

  public virtual async Task<IEnumerable<T>> ReadAll() {
    return await _repo.ReadAll().ToListAsync();
  }

  public virtual async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) {
    return await _repo.ReadAll(pagination).ToListAsync();
  }

  public virtual async Task<int> ReadCount() {
    return await _repo.ReadAll().CountAsync();
  }

  public async Task CommitDbTransaction(int rows, DbTransactionType type) {
    if (await _repo.SaveChangesAsync() < 0) {
      throw new DbTransactionException<T>(type, rows);
    }
  }

  public async Task CommitDbTransaction(DbTransactionType type) {
    await CommitDbTransaction(1, type);
  }

  public async Task CommitDbTransaction() {
    await CommitDbTransaction(DbTransactionType.None);
  }
}