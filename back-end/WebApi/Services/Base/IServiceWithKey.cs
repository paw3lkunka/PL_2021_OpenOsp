using System;
using OpenOsp.Model.Models;

namespace OpenOsp.WebApi.Services {
  public interface IServiceWithKey<T, TKey> : IService<T>
    where T : class, IHasKey<TKey>
    where TKey : IEquatable<TKey>, IComparable<TKey> {
    T ReadByKey(TKey key);
  }

  public interface IServiceWithKey<T, TKey1, TKey2> : IService<T>
    where T : class, IHasKey<TKey1, TKey2>
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2> {
    T ReadByKey(TKey1 key1, TKey2 key2);
  }

  public interface IServiceWithKey<T, TKey1, TKey2, TKey3> : IService<T>
    where T : class, IHasKey<TKey1, TKey2, TKey3>
    where TKey1 : IEquatable<TKey1>, IComparable<TKey1>
    where TKey2 : IEquatable<TKey2>, IComparable<TKey2>
    where TKey3 : IEquatable<TKey3>, IComparable<TKey3> {
    T ReadByKey(TKey1 key1, TKey2 key2, TKey3 key3);
  }
}