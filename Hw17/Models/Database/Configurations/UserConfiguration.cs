using Hw17.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hw17.Models.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");


            builder.HasData(
                new User { Id = 1, Username = "user1", Password = "1234", FirstName = "یوزر 1",LastName="",IsAdmin=false,PhoneNumber="09311674121" },
                new User { Id = 2, Username = "user2", Password = "1234", FirstName = "یوزر 2",LastName="",IsAdmin = false, PhoneNumber = "09121674121" },
                new User { Id = 3, Username = "admin1", Password = "1234", FirstName = "مدیر 1", LastName = "", IsAdmin = true, PhoneNumber = "09361674121" },
                new User { Id = 4, Username = "admin2", Password = "1234", FirstName = "مدیر 2", LastName = "", IsAdmin = true, PhoneNumber = "09161674121" }
                );
        }
    }
}
