using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Feat;

namespace Services.Feat
{
    public interface IFeatService
    {
        Task<bool> CreateFeatAsync(FeatCreate request);
        Task<IEnumerable<FeatListItem>> GetAllFeatsAsync();
        Task<FeatDetails> GetFeatByNameAsync(int featId);
        Task<bool> UpdateFeatAsync(FeatUpdate request);
    }
}