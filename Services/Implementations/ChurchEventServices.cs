using AutoMapper;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Interfaces;

namespace ChurchManagementApi.Services.Implementations
{
    public class ChurchEventServices : IChurchEventServices
    {
        private readonly IChurchEventRepository _churchEventRepository;
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;

        public ChurchEventServices(IChurchEventRepository churchEventRepository, IMapper mapper, IMemberRepository memberRepository)
        {
            _churchEventRepository = churchEventRepository;
            _mapper = mapper;
            _memberRepository = memberRepository;
        }

        public async Task<List<ChurchEvent>> GetChurchEvents(Guid churchUserId)
        {
            return await _churchEventRepository.GetChurchEvents(churchUserId);
        }

        public async Task<ChurchEvent> GetChurchEvent(Guid churchUserId, Guid ChurchEventId)
        {
            return await _churchEventRepository.GetChurchEvent(churchUserId, ChurchEventId);

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
