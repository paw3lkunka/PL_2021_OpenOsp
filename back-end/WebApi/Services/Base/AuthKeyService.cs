using System;
using System.Collections.Generic;
using System.Linq;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {

  public class AuthKeyService<T, TUserKey, TKey>
    : KeyService<T, TKey>, IAuthKeyService<T, TUserKey, TKey>
    where T : class, IHasKey<TKey>, IOwnedBy<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where TKey : IEquatable<TKey>, IComparable<TKey> {

    public AuthKeyService(AppDbContext context) : base(context) {
    }

    public override T ReadByKey(TKey key) {
      try {
        return base.ReadByKey(key);
      }
      catch(NotFoundException) {
        var entity = _context.Set<T>()
          .IgnoreQueryFilters()
          .Any(e => e.Key.Equals(key));
        if(entity == default(T)) {
          throw;
        }
        throw new UnauthorizedException();
      }
    }

  }

  public class AuthKeyService<TUserKey, T, TKey1, TKey2> 
    : KeyService<T, TKey1, TKey2>, IAuthKeyService<TUserKey, T, TKey1, TKey2>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where T : class, IHasKey<TKey1, TKey2>, IOwnedBy<TUserKey>
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {

    public AuthKeyService(AppDbContext context) : base(context) {
    }

    public override T ReadByKey(TKey1 key1, TKey2 key2) {
      try {
        return base.ReadByKey(key1, key2);
      }
      catch(NotFoundException) {
        var entity = _context.Set<T>()
          .IgnoreQueryFilters()
          .Any(e =>
            e.Key1.Equals(key1)
            && e.Key2.Equals(key2)
          );
        if(entity == default(T)) {
          throw;
        }
        throw new UnauthorizedException();
      }
    }

  }

  public class AuthKeyService<TUserKey, T, TKey1, TKey2, TKey3> 
    : KeyService<T, TKey1, TKey2, TKey3>, IAuthKeyService<TUserKey, T, TKey1, TKey2, TKey3>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey>, IConvertible
    where T : class, IHasKey<TKey1, TKey2, TKey3>, IOwnedBy<TUserKey>
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {

    public AuthKeyService(AppDbContext context) : base(context) {
    }

    public override T ReadByKey(TKey1 key1, TKey2 key2, TKey3 key3) {
      try {
        return base.ReadByKey(key1, key2, key3);
      }
      catch(NotFoundException) {
        var entity = _context.Set<T>()
          .IgnoreQueryFilters()
          .Any(e =>
            e.Key1.Equals(key1)
            && e.Key2.Equals(key2)
            && e.Key3.Equals(key3)
          );
        if(entity == default(T)) {
          throw;
        }
        throw new UnauthorizedException();
      }
    }
    
  }

}