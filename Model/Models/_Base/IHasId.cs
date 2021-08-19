using System;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Models {

  public interface IHasId<T>
    where T : IEquatable<T>, IComparable<T> {

    T Id { get; set; }

  }

  public interface IHasId<T1, T2>
    where T1 : IEquatable<T1>, IComparable<T1>
    where T2 : IEquatable<T2>, IComparable<T2> {

    T1 Id1 { get; set; }

    T2 Id2 { get; set; }

  }

  public interface IHasId<T1, T2, T3> : IHasId<T1, T2>
    where T1 : IEquatable<T1>, IComparable<T1>
    where T2 : IEquatable<T2>, IComparable<T2>
    where T3 : IEquatable<T3>, IComparable<T3> {

    T3 Id3 { get; set; }

  }

}