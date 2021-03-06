using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Group;

namespace Services.Group
{
    public interface IGroupService
    {
        Task<bool> CreateNewGroupAsync(GroupCreate group);
        Task<List<GroupListItem>> GetListOfGroupsAsync();
        Task<GroupDetail> GetGroupByIdAsync(int groupId);
        Task<bool> UpdateGroupByIdAsync(GroupUpdate request);
        Task<bool> DeleteGroupByIdAsync(int groupId);

    }
}