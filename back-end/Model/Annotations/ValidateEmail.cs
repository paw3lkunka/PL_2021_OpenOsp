using System;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Annotations {

  public class ValidateEmail : ValidationAttribute {

    public ValidateEmail(params object[] validValues) {
      ValidValues = validValues;
    }

    object[] ValidValues;

    public override bool IsValid(object value) {
      try {
        value = new MailAddress((string)value).Address;
        return true;
      }
      catch (FormatException) {
        ErrorMessage = "Email address format is invalid";
        return false;
      }
    }

  }

}