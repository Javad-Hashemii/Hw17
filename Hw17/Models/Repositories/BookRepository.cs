using Hw17.Models.Database;
using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hw17.Models.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository()
        {
            _context = new AppDbContext();
        }

        public List<Book> GetBooksByNewestPublishedDate()
        {
            return _context.Books.Include(b => b.Category)
                                      .OrderByDescending(b => b.PublishedDate)
                                      .ToList();
        }

        public List<Book> GetBooksByCategoryID(int categoryID)
        {
            return _context.Books.Where(b => b.CategoryId == categoryID).ToList();
        }

        public void AddBook(AddBookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ImageUrl = bookDto.ImageUrl,
                CategoryId = bookDto.CategoryId,
                Price=bookDto.Price,
            };

            _context.Books.Add(book);
            _context.SaveChanges();

        }
    }
}
