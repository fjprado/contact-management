using contact_management.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace contact_management.Data
{
    public class ContactManagementDbContext : DbContext
    {
        public ContactManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
