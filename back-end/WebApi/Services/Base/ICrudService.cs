using System;
using System.Collections.Generic;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {
  public interface ICrudService<T> where T : class {
    void Create(T entity);
    void Delete(T entity);
    IEnumerable<T> ReadAll();
    void Update(T entity);
    bool SaveChanges();
  }
}