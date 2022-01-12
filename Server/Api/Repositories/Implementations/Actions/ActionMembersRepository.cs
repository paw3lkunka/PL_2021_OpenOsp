using System.Linq;

using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Api.Repositories.Actions; 

public class ActionMembersRepository : HasIdRepository<ActionMember, int, int> {
  public ActionMembersRepository(AppDbContext context) : base(context)
  {
  }

  public override IQueryable<ActionMember> ReadById(int id) {
    return base.ReadById(id).Include(e => e.Member);
  }
}