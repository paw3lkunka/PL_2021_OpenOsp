using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenOsp.Server.Exceptions;
using OpenOsp.Server.Data.Contexts;
using OpenOsp.Model.Models;

namespace OpenOsp.Server.Api.Services {

  public class ActionsService
    : HasIdService<Action, int>, IActionsService {

    public ActionsService(AppDbContext context) : base(context) {
    }

    public async Task<Action> ReadExpanded(int id) {
      try {
        var entity = await _context.Actions
          .Include(e => e.Members)
          .Include(e => e.Equipment)
          .FirstOrDefaultAsync(e => e.Id.Equals(id));
        if (entity == default(Action)) {
          throw new UnauthorizedException();
        }
        return entity;
      }
      catch (UnauthorizedException) {
        await base.ReadById(id);
        throw;
      }
    }

  }

}