namespace ChurchManagementApi.Models
{
    public class Member
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public Nationality Nationality { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public bool IsWaterBaptized { get; set; }
        public DateOnly? BaptismDate { get; set; }
        public bool HasAcceptedPrivacyPolicy { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? ArchiveDate { get; set; }
        public bool IsArchived { get; set; } = false;
        public Guid ChurchUserId { get; set; }
        public ChurchUser ChurchUser { get; set; }
        public List<Group> Groups { get; set; }
    }
}
