using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public class NameAttribute : RegularExpressionAttribute {
  public NameAttribute()
    : base(
      @"^[\p{L} \.\-]+$") {
    ErrorMessage = @"{0} is not a valid name";
  }
}