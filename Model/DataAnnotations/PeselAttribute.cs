using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public class PeselAttribute : RegularExpressionAttribute {
  public PeselAttribute()
    : base(@"^\d{11}$") {
    ErrorMessage = "{0} must consist of exactly 11 digits";
  }
}