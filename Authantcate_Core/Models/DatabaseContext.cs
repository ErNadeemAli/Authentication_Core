using Microsoft.EntityFrameworkCore;
using Authantcate_Core.Models;

namespace Authantcate_Core.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {


        }
        public DbSet<user_tbl> Users { get; set; }
    }
}
