using ChurchManagementApi.Dtos;
using ChurchManagementApi.Extentions;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagementApi.Controllers
{
    public class MembersController : BaseController
    {
        private readonly IMemberServices _memberServices;

        public MembersController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            return Ok(await _memberServices.GetMembers(User.GetChurchUserId()));
        }

        [HttpPost]
        public async Task<ActionResult> AddMember(MemberDto request)
        {
            await _memberServices.AddMember(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMember(MemberDto request)
        {
            await _memberServices.UpdateMember(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMember(Guid memberId)
        {
            await _memberServices.DeleteMember(User.GetChurchUserId(), memberId);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ArchiveMember(Guid memberId, bool isArchived)
        {
            await _memberServices.ArchiveMember(User.GetChurchUserId(), memberId, isArchived);
            return Ok();
        }

    }
}
