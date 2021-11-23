using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.DataAnnotations {
  public class NameAttribute : RegularExpressionAttribute {
    public NameAttribute()
      : base(
        @"/^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u") {
      ErrorMessage = @"{0} is not a valid name";
    }
  }
}