namespace ChurchManagementApi.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ChurchUserId { get; set; }
        public ChurchUser ChurchUser { get; set; }
        public List<Member> Members { get; set; }
    }
}
