using System;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Models {

  public interface IOwnedBy<TUserKey>
    where TUserKey : IEquatable<TUserKey>, IComparable<TUserKey> {

    [Required]
    public TUserKey UserKey { get; set; }

  }
}