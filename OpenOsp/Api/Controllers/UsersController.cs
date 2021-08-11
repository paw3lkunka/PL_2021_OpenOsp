using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenOsp.Api.Exceptions;
using OpenOsp.Api.Services;
using OpenOsp.Model.Dtos.ViewModels;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase {

    public UsersController(
      IUsersService<User, int> usersService
    ) {
      _usersService = usersService;
    }

    private readonly IUsersService<User, int> _usersService;

    [HttpPost("login")]
    public async Task<ActionResult<string>> LogIn([FromBody] UserLoginVM vm) {
      try {
        if (!TryValidateModel(vm)) {
          throw new ValidationProblemException();
        }
        var user = await _usersService.ReadByEmail(vm.Email);
        var token = await _usersService.GetAuthenticationToken(user, vm.Password);
        return Ok(token);
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (NotFoundException) {
        return BadRequest("Invalid email.");
      }
      catch (DatabaseTransactionFailureException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] UserRegisterVM vm) {
      try {
        if (!TryValidateModel(vm)) {
          throw new ValidationProblemException();
        }
        var user = new User {
          Email = vm.Email,
        };
        await _usersService.Create(user, vm.Password);
        return Ok();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DatabaseTransactionFailureException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

  }

}