using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Dtos
{
    public class SubscribeAtChurchEventRequestDto
    {
        [Required]
        public Guid ChurchEventId { get; set; }
        [Required]
        public string Participant { get; set; }
        public string RedirectUrl { get; set; }
    }
}