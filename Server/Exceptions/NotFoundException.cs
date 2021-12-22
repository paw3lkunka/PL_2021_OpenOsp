using System;

namespace OpenOsp.Server.Exceptions; 

public class NotFoundException : Exception {
  public NotFoundException() {
  }

  public NotFoundException(string message) : base(message) {
  }
}

public class NotFoundException<T> : NotFoundException
  where T : class {
  public NotFoundException(bool multiple)
    : base($"{typeof(T).Name}{(multiple ? " entities" : string.Empty)} could not be found.") {
  }

  public NotFoundException()
    : this(false) {
  }
}

public class NotFoundException<T, TId> : NotFoundException
  where T : class
  where TId : IEquatable<TId>, IComparable<TId>, IConvertible {
  public NotFoundException(TId id, bool multiple)
    : base(
      $"{typeof(T).Name}{(multiple ? " entities" : string.Empty)} identified by {(string)Convert.ChangeType(id, typeof(string))} could not be found") {
  }

  public NotFoundException(TId id)
    : this(id, false) {
  }
}

public class NotFoundException<T, TId, TId2> : NotFoundException
  where T : class
  where TId : IEquatable<TId>, IComparable<TId>, IConvertible
  where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible {
  public NotFoundException(TId id1, TId2 id2, bool multiple)
    : base(
      $"{typeof(T).Name}{(multiple ? " entities" : string.Empty)} identified by {(string)Convert.ChangeType(id1, typeof(string))}"
      + $" and {(string)Convert.ChangeType(id1, typeof(string))} could not be found") {
  }

  public NotFoundException(TId id1, TId2 id2)
    : this(id1, id2, false) {
  }
}