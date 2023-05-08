using ChurchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _dataContext;

        public GroupRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Group>> GetGroups(Guid churchUserId)
        {
            return await _dataContext.Groups
                .Include(x => x.Members)
                .Where(x => x.ChurchUserId == churchUserId)
                .ToListAsync();
        }

        public async Task<List<Group>> GetGroups(Guid churchUserId, List<Guid> groupIds)
        {
            return await _dataContext.Groups
                .Include(x => x.Members)
                .Where(x => x.ChurchUserId == churchUserId && groupIds.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<Group> GetGroup(Guid churchUserId, Guid groupId)
        {
            return await _dataContext.Groups
                .Include(x => x.Members)
                .SingleOrDefaultAsync(x => x.Id == groupId && x.ChurchUserId == churchUserId);
        }

        public async Task AddGroup(Group group)
        {
            _dataContext.Groups.Add(group);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateGroup(Group group)
        {
            _dataContext.Groups.Update(group);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteGroup(Group group)
        {
            _dataContext.Groups.Remove(group);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteGroupMember(Guid churchUserId, Guid memberId)
        {
            List<Group> groups = await _dataContext.Groups
                .Include(x => x.Members)
                .Where(x => x.ChurchUserId == churchUserId && x.Members.Any(y => y.Id == memberId))
                .ToListAsync();
            groups.ForEach(x => x.Members.RemoveAll(y => y.Id == memberId));
            await _dataContext.SaveChangesAsync();
        }
    }
}
