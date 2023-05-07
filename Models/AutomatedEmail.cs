using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Models
{
    public class AutomatedEmail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime SendingDate { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public bool Sent { get; set; } = false;
        [Required]
        public Guid ChurchUserId { get; set; }
        public ChurchUser ChurchUser { get; set; }
        [Required]
        public List<Guid> Recipients { get; set; }
    }
}
