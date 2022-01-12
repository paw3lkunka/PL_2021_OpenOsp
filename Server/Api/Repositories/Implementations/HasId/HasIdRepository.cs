using System;
using System.Linq;

using OpenOsp.Model.Filters;
using OpenOsp.Model.Models;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Api.Repositories; 

public class HasIdRepository<T, TId>
  : Repository<T>, IHasIdRepository<T, TId>
  where T : class, IHasId<TId>
  where TId : IEquatable<TId>, IComparable<TId> {
  public HasIdRepository(AppDbContext context) : base(context) {
  }

  public virtual IQueryable<T> ReadById(TId id) {
    return ReadAll().Where(e => e.Id.Equals(id));
  }
}

public class HasIdRepository<T, TId, TId2>
  : HasIdRepository<T, TId>, IHasIdRepository<T, TId, TId2>
  where T : class, IHasId<TId, TId2>
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2> {
  public HasIdRepository(AppDbContext context) : base(context) {
  }

  public IQueryable<T> ReadById(TId id, PaginationFilter pagination) {
    return ReadById(id).Skip((pagination.PageIndex - 1) * pagination.PageSize)
      .Take(pagination.PageSize);
  }

  public IQueryable<T> ReadById(TId id, TId2 id2) {
    return ReadById(id).Where(e => e.Id2.Equals(id2));
  }
}

public class HasIdRepository<T, TId, TId2, TId3>
  : HasIdRepository<T, TId, TId2>, IHasIdRepository<T, TId, TId2, TId3>
  where T : class, IHasId<TId, TId2, TId3>
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2>
  where TId3 : IEquatable<TId3>, IComparable<TId3> {
  public HasIdRepository(AppDbContext context) : base(context) {
  }

  public IQueryable<T> ReadById(TId id, TId2 id2, PaginationFilter pagination) {
    return ReadById(id, id2).Skip((pagination.PageIndex - 1) * pagination.PageSize)
      .Take(pagination.PageSize);
  }

  public IQueryable<T> ReadById(TId id, TId2 id2, TId3 id3) {
    return ReadById(id, id2).Where(e => e.Id3.Equals(id3));
  }
}