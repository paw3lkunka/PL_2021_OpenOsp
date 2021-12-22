using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace OpenOsp.Client.Components.Forms; 

public class BaseForm<T> : InputBase<T> {
  protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
  {
    if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out T parsedValue))
    {
      result = parsedValue;
      validationErrorMessage = null;
      return true;
    }
    if (string.IsNullOrEmpty(value))
    {
      var nullableType = Nullable.GetUnderlyingType(typeof(T));
      if (nullableType != null)
      {
        result = default;
        validationErrorMessage = null;
        return true;
      }
    }
    result = default;
    validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";
    return false;
  }

  private string GetDisplayName(object value)
  {
    var member = value.GetType().GetMember(value.ToString())[0];
    var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
    if (displayAttribute != null) {
      return displayAttribute.GetName();
    }
    return value.ToString().Humanize();
  }
}