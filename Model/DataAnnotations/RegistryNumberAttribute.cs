using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public class RegistryNumberAttribute : RegularExpressionAttribute {
  public RegistryNumberAttribute()
    : base(@"^[a-zA-Z0-9.\-_\/]{1,16}$") {
    ErrorMessage = @"{0} must consist of up to 16 alphanumeric and '.', '-', '_', '/', '\' signs";
  }
}