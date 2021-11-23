using System.Collections.Generic;

namespace OpenOsp.Server.Api.Services {
  public interface IEntitiesAuthService<T> where T : class {
    bool IsAuthorized(T entity);

    T ReadAuthorized(T entity);

    IEnumerable<T> ReadAuthorized(IEnumerable<T> entity);
  }
}