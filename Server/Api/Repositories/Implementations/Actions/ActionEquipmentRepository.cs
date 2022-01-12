using System.Linq;

using Microsoft.EntityFrameworkCore;

using OpenOsp.Model.Models;
using OpenOsp.Server.Data.Contexts;

namespace OpenOsp.Server.Api.Repositories.Actions; 

public class ActionEquipmentRepository : HasIdRepository<ActionEquipment, int, int> {
  public ActionEquipmentRepository(AppDbContext context) : base(context) {
  }

  public override IQueryable<ActionEquipment> ReadById(int id) {
    return base.ReadById(id).Include(e => e.Equipment);
  }
}