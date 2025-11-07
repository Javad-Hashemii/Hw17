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
            var books = _bookRepo.GetBooksByNewestPublishedDate();

            if (books == null)
                throw new Exception("خطا در دریافت لیست کتاب‌ها.");

            if (!books.Any())
                throw new Exception("هیچ کتابی یافت نشد.");

            return _bookRepo.GetBooksByNewestPublishedDate();
        }

        public List<Book> GetBooksByCategoryId(int categoryId)
        {
            var books = _bookRepo.GetBooksByCategoryID(categoryId);

            if (books == null)
                throw new Exception("خطا در دریافت کتاب‌ها برای این دسته‌بندی.");

            return books;
        }

        public void AddBook(AddBookDto bookDto)
        {
            if (bookDto.Image == null)
                throw new Exception("تصویر کتاب الزامی است.");

            var imageAddress = _fileService.Upload(bookDto.Image, "Books");

            if (string.IsNullOrEmpty(imageAddress))
                throw new Exception("بارگذاری تصویر انجام نشد.");

            bookDto.ImageUrl = imageAddress;

            _bookRepo.AddBook(bookDto);
        }


    }
}
