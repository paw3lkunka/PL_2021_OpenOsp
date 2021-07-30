using System.ComponentModel.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  
  public class EquipmentUpdateDto {
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(30)]
    public string Brand { get; set; }

    [MaxLength(30)]
    public string Model { get; set; }

    [MaxLength(15)]
    public string ReqistryNumber { get; set; }

  }

}