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
        Task<FeatDetail> GetFeatByIdAsync(int featId);
        Task<bool> UpdateFeatAsync(FeatEdit request);
        Task<bool> DeleteFeatAsync(int featId);
    }
}