using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class Member : IHasId<int>, IOwnedBy<int> {

    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }

    [MaxLength(25), Display(Name = "PESEL")]
    public string LastName { get; set; }

    [MinLength(11), MaxLength(11), Display(Name = "PESEL")]
    public string Pesel { get; set; }

    [Required, Display(Name = "Member owner's id")]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual List<ActionMember> Actions { get; set; }

  }

}