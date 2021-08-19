using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class MemberReadDto {

    public int Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(15)]
    public string LastName { get; set; }

    [Required]
    [MinLength(11), MaxLength(11)]
    public string Pesel { get; set; }

  }

}