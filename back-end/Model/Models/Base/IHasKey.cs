using System;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Models {

  public interface IHasKey<T>
    where T : IEquatable<T>, IComparable<T> {

    T Key { get; set; }

  }

  public interface IHasKey<T1, T2>
    where T1 : IEquatable<T1>, IComparable<T1>
    where T2 : IEquatable<T2>, IComparable<T2> {
      
    T1 Key1 { get; set; }

    T2 Key2 { get; set; }

  }

  public interface IHasKey<T1, T2, T3> : IHasKey<T1, T2>
    where T1 : IEquatable<T1>, IComparable<T1>
    where T2 : IEquatable<T2>, IComparable<T2>
    where T3 : IEquatable<T3>, IComparable<T3> {

    T3 Key3 { get; set; }

  }

}