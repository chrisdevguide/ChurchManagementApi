using ChurchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _dataContext;

        public MemberRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Member>> GetMembers(Guid churchUserId)
        {
            return await _dataContext.Members.Where(x => x.ChurchUserId == churchUserId)
                .ToListAsync();
        }


        public async Task<List<Member>> GetMembers(Guid churchUserId, List<Guid> memberIds)
        {
            return await _dataContext.Members.Where(x => x.ChurchUserId == churchUserId && memberIds.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<List<Member>> GetMembers(List<Guid> memberIds)
        {
            return await _dataContext.Members.Where(x => memberIds.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<Member> GetMember(Guid churchUserId, Guid memberId)
        {
            return await _dataContext.Members
                .SingleOrDefaultAsync(x => x.ChurchUserId == churchUserId && x.Id == memberId);
        }

        public async Task<bool> MemberExists(Guid churchUserId, Guid memberId)
        {
            return await _dataContext.Members
                .AnyAsync(x => x.ChurchUserId == churchUserId && x.Id == memberId);
        }

        public async Task AddMember(Member member)
        {
            _dataContext.Members.Add(member);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateMember(Member member)
        {
            _dataContext.Members.Update(member);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteMember(Member member)
        {
            _dataContext.Members.Remove(member);
            await _dataContext.SaveChangesAsync();
        }

    }
}
