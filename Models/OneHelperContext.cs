using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneHelper.Models.ModelConfig;
namespace OneHelper.Models
{
    public class OneHelperContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<SleepLog> SleepLogs { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public OneHelperContext(DbContextOptions<OneHelperContext> options) : base(options) { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().Configure();
            modelBuilder.Entity<SleepLog>().Configure();
            modelBuilder.Entity<User>().Configure();
            base.OnModelCreating(modelBuilder);

            /*
            modelBuilder.Entity<User>( entity =>
            {
                entity.HasData(new User
                {
                    DateOfBirth = DateOnly.MaxValue,
                    Email = "norwen@gmail.com",
                    FirstName = "Norwen",
                    Gender = "Male",
                    Height = Convert.ToDecimal(1.71),
                    LastName = "Penas",
                    Password = "12345678",
                    PhoneNumber = "0997",
                    Username = "wen",
                    Weight = Convert.ToDecimal(151.7),
                    Id = 1
                }, new User
                {
                    DateOfBirth = DateOnly.MinValue,
                    Email = "kenneth@gmail.com",
                    FirstName = "kenneth",
                    Gender = "Male",
                    Height = Convert.ToDecimal(1.71),
                    LastName = "Amodia",
                    Password = "12345678",
                    PhoneNumber = "0997",
                    Username = "neth",
                    Weight = Convert.ToDecimal(151.7),
                    Id = 2
                });
            });
            base.OnModelCreating(modelBuilder); */
        }
    }
}
