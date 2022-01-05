using System;
using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public sealed class DateGreaterEqualAttribute : ValidationAttribute {
  private const string _defaultErrorMessage = "{0} must be later or equal {1}";

  private readonly string _basePropertyName;

  public DateGreaterEqualAttribute(string basePropertyName)
    : base(_defaultErrorMessage) {
    _basePropertyName = basePropertyName;
  }

  public override string FormatErrorMessage(string name) {
    return string.Format(_defaultErrorMessage, name, _basePropertyName);
  }

  protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
    var basePropertyInfo = validationContext.ObjectType.GetProperty(_basePropertyName);
    var startDate = (DateTime)basePropertyInfo.GetValue(validationContext.ObjectInstance, null);
    var thisDate = (DateTime)value;
    if (thisDate < startDate) {
      var message = FormatErrorMessage(validationContext.DisplayName);
      return new ValidationResult(message);
    }

    return null;
  }
}