using ChurchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public class ChurchEventRepository : IChurchEventRepository
    {
        private readonly DataContext _dataContext;

        public ChurchEventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<List<ChurchEvent>> GetChurchEvents(Guid churchUserId)
        {
            return await _dataContext.ChurchEvents
                .Where(x => x.ChurchUserId == churchUserId)
                .ToListAsync();
        }


        public async Task<ChurchEvent> GetChurchEvent(Guid ChurchEventId)
        {
            return await _dataContext.ChurchEvents
                .SingleOrDefaultAsync(x => x.Id == ChurchEventId);
        }

        public async Task<ChurchEvent> GetChurchEvent(Guid churchUserId, Guid ChurchEventId)
        {
            return await _dataContext.ChurchEvents
                .SingleOrDefaultAsync(x => x.Id == ChurchEventId && x.ChurchUserId == churchUserId);
        }

        public async Task<bool> ChurchEventExists(Guid churchUserId, Guid ChurchEventId)
        {
            return await _dataContext.ChurchEvents
                .AnyAsync(x => x.Id == ChurchEventId && x.ChurchUserId == churchUserId);
        }

        public async Task AddChurchEvent(ChurchEvent ChurchEvent)
        {
            _dataContext.ChurchEvents.Add(ChurchEvent);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateChurchEvent(ChurchEvent ChurchEvent)
        {
            _dataContext.ChurchEvents.Update(ChurchEvent);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateChurchEvents(List<ChurchEvent> ChurchEvents)
        {
            _dataContext.ChurchEvents.UpdateRange(ChurchEvents);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteChurchEvent(ChurchEvent ChurchEvent)
        {
            _dataContext.ChurchEvents.Remove(ChurchEvent);
            await _dataContext.SaveChangesAsync();
        }
    }
}
