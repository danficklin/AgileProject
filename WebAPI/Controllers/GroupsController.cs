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

        // [HttpPut]


    }
}