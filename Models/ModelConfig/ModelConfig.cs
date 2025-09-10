using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OneHelper.Models.ModelConfig
{
    public static class ModelConfig
    {
        public static void Configure(this EntityTypeBuilder<ToDo> builder )
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(1000).IsRequired();
            builder.HasIndex(x => x.Title).IsUnique();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.PriorityLevel).HasColumnType("tinyint").IsRequired();
            builder.HasOne(i => i.User).WithMany(i => i.Todos).HasForeignKey(i => i.UserId);
        }

        public static void Configure(this EntityTypeBuilder<User> builder)
        {
            /*
            builder.HasKey(x => x.Id);
            builder.Property(i => i.Username).HasMaxLength(100).IsRequired();
            builder.HasIndex( x=> x.Username).IsUnique();
            builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(6).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            */
            builder.Property(x => x.Height).HasPrecision(5, 2);
            builder.Property(x => x.Weight).HasPrecision(5, 2);
            /*builder.Property(x => x.PhoneNumber).HasMaxLength(12); */
        }

        public static void Configure(this EntityTypeBuilder<SleepLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.SleepLogs).HasForeignKey(x => x.UserId);

        }
    }
}
