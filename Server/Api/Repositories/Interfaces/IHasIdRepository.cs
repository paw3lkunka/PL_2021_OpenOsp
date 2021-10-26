using System;
using System.Linq;
using System.Threading.Tasks;
using OpenOsp.Model.Filters;
using OpenOsp.Model.Models;

namespace OpenOsp.Server.Api.Repositories {
  
  public interface IHasIdRepository<T, TId> : IRepository<T>
    where T : class, IHasId<TId>
    where TId : IEquatable<TId>, IComparable<TId> {

    IQueryable<T> ReadById(TId id);

  }

  public interface IHasIdRepository<T, TId1, TId2> : IHasIdRepository<T, TId1>
    where T : class, IHasId<TId1, TId2>
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2> {

    IQueryable<T> ReadById(TId1 id1, PaginationFilter pagination);

    IQueryable<T> ReadById(TId1 id1, TId2 id2);

  }

  public interface IHasIdRepository<T, TId1, TId2, TId3> : IHasIdRepository<T, TId1, TId2>
    where T : class, IHasId<TId1, TId2, TId3>
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {

    IQueryable<T> ReadById(TId1 id1, TId2 id2, PaginationFilter pagination);

    IQueryable<T> ReadById(TId1 id1, TId2 id2, TId3 id3);

  }
  
}