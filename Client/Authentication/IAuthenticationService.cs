using System.Threading.Tasks;

using OpenOsp.Model.Dtos;

namespace OpenOsp.Client.Authentication;

public interface IAuthenticationService
{
  Task<string> Login(UserLoginDto loginDto);
  Task Logout();
}