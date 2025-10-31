using Hw17.Models.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hw17.Models.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PublishedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(b => b.Category)
                  .WithMany(c => c.Books)
                  .HasForeignKey(b => b.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Book { Id = 1, Title = "باشگاه قتل پنجشنبه", Author = "ریچارد آزمن", CategoryId = 1,Price=300000, ImageUrl = "/Images/Books/The_Thursday_Murder_Club.jpg" },
                new Book { Id = 2, Title = "توپ های ماه اوت", Author = "باربارا تاکمن", CategoryId = 2, Price = 250000, ImageUrl = "/Images/Books/The_Guns_of_August.jpg" },
                new Book { Id = 3, Title = "گتسبی بزرگ", Author = "اف اسکات فیتزجرالد", CategoryId = 3, Price = 350000, ImageUrl = "/Images/Books/The_Great_Gatsby.jpg" },
                new Book { Id = 4, Title = "منشاء انواع", Author = "چارلز داروین", CategoryId = 4, Price = 200000, ImageUrl = "/Images/Books/On_the_Origin_of_Species.jpg" },
                new Book { Id = 5, Title = "تلماسه", Author = "فرانک هربرت", CategoryId = 5, Price = 230000, ImageUrl = "/Images/Books/Dune.jpg" },
                new Book { Id = 6, Title = "کشتن مرغ مقلد", Author = "هارپر لی", CategoryId = 6, Price = 300000, ImageUrl = "/Images/Books/To_Kill_a_Mockingbird.jpg" }
                );
        }
    }
}
