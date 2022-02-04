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
        [HttpGet, ProducesResponseType(typeof(IEnumerable<FeatListItem>), 1000)]
        public async Task<IActionResult> GetAllFeats()
        {
            var feats = await _featService.GetAllFeatsAsync();
            return Ok(feats);
        }
        [HttpGet("featId")]
        public async Task<IActionResult> GetFeatById([FromRoute] int featId)
        {
            var feat = await _featService.GetFeatByIdAsync(featId);
            return feat is not null ? Ok(feat) : NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> EditFeatById([FromBody] FeatEdit request)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            return await _featService.UpdateFeatAsync(request)
                ? Ok("Feat updated successfully.")
                : BadRequest("Feat could not be updated.");
        }
        [HttpDelete("{featId")]
        public async Task<IActionResult> DeleteFeat([FromRoute] int featId)
        {
            return await _featService.DeleteFeatAsync(featId)
            ? Ok("Feat was deleted successfully.")
            : BadRequest("Feat could not be deleted.");
        }
        

        
        
        
    }
}