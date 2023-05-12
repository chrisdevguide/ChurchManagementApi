using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public interface IChurchEventServices
    {
        Task AddChurchEvent(Guid churchUserId, ChurchEventDto request);
        Task DeleteChurchEvent(Guid churchUserId, Guid ChurchEventId);
        Task<ChurchEvent> GetChurchEvent(Guid ChurchEventId);
        Task<List<ChurchEvent>> GetChurchEvents(Guid churchUserId);
        Task SubscribeAtChurchEvent(SubscribeAtChurchEventRequestDto request);
        Task UpdateChurchEvent(Guid churchUserId, ChurchEventDto request);
    }
}