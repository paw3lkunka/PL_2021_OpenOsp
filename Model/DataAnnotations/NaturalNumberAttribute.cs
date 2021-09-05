using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class NaturalNumberAttribute : RangeAttribute {

    public NaturalNumberAttribute() 
      : base(0, int.MaxValue) {
    }

    public override bool IsValid(object value) {
      var isValid = base.IsValid(value);
      if(!isValid) {
        ErrorMessage = "The {0} field value must be greater or equal zero";
      }
      return isValid;
    }

  }

}