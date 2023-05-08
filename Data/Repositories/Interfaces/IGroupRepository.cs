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
        Task<List<Group>> GetGroups(Guid churchUserId, List<Guid> groupIds);
        Task UpdateGroup(Group group);
    }
}