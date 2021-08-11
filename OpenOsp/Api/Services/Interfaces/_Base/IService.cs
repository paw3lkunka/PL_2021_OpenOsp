using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

  public interface IService<T> where T : class {

    void Create(T entity);

    void Delete(T entity);

    Task<IEnumerable<T>> ReadAll();

    void Update(T entity);

    Task SaveChanges();

  }

}