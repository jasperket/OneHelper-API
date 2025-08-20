using Microsoft.EntityFrameworkCore;
using OneHelper.Models;
namespace OneHelper.Models
{
    public class OneHelperContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SleepLog> SleepLogs { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public OneHelperContext(DbContextOptions options) : base(options) { 
            
        }
    }
}
