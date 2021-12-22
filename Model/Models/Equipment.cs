using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models; 

public class Equipment : IHasId<int>, IOwnedBy<int> {
  [OspDA.Required]
  [OspDA.MaxLength(24)]
  [OspDA.Name]
  public string Brand { get; set; }

  [OspDA.Required]
  [OspDA.MaxLength(24)]
  [OspDA.Name]
  public string Model { get; set; }

  [Display(Name = "Registry number")]
  [Column(TypeName = "varchar(16)")]
  [OspDA.Required]
  [OspDA.MaxLength(16)]
  [OspDA.RegistryNumber]
  public string RegistryNumber { get; set; }

  public virtual User User { get; set; }

  public virtual IEnumerable<ActionEquipment> Actions { get; set; }

  [Key] [OspDA.Required] public int Id { get; set; }

  [Display(Name = "Owner's id")]
  [Column("OwnerId")]
  [OspDA.Required]
  public int UserId { get; set; }
}