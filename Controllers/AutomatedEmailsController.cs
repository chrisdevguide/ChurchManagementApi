using ChurchManagementApi.Extentions;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Implementations;
using ChurchManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagementApi.Controllers
{
    public class AutomatedEmailsController : BaseController
    {
        private readonly IAutomatedEmailServices _automatedEmailServices;

        public AutomatedEmailsController(IAutomatedEmailServices automatedEmailServices)
        {
            _automatedEmailServices = automatedEmailServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutomatedEmail>>> GetAutomatedEmails()
        {
            return Ok(await _automatedEmailServices.GetAutomatedEmails(User.GetChurchUserId()));
        }

        [HttpPost]
        public async Task<ActionResult> AddAutomatedEmail(AutomatedEmailDto request)
        {
            await _automatedEmailServices.AddAutomatedEmail(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAutomatedEmail(AutomatedEmailDto request)
        {
            await _automatedEmailServices.UpdateAutomatedEmail(User.GetChurchUserId(), request);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAutomatedEmail(Guid automatedEmailId)
        {
            await _automatedEmailServices.DeleteAutomatedEmail(User.GetChurchUserId(), automatedEmailId);
            return Ok();
        }
    }
}
