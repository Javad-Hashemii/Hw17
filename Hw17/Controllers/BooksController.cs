using Hw17.Models.Database;
using Hw17.Models.Dtos;
using Hw17.Models.Entities;
using Hw17.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hw17.Controllers
{
    public class BooksController:Controller
    {
        private readonly AppDbContext _context;
        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;

        public BooksController()
        {
            _context = new AppDbContext();
            _bookService = new BookService();
            _categoryService = new CategoryService();
        }

        public IActionResult Index()
        {
            var books = _bookService.GetNewestBooks();
            return View(books);
        }

        public IActionResult ByCategory(int id)
        {
            var books = _bookService.GetBooksByCategoryId(id);
            return View(books);
        }


        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.Categories = _categoryService.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto bookDto)
        {
            _bookService.AddBook(bookDto);
            return RedirectToAction("Index");
        }

        public IActionResult All()
        {
            var books = _bookService.GetNewestBooks();
            return View(books);
        }


    }
}
