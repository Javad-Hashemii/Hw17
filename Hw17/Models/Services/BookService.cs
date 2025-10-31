using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Interfaces.Repositories;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Repositories;

namespace Hw17.Models.Services
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IFileService _fileService;
        public BookService()
        {
            _bookRepo= new BookRepository();
            _fileService= new FileService();
        }

        public List<Book> GetNewestBooks()
        {
            return _bookRepo.GetBooksByNewestPublishedDate();
        }

        public List<Book> GetBooksByCategoryId(int categoryId)
        {
            return _bookRepo.GetBooksByCategoryID(categoryId);
        }

        public void AddBook(AddBookDto bookDto)
        {
            var imageAddress= _fileService.Upload(bookDto.Image,"Books");
            bookDto.ImageUrl = imageAddress;
            _bookRepo.AddBook(bookDto);
        }
    }
}
