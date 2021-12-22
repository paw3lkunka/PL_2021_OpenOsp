using System.Linq;
using System.Threading.Tasks;

using OpenOsp.Model.Filters;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Api.Repositories; 

public class Repository<T> : IRepository<T>
  where T : class {
  private readonly AppDbContext _context;

  public Repository(AppDbContext context) {
    _context = context;
  }

  public void Create(T entity) {
    _context.Add(entity);
  }

  public void Update(T entity) {
    _context.Update(entity);
  }

  public void Delete(T entity) {
    _context.Remove(entity);
  }

  public virtual IQueryable<T> ReadAll() {
    return _context.Set<T>();
  }

  public IQueryable<T> ReadAll(PaginationFilter pagination) {
    return ReadAll().Skip((pagination.PageIndex - 1) * pagination.PageSize)
      .Take(pagination.PageSize);
  }

  public async Task<int> SaveChangesAsync() {
    return await _context.SaveChangesAsync();
  }
}