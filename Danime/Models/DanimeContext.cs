using Microsoft.EntityFrameworkCore;

namespace Danime.Models
{
    public class DanimeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DanimeContext(DbContextOptions<DanimeContext> options) : base(options) 
        { 
        }
    }
}
