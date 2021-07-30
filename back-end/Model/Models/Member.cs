using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class Member : IHasKey<int>, IOwnedBy<int> {

    [Key]
    [Column("id")]
    public int Key { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Pesel { get; set; }

    [Required(ErrorMessage = "Action's owner id is required")]
    public int UserKey { get; set; }

    public virtual User User { get; set; }

    public virtual List<ActionMember> Actions { get; set; }

  }

}