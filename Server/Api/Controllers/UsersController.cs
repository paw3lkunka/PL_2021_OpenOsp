using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;
using OpenOsp.Server.Exceptions;

namespace OpenOsp.Server.Api.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  [AllowAnonymous]
  public class UsersController : ControllerBase {
    private readonly IEmailsService _emailsService;

    private readonly IUserDtoMapper _mapper;

    private readonly IUserService<User, int> _service;

    public UsersController(
      IUserService<User, int> service,
      IUserDtoMapper mapper,
      IEmailsService emailsService) {
      _service = service;
      _mapper = mapper;
      _emailsService = emailsService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> LogIn([FromBody] UserLoginDto dto) {
      try {
        if (TryValidateModel(dto) == false) {
          throw new ValidationProblemException();
        }

        var user = await _service.ReadByEmail(dto.Email);
        var token = await _service.GetAuthenticationToken(user, dto.Password);
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
        if (TryValidateModel(dto) == false) {
          throw new ValidationProblemException();
        }

        var user = _mapper.MapRegister(dto);
        await _service.Create(user, dto.Password);
        var token = await _service.GetEmailConfirmationToken(user);
        var link = Url.Action(
          "Verify",
          "Users",
          new {uid = user.Id, token},
          HttpContext.Request.Scheme);
        await _emailsService.SendVerificationEmail(user.Email, link);
        return Ok();
      }
      catch (ValidationProblemException) {
        return ValidationProblem();
      }
      catch (DbTransactionException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new {ex.Message});
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [HttpGet("verify")]
    public async Task<ActionResult> Verify([FromQuery] int uid, [FromQuery] string token) {
      try {
        var user = await _service.ReadById(uid);
        await _service.ConfirmEmail(user, token);
        return Ok();
      }
      catch (DbTransactionException ex) {
        return StatusCode(StatusCodes.Status500InternalServerError, new {ex.Message});
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}