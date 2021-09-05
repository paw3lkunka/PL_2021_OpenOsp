using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class UsernameAttribute : RegularExpressionAttribute {

    public UsernameAttribute() 
      : base(@"^[a-z0-9_-]{3,15}$") {
    }

    public override bool IsValid(object value) {
      var isValid = base.IsValid(value);
      if(!isValid) {
        ErrorMessage = @"The {0} field must consist of 3 up to 15 alphanumeric and '-', '_' signs";
      }
      return isValid;
    }

  }

}