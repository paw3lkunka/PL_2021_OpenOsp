using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {
  public class Equipment : IHasKey<int> {
    [Key]
    [Column("id")]
    public int Key { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string RegistryNumber { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual List<ActionEquipment> Actions { get; set; }
  }
}