using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Filters;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Repositories;
using OpenOsp.Server.Exceptions;

namespace OpenOsp.Server.Api.Services; 

public class HasIdService<T, TId> : Service<T>, IHasIdService<T, TId>
  where T : class, IHasId<TId>
  where TId : IEquatable<TId>, IComparable<TId>, IConvertible {
  private readonly IHasIdRepository<T, TId> _repo;

  public HasIdService(IHasIdRepository<T, TId> repo) : base(repo) {
    _repo = repo;
  }

  public virtual async Task<T> ReadById(TId id) {
    var entity = await _repo.ReadById(id).FirstOrDefaultAsync();
    if (entity == default(T)) {
      throw new NotFoundException<T, TId>(id);
    }

    return entity;
  }
}

public class HasIdService<T, TId, TId2> : Service<T>, IHasIdService<T, TId, TId2>
  where T : class, IHasId<TId, TId2>
  where TId : IEquatable<TId>, IComparable<TId>, IConvertible
  where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible {
  private readonly IHasIdRepository<T, TId, TId2> _repo;

  public HasIdService(IHasIdRepository<T, TId, TId2> repo) : base(repo) {
    _repo = repo;
  }

  public virtual async Task<IEnumerable<T>> ReadById(TId id) {
    var entities = await _repo.ReadById(id).ToListAsync();
    if (entities?.Any() != true) {
      throw new NotFoundException<T, TId>(id, true);
    }

    return entities;
  }

  public virtual async Task<IEnumerable<T>> ReadById(TId id, PaginationFilter pagination) {
    return await _repo.ReadById(id, pagination).ToListAsync();
  }

  public virtual async Task<T> ReadById(TId id, TId2 id2) {
    var entity = await _repo.ReadById(id, id2).FirstOrDefaultAsync();
    if (entity == default(T)) {
      throw new NotFoundException<T, TId, TId2>(id, id2);
    }

    return entity;
  }

  public virtual async Task<int> ReadCount(TId id) {
    return await _repo.ReadById(id).CountAsync();
  }
}

public class HasIdService<T, TId, TId2, TId3> : Service<T>, IHasIdService<T, TId, TId2, TId3>
  where T : class, IHasId<TId, TId2, TId3>
  where TId : IEquatable<TId>, IComparable<TId>, IConvertible
  where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible
  where TId3 : IEquatable<TId3>, IComparable<TId3>, IConvertible {
  private readonly IHasIdRepository<T, TId, TId2, TId3> _repo;

  public HasIdService(IHasIdRepository<T, TId, TId2, TId3> repo) : base(repo) {
    _repo = repo;
  }

  public virtual async Task<IEnumerable<T>> ReadById(TId id) {
    var entities = await _repo.ReadById(id).ToListAsync();
    if (entities?.Any() != true) {
      throw new NotFoundException<T, TId>(id, true);
    }

    return entities;
  }

  public virtual async Task<IEnumerable<T>> ReadById(TId id, PaginationFilter pagination) {
    return await _repo.ReadById(id, pagination).ToListAsync();
  }


  public virtual async Task<IEnumerable<T>> ReadById(TId id, TId2 id2) {
    var entities = await _repo.ReadById(id, id2).ToListAsync();
    if (entities?.Any() != true) {
      throw new NotFoundException<T, TId, TId2>(id, id2, true);
    }

    return entities;
  }

  public virtual async Task<IEnumerable<T>> ReadById(TId id, TId2 id2, PaginationFilter pagination) {
    return await _repo.ReadById(id, id2, pagination).ToListAsync();
  }

  public virtual async Task<T> ReadById(TId id, TId2 id2, TId3 id3) {
    var entity = await _repo.ReadById(id, id2, id3).FirstOrDefaultAsync();
    if (entity == default(T)) {
      throw new NotFoundException<T>();
    }

    return entity;
  }

  public virtual async Task<int> ReadCount(TId id) {
    return await _repo.ReadById(id).CountAsync();
  }

  public virtual async Task<int> ReadCount(TId id, TId2 id2) {
    return await _repo.ReadById(id, id2).CountAsync();
  }
}