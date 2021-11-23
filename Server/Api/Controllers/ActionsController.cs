using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using OpenOsp.Model.Dtos;
using OpenOsp.Model.Dtos.Mappers;
using OpenOsp.Model.Models;
using OpenOsp.Server.Api.Services;

namespace OpenOsp.Server.Api.Controllers {
  [ApiController]
  public class ActionsController
    : AuthorizedController<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto, int> {
    private readonly ActionEquipmentController _actionEquipment;

    private readonly ActionMembersController _actionMembers;

    public ActionsController(
      IHasIdService<Action, int> service,
      IDtoMapper<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto> mapper,
      ActionEquipmentController actionEquipment,
      ActionMembersController actionMembers)
      : base(service, mapper) {
      _actionEquipment = actionEquipment;
      _actionMembers = actionMembers;
    }

    /// ActionEquipment
    [HttpGet("{id}/equipment")]
    public async Task<ActionResult<IEnumerable<ActionEquipmentReadDto>>> ReadEquipment(int id) {
      return await _actionEquipment.ReadById(id);
    }

    [HttpGet("{id}/equipment/count")]
    public async Task<ActionResult<int>> ReadEquipmentCount(int id) {
      return await _actionEquipment.ReadCount(id);
    }

    [HttpGet("{id}/equipment/{id2}")]
    public async Task<ActionResult<ActionEquipmentReadDto>> ReadEquipment(int id, int id2) {
      return await _actionEquipment.ReadById(id, id2);
    }

    [HttpPost("{id}/equipment")]
    public async Task<ActionResult<ActionEquipmentReadDto>>
      CreateEquipment(int id, ActionEquipmentCreateDto createDto) {
      return await _actionEquipment.Create(id, createDto);
    }

    [HttpPut("{id}/equipment/{id2}")]
    public async Task<ActionResult> UpdateEquipment(int id, int id2, ActionEquipmentUpdateDto updateDto) {
      return await _actionEquipment.Update(id, id2, updateDto);
    }

    [HttpPatch("{id}/equipment/{id2}")]
    public async Task<ActionResult> PatchEquipment(int id, int id2,
      JsonPatchDocument<ActionEquipmentUpdateDto> patchDoc) {
      return await _actionEquipment.Patch(id, id2, patchDoc);
    }

    [HttpDelete("{id}/equipment/{id2}")]
    public async Task<ActionResult> DeleteEquipment(int id, int id2) {
      return await _actionEquipment.Delete(id, id2);
    }

    /// ActionMembers
    [HttpGet("{id}/members")]
    public async Task<ActionResult<IEnumerable<ActionMemberReadDto>>> ReadMembers(int id) {
      return await _actionMembers.ReadById(id);
    }

    [HttpGet("{id}/members/count")]
    public async Task<ActionResult<int>> ReadMembersCount(int id) {
      return await _actionMembers.ReadCount(id);
    }

    [HttpGet("{id}/members/{id2}")]
    public async Task<ActionResult<ActionMemberReadDto>> ReadMember(int id, int id2) {
      return await _actionMembers.ReadById(id, id2);
    }

    [HttpPost("{id}/members")]
    public async Task<ActionResult<ActionMemberReadDto>> CreateMembers(int id, ActionMemberCreateDto createDto) {
      return await _actionMembers.Create(id, createDto);
    }

    [HttpPut("{id}/members/{id2}")]
    public async Task<ActionResult> UpdateMembers(int id, int id2, ActionMemberUpdateDto updateDto) {
      return await _actionMembers.Update(id, id2, updateDto);
    }

    [HttpPatch("{id}/members/{id2}")]
    public async Task<ActionResult> PatchMembers(int id, int id2, JsonPatchDocument<ActionMemberUpdateDto> patchDoc) {
      return await _actionMembers.Patch(id, id2, patchDoc);
    }

    [HttpDelete("{id}/members/{id2}")]
    public async Task<ActionResult> DeleteMembers(int id, int id2) {
      return await _actionMembers.Delete(id, id2);
    }
  }
}