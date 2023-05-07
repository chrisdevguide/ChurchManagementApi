using ChurchManagementApi.Extentions;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagementApi.Controllers
{
    public class GroupsController : BaseController
    {
        private readonly IGroupServices _groupServices;

        public GroupsController(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
            return Ok(await _groupServices.GetGroups(User.GetChurchUserId()));
        }

        [HttpPost]
        public async Task<ActionResult> AddGroup(GroupDto request)
        {
            await _groupServices.AddGroup(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGroup(GroupDto request)
        {
            await _groupServices.UpdateGroup(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGroup(Guid groupId)
        {
            await _groupServices.DeleteGroup(User.GetChurchUserId(), groupId);
            return Ok();
        }
    }
}
