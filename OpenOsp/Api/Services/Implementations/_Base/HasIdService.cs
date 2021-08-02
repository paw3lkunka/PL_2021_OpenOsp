using System;
using System.Linq;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;
using OpenOsp.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace OpenOsp.Api.Services {

  public class HasIdService<T, TId> 
    : Service<T>, IHasIdService<T, TId>
    where T : class, IHasId<TId>
    where TId : IEquatable<TId>, IComparable<TId> {

    public HasIdService(AppDbContext context) : base(context) {
    }

    public virtual T ReadById(TId id) {
      var entity = _context.Set<T>()
        .IgnoreQueryFilters()
        .FirstOrDefault(e => e.Id.Equals(id));
      if (entity == default(T)) {
        throw new NotFoundException();
      }
      return entity;
    }

  }

  public class HasIdService<T, TId1, TId2> 
    : Service<T>, IHasIdService<T, TId1, TId2>
    where T : class, IHasId<TId1, TId2>
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2> {

    public HasIdService(AppDbContext context) : base(context) {
    }

    public virtual T ReadById(TId1 id1, TId2 id2) {
      var entity = _context.Set<T>()
        .IgnoreQueryFilters()
        .FirstOrDefault(e =>
          e.Id1.Equals(id1)
          && e.Id2.Equals(id2)
        );
      if (entity == default(T)) {
        throw new NotFoundException();
      }
      return entity;
    }

  }

  public class HasIdService<T, TId1, TId2, TId3> 
    : Service<T>, IHasIdService<T, TId1, TId2, TId3>
    where T : class, IHasId<TId1, TId2, TId3> 
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {

    public HasIdService(AppDbContext context) : base(context) {
    }

    public virtual T ReadById(TId1 id1, TId2 id2, TId3 id3) {
      var entity = _context.Set<T>()
        .IgnoreQueryFilters()
        .FirstOrDefault(e =>
          e.Id1.Equals(id1)
          && e.Id2.Equals(id2)
          && e.Id3.Equals(id3)
        );
      if (entity == default(T)) {
        throw new NotFoundException();
      }
      return entity;
    }

  }

}