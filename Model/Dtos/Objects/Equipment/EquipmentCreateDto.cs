using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.DataAnnotations;
using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {

  public class EquipmentCreateDto {

    [OspDA.Required, OspDA.MaxLength(24), Name]
    public string Brand { get; set; }

    [OspDA.Required, OspDA.MaxLength(24), Name]
    public string Model { get; set; }

    [Display(Name ="Registry number")]
    [OspDA.Required, RegistryNumber]
    public string RegistryNumber { get; set; }

  }

}