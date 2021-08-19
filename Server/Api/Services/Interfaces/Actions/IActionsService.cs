using System.Threading.Tasks;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Services {

  public interface IActionsService
    : IHasIdService<Action, int> {

    Task<Action> ReadExpanded(int id);

  }

}