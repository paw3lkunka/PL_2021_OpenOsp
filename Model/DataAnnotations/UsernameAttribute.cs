using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public class UsernameAttribute : RegularExpressionAttribute {
  public UsernameAttribute()
    : base(@"^[a-zA-Z0-9_-]{3,16}$") {
    ErrorMessage = @"{0} must consist of at least 3 and up to 16 alphanumeric or '-', '_' signs";
  }
}