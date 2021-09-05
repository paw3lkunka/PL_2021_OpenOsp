using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace OpenOsp.Model.Models {

  public class User : IdentityUser<int> {

    public virtual IEnumerable<Member> Members { get; set; }

    public virtual IEnumerable<Equipment> Equipment { get; set; }

    public virtual IEnumerable<Action> Actions { get; set; }

  }

}