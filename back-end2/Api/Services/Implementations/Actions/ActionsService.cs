using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenOsp.Api.Exceptions;
using OpenOsp.Data.Contexts;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

  public class ActionsService
    : HasIdService<Action, int>, IActionsService {

    public ActionsService(AppDbContext context) : base(context) {
    }

    public Action ReadExpanded(int id) {
      try {
        var entity = _context.Actions
          .Include(e => e.Members)
          .Include(e => e.Equipment)
          .FirstOrDefault(e => e.Id.Equals(id));
        if (entity == default(Action)) {
          throw new UnauthorizedException();
        }
        return entity;
      }
      catch (UnauthorizedException) {
        base.ReadById(id);
        throw;
      }
    }

  }

}