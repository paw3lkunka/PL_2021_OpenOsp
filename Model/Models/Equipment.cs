using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {
  public class Equipment : IHasId<int>, IOwnedBy<int> {
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string Brand { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(24)]
    [OspDA.NameAttribute]
    public string Model { get; set; }

    [Display(Name = "Registry number")]
    [Column(TypeName = "varchar(16)")]
    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(16)]
    [OspDA.RegistryNumberAttribute]
    public string RegistryNumber { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionEquipment> Actions { get; set; }

    [Key] [OspDA.RequiredAttribute] public int Id { get; set; }

    [Display(Name = "Owner's id")]
    [Column("OwnerId")]
    [OspDA.RequiredAttribute]
    public int UserId { get; set; }
  }
}