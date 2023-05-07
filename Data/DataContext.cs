using ChurchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagementApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ChurchUser> ChurchUsers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AutomatedEmail> AutomatedEmails { get; set; }
        public DbSet<ChurchEvent> ChurchEvents { get; set; }

    }
}
