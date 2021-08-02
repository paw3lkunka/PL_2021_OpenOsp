using System;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Models {

  public interface IOwnedBy<TUserId>
    where TUserId : IEquatable<TUserId>, IComparable<TUserId> {

    [Required]
    public TUserId UserId { get; set; }

  }
}