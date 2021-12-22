using SystemDA = System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public class MaxLengthAttribute : System.ComponentModel.DataAnnotations.MaxLengthAttribute {
  public MaxLengthAttribute(int maxLength) : base(maxLength) {
    ErrorMessage = @"{0} can consist of up to {1} characters";
  }
}