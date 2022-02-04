using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Character;
using Services.Character;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerCharacterController : ControllerBase
    {
        private readonly IPlayerCharacterService _playerCharacterService;
        public PlayerCharacterController(IPlayerCharacterService playerCharacterService)
        {
            _playerCharacterService = playerCharacterService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlayerCharacter([FromBody] PlayerCharacterCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _playerCharacterService.CreatePlayerCharacterAsync(request))
            {
                return Ok("Character successfully made!");
            }
            return BadRequest("Character was not created.");
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PlayerCharacterList>), 100)]
        public async Task<IActionResult> GetAllPlayerCharacters()
        {
            var characters = await _playerCharacterService.GetAllCharactersAsync();
            return Ok(characters);
        }
        [HttpGet("{playerCharacterId}")]
        public async Task<IActionResult> GetPlayerCharacterById([FromRoute] int playerCharacterId)
        {
            var playerCharacter = await _playerCharacterService.GetCharacterByIdAsync(playerCharacterId);
            return playerCharacter is not null
                ? Ok(playerCharacter)
                : NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlayerCharacterById([FromBody] PlayerCharacterUpdate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _playerCharacterService.UpdateCharacterAsync(request)
                ? Ok("Player Character was updated successfully!")
                : BadRequest("Player Character could not be updated.");
        }
        
        [HttpPut("{playerCharacterId:int}")]
        public async Task<IActionResult> AddPlayerToGroupAsync([FromRoute] int playerCharacterId, [FromBody] AddPlayerToGroup request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _playerCharacterService.AddCharacterToGroupAsync(playerCharacterId, request)
                ? Ok("Player Character was added to the group successfully!")
                : BadRequest("Player Character could not be added to group.");
        }


        [HttpDelete("{playerCharacterId}")]
        public async Task<IActionResult> DeletePlayerCharacter([FromRoute] int playerCharacterId)
        {
            return await _playerCharacterService.DeleteCharacterAsync(playerCharacterId)
                ? Ok($"Player character with ID {playerCharacterId} was deleted successfully!")
                : BadRequest($"Player character with ID {playerCharacterId} could not be deleted.");
        }
    }
}