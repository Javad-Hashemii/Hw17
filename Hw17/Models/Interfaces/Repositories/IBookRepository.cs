using Hw17.Models.Dtos;
using Hw17.Models.Entities;

namespace Hw17.Models.Interfaces.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooksByCategoryID(int categoryID);
        List<Book> GetBooksByNewestPublishedDate();
        void AddBook(AddBookDto bookDto);

    }
}
