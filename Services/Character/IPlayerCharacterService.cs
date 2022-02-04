using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Character;

namespace Services.Character
{
    public interface IPlayerCharacterService
    {
        Task<bool> CreatePlayerCharacterAsync(PlayerCharacterCreate request);
        Task<IEnumerable<PlayerCharacterList>> GetAllCharactersAsync();
        Task<PlayerCharacterDetail> GetCharacterByIdAsync(int playerCharacterId);
        Task<bool> UpdateCharacterAsync(PlayerCharacterUpdate request);
        Task<bool> AddCharacterToGroupAsync(int playerId, AddPlayerToGroup request);
        Task<bool> DeleteCharacterAsync(int playerCharacterId);
    }
}