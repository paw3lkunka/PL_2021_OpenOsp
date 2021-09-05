using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class PasswordAttribute : RegularExpressionAttribute {

    public PasswordAttribute() 
      : base(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-_]).{12,}$") {
    }

    public override bool IsValid(object value) {
      var isValid = base.IsValid(value);
      if(!isValid) {
        ErrorMessage = @"The {0} field must be at least 12 characters long. Forbidden characters: '/' and '\'";
      }
      return isValid;
    }

  }

}