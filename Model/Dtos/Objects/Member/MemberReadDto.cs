using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class MemberReadDto {

    [Required]
    public int Id { get; set; }

    [Required, MaxLength(24), Name]
    public string FirstName { get; set; }

    [Required, MaxLength(24), Name]
    public string LastName { get; set; }

    [Display(Name = "PESEL")]
    [Required, Pesel]
    public string Pesel { get; set; }

  }

}