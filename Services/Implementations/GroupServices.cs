using AutoMapper;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public class GroupServices : IGroupServices
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;

        public GroupServices(IGroupRepository groupRepository, IMapper mapper, IMemberRepository memberRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _memberRepository = memberRepository;
        }

        public async Task<List<Group>> GetGroups(Guid churchUserId)
        {
            return await _groupRepository.GetGroups(churchUserId);
        }

        public async Task AddGroup(Guid churchUserId, GroupDto request)
        {
            Group group = _mapper.Map<Group>(request);
            group.Id = Guid.NewGuid();
            group.ChurchUserId = churchUserId;
            group.Members = await _memberRepository.GetMembers(churchUserId, request.MemberIds);

            await _groupRepository.AddGroup(group);
        }

        public async Task UpdateGroup(Guid churchUserId, GroupDto request)
        {
            Group group = await _groupRepository.GetGroup(churchUserId, (Guid)request.Id) ?? throw new ApiException("El grupo no existe.");
            group.Members = await _memberRepository.GetMembers(churchUserId, request.MemberIds);
            group.Name = request.Name;

            await _groupRepository.UpdateGroup(group);
        }

        public async Task DeleteGroup(Guid churchUserId, Guid groupId)
        {
            Group group = await _groupRepository.GetGroup(churchUserId, groupId) ?? throw new ApiException("El grupo no existe.");
            await _groupRepository.DeleteGroup(group);
        }
    }
}
