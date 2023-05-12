using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Dtos
{
    public class UpdateChurchUserRequestDto
    {
        [EmailAddress]
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        [Required]
        public string ChurchName { get; set; }
    }
}