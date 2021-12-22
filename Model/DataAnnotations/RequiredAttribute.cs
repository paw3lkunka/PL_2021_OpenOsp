using SystemDA = System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations; 

public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute {
  public RequiredAttribute() {
    ErrorMessage = @"{0} is required";
  }
}