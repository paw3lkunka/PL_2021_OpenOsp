using SystemDA = System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {
  public class RequiredAttribute : SystemDA.RequiredAttribute {
    public RequiredAttribute() {
      ErrorMessage = @"{0} is required";
    }
  }
}