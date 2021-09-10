using System;
using System.Text.RegularExpressions;
using SystemDA = System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {

  public class RequiredAttribute : SystemDA.RequiredAttribute {

    public RequiredAttribute() : base() {
      ErrorMessage = @"{0} is required";
    }

  }

}