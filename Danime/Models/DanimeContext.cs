using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Danime.Models
{
    public class DanimeContext : IdentityDbContext
    {
      
        public DanimeContext(DbContextOptions<DanimeContext> options) : base(options) 
        { 
        }
    }
}
