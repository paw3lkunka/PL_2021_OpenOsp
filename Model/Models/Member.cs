using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Models {

  public class Member : IHasId<int>, IOwnedBy<int> {

    [Key]
    [Required]
    public int Id { get; set; }

    [Required, MaxLength(24), Name]
    public string FirstName { get; set; }

    [Required, MaxLength(24), Name]
    public string LastName { get; set; }

    [Display(Name = "PESEL"), Column(TypeName = "char(11)")]
    [Required, MaxLength(11), Pesel]
    public string Pesel { get; set; }

    [Display(Name = "Member owner's id"), Column("OwnerId")]
    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual IEnumerable<ActionMember> Actions { get; set; }

  }

}