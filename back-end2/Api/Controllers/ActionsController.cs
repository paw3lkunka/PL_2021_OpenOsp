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

namespace OpenOsp.Api.Controllers {

  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ActionsController
    : AuthController<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto, int> {

    public ActionsController(
      IActionsService service,
      IDtoMapper<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto> mapper,
      AuthController<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto, int, int> actionEquipment,
      AuthController<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto, int, int> actionMembers)
      : base(service, mapper) {
      _service = service;
      _actionEquipment = actionEquipment;
      _actionMembers = actionMembers;
    }

    private new readonly IActionsService _service;

    AuthController<ActionEquipment, ActionEquipmentCreateDto, ActionEquipmentReadDto, ActionEquipmentUpdateDto, int, int> _actionEquipment;

    AuthController<ActionMember, ActionMemberCreateDto, ActionMemberReadDto, ActionMemberUpdateDto, int, int> _actionMembers;

    [HttpGet("expanded/{id}")]
    public ActionResult<ActionReadDto> ReadExpanded(int id) {
      try {
        var entity = _service.ReadExpanded(id);
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
    public ActionResult<ActionEquipmentReadDto> ReadEquipment(int id1, int id2) => _actionEquipment.ReadById(id1, id2);

    [HttpPost("equipment")]
    public ActionResult<ActionEquipmentReadDto> CreateEquipment(ActionEquipmentCreateDto createDto) => _actionEquipment.Create(createDto);

    [HttpPut("{id1}/equipment/{id2}")]
    public ActionResult UpdateEquipment(int id1, int id2, ActionEquipmentUpdateDto updateDto) => _actionEquipment.Update(id1, id2, updateDto);

    [HttpPatch("{id1}/equipment/{id2}")]
    public ActionResult PatchEquipment(int id1, int id2, JsonPatchDocument<ActionEquipmentUpdateDto> patchDoc) => _actionEquipment.Patch(id1, id2, patchDoc);

    [HttpDelete("{id1}/equipment/{id2}")]
    public ActionResult DeleteEquipment(int id1, int id2) => _actionEquipment.Delete(id1, id2);

    /// ActionMembers
    [HttpGet("{id1}/members/{id2}")]
    public ActionResult<ActionMemberReadDto> ReadMember(int id1, int id2) => _actionMembers.ReadById(id1, id2);

    [HttpPost("members")]
    public ActionResult<ActionMemberReadDto> CreateMembers(ActionMemberCreateDto createDto) => _actionMembers.Create(createDto);

    [HttpPut("{id1}/members/{id2}")]
    public ActionResult UpdateMembers(int id1, int id2, ActionMemberUpdateDto updateDto) => _actionMembers.Update(id1, id2, updateDto);

    [HttpPatch("{id1}/members/{id2}")]
    public ActionResult PatchMembers(int id1, int id2, JsonPatchDocument<ActionMemberUpdateDto> patchDoc) => _actionMembers.Patch(id1, id2, patchDoc);

    [HttpDelete("{id1}/members/{id2}")]
    public ActionResult DeleteMembers(int id1, int id2) => _actionMembers.Delete(id1, id2);

  }

}