using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenOsp.Api.Enums;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

  public interface IService<T> where T : class {

    void Create(T entity);

    Task CreateAsync(T entity);

    void Delete(T entity);

    Task DeleteAsync(T entity);

    Task<IEnumerable<T>> ReadAll();

    void Update(T entity);

    Task UpdateAsync(T entity);

    Task CommitDbTransaction(int rows, DbTransactionType type);

    Task CommitDbTransaction(DbTransactionType type);

    Task CommitDbTransaction();

  }

}