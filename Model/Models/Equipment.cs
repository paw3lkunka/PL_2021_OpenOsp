using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {

  public class Equipment : IHasId<int>, IOwnedBy<int> {

    [Key]
    [Required]
    public int Id { get; set; }

    [Required, MaxLength(24), Name]
    public string Brand { get; set; }

    [Required, MaxLength(24), Name]
    public string Model { get; set; }

    [Display(Name ="Registry number"), Column(TypeName = "varchar(16)")]
    [Required, MaxLength(16), RegistryNumber]
    public string RegistryNumber { get; set; }

    [Display(Name = "Owner's id"), Column("OwnerId")]
    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionEquipment> Actions { get; set; }

  }

}