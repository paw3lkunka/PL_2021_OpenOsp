using System;

namespace OpenOsp.Api.Exceptions {

  public class NotFoundException : Exception {

    public NotFoundException() : base() {
    }

    public NotFoundException(string message) : base(message) {
    }

  }

  public class NotFoundException<T> : NotFoundException
    where T : class {
    
    public NotFoundException()
      : base($"{typeof(T).Name} could not be found.") {
    }

  }

  public class NotFoundException<T, TId> : NotFoundException
    where T : class
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {
    
    public NotFoundException(TId id)
      : base($"{typeof(T).Name} identified by {(string) Convert.ChangeType(id, typeof(string))} could not be found") {
    }

  }

  public class NotFoundException<T, TId1, TId2> : NotFoundException
    where T : class
    where TId1 : IEquatable<TId1>, IComparable<TId1>, IConvertible
    where TId2 : IEquatable<TId2>, IComparable<TId2>, IConvertible {
    
    public NotFoundException(TId1 id1, TId2 id2)
      : base($"{typeof(T).Name} identified by {(string) Convert.ChangeType(id1, typeof(string))}"
        + $" and {(string) Convert.ChangeType(id1, typeof(string))} could not be found"
      ) {
    }

  }

}