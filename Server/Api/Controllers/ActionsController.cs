using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OpenOsp.Model.Models;
using OpenOsp.Model.Dtos;
using OpenOsp.Server.Api.Services;
using OpenOsp.Model.Dtos.Mappers;
using Microsoft.AspNetCore.Http;
using OpenOsp.Server.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace OpenOsp.Server.Api.Controllers {

  [ApiController]
  public class ActionsController
    : AuthController<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto, int> {

    public ActionsController(
      IHasIdService<Action, int> service,
      IDtoMapper<Action, ActionCreateDto, ActionReadDto, ActionUpdateDto> mapper,
      ActionEquipmentController actionEquipment,
      ActionMembersController actionMembers)
      : base(service, mapper) {
      _actionEquipment = actionEquipment;
      _actionMembers = actionMembers;
    }

    ActionEquipmentController _actionEquipment;

    ActionMembersController _actionMembers;

    /// ActionEquipment
    [HttpGet("{id1}/equipment")]
    public async Task<ActionResult<IEnumerable<ActionEquipmentReadDto>>> ReadEquipment(int id1) => await _actionEquipment.ReadById(id1);

    [HttpGet("{id1}/equipment/count")]
    public async Task<ActionResult<int>> ReadEquipmentCount(int id1) => await _actionEquipment.ReadCount(id1);
    
    [HttpGet("{id1}/equipment/{id2}")]
    public async Task<ActionResult<ActionEquipmentReadDto>> ReadEquipment(int id1, int id2) => await _actionEquipment.ReadById(id1, id2);

    [HttpPost("{id1}/equipment")]
    public async Task<ActionResult<ActionEquipmentReadDto>> CreateEquipment(int id1, ActionEquipmentCreateDto createDto) => await _actionEquipment.Create(id1, createDto);

    [HttpPut("{id1}/equipment/{id2}")]
    public async Task<ActionResult> UpdateEquipment(int id1, int id2, ActionEquipmentUpdateDto updateDto) => await _actionEquipment.Update(id1, id2, updateDto);

    [HttpPatch("{id1}/equipment/{id2}")]
    public async Task<ActionResult> PatchEquipment(int id1, int id2, JsonPatchDocument<ActionEquipmentUpdateDto> patchDoc) => await _actionEquipment.Patch(id1, id2, patchDoc);

    [HttpDelete("{id1}/equipment/{id2}")]
    public async Task<ActionResult> DeleteEquipment(int id1, int id2) => await _actionEquipment.Delete(id1, id2);

    /// ActionMembers
    [HttpGet("{id1}/members")]
    public async Task<ActionResult<IEnumerable<ActionMemberReadDto>>> ReadMembers(int id1) => await _actionMembers.ReadById(id1);
    
    [HttpGet("{id1}/members/count")]
    public async Task<ActionResult<int>> ReadMembersCount(int id1) => await _actionMembers.ReadCount(id1);
    
    [HttpGet("{id1}/members/{id2}")]
    public async Task<ActionResult<ActionMemberReadDto>> ReadMember(int id1, int id2) => await _actionMembers.ReadById(id1, id2);

    [HttpPost("{id1}/members")]
    public async Task<ActionResult<ActionMemberReadDto>> CreateMembers(int id1, ActionMemberCreateDto createDto) => await _actionMembers.Create(id1, createDto);

    [HttpPut("{id1}/members/{id2}")]
    public async Task<ActionResult> UpdateMembers(int id1, int id2, ActionMemberUpdateDto updateDto) => await _actionMembers.Update(id1, id2, updateDto);

    [HttpPatch("{id1}/members/{id2}")]
    public async Task<ActionResult> PatchMembers(int id1, int id2, JsonPatchDocument<ActionMemberUpdateDto> patchDoc) => await _actionMembers.Patch(id1, id2, patchDoc);

    [HttpDelete("{id1}/members/{id2}")]
    public async Task<ActionResult> DeleteMembers(int id1, int id2) => await _actionMembers.Delete(id1, id2);

  }

}