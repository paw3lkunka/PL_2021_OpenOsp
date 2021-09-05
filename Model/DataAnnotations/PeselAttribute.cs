using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class PeselAttribute : RegularExpressionAttribute {

    public PeselAttribute() 
      : base(@"^\d{11}$") {
    }

    public override bool IsValid(object value) {
      var isValid = base.IsValid(value);
      if(!isValid) {
        ErrorMessage = "The {0} field must consist of exactly 11 digits";
      }
      return isValid;
    }

  }

}