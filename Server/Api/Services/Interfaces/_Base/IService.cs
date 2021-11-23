using System.Collections.Generic;
using System.Threading.Tasks;

using OpenOsp.Model.Filters;
using OpenOsp.Server.Enums;

namespace OpenOsp.Server.Api.Services {
  public interface IService<T> where T : class {
    Task Create(T entity);

    Task Delete(T entity);

    Task Update(T entity);

    Task<IEnumerable<T>> ReadAll();

    Task<IEnumerable<T>> ReadAll(PaginationFilter pagination);

    Task<int> ReadCount();

    Task CommitDbTransaction(int rows, DbTransactionType type);

    Task CommitDbTransaction(DbTransactionType type);

    Task CommitDbTransaction();
  }
}