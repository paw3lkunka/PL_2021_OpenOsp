using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using OpenOsp.Model.Filters;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Repositories;

namespace OpenOsp.Server.Api.Services {
  public class AuthorizedService<T, TUserId> : Service<T>
    where T : class, IOwnedBy<TUserId>
    where TUserId : IEquatable<TUserId>, IComparable<TUserId>, IConvertible {
    private readonly IEntitiesAuthService<T> _entitiesAuth;

    public AuthorizedService(IRepository<T> repo, IEntitiesAuthService<T> entitiesAuth) : base(repo) {
      _entitiesAuth = entitiesAuth;
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll());
    }

    public override async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll(pagination));
    }
  }

  public class AuthorizedService<T, TUserId, TId> : HasIdService<T, TId>
    where T : class, IHasId<TId>
    where TUserId : IEquatable<TUserId>, IComparable<TUserId>, IConvertible
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {
    private readonly IEntitiesAuthService<T> _entitiesAuth;

    public AuthorizedService(IHasIdRepository<T, TId> repo, IEntitiesAuthService<T> entitiesAuth) : base(repo) {
      _entitiesAuth = entitiesAuth;
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll());
    }

    public override async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll(pagination));
    }

    public override async Task<T> ReadById(TId id) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id));
    }
  }

  public class AuthorizedService<T, TUserId, TId, TId2> : HasIdService<T, TId, TId2>
    where T : class, IHasId<TId, TId2>
    where TUserId : IEquatable<TUserId>, IComparable<TUserId>, IConvertible
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible
    where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible {
    private readonly IEntitiesAuthService<T> _entitiesAuth;

    public AuthorizedService(IHasIdRepository<T, TId, TId2> repo, IEntitiesAuthService<T> entitiesAuth) : base(repo) {
      _entitiesAuth = entitiesAuth;
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll());
    }

    public override async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll(pagination));
    }

    public override async Task<IEnumerable<T>> ReadById(TId id) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id));
    }

    public override async Task<IEnumerable<T>> ReadById(TId id, PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id, pagination));
    }

    public override async Task<T> ReadById(TId id, TId2 id2) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id, id2));
    }
  }

  public class AuthorizedService<T, TUserId, TId, TId2, TId3> : HasIdService<T, TId, TId2, TId3>
    where T : class, IHasId<TId, TId2, TId3>
    where TUserId : IEquatable<TUserId>, IComparable<TUserId>, IConvertible
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible
    where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible
    where TId3 : IEquatable<TId3>, IComparable<TId3>, IConvertible {
    private readonly IEntitiesAuthService<T> _entitiesAuth;

    public AuthorizedService(IHasIdRepository<T, TId, TId2, TId3> repo, IEntitiesAuthService<T> entitiesAuth) :
      base(repo) {
      _entitiesAuth = entitiesAuth;
    }

    public override async Task<IEnumerable<T>> ReadAll() {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll());
    }

    public override async Task<IEnumerable<T>> ReadAll(PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadAll(pagination));
    }

    public override async Task<IEnumerable<T>> ReadById(TId id) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id));
    }

    public override async Task<IEnumerable<T>> ReadById(TId id, PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id, pagination));
    }

    public override async Task<IEnumerable<T>> ReadById(TId id, TId2 id2) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id, id2));
    }

    public override async Task<IEnumerable<T>> ReadById(TId id, TId2 id2, PaginationFilter pagination) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id, id2, pagination));
    }

    public override async Task<T> ReadById(TId id, TId2 id2, TId3 id3) {
      return _entitiesAuth.ReadAuthorized(await base.ReadById(id, id2, id3));
    }
  }
}