namespace ChurchManagementApi.Models
{
    public class GroupMember
    {
        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
