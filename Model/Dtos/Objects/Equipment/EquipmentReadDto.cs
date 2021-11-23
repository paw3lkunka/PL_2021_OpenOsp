using System.ComponentModel.DataAnnotations;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class EquipmentReadDto {
    [OspDA.RequiredAttribute] public int Id { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string Brand { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string Model { get; set; }

    [Display(Name = "Registry number")]
    [OspDA.RequiredAttribute]
    [OspDA.RegistryNumberAttribute]
    public string RegistryNumber { get; set; }
  }
}