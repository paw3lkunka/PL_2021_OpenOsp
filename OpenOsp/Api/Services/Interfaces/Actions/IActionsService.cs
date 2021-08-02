using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

  public interface IActionsService
    : IHasIdService<Action, int> {

    Action ReadExpanded(int id);

  }

}