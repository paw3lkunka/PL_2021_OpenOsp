using System;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Attributes {
  public class ValidateEmail : ValidationAttribute {
    object[] ValidValues;

    public ValidateEmail(params object[] validValues) {
      ValidValues = validValues;
    }

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