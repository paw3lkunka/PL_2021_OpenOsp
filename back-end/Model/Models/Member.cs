using System.Collections.Generic;

namespace OpenOsp.Model.Models {
  public class Member {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; } 
    public int UserId { get; set; }

    public virtual User User { get; set; }
    public virtual List<ActionMember> Actions { get; set; }
  }
}