using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class MemberCreateDto {
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(15)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(15)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "PESEL is required")]
    [MinLength(11), MaxLength(11)]
    public string PESEL { get; set; }
  }
}