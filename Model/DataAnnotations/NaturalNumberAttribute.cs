using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class NaturalNumberAttribute : RangeAttribute {

    public NaturalNumberAttribute() 
      : base(0, int.MaxValue) {
      ErrorMessage = "{0} value must be greater or equal zero";
    }

  }

}