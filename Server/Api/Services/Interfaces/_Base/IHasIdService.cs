using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenOsp.Model.Models;

namespace OpenOsp.Server.Api.Services {

  public interface IHasIdService<T, TId> : IService<T>
    where T : class, IHasId<TId>
    where TId : IEquatable<TId>, IComparable<TId> {

    Task<T> ReadById(TId id);

  }

  public interface IHasIdService<T, TId1, TId2> : IService<T>
    where T : class, IHasId<TId1, TId2>
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2> {

    Task<IEnumerable<T>> ReadById(TId1 id1);

    Task<T> ReadById(TId1 id1, TId2 id2);

  }

  public interface IHasIdService<T, TId1, TId2, TId3> : IService<T>
    where T : class, IHasId<TId1, TId2, TId3>
    where TId1 : IEquatable<TId1>, IComparable<TId1>
    where TId2 : IEquatable<TId2>, IComparable<TId2>
    where TId3 : IEquatable<TId3>, IComparable<TId3> {

    Task<IEnumerable<T>> ReadById(TId1 id1);

    Task<IEnumerable<T>> ReadById(TId1 id1, TId2 id2);

    Task<T> ReadById(TId1 id1, TId2 id2, TId3 id3);

  }

}