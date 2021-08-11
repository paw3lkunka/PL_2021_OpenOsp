using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenOsp.Api.Exceptions;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

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