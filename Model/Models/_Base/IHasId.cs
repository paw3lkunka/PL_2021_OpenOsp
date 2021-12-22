using System;

namespace OpenOsp.Model.Models; 

public interface IHasId<T>
  where T : IEquatable<T>, IComparable<T> {
  T Id { get; set; }
}

public interface IHasId<T, T2> : IHasId<T>
  where T : IEquatable<T>, IComparable<T>
  where T2 : IEquatable<T2>, IComparable<T2> {
  T2 Id2 { get; set; }
}

public interface IHasId<T, T2, T3> : IHasId<T, T2>
  where T : IEquatable<T>, IComparable<T>
  where T2 : IEquatable<T2>, IComparable<T2>
  where T3 : IEquatable<T3>, IComparable<T3> {
  T3 Id3 { get; set; }
}