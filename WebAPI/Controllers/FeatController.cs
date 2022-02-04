using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Feat;
using Services.Feat;

namespace WebAPI.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class FeatController : ControllerBase
    {
        private readonly IFeatService _featService;
        public FeatController(IFeatService featService) {_featService = featService;}
        
        [HttpPost("Create")] // Create a feat
        public async Task<IActionResult> CreateFeat([FromBody] FeatCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createResult = await _featService.CreateFeatAsync(model);
            if (createResult)
            {
                return Ok("Feat added to database.");
            }
            return BadRequest("Feat could not be added.");
        }
        
        // [HttpGet("{name:string}"), ProducesResponseType(typeof(string), 200)]
        // public async Task<IActionResult> GetFeatByNameAsync([FromRoute] int featName)
        // {
        //     var featDetail = await _featService.GetFeatByNameAsync(featName);
        //     if(featDetail is null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(featDetail);
        // }
        
    }
}