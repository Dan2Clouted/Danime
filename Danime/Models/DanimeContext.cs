using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Danime.Models
{
    public class DanimeContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public DanimeContext(DbContextOptions<DanimeContext> options) : base(options) 
        { 
        }
    }
}
