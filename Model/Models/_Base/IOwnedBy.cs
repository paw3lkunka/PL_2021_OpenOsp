using System;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {
  public interface IOwnedBy<TUserId>
    where TUserId : IEquatable<TUserId>, IComparable<TUserId> {
    [OspDA.RequiredAttribute] public TUserId UserId { get; set; }
  }
}