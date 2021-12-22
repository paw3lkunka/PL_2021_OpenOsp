using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos; 

public class EquipmentReadDto {
  [OspDA.Required] public int Id { get; set; }

  [OspDA.Required]
  [OspDA.MaxLength(24)]
  [OspDA.Name]
  public string Brand { get; set; }

  [OspDA.Required]
  [OspDA.MaxLength(24)]
  [OspDA.Name]
  public string Model { get; set; }

  [Display(Name = "Registry number")]
  [OspDA.Required]
  [OspDA.RegistryNumber]
  public string RegistryNumber { get; set; }
}