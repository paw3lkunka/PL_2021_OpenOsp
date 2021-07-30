using System;
using System.Collections.Generic;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {

  public interface IAuthKeyService<T, TUserKey, TKey> 
    : IAuthService<T, TUserKey>, IKeyService<T, TKey>
    where T : class, IHasKey<TKey>, IOwnedBy<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where TKey : IEquatable<TKey>, IComparable<TKey> {
  }

  public interface IAuthKeyService<T, TUserKey, TKey1, TKey2> 
    : IAuthService<T, TUserKey>, IKeyService<T, TKey1, TKey2>
    where T : class, IHasKey<TKey1, TKey2>, IOwnedBy<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {
  }

  public interface IAuthKeyService<TUserKey, T, TKey1, TKey2, TKey3> 
    : IAuthService<T, TUserKey>, IKeyService<T, TKey1, TKey2, TKey3>
    where T : class, IHasKey<TKey1, TKey2, TKey3>, IOwnedBy<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {
  }

}