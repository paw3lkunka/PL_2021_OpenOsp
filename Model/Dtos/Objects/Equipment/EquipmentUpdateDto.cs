using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class EquipmentUpdateDto {

    [Required, MaxLength(24), Name]
    public string Brand { get; set; }

    [Required, MaxLength(24), Name]
    public string Model { get; set; }

    [Display(Name ="Registry number")]
    [Required, RegistryNumber]
    public string RegistryNumber { get; set; }

  }

}