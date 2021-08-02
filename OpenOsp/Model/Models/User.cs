using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OpenOsp.Model.Models {

  public class User : IdentityUser<int> {

    public virtual List<Member> Members { get; set; }

    public virtual List<Equipment> Equipment { get; set; }

    public virtual List<Action> Actions { get; set; }

  }

}