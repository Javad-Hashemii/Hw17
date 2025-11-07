using Hw17.Models.Dtos;
using Hw17.Models.Entities;

namespace Hw17.Models.Interfaces.Services
{
    public interface IBookService
    {
        public List<Book> GetNewestBooks();

        public List<Book> GetBooksByCategoryId(int categoryId);

        public void AddBook(AddBookDto bookDto);

    }
}
