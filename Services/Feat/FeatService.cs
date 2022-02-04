using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Feat;

namespace Services.Feat
{
    public class FeatService : IFeatService
    {
        private readonly ApplicationDbContext _ctx;
        public FeatService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> CreateFeatAsync(FeatCreate model) // * Add a feat to the table
        {
            if (await GetFeatByNameAsync(model.FeatName) != null) return false;
            var entity = new FeatEntity
            {
                FeatName = model.FeatName,
                FeatType = model.FeatType,
                FeatShortDescription = model.FeatShortDescription,
                FeatPrerequisites = model.FeatPrerequisites,
                FeatBenefits = model.FeatBenefits,
                FeatNormal = model.FeatNormal,
                FeatSpecial = model.FeatSpecial,
                FeatDescription = model.FeatDescription,
                FeatCombatFeat = model.FeatCombatFeat,
                DateAdded = DateTime.Now
            };
            _ctx.Feats.Add(entity);
            var numberOfChanges = await _ctx.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<FeatEntity> GetFeatByNameAsync(string name) // ? Get a feat by name helper method
        {
            return await _ctx.Feats.FirstOrDefaultAsync(feat => feat.FeatName.ToLower() == name.ToLower());
        }
        public async Task<IEnumerable<FeatListItem>> GetAllFeatsAsync()
        {
            var feat = await _ctx.Feats.Select(entity => new FeatListItem
            {
                FeatId = entity.FeatId,
                FeatName = entity.FeatName,
                FeatShortDescription = entity.FeatShortDescription,
                FeatCombatFeat = entity.FeatCombatFeat
            })
            .ToListAsync();
        return feat;
        }
        public async Task<FeatDetail> GetFeatByIdAsync(int featId)
        {
            var featEntity = await _ctx.Feats.FirstOrDefaultAsync(entity => entity.FeatId == featId);
            return featEntity is null ? null : new FeatDetail
            {
                FeatName = featEntity.FeatName,
                FeatType = featEntity.FeatType,
                FeatShortDescription = featEntity.FeatShortDescription,
                FeatPrerequisites = featEntity.FeatPrerequisites,
                FeatBenefits = featEntity.FeatBenefits,
                FeatNormal = featEntity.FeatNormal,
                FeatSpecial = featEntity.FeatSpecial,
                FeatDescription = featEntity.FeatDescription,
                FeatCombatFeat = featEntity.FeatCombatFeat,
                DateAdded = featEntity.DateAdded
            };
        }
        public async Task<bool> UpdateFeatAsync(FeatEdit request)
        {
            var entity = await _ctx.Feats.FindAsync(request.Id);
            entity.FeatName = request.FeatName;
            entity.FeatType = request.FeatType;
            entity.FeatShortDescription = request.FeatShortDescription;
            entity.FeatPrerequisites = request.FeatPrerequisites;
            entity.FeatBenefits = request.FeatBenefits;
            entity.FeatNormal = request.FeatNormal;
            entity.FeatSpecial = request.FeatSpecial;
            entity.FeatDescription = request.FeatDescription;
            entity.FeatCombatFeat = request.FeatCombatFeat;
            var changes = await _ctx.SaveChangesAsync();
            return changes == 1;
    }
    public async Task<bool> DeleteFeatAsync(int featId)
    {
        var featEntity = await _ctx.Feats.FindAsync(featId);
        _ctx.Feats.Remove(featEntity);
        return await _ctx.SaveChangesAsync() == 1;
    }
    }
}