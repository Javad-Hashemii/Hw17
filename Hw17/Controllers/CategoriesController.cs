using Hw17.Models.Database;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hw17.Controllers
{
    public class CategoriesController:Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoriesController()
        {
            _context = new AppDbContext();
            _categoryService = new CategoryService();
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
    }
}
