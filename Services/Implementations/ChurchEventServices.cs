using AutoMapper;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public class ChurchEventServices : IChurchEventServices
    {
        private readonly IChurchEventRepository _churchEventRepository;
        private readonly IMapper _mapper;

        public ChurchEventServices(IChurchEventRepository churchEventRepository, IMapper mapper)
        {
            _churchEventRepository = churchEventRepository;
            _mapper = mapper;
        }

        public async Task<List<ChurchEvent>> GetChurchEvents(Guid churchUserId)
        {
            return await _churchEventRepository.GetChurchEvents(churchUserId);
        }

        public async Task<ChurchEvent> GetChurchEvent(Guid ChurchEventId)
        {
            ChurchEvent churchEvent = await _churchEventRepository.GetChurchEvent(ChurchEventId);
            churchEvent.Participants = null;
            return churchEvent;
        }

        public async Task SubscribeAtChurchEvent(SubscribeAtChurchEventRequestDto request)
        {
            ChurchEvent churchEvent = await _churchEventRepository.GetChurchEvent(request.ChurchEventId) ?? throw new ApiException("El evento no existe");
            if (churchEvent.Participants.Contains(request.Participant)) throw new ApiException("El participante ya está inscrito.");
            churchEvent.Participants.Add(request.Participant);
            await _churchEventRepository.UpdateChurchEvent(churchEvent);
        }

        public async Task AddChurchEvent(Guid churchUserId, ChurchEventDto request)
        {
            ChurchEvent ChurchEvent = _mapper.Map<ChurchEvent>(request);
            ChurchEvent.Id = Guid.NewGuid();
            ChurchEvent.ChurchUserId = churchUserId;
            await _churchEventRepository.AddChurchEvent(ChurchEvent);
        }

        public async Task UpdateChurchEvent(Guid churchUserId, ChurchEventDto request)
        {
            if (!await _churchEventRepository.ChurchEventExists(churchUserId, (Guid)request.Id)) throw new ApiException("Evento no existe.");
            ChurchEvent churchEvent = _mapper.Map<ChurchEvent>(request);
            churchEvent.ChurchUserId = churchUserId;
            await _churchEventRepository.UpdateChurchEvent(churchEvent);
        }

        public async Task DeleteChurchEvent(Guid churchUserId, Guid ChurchEventId)
        {
            ChurchEvent ChurchEvent = await _churchEventRepository.GetChurchEvent(churchUserId, ChurchEventId) ?? throw new ApiException("Evento no existe.");
            await _churchEventRepository.DeleteChurchEvent(ChurchEvent);
        }
    }
}
