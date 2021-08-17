using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenOsp.Api.Exceptions;
using OpenOsp.Api.Services;
using OpenOsp.Model.Dtos.ViewModels;
using OpenOsp.Model.Models;

namespace OpenOsp.Api.Controllers {

  [ApiController]
  [Route("[controller]")]
  [AllowAnonymous]
  public class UsersController : ControllerBase {

    public UsersController(
      IUsersService<User, int> usersService,
      IEmailsService emailsService
    ) {
      _usersService = usersService;
      _emailsService = emailsService;
    }

    private readonly IUsersService<User, int> _usersService;

    private readonly IEmailsService _emailsService;

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
      catch (DbTransactionException) {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      catch {
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
          UserName = vm.UserName,
          Email = vm.Email,
        };
        await _usersService.Create(user, vm.Password);
        var token = await _usersService.GetEmailConfirmationToken(user);
        var link = Url.Action(
          "Verify",
          "Users",
          new { uid = user.Id, token = token },
          protocol: HttpContext.Request.Scheme
        );
        await _emailsService.SendVerificationEmail(user.Email, link);
        return Ok();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DbTransactionException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("verify")]
    public async Task<ActionResult> Verify([FromQuery] int uid, [FromQuery] string token) {
      try {
        var user = await _usersService.ReadById(uid);
        await _usersService.ConfirmEmail(user, token);
        return Ok();
      }
      catch (DbTransactionException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

  }

}