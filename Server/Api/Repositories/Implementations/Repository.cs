using System.Linq;

using OpenOsp.Model.Filters;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Api.Repositories {
  
  public class Repository<T> : IRepository<T> 
    where T : class {

    public Repository(AppDbContext context) {
      _context = context;
    }

    private readonly AppDbContext _context;
    
    public void Create(T entity) => _context.Add<T>(entity);

    public void Update(T entity) => _context.Update<T>(entity);

    public void Delete(T entity) => _context.Remove<T>(entity);

    public virtual IQueryable<T> ReadAll() => _context.Set<T>();

    public virtual IQueryable<T> ReadAll(PaginationFilter pagination) => ReadAll()
      .Skip((pagination.PageIndex - 1) * pagination.PageSize)
      .Take(pagination.PageSize);
    
  }
  
}