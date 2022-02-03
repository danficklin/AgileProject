using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Feat;

namespace Services.Feat
{
    // public class FeatService : IFeatService
    // {
    //     private readonly ApplicationDbContext _ctx;
    //     public FeatService(ApplicationDbContext ctx)
    //     {
    //         _ctx = ctx;
    //     }
    //     public async Task<bool> CreateFeatAsync(FeatCreate model) // * Add a feat to the table
    //     {
    //         if (await GetFeatByNameAsync(model.Name)) return false;
    //         var entity = new FeatEntity
    //         {
    //             Name = model.Name,
    //             Type = model.Type,
    //             ShortDescription = model.ShortDescription,
    //             Prerequisites = model.Prerequisites,
    //             Benefits = model.Benefits,
    //             Special = model.Special,
    //             Description = model.Description,
    //             CombatFeat = model.CombatFeat,
    //             DateAdded = DateTime.Now
    //         };
    //         _ctx.Feats.Add(entity);
    //         var numberOfChanges = await _ctx.SaveChangesAsync();
    //         return numberOfChanges == 1;
    //     }
    //     public async Task<FeatEntity> GetFeatByNameAsync(string name) // ? Get a feat by name helper method
    //     {
    //         return await _ctx.Feats.FirstOrDefaultAsync(feat => feat.Name.ToLower() == name.ToLower());
    //     }
    //     public async Task<IActionResult> GetAllFeatsAsync()
    //     {
    //         var feats = await _ctx.Feats.ToListAsync();
    //         var featListItems = new List<FeatListItem>();
    //         featListItems = feats.Select(f => new FeatListItem()
    //         {
    //             Id = f.Id,
    //             Name = f.Name,
    //             ShortDescription = f.ShortDescription,
    //             CombatFeat = f.CombatFeat
    //         }).ToList();
    //         return Ok(featListItems);

    //     }

    // }
}