using System.Linq;
using System.Threading.Tasks;

using OpenOsp.Model.Filters;

namespace OpenOsp.Server.Api.Repositories; 

public interface IRepository<T> {
  void Create(T entity);

  void Delete(T entity);

  void Update(T entity);

  IQueryable<T> ReadAll();

  IQueryable<T> ReadAll(PaginationFilter pagination);

  Task<int> SaveChangesAsync();
}