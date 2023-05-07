using ChurchManagementApi.Models;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public interface IGroupRepository
    {
        Task AddGroup(Group group);
        Task DeleteGroup(Group group);
        Task DeleteGroupMember(Guid churchUserId, Guid memberId);
        Task<Group> GetGroup(Guid churchUserId, Guid groupId);
        Task<List<Group>> GetGroups(Guid churchUserId);
        Task UpdateGroup(Group group);
    }
}