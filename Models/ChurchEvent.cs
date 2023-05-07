namespace ChurchManagementApi.Models
{
    public class ChurchEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public Guid ChurchUserId { get; set; }
        public ChurchUser ChurchUser { get; set; }
        public List<string> Participants { get; set; }
    }
}
