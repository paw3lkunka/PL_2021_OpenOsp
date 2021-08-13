using Microsoft.AspNetCore.Authorization;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;
using OpenOsp.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Http;
using OpenOsp.Api.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace OpenOsp.Api.Controllers {

  [ApiController]
  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ActionsController
    : AuthController<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto, int> {

    public ActionsController(
      IActionsService service,
      IDtoMapper<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto> mapper,
      ActionEquipmentController actionEquipment,
      ActionMembersController actionMembers
    ) : base(service, mapper) {
      _service = service;
      _actionEquipment = actionEquipment;
      _actionMembers = actionMembers;
    }

    private new readonly IActionsService _service;

    ActionEquipmentController _actionEquipment;

    ActionMembersController _actionMembers;

    [HttpGet("expanded/{id}")]
    public async Task<ActionResult<ActionReadDto>> ReadExpanded(int id) {
      try {
        var entity = await _service.ReadExpanded(id);
        return base.ReadEntity(entity);
      }
      catch (UnauthorizedException) {
        return Unauthorized();
      }
      catch (NotFoundException) {
        return NotFound();
      }
      catch {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    /// ActionEquipment
    [HttpGet("{id1}/equipment/{id2}")]
    public async Task<ActionResult<ActionEquipmentReadDto>> ReadEquipment(int id1, int id2) => await _actionEquipment.ReadById(id1, id2);

    [HttpPost("equipment")]
    public async Task<ActionResult<ActionEquipmentReadDto>> CreateEquipment(ActionEquipmentCreateDto createDto) => await _actionEquipment.Create(createDto);

    [HttpPut("{id1}/equipment/{id2}")]
    public async Task<ActionResult> UpdateEquipment(int id1, int id2, ActionEquipmentUpdateDto updateDto) => await _actionEquipment.Update(id1, id2, updateDto);

    [HttpPatch("{id1}/equipment/{id2}")]
    public async Task<ActionResult> PatchEquipment(int id1, int id2, JsonPatchDocument<ActionEquipmentUpdateDto> patchDoc) => await _actionEquipment.Patch(id1, id2, patchDoc);

    [HttpDelete("{id1}/equipment/{id2}")]
    public async Task<ActionResult> DeleteEquipment(int id1, int id2) => await _actionEquipment.Delete(id1, id2);

    /// ActionMembers
    [HttpGet("{id1}/members/{id2}")]
    public async Task<ActionResult<ActionMemberReadDto>> ReadMember(int id1, int id2) => await _actionMembers.ReadById(id1, id2);

    [HttpPost("members")]
    public async Task<ActionResult<ActionMemberReadDto>> CreateMembers(ActionMemberCreateDto createDto) => await _actionMembers.Create(createDto);

    [HttpPut("{id1}/members/{id2}")]
    public async Task<ActionResult> UpdateMembers(int id1, int id2, ActionMemberUpdateDto updateDto) => await _actionMembers.Update(id1, id2, updateDto);

    [HttpPatch("{id1}/members/{id2}")]
    public async Task<ActionResult> PatchMembers(int id1, int id2, JsonPatchDocument<ActionMemberUpdateDto> patchDoc) => await _actionMembers.Patch(id1, id2, patchDoc);

    [HttpDelete("{id1}/members/{id2}")]
    public async Task<ActionResult> DeleteMembers(int id1, int id2) => await _actionMembers.Delete(id1, id2);

  }

}