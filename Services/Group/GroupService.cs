using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Group;

namespace Services.Group
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;
        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNewGroupAsync(GroupCreate model)
        {
            var newGroup = new GroupEntity
            {
                GroupName = model.GroupName
            };
            _context.Add(newGroup);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<List<GroupListItem>> GetListOfGroupsAsync()
        {
            var groups = await _context.Groups
                .Select(entity => new GroupListItem
                {
                    GroupId = entity.GroupId,
                    GroupName = entity.GroupName
                })
                .ToListAsync();

            return groups;
        }

        public async Task<bool> UpdateGroupByIdAsync(GroupUpdate request)
        {
            var groupEntity = await _context.Groups.FindAsync();

            groupEntity.GroupName = request.GroupName;
            groupEntity.GroupMembers = request.GroupPlayerCharacters;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteGroupByIdAsync(int groupId)
        {
            var groupEntity = await _context.Groups.FindAsync(groupId);

            _context.Groups.Remove(groupEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}