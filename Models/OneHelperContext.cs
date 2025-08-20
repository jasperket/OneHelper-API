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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>( entity =>
            {
                entity.HasMany(e => e.SleepLogs)
                    .WithOne(t => t.User)
                    .HasForeignKey( t => t.UserId)
                    .IsRequired();

                entity.HasMany( b => b.Todos)
                    .WithOne( b => b.User)
                    .HasForeignKey( b => b.UserId)
                    .IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
