using System;
using System.Linq;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;
using OpenOsp.WebApi.Exceptions;

namespace OpenOsp.WebApi.Services {

  public class KeyService<T, TKey> : Service<T>, IKeyService<T, TKey>
    where T : class, IHasKey<TKey>
    where TKey : IEquatable<TKey>, IComparable<TKey> {

    public KeyService(AppDbContext context) : base(context) {
    }

    public virtual T ReadByKey(TKey key) {
      var entity = _context.Set<T>()
        .FirstOrDefault(e => e.Key.Equals(key));
      if (entity == default(T)) {
        throw new NotFoundException();
      }
      return entity;
    }

  }

  public class KeyService<T, TKey1, TKey2> : Service<T>, IService<T>
    where T : class, IHasKey<TKey1, TKey2>
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {

    public KeyService(AppDbContext context) : base(context) {
    }

    public virtual T ReadByKey(TKey1 key1, TKey2 key2) {
      var entity = _context.Set<T>()
        .FirstOrDefault(e =>
          e.Key1.Equals(key1)
          && e.Key2.Equals(key2)
        );
      if (entity == default(T)) {
        throw new NotFoundException();
      }
      return entity;
    }

  }

  public class KeyService<T, TKey1, TKey2, TKey3> : Service<T>, IService<T>
    where T : class, IHasKey<TKey1, TKey2, TKey3>
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {

    public KeyService(AppDbContext context) : base(context) {
    }

    public virtual T ReadByKey(TKey1 key1, TKey2 key2, TKey3 key3) {
      var entity = _context.Set<T>()
        .FirstOrDefault(e =>
          e.Key1.Equals(key1)
          && e.Key2.Equals(key2)
          && e.Key3.Equals(key3)
        );
      if (entity == default(T)) {
        throw new NotFoundException();
      }
      return entity;
    }

  }

}