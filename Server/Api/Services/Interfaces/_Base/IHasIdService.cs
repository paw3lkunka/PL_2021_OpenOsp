using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using OpenOsp.Model.Filters;
using OpenOsp.Model.Models;

namespace OpenOsp.Server.Api.Services; 

public interface IHasIdService<T, TId> : IService<T>
  where T : class, IHasId<TId>
  where TId : IEquatable<TId>, IComparable<TId> {
  Task<T> ReadById(TId id);
}

public interface IHasIdService<T, TId, TId2> : IService<T>
  where T : class, IHasId<TId, TId2>
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2> {
  Task<IEnumerable<T>> ReadById(TId id);

  Task<IEnumerable<T>> ReadById(TId id, PaginationFilter pagination);

  Task<T> ReadById(TId id, TId2 id2);

  Task<int> ReadCount(TId id);
}

public interface IHasIdService<T, TId, TId2, TId3> : IService<T>
  where T : class, IHasId<TId, TId2, TId3>
  where TId : IEquatable<TId>, IComparable<TId>
  where TId2 : IEquatable<TId2>, IComparable<TId2>
  where TId3 : IEquatable<TId3>, IComparable<TId3> {
  Task<IEnumerable<T>> ReadById(TId id);

  Task<IEnumerable<T>> ReadById(TId id, PaginationFilter pagination);

  Task<IEnumerable<T>> ReadById(TId id, TId2 id2);

  Task<IEnumerable<T>> ReadById(TId id, TId2 id2, PaginationFilter pagination);

  Task<T> ReadById(TId id, TId2 id2, TId3 id3);

  Task<int> ReadCount(TId id);

  Task<int> ReadCount(TId id, TId2 id2);
}