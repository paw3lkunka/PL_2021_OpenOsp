using System;
using System.Collections.Generic;
using System.Linq;

using OpenOsp.Model.Models;
using OpenOsp.Server.Exceptions;

namespace OpenOsp.Server.Api.Services; 

public class EntitiesAuthService<T, TUserId> : IEntitiesAuthService<T>
  where T : class, IOwnedBy<TUserId>
  where TUserId : IEquatable<TUserId>, IComparable<TUserId>, IConvertible {
  private readonly IUserClaimsService<TUserId> _claims;

  public EntitiesAuthService(IUserClaimsService<TUserId> claims) {
    _claims = claims;
  }

  public virtual bool IsAuthorized(T entity) {
    return entity.UserId.Equals(_claims.UserId);
  }

  public virtual T ReadAuthorized(T entity) {
    return IsAuthorized(entity) ? entity : throw new UnauthorizedException();
  }

  public virtual IEnumerable<T> ReadAuthorized(IEnumerable<T> entities) {
    var ownedEntities = entities.Where(IsAuthorized);
    if (ownedEntities.Count() == 0 && entities.Count() != 0) {
      throw new UnauthorizedException();
    }

    return ownedEntities;
  }
}