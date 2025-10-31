using Hw17.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hw17.Models.Database.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasData(
                new Category { Id = 1, Name = "جنایی",ImageUrl="/Images/Categories/crime.png" },
                new Category { Id = 2, Name = "تاریخی", ImageUrl = "/Images/Categories/history.png" },
                new Category { Id = 3, Name = "تخیلی", ImageUrl = "/Images/Categories/fiction.png" },
                new Category { Id = 4, Name = "علمی", ImageUrl = "/Images/Categories/science.png" },
                new Category { Id = 5, Name = "علمی تخیلی", ImageUrl = "/Images/Categories/sci-fi.png" },
                new Category { Id = 6, Name = "رمان", ImageUrl = "/Images/Categories/Novel.png" }
            );
        }
    }
}
