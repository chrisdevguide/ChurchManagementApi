using ChurchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public class ChurchUserRepository : IChurchUserRepository
    {
        private readonly DataContext _dataContext;

        public ChurchUserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> ChurchUserExist(string username)
        {
            return await _dataContext.ChurchUsers.AnyAsync(u => u.Username == username);
        }

        public async Task AddChurchUser(ChurchUser churchUser)
        {
            _dataContext.ChurchUsers.Add(churchUser);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<ChurchUser> GetChurchUser(string username)
        {
            return await _dataContext.ChurchUsers.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<ChurchUser> GetChurchUser(Guid churchUserId, string username)
        {
            return await _dataContext.ChurchUsers.SingleOrDefaultAsync(u => u.Username == username && u.Id == churchUserId);
        }

        public async Task UpdateChurchUser(ChurchUser churchUser)
        {
            _dataContext.ChurchUsers.Update(churchUser);
            await _dataContext.SaveChangesAsync();
        }


    }
}
