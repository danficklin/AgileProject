using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Character;

namespace Services.Character
{
    public class PlayerCharacterService : IPlayerCharacterService
    {
        private readonly ApplicationDbContext _dbContext;
        public PlayerCharacterService (ApplicationDbContext dbContext){
            _dbContext = dbContext;
        }
        public async Task<bool> CreatePlayerCharacterAsync(PlayerCharacterCreate request)
        {
            var characterEntity = new PlayerCharacterEntity
            {
                Name = request.Name,
                Class = request.Class,
                Race = request.Race,
                Level = request.Level,
                Strength = request.Strength,
                Dexterity = request.Dexterity,
                Constitution = request.Constitution,
                Intelligence = request.Intelligence,
                Wisdom = request.Wisdom,
                Charisma = request.Charisma,
                HitPoints = request.HitPoints

            };
            _dbContext.Characters.Add(characterEntity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<PlayerCharacterList>> GetAllCharactersAsync()
        {
            var playerCharacter = await _dbContext.Characters
                .Select(entity => new PlayerCharacterList
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Class = entity.Class,
                        Race = entity.Race,
                        Level = entity.Level
                    })
                .ToListAsync();
            return playerCharacter;
        }
        public async Task<PlayerCharacterDetail> GetNoteByIdAsync(int playerCharacterId)
        {
            var playerCharacterEntity = await _dbContext.Characters
                .FirstOrDefaultAsync(entity => 
                entity.Id == playerCharacterId);
            return playerCharacterEntity is null ? null : new PlayerCharacterDetail
            {
                Id = playerCharacterEntity.Id,
                Name = playerCharacterEntity.Name,
                Class = playerCharacterEntity.Class,
                Race = playerCharacterEntity.Race,
                Level = playerCharacterEntity.Level
            };
        }
        public async Task<bool> UpdateCharacterAsync(PlayerCharacterUpdate request)
        {
            var entity = await _dbContext.Characters.FindAsync(request.Id);

            entity.Name = request.Name;
            entity.Class = request.Class;
            entity.Race = request.Race;
            entity.Level = request.Level;
            entity.Strength = request.Strength;
            entity.Dexterity = request.Dexterity;
            entity.Intelligence = request.Intelligence;
            entity.Wisdom = request.Wisdom;
            entity.Charisma = request.Charisma;
            entity.HitPoints = request.HitPoints;
            entity.Backstory = request.Backstory;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<bool> DeleteCharacterAsync(int playerCharacterId)
        {
            var noteEntity = await _dbContext.Characters.FindAsync(playerCharacterId);
            _dbContext.Characters.Remove(noteEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}