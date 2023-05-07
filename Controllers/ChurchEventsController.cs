using ChurchManagementApi.Dtos;
using ChurchManagementApi.Extentions;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagementApi.Controllers
{
    public class ChurchEventsController : BaseController
    {
        private readonly IChurchEventServices _churchEventServices;

        public ChurchEventsController(IChurchEventServices ChurchEventServices)
        {
            _churchEventServices = ChurchEventServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChurchEvent>>> GetChurchEvents()
        {
            return Ok(await _churchEventServices.GetChurchEvents(User.GetChurchUserId()));
        }

        [HttpPost]
        public async Task<ActionResult> AddChurchEvent(ChurchEventDto request)
        {
            await _churchEventServices.AddChurchEvent(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateChurchEvent(ChurchEventDto request)
        {
            await _churchEventServices.UpdateChurchEvent(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteChurchEvent(Guid ChurchEventId)
        {
            await _churchEventServices.DeleteChurchEvent(User.GetChurchUserId(), ChurchEventId);
            return Ok();
        }
    }
}
