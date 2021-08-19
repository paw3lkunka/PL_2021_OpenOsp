using System;

namespace OpenOsp.Api.Services {

  public interface IUserClaimsService<TId>
    where TId : IEquatable<TId>, IComparable<TId>, IConvertible {

    TId UserId { get; }

  }

}