using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class RegistryNumberAttribute : RegularExpressionAttribute {

    public RegistryNumberAttribute() 
      : base(@"^[a-zA-Z0-9.-_/\]{1,15}$") {
    }

    public override bool IsValid(object value) {
      var isValid = base.IsValid(value);
      if(!isValid) {
        ErrorMessage = @"The {0} field must consist of up to 15 alphanumeric and '.', '-', '_', '/', '\' signs";
      }
      return isValid;
    }

  }

}