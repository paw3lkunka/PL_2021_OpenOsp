using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenOsp.Server.Exceptions;
using OpenOsp.Server.Api.Services;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;

namespace OpenOsp.Server.Api.Controllers {

  [ApiController]
  [Route("api/[controller]")]
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
    public async Task<ActionResult<string>> LogIn([FromBody] UserLoginDto dto) {
      try {
        if (!TryValidateModel(dto)) {
          throw new ValidationProblemException();
        }
        var user = await _usersService.ReadByEmail(dto.Email);
        var token = await _usersService.GetAuthenticationToken(user, dto.Password);
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
    public async Task<ActionResult> Register([FromBody] UserRegisterDto dto) {
      try {
        if (!TryValidateModel(dto)) {
          throw new ValidationProblemException();
        }
        var user = new User {
          UserName = dto.UserName,
          Email = dto.Email,
        };
        await _usersService.Create(user, dto.Password);
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