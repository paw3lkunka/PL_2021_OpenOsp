using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Annotations {
  public class ValidatePassword : ValidationAttribute {
    object[] ValidValues;

    public ValidatePassword(params object[] validValues) {
      ValidValues = validValues;
    }

    public override bool IsValid(object value) {
      string password = (string)value;

      if (password.Length < 12) {
        ErrorMessage = "Password must be at least 12 characters long";
        return false;
      }

      // Regex upperCase = new Regex(@"[A-Z]");
      // Regex lowerCase = new Regex(@"[a-z]");
      // Regex numbers = new Regex(@"[\d]");
      // Regex specSym = new Regex(@"[@$!%*?&]");

      // if (!((Convert.ToInt32(upperCase.IsMatch(password)) +
      //     Convert.ToInt32(lowerCase.IsMatch(password)) +
      //     Convert.ToInt32(numbers.IsMatch(password)) +
      //     Convert.ToInt32(specSym.IsMatch(password))) >= 2)) {
      //   ErrorMessage = "Password should satisfy at least two of the following rules: one lowercase letter, one upper case letter, one number, one special character (!, @, #, $, %, &)";
      //   return false;
      // }

      return true;
    }
  }
}