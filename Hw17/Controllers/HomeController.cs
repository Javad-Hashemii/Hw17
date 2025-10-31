using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hw17.Models.Database;
using Hw17.Models.Entities;
using System.Linq;
using Hw17.Models.Interfaces.Services;
using Hw17.Models.Services;

namespace Hw17.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController()
        {
            _homeService = new HomeService();
        }

        public IActionResult Index()
        {
            var model= _homeService.GetCategoriesAndBooks();
            return View(model);
        }
    }
}
