using System;
using System.Collections.Generic;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {

  public interface IAuthService<T, TUserKey> : IService<T>
    where T : class, IHasKey<TKey>, IOwnedBy<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible {
    
    IEnumerable<T> AuthReadForUser(TUserKey userKey);

  }

}