using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Group;
using Services.Group;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupservice;
        public GroupController (IGroupService groupservice)
        {
            _groupservice = groupservice;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            if (await _groupservice.CreateNewGroupAsync(request))
                return Ok($"{request.GroupName} successfully added");
            
            return BadRequest("Group could not be created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groupList = await _groupservice.GetListOfGroupsAsync();
            return Ok(groupList);
        }

        [HttpGet("{groupId:int}")]
        public async Task<IActionResult> GetGroupById([FromRoute] int groupId)
        {
            var groupFind = await _groupservice.GetGroupByIdAsync(groupId);
            return groupFind is not null
                ? Ok(groupFind)
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroups([FromBody] GroupUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return await _groupservice.UpdateGroupByIdAsync(request)
                ? Ok($"Group {request.GroupName} update successfully")
                : BadRequest("Group could not be updated");
            
        }

        [HttpDelete("{groupId:int}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int groupId)
        {
            return await _groupservice.DeleteGroupByIdAsync(groupId)
                ? Ok("Group deleted")
                : BadRequest($"Group {groupId} could not be found.");
        }

    }
}