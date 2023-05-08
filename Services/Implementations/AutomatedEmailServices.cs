using AutoMapper;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Interfaces;

namespace ChurchManagementApi.Services.Implementations
{
    public class AutomatedEmailServices : IAutomatedEmailServices
    {
        private readonly IAutomatedEmailRepository _automatedEmailRepository;
        private readonly IMapper _mapper;
        private readonly IEmailServices _emailServices;
        private readonly IMemberRepository _memberRepository;
        private readonly IGroupRepository _groupRepository;

        public AutomatedEmailServices(IAutomatedEmailRepository automatedEmailRepository, IMapper mapper, IEmailServices emailServices, IMemberRepository memberRepository, IGroupRepository groupRepository)
        {
            _automatedEmailRepository = automatedEmailRepository;
            _mapper = mapper;
            _emailServices = emailServices;
            _memberRepository = memberRepository;
            _groupRepository = groupRepository;
        }

        public async Task<List<AutomatedEmail>> GetAutomatedEmails(Guid churchUserId)
        {
            return await _automatedEmailRepository.GetAutomatedEmails(churchUserId);
        }

        public async Task<AutomatedEmail> GetAutomatedEmail(Guid churchUserId, Guid automatedEmailId)
        {
            return await _automatedEmailRepository.GetAutomatedEmail(churchUserId, automatedEmailId);

        }

        public async Task AddAutomatedEmail(Guid churchUserId, AutomatedEmailDto request)
        {
            AutomatedEmail automatedEmail = _mapper.Map<AutomatedEmail>(request);
            automatedEmail.Id = Guid.NewGuid();
            automatedEmail.ChurchUserId = churchUserId;
            await _automatedEmailRepository.AddAutomatedEmail(automatedEmail);
        }

        public async Task UpdateAutomatedEmail(Guid churchUserId, AutomatedEmailDto request)
        {
            AutomatedEmail automatedEmail = await _automatedEmailRepository.GetAutomatedEmail(churchUserId, (Guid)request.Id) ?? throw new ApiException("Correo automatizado no existe.");
            if (automatedEmail.Sent) throw new ApiException("Correo automatizado ya ha sido enviado.");
            automatedEmail = _mapper.Map<AutomatedEmail>(request);
            automatedEmail.ChurchUserId = churchUserId;
            List<Group> groups = await _groupRepository.GetGroups(churchUserId, request.Groups);
            groups.ForEach(x =>
            {
                x.Members.ForEach(member =>
                {
                    if (!automatedEmail.Recipients.Contains(member.Id)) automatedEmail.Recipients.Add(member.Id);
                });
            });
            await _automatedEmailRepository.UpdateAutomatedEmail(automatedEmail);
        }

        public async Task DeleteAutomatedEmail(Guid churchUserId, Guid automatedEmailId)
        {
            AutomatedEmail automatedEmail = await _automatedEmailRepository.GetAutomatedEmail(churchUserId, automatedEmailId) ?? throw new ApiException("Correo automatizado no existe.");
            await _automatedEmailRepository.DeleteAutomatedEmail(automatedEmail);
        }

        public async Task SendAutomatedEmails()
        {
            List<AutomatedEmail> automatedEmailsToSend = await _automatedEmailRepository.GetAutomatedEmailsToSend();
            automatedEmailsToSend.ForEach(email =>
            {
                List<string> recipients = _memberRepository.GetMembers(email.Recipients).Result.Select(x => x.Email).ToList();
                List<Group> groups = _groupRepository.GetGroups(email.ChurchUserId, email.Groups).Result;
                groups.ForEach(x =>
                {
                    x.Members.ForEach(member =>
                    {
                        if (!recipients.Contains(member.Email)) recipients.Add(member.Email);
                    });
                });
                _emailServices.SendEmail(email, recipients);
                email.Sent = true;
            });
            await _automatedEmailRepository.UpdateAutomatedEmails(automatedEmailsToSend);
        }
    }
}
