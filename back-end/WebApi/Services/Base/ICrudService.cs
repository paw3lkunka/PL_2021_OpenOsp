using System;
using System.Collections.Generic;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {
  public interface ICrudService<T> where T : DbModel {
    void Create(T entity);
    void Delete(T entity);
    IEnumerable<T> ReadAll();
    T ReadById(int id);
    void Update(T entity);
    bool SaveChanges();
  }
}