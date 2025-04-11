using Microsoft.EntityFrameworkCore;
using ContactApi.Models;

namespace ContactApi.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactMessge> ContactMessge { get; set; }
        public DbSet<ReposneMessage> ReposneMessage { get; set; }
        public DbSet<Applications> Applications { get; set; }
        

    }
}