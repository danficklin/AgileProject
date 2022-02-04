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
        // public async Task<IActionResult> GetAllFeatsAsync()
        // {
        //     var feats = await _ctx.Feats.ToListAsync();
        //     var featListItems = new List<FeatListItem>();
        //     featListItems = feats.Select(f => new FeatListItem()
        //     {
        //         FeatId = f.FeatId,
        //         FeatName = f.FeatName,
        //         FeatShortDescription = f.FeatShortDescription,
        //         FeatCombatFeat = f.FeatCombatFeat
        //     }).ToList();
        //     return Ok(featListItems);

        // }

    }
}