using AutoMapper;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public class MemberServices : IMemberServices
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public MemberServices(IMemberRepository memberRepository, IMapper mapper, IGroupRepository groupRepository)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        public async Task<List<Member>> GetMembers(Guid churchUserId)
        {
            return await _memberRepository.GetMembers(churchUserId);
        }

        public async Task AddMember(Guid churchUserId, MemberDto request)
        {
            Member member = _mapper.Map<Member>(request);
            member.Id = Guid.NewGuid();
            member.ChurchUserId = churchUserId;

            await _memberRepository.AddMember(member);
        }

        public async Task UpdateMember(Guid churchUserId, MemberDto request)
        {
            if (!await _memberRepository.MemberExists(churchUserId, (Guid)request.Id)) throw new ApiException("Miembro no existe.");
            Member member = _mapper.Map<Member>(request);
            member.ChurchUserId = churchUserId;

            await _memberRepository.UpdateMember(member);
        }

        public async Task ArchiveMember(Guid churchUserId, Guid memberId, bool isArchived)
        {
            Member member = await _memberRepository.GetMember(churchUserId, memberId) ?? throw new ApiException("Miembro no existe.");
            member.ArchiveDate = (isArchived) ? DateTime.Now : null;
            member.IsArchived = isArchived;
            if (isArchived) await _groupRepository.DeleteGroupMember(churchUserId, memberId);


            await _memberRepository.UpdateMember(member);
        }

        public async Task DeleteMember(Guid churchUserId, Guid memberId)
        {
            Member member = await _memberRepository.GetMember(churchUserId, memberId) ?? throw new ApiException("Miembro no existe.");
            await _groupRepository.DeleteGroupMember(churchUserId, memberId);

            await _memberRepository.DeleteMember(member);
        }

    }
}
